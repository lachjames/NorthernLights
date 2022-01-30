using AuroraEngine;
using NCSInstructions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;
using Newtonsoft.Json;
using System.Net.Mime;
using System.Reflection;

public class NCSContext
{
    public AuroraObject objectSelf;

    public List<int> returnStack = new List<int>();
    public List<object> stack = new List<object>();
    public List<NCSContext> stateStack = new List<NCSContext>();
    Dictionary<string, object> globals = new Dictionary<string, object>();

    public int stackPointer, basePointer, programCounter;

    public NCSScript script;

    public object last_return;

    public List<string> logs = new List<string>();
    public NCSFile file;

    public NCSContext(NCSScript script, NCSFile file)
    {
        this.script = script;
        this.file = file;

        // programCounter = 0;
        // returnStack.Clear();
        // returnStack.Add(-1);
    }

    // public void Start(NCSScript script, NCSFile file)
    // {
    //     this.script = script;
    //     this.file = file;

    //     programCounter = 0;
    //     returnStack.Clear();
    //     returnStack.Add(-1);
    // }

    public void StoreState(int pc)
    {
        stateStack.Add(Copy(pc));
    }

    public NCSContext GetState()
    {
        NCSContext ctx = stateStack.Last();
        stateStack.RemoveAt(stateStack.Count - 1);

        return ctx;
    }

    public NCSContext Copy(int pc)
    {
        NCSContext copy = new NCSContext(script, file);

        // We don't actually copy the return stack here
        //foreach (int r in returnStack)
        //{
        //    copy.returnStack.Add(r);
        //}

        // Copy stack
        foreach (object o in stack)
        {
            copy.stack.Add(o);
        }

        // Copy globals
        foreach (string g in globals.Keys)
        {
            copy.globals[g] = globals[g];
        }

        // Copy state stack
        foreach (NCSContext ctx in stateStack)
        {
            copy.stateStack.Add(ctx.Copy(ctx.GetPC()));
        }

        copy.stackPointer = stackPointer;
        copy.basePointer = basePointer;
        copy.programCounter = pc;

        copy.script = script;

        return copy;
    }

    public void Dump(string loc)
    {
        // Dump the current state to disk in JSON form
        //File.WriteAllText(loc, JsonConvert.SerializeObject(this));
    }

    public void LoadGlobals(Dictionary<string, object> globals)
    {
        this.globals = globals;
    }

    public void PushGlobal(string globalName)
    {
        Push(globals[globalName]);
    }

    public void PushGlobals(string[] globalNames)
    {
        foreach (string name in globalNames)
        {
            PushGlobal(name);
        }
    }

    public object Get(int pos)
    {
        return stack[pos / 4];
    }

    public object GetOffsetSP(int offset)
    {
        // If the stackPointer is at 240, meaning we have 60 words on the stack, we access the last word at
        // -4($sp), or at position 236 (as an index we divide by 4 to get 59) . So if the offset is -4,
        // we will get the correct element if the stackPointer points to the start of the FIRST WORD *NOT* ON
        // the stack (i.e. not the start of the top item on the stack).
        return stack[(stackPointer + offset) / 4];
    }

    public void SetOffsetSP(int offset, object value)
    {
        stack[(stackPointer + offset) / 4] = value;
    }

    public object GetOffsetBP(int offset)
    {
        return stack[(basePointer + offset) / 4];
    }

    public void SetOffsetBP(int offset, object value)
    {
        stack[(basePointer + offset) / 4] = value;
    }

    public void SetValue(int pos, object val)
    {
        stack[pos / 4] = val;
    }

    public void Push(object value, bool isVector = false)
    {
        stack.Add(value);

        // TODO: Figure out how I want to implement vectors
        if (isVector)
        {
            stackPointer += 12;
        }
        else
        {
            stackPointer += 4;
        }
    }

    public object Pop(bool isVector = false)
    {
        object item = stack.Last();
        stack.RemoveAt(stack.Count - 1);

        // TODO: Figure out how I want to implement vectors
        if (isVector)
        {
            stackPointer -= 12;
        }
        else
        {
            stackPointer -= 4;
        }

        return item;
    }

