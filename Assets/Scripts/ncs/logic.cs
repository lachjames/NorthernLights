using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCSInstructions
{

    public class LOGANDII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Compute the logical AND of two integer values.
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            bool truth = (val1 != 0) && (val2 != 0);
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }
    public class LOGORII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Compute the logical OR of two integer values.
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            bool truth = (val1 != 0) || (val2 != 0);
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }
    public class INCORII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Bitwise inclusive or
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            int result = val1 | val2;
            context.Push(result);
        }
    }
    public class EXCORII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Bitwise exclusive or
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            int result = val1 ^ val2;
            context.Push(result);
        }
    }
    public class BOOLANDII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Computes the boolean/bitwise AND of two integers
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            int result = val1 & val2;
            context.Push(result);
        }
    }
    public class EQII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Determines if two integers are equal
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            bool truth = val1 == val2;
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }
    public class EQFF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Determines if two floats are equal
            float val2 = (float)context.Pop();
            float val1 = (float)context.Pop();
            bool truth = val1 == val2;
            int result = truth ? 1: 0;
            context.Push(result);
        }
    }
    public class EQSS : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Determines if two strings are equal
            string val2 = (string)context.Pop();
            string val1 = (string)context.Pop();
            bool truth = val1 == val2;
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }
    public class EQOO : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Pushes an immediate value onto the stack
            AuroraObject val2 = (AuroraObject)context.Pop();
            AuroraObject val1 = (AuroraObject)context.Pop();
            bool truth = val1 == val2;
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }
    public class EQTT : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Pushes an immediate value onto the stack
            object val2 = context.Pop();
            object val1 = context.Pop();
            bool truth = val1 == val2;
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }
    public class NEQII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Determines if two integers are equal
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            bool truth = val1 != val2;
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }
    public class NEQFF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Determines if two floats are equal
            float val2 = (float)context.Pop();
            float val1 = (float)context.Pop();
            bool truth = val1 != val2;
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }
    public class NEQSS : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Determines if two strings are equal
            string val2 = (string)context.Pop();
            string val1 = (string)context.Pop();
            bool truth = val1 != val2;
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }
    public class NEQOO : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Pushes an immediate value onto the stack
            AuroraObject val2 = (AuroraObject)context.Pop();
            AuroraObject val1 = (AuroraObject)context.Pop();
            bool truth = val1 != val2;
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }
    public class NEQTT : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Pushes an immediate value onto the stack
            object val2 = context.Pop();
            object val1 = context.Pop();
            bool truth = val1 != val2;
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }
    public class GEQII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {

            context.Log(context.stack[context.stack.Count - 1]);
            context.Log(context.stack[context.stack.Count - 2]);

            // Determines if two integers are equal
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            bool truth = val1 >= val2;
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }
    public class GEQFF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Determines if two floats are equal
            float val2 = (float)context.Pop();
            float val1 = (float)context.Pop();
            bool truth = val1 >= val2;
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }

    public class GTII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Determines if two integers are equal
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            bool truth = val1 > val2;
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }
    public class GTFF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Determines if two floats are equal
            float val2 = (float)context.Pop();
            float val1 = (float)context.Pop();
            bool truth = val1 > val2;
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }
    public class LTII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Determines if two integers are equal
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            bool truth = val1 < val2;
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }
    public class LTFF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Determines if two floats are equal
            float val2 = (float)context.Pop();
            float val1 = (float)context.Pop();
            bool truth = val1 < val2;
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }
    public class LEQII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Determines if two integers are equal
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            bool truth = val1 <= val2;
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }
    public class LEQFF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Determines if two floats are equal
            float val2 = (float)context.Pop();
            float val1 = (float)context.Pop();
            bool truth = val1 <= val2;
            int result = truth ? 1 : 0;
            context.Push(result);
        }
    }

    public class SHLEFTII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            int result = val1 << val2;
            context.Push(result);
        }
    }
    public class SHRIGHTII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            int val2 = (int)context.Pop();
            int val1 = (int)context.Pop();
            int result = val1 >> val2;
            context.Push(result);
        }
    }
    public class USHRIGHTII : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Reference: https://stackoverflow.com/questions/8125127/what-is-the-c-sharp-equivalent-of-java-unsigned-right-shift-operator
            int val2 = (int)context.Pop();
            uint val1 = (uint)(int)context.Pop();
            uint result = val1 << val2;
            context.Push((int)result);
        }
    }

    public class NOTI : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Computes the logical not of the value
            int val1 = (int)context.Pop();
            int result = val1 == 0 ? 1 : 0;
            context.Push(result);
        }
    }

}