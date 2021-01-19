
using NCSInstructions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum NCSDataType
{
    INT, STRING, FLOAT, VECTOR, OBJECT, E0, E1, E2, E3, E4, E5
}

public class PropagateData
{
    public NCSDataType type;
    public string value;
    public bool assigns_variable;
    public string variable_name;

    public PropagateData (NCSDataType dt, string val, bool asgn = false, string var = null)
    {
        type = dt;
        value = val;
        assigns_variable = asgn;
        variable_name = var;
    }

    public PropagateData Copy ()
    {
        return new PropagateData(
            type,
            value,
            assigns_variable,
            variable_name
        );
    }
}

public class PropagateState
{
    public int stack_pointer, base_pointer;

    public PropagateState Copy ()
    {
        return new PropagateState()
        {
            stack_pointer = stack_pointer,
            base_pointer = base_pointer
        };
    }
}

//public abstract class PropagateStructure
//{
//    public int sizeX, sizeY;
//    public object default_value;
//    public PropagateStructure(int sizeX, int sizeY, object default_value)
//    {
//        this.sizeX = sizeX;
//        this.sizeY = sizeY;
//        this.default_value = default_value;
//    }

//    public abstract PropagateData GetItem(int step, int pos);
//    public abstract void SetItem(int step, int pos, PropagateData value);
//}

public class PropagateMatrix<T>
{
    public int sizeX, sizeY;
    public object default_value;
    List<Dictionary<int, T>> values = new List<Dictionary<int, T>>();

    public PropagateMatrix(int sizeX, int sizeY, object default_value)
    {
        this.sizeX = sizeX;
        this.sizeY = sizeY;
        this.default_value = default_value;

        for (int i = 0; i < sizeY; i++)
        {
            values.Add(new Dictionary<int, T>());
        }
    }

    public T[] GetFrame(int i)
    {
        T[] frame = new T[sizeY];

        for (int j = 0; j < sizeY; j++)
        {
            frame[j] = GetItem(i, j);
        }

        return frame;
    }

    public void SetFrame (int command, T[] frame)
    {
        for (int j = 0; j < sizeY; j++)
        {
            SetItem(command, j, frame[j]);
        }
    }

    public T[] GetLastFrame()
    {
        return GetFrame(sizeX - 1);
    }

    public T GetItem(int step, int pos)
    {
        return default;
    }

    public void SetItem(int step, int pos, T value)
    {
        values[step][pos] = value;
    }
}

//public class PropagateVector
//{
//    PropagateMatrix matrix;
//    int sizeX;
//    object default_value;

//    public PropagateVector(int sizeX, object default_value)
//    {
//        this.sizeX = sizeX;
//        this.default_value = default_value;

//        matrix = new PropagateMatrix(sizeX, 1, default_value);
//    }

//    public PropagateState GetItem(int step, int pos)
//    {
//        return matrix.GetItem(step, 0);
//    }

//    public void SetItem(int step, int pos, PropagateState value)
//    {
//        matrix.SetItem(step, 0, value);
//    }
//}


public class SubroutineGraph
{
    public List<Subroutine> subs = new List<Subroutine>();
    public Dictionary<Subroutine, Subroutine> links = new Dictionary<Subroutine, Subroutine>();
    public NCSScript script;
    public SubroutineGraph(NCSScript script)
    {
        this.script = script;

        // Not every label points to a subroutine...
        HashSet<string> sub_names = new HashSet<string>();
        foreach (NCSInstruction inst in script.instructions)
        {
            if (inst.GetType() != typeof(JSR))
            {
                continue;
            }
            JSR jsr = (JSR)inst;

            sub_names.Add(jsr.args[1]);
            Debug.Log("Adding sub " + jsr.args[1]);
        }

        List<int> sub_starts = new List<int>();

        foreach (string label_name in script.labels.Keys)
        {
            if (!sub_names.Contains(label_name))
            {
                continue;
            }

            int sub_start = script.labels[label_name];
            if (sub_start == 0)
            {
                continue;
            }

            sub_starts.Add(sub_start);
        }

        if (!sub_starts.Contains(0))
        {
            sub_starts.Add(0);
        }

        sub_starts.Sort();

        for (int i = 0; i < sub_starts.Count; i++)
        {
            int sub_start = sub_starts[i];
            int sub_end;
            if (i < sub_starts.Count - 1)
            {
                sub_end = sub_starts[i + 1] - 1;
            }
            else
            {
                sub_end = script.instructions.Count - 1;
            }
            subs.Add(new Subroutine(sub_start, sub_end, "sub_" + subs.Count, script));
        }

        foreach (Subroutine sub in subs)
        {
            Debug.Log("Subroutine " + sub.name + " [" + sub.firstInstruction + "-" + sub.lastInstruction + "]");
        }
    }