    public void JumpOffset(int offset, bool pushReturn = false)
    {
        UnityEngine.Debug.Log("Jumping to offset " + offset + ", current PC is " + programCounter);
        if (pushReturn)
        {
            returnStack.Add(programCounter + 1);
        }

        int dir = 1;
        if (offset < 0)
        {
            dir = -1;
        }
        UnityEngine.Debug.Log("Moving in direction " + dir);

        if (dir == -1)
        {
            UnityEngine.Debug.Log("Adjusting offset because we don't include the current instruction when jumping backwards");
            offset -= file.operations[programCounter].instructionSize;
        }

        // int cur_offset = file.operations[programCounter].instructionStart;
        // UnityEngine.Debug.Log("Current offset: " + cur_offset);
        while (offset != 0)
        {
            UnityEngine.Debug.Log("Jumping over instruction " + file.operations[programCounter].opType.Name);
            offset -= dir * file.operations[programCounter].instructionSize;
            programCounter += dir;
            UnityEngine.Debug.Log("Program counter: " + programCounter + ", offset: " + offset);
        }
        
        UnityEngine.Debug.Log("New program counter is " + programCounter);
        // programCounter = pos;
    }

    public void Return()
    {
        if (returnStack.Count == 0)
        {
            // Finished
            programCounter = -1;
            return;
        }
        programCounter = returnStack[returnStack.Count - 1];
        returnStack.RemoveAt(returnStack.Count - 1);
    }

    public void Step()
    {
        programCounter++;
    }

    public int GetPC()
    {
        return programCounter;
    }

    public void ChangePC(int steps)
    {
        programCounter += steps;
    }

    public bool Finished()
    {
        // We're finished if the program counter is set to -1
        return programCounter == -1;
    }

    public void Log(object obj)
    {
        logs.Add(obj.ToString());
    }
}

public class NCSScript
{
    public static Dictionary<int, MethodInfo> actions = null;
    public string scriptName;

    public List<NCSInstruction> instructions = new List<NCSInstruction>();
    public Dictionary<string, int> labels = new Dictionary<string, int>();

    public NCSInstruction lastInstruction;
    public NCSFile file;

    public NCSScript(Stream stream, string name)
    {
        // if (actions == null)
        // {
        //     ReadActions();
        // }
        // We read the NCS file directly from the stream
        file = new NCSFile(stream);
        scriptName = name;

        foreach (NCSOperation op in file.operations)
        {
            NCSInstruction instruction = (NCSInstruction)Activator.CreateInstance(op.opType);
            //Debug.Log(instruction);

            instruction.Initialize(op.args, this);
            instructions.Add(instruction);
        }
    }

    // void ReadActions()
    // {
    //     // Read actions from nwscript.nss
    //     actions = new Dictionary<int, MethodInfo>();
    //     Stream stream = AuroraData.Instance.GetStream("nwscript.nss", AuroraEngine.ResourceType.NSS);
    //     string text = new StreamReader(stream).ReadToEnd();
    //     UnityEngine.Debug.Log("Loaded nwscript.nss: " + text);
    // }

    // public NCSScript(Stream stream, string name)
    // {
    //     // Firstly, we save the script to disk

    //     byte[] buffer = new byte[stream.Length];
    //     stream.Read(buffer, 0, (int)stream.Length);

    //     FileStream filestream = File.Create("D:\\KOTOR\\KotOR-Unity\\tmp\\tmp.ncs");
    //     stream.Seek(0, SeekOrigin.Begin);
    //     stream.CopyTo(filestream);
    //     filestream.Close();

    //     // Then we read it using xoreos-tools's disassembler
    //     Process p = new Process();
    //     p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    //     p.StartInfo.CreateNoWindow = true;
    //     p.StartInfo.UseShellExecute = false;
    //     p.StartInfo.FileName = "D:\\KOTOR\\KOTOR1\\KotOR-Unity\\xt\\ncsdis.exe";
    //     p.StartInfo.Arguments = "--assembly --kotor D:\\KOTOR\\KotOR-Unity\\tmp\\tmp.ncs";
    //     p.StartInfo.RedirectStandardOutput = true;
    //     p.StartInfo.RedirectStandardError = true;
    //     p.EnableRaisingEvents = true;

    //     StringBuilder outputBuilder = new StringBuilder();
    //     StringBuilder errorBuilder = new StringBuilder();

    //     using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
    //     using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
    //     {
    //         p.OutputDataReceived += (sender, e) =>
    //         {
    //             if (e.Data == null)
    //             {
    //                 outputWaitHandle.Set();
    //             }
    //             else
    //             {
    //                 outputBuilder.AppendLine(e.Data);
    //             }
    //         };
    //         p.ErrorDataReceived += (sender, e) =>
    //         {
    //             if (e.Data == null)
    //             {
    //                 errorWaitHandle.Set();
    //             }
    //             else
    //             {
    //                 errorBuilder.AppendLine(e.Data);
    //             }
    //         };

