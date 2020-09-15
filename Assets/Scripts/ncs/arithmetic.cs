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
    }

}