    public void CalculateDataFlow()
    {

    }

    void SubDataFlow(Subroutine sub)
    {
        Graph<BasicBlock> graph = sub.GetBasicBlocks();

        int len = sub.lastInstruction - sub.firstInstruction;
        StackMatrix matrix = new StackMatrix(len, len, sub);

        HashSet<BasicBlock> done_blocks = new HashSet<BasicBlock>();

        Stack<(BasicBlock, PropagateData[], int)> stack = new Stack<(BasicBlock, PropagateData[], int)>();
        stack.Push((graph.GetRoot(), null, -1));

        while (stack.Count > 0)
        {
            (BasicBlock block, PropagateData[] last_frame, int sp) = stack.Pop();

            if (last_frame != null)
            {
                matrix.data_matrix.SetFrame(block.first, last_frame);
                matrix.state_matrix.SetItem(block.first, 0, new PropagateState()
                {
                    stack_pointer = sp,
                    base_pointer = -1 // TODO: Set base pointer properly?
                });
            }

            ILInstruction[] il_conversion = ConvertToIL(block, sub, matrix);
        }
    }

    ILInstruction[] ConvertToIL (BasicBlock block, Subroutine sub, StackMatrix matrix)
    {
        List<ILInstruction> il_instructions = new List<ILInstruction>();

        for (int i = block.first; i <= block.last; i++)
        {
            NCSInstruction ncs = script.instructions[i];
            ILInstruction il = ncs.Convert(i, matrix);
            if (il.GetType() != typeof(NOOP))
            {
                il_instructions.Add(il);
            }
        }

        return il_instructions.ToArray();
    }
}

public class Subroutine
{
    public int firstInstruction, lastInstruction;
    public string name;
    public NCSScript script;

    public Subroutine(int f, int l, string n, NCSScript s)
    {
        firstInstruction = f;
        lastInstruction = l;
        name = n;
        script = s;
    }