    //         p.Start();

    //         p.BeginOutputReadLine();
    //         p.BeginErrorReadLine();

    //         if (p.WaitForExit(1000) &&
    //             outputWaitHandle.WaitOne() &&
    //             errorWaitHandle.WaitOne())
    //         {
    //             // Process completed. Check process.ExitCode here.
    //         }
    //         else
    //         {
    //             // Timed out.
    //         }
    //     }

    //     string output = outputBuilder.ToString();
    //     string error = errorBuilder.ToString();

    //     //UnityEngine.Debug.Log(output);
    //     //UnityEngine.Debug.Log(error);

    //     // Finally, we run the normal NCSScript reader on that
    //     ParseString(output, name);
    // }

    // public NCSScript(string script, string name)
    // {
    //     ParseString(script, name);
    // }

    // void ParseString(string script, string name)
    // {
    //     this.scriptName = name;
    //     string[] lines = script.Split(new[] { '\n' }, StringSplitOptions.None);
    //     //UnityEngine.Debug.Log(lines.Length);
    //     foreach (string rawline in lines)
    //     {
    //         // Determine the line type
    //         string line = rawline.Trim().Split(new char[] { ';' })[0].Trim();
    //         //UnityEngine.Debug.Log(line);
    //         if (line.Length == 0)
    //         {
    //             // This was a blank line or comment, so ignore it
    //             //Debug.Log("Ignoring blank/comment line: " + rawline);
    //         }
    //         else if (line[line.Length - 1] == ':')
    //         {
    //             // This is a label
    //             //Debug.Log("Registering label: " + rawline);

    //             string labelName = String.Concat(line.Take(line.Length - 1));
    //             // If we have n instructions, this label points to instruction n+1 (at index n+1-1=n)
    //             labels[labelName] = instructions.Count;
    //         }
    //         else
    //         {
    //             // This is an instruction
    //             //Debug.Log("Registering instruction: " + rawline);

    //             // TODO: Make this work for lines that have strings with spaces in them
    //             string[] rawInstruction = line.Split(new char[] { ' ' });

    //             // Remove quotes surrounding strings
    //             for (int i = 0; i < rawInstruction.Length; i++)
    //             {
    //                 string s = rawInstruction[i];
    //                 if (s.Length < 2)
    //                 {
    //                     continue;
    //                 }
    //                 if (s[0] == '"' && s[s.Length - 1] == '"')
    //                 {
    //                     s = s.Substring(1, s.Length - 2);
    //                     rawInstruction[i] = s;
    //                 }
    //             }

    //             string instructionName = rawInstruction[0];

    //             Type instructionType = Type.GetType("NCSInstructions." + instructionName);
    //             if (instructionType == null)
    //             {
    //                 throw new Exception("Instruction type was null for " + instructionName);
    //             }
    //             NCSInstruction instruction = (NCSInstruction)Activator.CreateInstance(instructionType);
    //             //Debug.Log(instruction);

    //             instruction.Initialize(rawInstruction, this);
    //             instructions.Add(instruction);
    //         }
    //     }
    // }

    // public void Start(NCSContext context)
    // {
    //     context.Start(this);
    // }

    public void Run(NCSContext context)
    {
        int steps = 0;

        Stopwatch watch = new Stopwatch();
        watch.Start();
        while (!context.Finished())
        {
            if (watch.ElapsedMilliseconds > 500)
            {
                throw new Exception("Executing script " + scriptName + " took over 500 milliseconds; stopped on line " + context.GetPC());
            }

            Step(context);
            steps++;
        }
    }

    public int RunConditional(NCSContext context)
    {
        Run(context);
        return (int)context.last_return;
    }

    public void Step(NCSContext context)
    {
        context.script = this;
        NCSInstruction instruction = instructions[context.GetPC()];

        //Debug.Log(instruction.AsString());

        instruction.Run(context);
        if (instruction.IncrementsPC)
        {
            //Debug.Log("Incrementing PC");
            context.Step();
        }

        lastInstruction = instruction;
    }
}

public class NCSTrace
{
    public static List<NCSTrace> traces = new List<NCSTrace>();

    public List<NCSContext> contexts;
}