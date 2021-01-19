using UnityEngine;

namespace NCSInstructions
{
    public abstract class NCSInstruction
    {
        // By default, all instructions increment the program counter
        public virtual bool IncrementsPC { get { return true; } }

        public string[] args;
        public NCSScript script;
        public void Initialize(string[] args, NCSScript script)
        {
            this.args = args;
            this.script = script;
        }

        public string ToString()
        {
            return string.Join(" ", args);
        }

        public abstract void Run(NCSContext context);

        public abstract ILInstruction Convert(int command, StackMatrix matrix);
    }
}