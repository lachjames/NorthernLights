using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

// Much of this implementation has been converted from the C++ source of Xoreos
// https://github.com/xoreos/xoreos/blob/61cd69b574a24808f62024769cf0b887e9a735bb/src/aurora/nwscript/ncsfile.cpp

namespace NCSInstructions
{
    public class CPTOPSP : NCSInstruction
    {
        // Copy the given number of bytes from the location specified in the stack to the top of the stack.
        public override void Run(NCSContext context)
        {
            int start = int.Parse(args[1]); // This should always be a multiple of 4
            int size = int.Parse(args[2]); // This should always be a multiple of 4

            while (size > 0)
            {
                // We don't add (+ 4 * i) because every time we push to the stack the top gets pushed up;
                // i..e the + 4 to the offset happens for us when we push to the stack, since the position is relative
                int offset = start;
                object value = context.GetOffsetSP(offset);
                context.Push(value);
                size -= 4;
            }
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class CPDOWNSP : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            int offset = int.Parse(args[1]);
            int size = int.Parse(args[2]);

            int startPos = -size;
            while (size > 0)
            {
                object value = context.GetOffsetSP(startPos);
                context.SetOffsetSP(offset, value);

                startPos += 4;
                offset += 4;
                size -= 4;
            }
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }

    public class CPTOPBP : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Add the given number of bytes from the location specified
            // relative to the base pointer to the top of the stack.
            int offset = int.Parse(args[1]) - 4;
            int size = int.Parse(args[2]);

            while (size > 0)
            {
                object value = context.GetOffsetBP(offset);
                context.Push(value);

                size -= 4;
                offset += 4;
            }
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class CPDOWNBP : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Copy the given number of bytes from the base pointer
            // down to the location specified.
            int offset = int.Parse(args[1]) - 4;
            int size = int.Parse(args[2]);

            int startPos = -size;
            while (size > 0)
            {
                object val = context.GetOffsetSP(startPos);
                context.SetOffsetBP(offset, val);

                startPos += 4;
                offset += 4;
                size -= 4;
            }
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class MOVSP : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // TODO: Check whether this is correct:
            // In Xoreos they subtract the offset from the stack pointer?
            int offset = -int.Parse(args[1]);

            while (offset > 0)
            {
                // TODO: Make this work for vectors and structs
                try
                {
                    context.Pop();
                } catch
                {
                    Debug.LogError("Could not pop from stack with MOVSP, offset = " + offset);
                    return;
                }
                offset -= 4;
            }
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }


    public class RSADDI : NCSInstruction
    {
        // Reserves space on the stack for an integer
        public override void Run(NCSContext context)
        {
            context.Push(0);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            matrix.Push(command, new PropagateData(NCSDataType.INT, "0"));
            return new NOOP();
        }

    }

    public class RSADDF : NCSInstruction
    {
        // Reserves space on the stack for a float
        public override void Run(NCSContext context)
        {
            context.Push(0.0);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            matrix.Push(command, new PropagateData(NCSDataType.FLOAT, "0.0"));
            return new NOOP();
        }

    }

    public class RSADDS : NCSInstruction
    {
        // Reserves space on the stack for a string
        public override void Run(NCSContext context)
        {
            context.Push("");
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            matrix.Push(command, new PropagateData(NCSDataType.STRING, "\"\""));
            return new NOOP();
        }

    }

    public class RSADDO : NCSInstruction
    {
        // Reserves space on the stack for an object
        public override void Run(NCSContext context)
        {
            // Not required
            context.Push(new object());
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            matrix.Push(command, new PropagateData(NCSDataType.OBJECT, "OBJECT_INVALID"));
            return new NOOP();
        }

    }

    public class RSADDE0 : NCSInstruction
    {
        // Reserves space on the stack for an object
        public override void Run(NCSContext context)
        {
            // Not required
            context.Push(new object());
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            matrix.Push(command, new PropagateData(NCSDataType.E0, ""));
            return new NOOP();
        }

    }

    public class RSADDE1 : NCSInstruction
    {
        // Reserves space on the stack for an object
        public override void Run(NCSContext context)
        {
            // Not required
            context.Push(new object());
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            matrix.Push(command, new PropagateData(NCSDataType.E1, ""));
            return new NOOP();
        }

    }
    public class RSADDE2 : NCSInstruction
    {
        // Reserves space on the stack for an object
        public override void Run(NCSContext context)
        {
            // Not required
            context.Push(new object());
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            matrix.Push(command, new PropagateData(NCSDataType.E2, ""));
            return new NOOP();
        }

    }
    public class RSADDE3 : NCSInstruction
    {
        // Reserves space on the stack for an object
        public override void Run(NCSContext context)
        {
            // Not required
            context.Push(new object());
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            matrix.Push(command, new PropagateData(NCSDataType.E3, ""));
            return new NOOP();
        }

    }
    public class RSADDE4 : NCSInstruction
    {
        // Reserves space on the stack for an object
        public override void Run(NCSContext context)
        {
            // Not required
            context.Push(new object());
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            matrix.Push(command, new PropagateData(NCSDataType.E4, ""));
            return new NOOP();
        }

    }
    public class RSADDE5 : NCSInstruction
    {
        // Reserves space on the stack for an object
        public override void Run(NCSContext context)
        {
            // Not required
            context.Push(new object());
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            matrix.Push(command, new PropagateData(NCSDataType.E5, ""));
            return new NOOP();
        }

    }


