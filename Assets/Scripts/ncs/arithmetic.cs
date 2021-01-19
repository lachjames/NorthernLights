using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCSInstructions
{
    public class ADDII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Adds two integers together
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            int result = val1 + val2;
            context.Push(result);
        }

        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }
    }
    public class ADDIF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Adds an integer and a float together
            float val2 = (float)context.Pop();
            int val1 = (int)context.Pop();
            float result = val1 + val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class ADDFI : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Adds a float and an integer together
            int val2 = (int)context.Pop();
            float val1 = (float)context.Pop();
            float result = val1 + val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }
    }
    public class ADDFF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Adds two floats together
            float val2 = (float)context.Pop();
            float val1 = (float)context.Pop();
            float result = val1 + val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class ADDSS : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Adds two floats together
            string val2 = (string)context.Pop();
            string val1 = (string)context.Pop();
            string result = val1 + val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class ADDVV : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Pushes an immediate value onto the stack
            Vector3 val2 = (Vector3)context.Pop();
            Vector3 val1 = (Vector3)context.Pop();
            Vector3 result = val1 + val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class SUBII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Adds two integers together
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            int result = val1 - val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class SUBIF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Adds an integer and a float together
            float val2 = (float)context.Pop();
            int val1 = (int)context.Pop();
            float result = val1 - val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class SUBFI : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Adds a float and an integer together
            int val2 = (int)context.Pop();
            float val1 = (float)context.Pop();
            float result = val1 - val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class SUBFF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Adds two floats together
            float val2 = (float)context.Pop();
            float val1 = (float)context.Pop();
            float result = val1 - val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class SUBVV : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Pushes an immediate value onto the stack
            Vector3 val2 = (Vector3)context.Pop();
            Vector3 val1 = (Vector3)context.Pop();
            Vector3 result = val1 - val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class MULII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Adds two integers together
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            int result = val1 * val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class MULIF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Adds an integer and a float together
            float val2 = (float)context.Pop();
            int val1 = (int)context.Pop();
            float result = val1 * val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class MULFI : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Adds a float and an integer together
            int val2 = (int)context.Pop();
            float val1 = (float)context.Pop();
            float result = val1 * val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class MULFF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Adds two floats together
            float val2 = (float)context.Pop();
            float val1 = (float)context.Pop();
            float result = val1 * val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class MULVF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Pushes an immediate value onto the stack
            float val2 = (float)context.Pop();
            Vector3 val1 = (Vector3)context.Pop();
            Vector3 result = val1 * val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class MULFV : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Pushes an immediate value onto the stack
            Vector3 val2 = (Vector3)context.Pop();
            float val1 = (float)context.Pop();
            Vector3 result = val1 * val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class DIVII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Adds two integers together
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            int result = val1 / val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class DIVIF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Adds an integer and a float together
            float val2 = (float)context.Pop();
            int val1 = (int)context.Pop();
            float result = val1 / val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class DIVFI : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Adds a float and an integer together
            int val2 = (int)context.Pop();
            float val1 = (float)context.Pop();
            float result = val1 / val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class DIVFF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Adds two floats together
            float val2 = (float)context.Pop();
            float val1 = (float)context.Pop();
            float result = val1 / val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class DIVVF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Pushes an immediate value onto the stack
            float val2 = (float)context.Pop();
            Vector3 val1 = (Vector3)context.Pop();
            Vector3 result = val1 / val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class MODII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            int result = val1 % val2;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class NEGI : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Computes the negation of an int
            int val1 = (int)context.Pop();
            int result = -val1;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class NEGF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Computes the negation of a float
            float val1 = (float)context.Pop();
            float result = -val1;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class COMPI : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // https://stackoverflow.com/questions/50870534/ones-complement-in-c-sharp
            int val1 = (int)context.Pop();
            int result = ~val1;
            context.Push(result);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }

}
