using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AuroraAnimation
{
    public abstract int id { get; }
    public abstract string name { get; }
    public abstract string description { get; }
    public abstract bool stationary { get; }
    public abstract bool pause { get; }
    public abstract bool walking { get; }
    public abstract bool running { get; }
    public abstract bool looping { get; }
    public abstract bool fireforget { get; }
    public abstract bool overlay { get; }
    public abstract bool playoutofplace { get; }
    public abstract bool dialog { get; }
    public abstract bool damage { get; }
    public abstract bool parry { get; }
    public abstract bool dodge { get; }
    public abstract bool attack { get; }
    public abstract bool hideequippeditems { get; }

    public void PlayAnimation (Animation anim)
    {
        anim.CrossFade(name.ToLower());
    }
}