    public class CONSTI : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Pushes an immediate value onto the stack
            int value = int.Parse(args[1]);
            context.Push(value);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            matrix.Push(command, new PropagateData(NCSDataType.INT, args[1]));
            return new NOOP();
        }

    }

    public class CONSTF : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Pushes an immediate value onto the stack
            float value = float.Parse(args[1]);
            context.Push(value);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            matrix.Push(command, new PropagateData(NCSDataType.FLOAT, args[1]));
            return new NOOP();
        }

    }
    public class CONSTS : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Pushes an immediate value onto the stack
            string value = args[2];
            context.Push(value);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            matrix.Push(command, new PropagateData(NCSDataType.STRING, args[2]));
            return new NOOP();
        }

    }

    public class CONSTO : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Pushes an immediate value onto the stack
            int value = int.Parse(args[1]);
            if (value == 0)
            {
                context.Push(context.objectSelf);
            }
            else if (value == 0x00000001 || value == -1 || value == 0x7F000000)
            {
                context.Push(null);
            }
            else
            {
                throw new Exception("Tried to instantiate constant object with value " + args[1]);
            }
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            int value = int.Parse(args[1]);
            if (value == 0)
            {
                matrix.Push(command, new PropagateData(NCSDataType.OBJECT, "OBJECT_SELF"));
            }
            else if (value == 0x00000001 || value == -1 || value == 0x7F000000)
            {
                matrix.Push(command, new PropagateData(NCSDataType.OBJECT, "OBJECT_INVALID"));
            }
            else
            {
                throw new Exception("Tried to instantiate constant object with value " + args[1]);
            }
            return new NOOP();
        }

    }

    public class STORE_STATEALL : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Pushes an immediate value onto the stack
            Debug.Log("STORE_STATEALL is obsolete and not implemented");
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }

    public class DESTRUCT : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            int stackSize = int.Parse(args[1]);
            int dontRemoveOffset = int.Parse(args[2]);
            int dontRemoveSize = int.Parse(args[3]);

            List<object> tmp = new List<object>();

            while (stackSize > 0)
            {
                object obj = context.Pop();
                if ((stackSize <= (dontRemoveOffset + dontRemoveSize)) &&
                    (stackSize > dontRemoveOffset))
                {
                    tmp.Add(obj);
                }
                stackSize -= 4;
            }

            if (tmp.Count != dontRemoveSize / 4)
            {
                throw new Exception("Expected tmp.Count = " + dontRemoveSize / 4 + " but found " + tmp.Count);
            }

            foreach (object obj in tmp)
            {
                context.Push(obj);
            }
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }

    public class DECSPI : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            int offset = int.Parse(args[1]);

            int value = ((int)context.GetOffsetSP(offset)) - 1;
            context.SetOffsetSP(offset, value);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }

    public class INCSPI : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            int offset = int.Parse(args[1]);

            int value = ((int)context.GetOffsetSP(offset)) + 1;
            context.SetOffsetSP(offset, value);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }

    public class DECBP : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            int offset = int.Parse(args[1]);

            int value = ((int)context.GetOffsetBP(offset)) - 1;
            context.SetOffsetBP(offset, value);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }
    public class INCBP : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            int offset = int.Parse(args[1]);

            int value = ((int)context.GetOffsetBP(offset)) + 1;
            context.SetOffsetBP(offset, value);
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }

    public class SAVEBP : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            int basePtr = context.basePointer;
            context.Push(basePtr);
            context.basePointer = context.stackPointer;
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }

    public class RESTOREBP : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            int basePtr = (int)context.Pop();
            context.basePointer = basePtr;
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }

    }

    public class STORESTATE : NCSInstruction
    {
        public override void Run(NCSContext context)
        {
            // Push a copy of the current context to the stack
            context.StoreState(context.script.labels[args[1]]);
            //throw new NotImplementedException("STORESTATE not yet implemented ;(");
        }
        public override ILInstruction Convert(int command, StackMatrix matrix)
        {
            throw new System.NotImplementedException();
        }
    }
}