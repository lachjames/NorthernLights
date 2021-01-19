using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ILInstruction
{
    public abstract override string ToString();
}

public class NOOP : ILInstruction
{
    public override string ToString()
    {
        return "";
    }
}

public class Assignment : ILInstruction
{
    public override string ToString()
    {
        return "=";
    }
}

//public class CreateLocal : ILInstruction
//{

//}

//public class ReturnValue : ILInstruction
//{

//}

//public class NSSAction : ILInstruction
//{

//}

//public class NSSReference : ILInstruction
//{

//}