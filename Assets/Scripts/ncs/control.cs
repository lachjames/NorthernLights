using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace NCSInstructions
{
    public class ACTION : NCSInstruction
    {
        static Type nwscript;
        static ACTION () {
            nwscript = Type.GetType("AuroraEngine.NWScript");
        }
        
        // Runs an engine function (defined in nwscript.nss)
        public override void Run(NCSContext context)
        {
            context.Log("Calling " + args[1]);

            // Get the function definition for the action
            MethodInfo m = nwscript.GetMethod(args[1]);

            if (m == null)
            {
                Debug.LogError("Warning: could not find method " + args[1]);
            }

            int paramCount = int.Parse(args[2]);

            object[] parameters = new object[m.GetParameters().Length];

            context.Log("Method " + m.Name + " has " + 
                m.GetParameters().Length + " parameter(s)" + 
                " and providing " + paramCount
            );

            ParameterInfo[] paramInfo= m.GetParameters();
            for (int i = 0; i < paramCount; i++)
            {
                ParameterInfo p = paramInfo[i];

                if (p.ParameterType == typeof(NCSContext))
                {
                    context.Log("Getting parameter from store state stack");
                    parameters[i] = context.GetState();
                } else if (p.ParameterType == typeof(AuroraVector)) {
                    context.Log("Getting vector from stack");

                    context.Log(context.stack.Last());
                    float x = (float)context.Pop();
                    context.Log(context.stack.Last());
                    float y = (float)context.Pop();
                    context.Log(context.stack.Last());
                    float z = (float)context.Pop();

                    parameters[i] = new AuroraVector(x, y, z);
                } else {
                    context.Log("Getting parameter from stack");
                    parameters[i] = context.Pop();
                }
                context.Log("Parameter " + i + ": " + parameters[i]);
            }

            // Add any optional parameters if we need to
            for (int i = paramCount; i < m.GetParameters().Length; i++)
            {
                parameters[i] = Type.Missing;
            }

            // Generate the function call signature
            string signature = args[1] + "(";
            
            for (int i = 0; i < parameters.Length; i++)
            {
                signature += parameters[i];
                if (i != parameters.Length - 1)
                {
                    signature += ",";
                }
            }
            
            signature += ")";

            object return_value;

            try
            {
                return_value = m.Invoke(null, parameters);
            } catch (Exception e)
            {
                LoggedEvents.Log("  Action", "FAILED: " + signature);
                throw e;
            }

            LoggedEvents.Log("  Action", signature + " = " + return_value);

            context.Log(m.Name + " returned with value " + return_value);

            if (m.ReturnType == typeof(void))
            {

            } else if (m.ReturnType == typeof(AuroraVector))
            {
                AuroraVector vec = (AuroraVector)return_value;
                context.Push(vec.z);
                context.Push(vec.y);
                context.Push(vec.x);
            } else
            {
                context.Push(return_value);
            }
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }

    public class JNZ : NCSInstruction
    {

        public override void Run(NCSContext context)
        {
            string label = args[1];
            int offset = context.script.labels[label];

            int stackTop = (int)context.Pop();
            if (stackTop != 0)
            {
                // Jump to the label
                // Subtract one from the program counter
                // because we will add one to it when this is done -
                // this avoids having to write custom logic for whether to
                // increment the PC or not after doing this instruction
                context.programCounter = offset - 1;
            }
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }

    public class JZ : NCSInstruction
    {

        public override void Run(NCSContext context)
        {
            string label = args[1];
            int offset = context.script.labels[label];

            int stackTop = (int)context.Pop();
            if (stackTop == 0)
            {
                // Jump to the label
                // Subtract one from the program counter
                // because we will add one to it when this is done -
                // this avoids having to write custom logic for whether to
                // increment the PC or not after doing this instruction
                context.programCounter = offset - 1;
            }
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class JMP : NCSInstruction
    {
        public override bool IncrementsPC { get { return false; } }
        public override void Run(NCSContext context)
        {
            // Moves forward a number of steps in the program
            int newPC = script.labels[args[1]];
            context.programCounter = newPC;
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }

    public class JSR : NCSInstruction
    {
        public override bool IncrementsPC { get { return false; } }
        public override void Run(NCSContext context)
        {
            int newPC = script.labels[args[1]];
            context.Jump(newPC);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }


    public class RETN : NCSInstruction
    {
        public override bool IncrementsPC { get { return false; } }
        public override void Run(NCSContext context)
        {
            if (context.stack.Count == 1)
                context.last_return = context.stack[0];
            context.Return();
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }


    public class NOP : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Pushes an immediate value onto the stack
            //Debug.Log("No-op");
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }

    public class T : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Pushes an immediate value onto the stack
            Debug.Log("This should never be reached");
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
}