    public Graph<BasicBlock> GetBasicBlocks()
    {
        HashSet<int> leaders = new HashSet<int>();
        leaders.Add(0);

        // Leaders are:
        //   - The first instruction
        //   - Targets of a jump (conditional or otherwise)
        //   - The instruction after a conditional or unconditional jump
        for (int i = 0; i < script.instructions.Count; i++)
        {
            NCSInstruction inst = script.instructions[i];
            Type t = inst.GetType();

            if (t == typeof(JMP))
            {
                // Unconditional jump
                int target = script.labels[inst.args[1]];

                leaders.Add(target);
                leaders.Add(i + 1);
            }
            else if (t == typeof(JNZ) || t == typeof(JZ))
            {
                // Conditional jump
                int target = script.labels[inst.args[1]];

                leaders.Add(target);
                leaders.Add(i + 1);
            } // else if (t == typeof(STORESTATE))
            //{
            //    // StoreState instruction is an unconditional jump
            //    // TODO: Check this
            //    int target = script.labels[inst.args[1]];
            //    leaders.Add(target);
            //} else if (t == typeof(STORESTATE_RETURN))
            //{
            // TODO: Implement pre-processing that implements STORESTATE_RETURN
            //}
        }

        List<int> leaders_sorted = leaders.ToList<int>();
        leaders_sorted.Sort();

        Dictionary<int, BasicBlock> block_dict = new Dictionary<int, BasicBlock>();

        for (int i = 0; i < leaders_sorted.Count; i++)
        {
            int leader = leaders_sorted[i];
            int next = (i == leaders_sorted.Count - 1) ? script.instructions.Count : leaders_sorted[i + 1];

            BasicBlock block = new BasicBlock(leader, next - 1);
            block_dict[leader] = block;
        }

        // Create the graph and all nodes
        Graph<BasicBlock> graph = new Graph<BasicBlock>();
        foreach (BasicBlock block in block_dict.Values)
        {
            graph.AddNode(block);
        }

        // Set the root node to the first node of the subroutine
        graph.SetRoot(block_dict[0]);

        // Create the edges, which demonstrate which blocks a given block might navigate to
        foreach (BasicBlock block in block_dict.Values)
        {
            NCSInstruction last_statement = script.instructions[block.last];
            Type last_type = last_statement.GetType();

            if (last_type == typeof(JMP))
            {
                // Unconditional jump
                BasicBlock target = block_dict[script.labels[last_statement.args[1]]];
                graph.AddEdge(block, target);
            }
            else if (last_type == typeof(JNZ) || last_type == typeof(JZ))
            {
                BasicBlock target = block_dict[script.labels[last_statement.args[1]]];
                graph.AddEdge(block, target);

                BasicBlock next = block_dict[block.last + 1];
                graph.AddEdge(block, next);
            }
        }

        return graph;
    }
}

public class BasicBlock
{
    public int first, last;
    public BasicBlock(int f, int l)
    {
        first = f;
        last = l;
    }

    public override string ToString()
    {
        return "BB[" + first + "-" + last + "]";
    }
}

public class StackMatrix
{
    int num_commands, stack_size;
    Subroutine sub;

    public PropagateMatrix<PropagateData> data_matrix;
    public PropagateMatrix<PropagateState> state_matrix;

    public StackMatrix(int n, int s, Subroutine sub)
    {
        num_commands = n;
        stack_size = s;
        this.sub = sub;

        data_matrix = new PropagateMatrix<PropagateData>(num_commands, stack_size, null);
        state_matrix = new PropagateMatrix<PropagateState>(num_commands, 1, null);
    }

    public PropagateData GetItem(int posX, int posY)
    {
        return data_matrix.GetItem(posX, posY);
    }

    public void SetData(int posX, int posY, PropagateData data)
    {
        data_matrix.SetItem(posX, posY, data);
    }

    public void Push(int command, PropagateData data)
    {
        // TODO: Fresh matrix?
        ModifySP(command, 1);
        Propagate(data, command, -4);
    }

    public PropagateData Pop(int command)
    {
        // TODO: Vector support
        PropagateData value = GetValue(command, -4);
        ModifySP(command, -1);

        return value;
    }

    public PropagateData GetValue(int command, int offset)
    {
        int pos = SPOffsetToPos(command, offset);
        return data_matrix.GetItem(command, pos);
    }

    public void Propagate(PropagateData data, int command, int offset)
    {
        int pos = SPOffsetToPos(command, offset);
        data_matrix.SetItem(command, pos, data);
    }

    public int SPOffsetToPos(int command, int offset)
    {
        return TopOfStack(command) + (int)(offset / 4);
    }

    int TopOfStack(int command)
    {
        return state_matrix.GetItem(command, 0).stack_pointer;
    }

    void ModifySP(int command, int offset)
    {
        int new_sp = state_matrix.GetItem(command, 0).stack_pointer + offset;
        state_matrix.SetItem(command, 0, new PropagateState()
        {
            stack_pointer = new_sp,
            base_pointer = state_matrix.GetItem(command, 0).base_pointer
        });
    }
}