
public class AuroraAnimations
{

    public class Anim_Walk_No_Weapon : AuroraAnimation
    {
        public override int id { get { return 0; } }
        public override string name { get { return "walk"; } }
        public override string description { get { return "Walk_No_Weapon"; } }
        public override bool stationary { get { return false; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return true; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Walk_While_Injured : AuroraAnimation
    {
        public override int id { get { return 1; } }
        public override string name { get { return "walkinj"; } }
        public override string description { get { return "Walk_While_Injured"; } }
        public override bool stationary { get { return false; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return true; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Run_No_Weapon : AuroraAnimation
    {
        public override int id { get { return 2; } }
        public override string name { get { return "run"; } }
        public override string description { get { return "Run_No_Weapon"; } }
        public override bool stationary { get { return false; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return true; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Run_Dual_Saber : AuroraAnimation
    {
        public override int id { get { return 3; } }
        public override string name { get { return "runds"; } }
        public override string description { get { return "Run_Dual_Saber"; } }
        public override bool stationary { get { return false; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return true; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Run_Injured : AuroraAnimation
    {
        public override int id { get { return 4; } }
        public override string name { get { return "runinj"; } }
        public override string description { get { return "Run_Injured"; } }
        public override bool stationary { get { return false; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return true; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Walk_Stealthily : AuroraAnimation
    {
        public override int id { get { return 5; } }
        public override string name { get { return "stealth"; } }
        public override string description { get { return "Walk_Stealthily"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return true; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Idle_1 : AuroraAnimation
    {
        public override int id { get { return 6; } }
        public override string name { get { return "pause1"; } }
        public override string description { get { return "Idle_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Idle_2 : AuroraAnimation
    {
        public override int id { get { return 7; } }
        public override string name { get { return "pause2"; } }
        public override string description { get { return "Idle_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Idle_Injured : AuroraAnimation
    {
        public override int id { get { return 8; } }
        public override string name { get { return "pauseinj"; } }
        public override string description { get { return "Idle_Injured"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Idle_Stealthily : AuroraAnimation
    {
        public override int id { get { return 9; } }
        public override string name { get { return "pausestl"; } }
        public override string description { get { return "Idle_Stealthily"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_hturnr : AuroraAnimation
    {
        public override int id { get { return 10; } }
        public override string name { get { return "hturnr"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_hturnl : AuroraAnimation
    {
        public override int id { get { return 11; } }
        public override string name { get { return "hturnl"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Idle_Scratch_Head : AuroraAnimation
    {
        public override int id { get { return 12; } }
        public override string name { get { return "pausesh"; } }
        public override string description { get { return "Idle_Scratch_Head"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Idle_Bored : AuroraAnimation
    {
        public override int id { get { return 13; } }
        public override string name { get { return "pausebrd"; } }
        public override string description { get { return "Idle_Bored"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Idle_Tired : AuroraAnimation
    {
        public override int id { get { return 14; } }
        public override string name { get { return "pausetrd"; } }
        public override string description { get { return "Idle_Tired"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Idle_Poisoned : AuroraAnimation
    {
        public override int id { get { return 15; } }
        public override string name { get { return "pausepsn"; } }
        public override string description { get { return "Idle_Poisoned"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Salute : AuroraAnimation
    {
        public override int id { get { return 16; } }
        public override string name { get { return "salute"; } }
        public override string description { get { return "Salute"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Victory_Taunt : AuroraAnimation
    {
        public override int id { get { return 17; } }
        public override string name { get { return "victory"; } }
        public override string description { get { return "Victory_Taunt"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Idle_Listen : AuroraAnimation
    {
        public override int id { get { return 18; } }
        public override string name { get { return "listen"; } }
        public override string description { get { return "Idle_Listen"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Bow : AuroraAnimation
    {
        public override int id { get { return 19; } }
        public override string name { get { return "bow"; } }
        public override string description { get { return "Bow"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Sit_Down_Feet_Stationary : AuroraAnimation
    {
        public override int id { get { return 20; } }
        public override string name { get { return "sitdown"; } }
        public override string description { get { return "Sit_Down_Feet_Stationary"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Sit_Loop : AuroraAnimation
    {
        public override int id { get { return 21; } }
        public override string name { get { return "sit"; } }
        public override string description { get { return "Sit_Loop"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Stand_From_Sit : AuroraAnimation
    {
        public override int id { get { return 22; } }
        public override string name { get { return "standup"; } }
        public override string description { get { return "Stand_From_Sit"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Kneel_To_Meditate : AuroraAnimation
    {
        public override int id { get { return 23; } }
        public override string name { get { return "kneel"; } }
        public override string description { get { return "Kneel_To_Meditate"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Meditate_Loop : AuroraAnimation
    {
        public override int id { get { return 24; } }
        public override string name { get { return "meditate"; } }
        public override string description { get { return "Meditate_Loop"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Talk_Normal : AuroraAnimation
    {
        public override int id { get { return 25; } }
        public override string name { get { return "tlknorm"; } }
        public override string description { get { return "Talk_Normal"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Talk_Forceful : AuroraAnimation
    {
        public override int id { get { return 26; } }
        public override string name { get { return "tlkforce"; } }
        public override string description { get { return "Talk_Forceful"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Talk_Pleading : AuroraAnimation
    {
        public override int id { get { return 27; } }
        public override string name { get { return "tlkplead"; } }
        public override string description { get { return "Talk_Pleading"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Talk_Sad : AuroraAnimation
    {
        public override int id { get { return 28; } }
        public override string name { get { return "tlksad"; } }
        public override string description { get { return "Talk_Sad"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Talk_Laughing : AuroraAnimation
    {
        public override int id { get { return 29; } }
        public override string name { get { return "tlklaugh"; } }
        public override string description { get { return "Talk_Laughing"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Talk_Mouth_Phenomes : AuroraAnimation
    {
        public override int id { get { return 30; } }
        public override string name { get { return "talk"; } }
        public override string description { get { return "Talk_Mouth_Phenomes"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Greeting : AuroraAnimation
    {
        public override int id { get { return 31; } }
        public override string name { get { return "greeting"; } }
        public override string description { get { return "Greeting"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Flirt : AuroraAnimation
    {
        public override int id { get { return 32; } }
        public override string name { get { return "flirt"; } }
        public override string description { get { return "Flirt"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Taunt : AuroraAnimation
    {
        public override int id { get { return 33; } }
        public override string name { get { return "taunt"; } }
        public override string description { get { return "Taunt"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Treat_Injured_On_Ground : AuroraAnimation
    {
        public override int id { get { return 34; } }
        public override string name { get { return "treatinj"; } }
        public override string description { get { return "Treat_Injured_On_Ground"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Treat_Injured_Loop : AuroraAnimation
    {
        public override int id { get { return 35; } }
        public override string name { get { return "treatinjlp"; } }
        public override string description { get { return "Treat_Injured_Loop"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Treat_Injured_Standing : AuroraAnimation
    {
        public override int id { get { return 36; } }
        public override string name { get { return "treatinjstand"; } }
        public override string description { get { return "Treat_Injured_Standing"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Inject_Self_In_Leg : AuroraAnimation
    {
        public override int id { get { return 37; } }
        public override string name { get { return "inject"; } }
        public override string description { get { return "Inject_Self_In_Leg"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return true; } }
    }

    public class Anim_Activate_Wrist : AuroraAnimation
    {
        public override int id { get { return 38; } }
        public override string name { get { return "activate"; } }
        public override string description { get { return "Activate_Wrist"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Equip_From_Belt : AuroraAnimation
    {
        public override int id { get { return 39; } }
        public override string name { get { return "equip"; } }
        public override string description { get { return "Equip_From_Belt"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Pick_Up_From_Ground : AuroraAnimation
    {
        public override int id { get { return 40; } }
        public override string name { get { return "getfromgnd"; } }
        public override string description { get { return "Pick_Up_From_Ground"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Pick_Up_From_Table : AuroraAnimation
    {
        public override int id { get { return 41; } }
        public override string name { get { return "getfromtbl"; } }
        public override string description { get { return "Pick_Up_From_Table"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Pick_Up_From_Container : AuroraAnimation
    {
        public override int id { get { return 42; } }
        public override string name { get { return "getfromcntr"; } }
        public override string description { get { return "Pick_Up_From_Container"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Use_Computer : AuroraAnimation
    {
        public override int id { get { return 43; } }
        public override string name { get { return "usecomp"; } }
        public override string description { get { return "Use_Computer"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Use_Computer_Loop : AuroraAnimation
    {
        public override int id { get { return 44; } }
        public override string name { get { return "usecomplp"; } }
        public override string description { get { return "Use_Computer_Loop"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Use_Handheld_Computer : AuroraAnimation
    {
        public override int id { get { return 45; } }
        public override string name { get { return "handheld"; } }
        public override string description { get { return "Use_Handheld_Computer"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Use_Handheld_Computer_Loop : AuroraAnimation
    {
        public override int id { get { return 46; } }
        public override string name { get { return "handheldlp"; } }
        public override string description { get { return "Use_Handheld_Computer_Loop"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Unlock_Door : AuroraAnimation
    {
        public override int id { get { return 47; } }
        public override string name { get { return "unlockdr"; } }
        public override string description { get { return "Unlock_Door"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return true; } }
    }

    public class Anim_Unlock_Container : AuroraAnimation
    {
        public override int id { get { return 48; } }
        public override string name { get { return "unlockcntr"; } }
        public override string description { get { return "Unlock_Container"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return true; } }
    }

    public class Anim_Open_Container : AuroraAnimation
    {
        public override int id { get { return 49; } }
        public override string name { get { return "opencntr"; } }
        public override string description { get { return "Open_Container"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Operate_Switch : AuroraAnimation
    {
        public override int id { get { return 50; } }
        public override string name { get { return "opswitch"; } }
        public override string description { get { return "Operate_Switch"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Disable_Mine_On_Ground : AuroraAnimation
    {
        public override int id { get { return 51; } }
        public override string name { get { return "disablemine"; } }
        public override string description { get { return "Disable_Mine_On_Ground"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return true; } }
    }

    public class Anim_Set_Mine_On_Ground : AuroraAnimation
    {
        public override int id { get { return 52; } }
        public override string name { get { return "setmine"; } }
        public override string description { get { return "Set_Mine_On_Ground"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return true; } }
    }

    public class Anim_Dance_1 : AuroraAnimation
    {
        public override int id { get { return 53; } }
        public override string name { get { return "dance"; } }
        public override string description { get { return "Dance_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Dance_2 : AuroraAnimation
    {
        public override int id { get { return 54; } }
        public override string name { get { return "dance1"; } }
        public override string description { get { return "Dance_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_drink : AuroraAnimation
    {
        public override int id { get { return 55; } }
        public override string name { get { return "drink"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_cardplay : AuroraAnimation
    {
        public override int id { get { return 56; } }
        public override string name { get { return "cardplay"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Throw_Grenade_1 : AuroraAnimation
    {
        public override int id { get { return 57; } }
        public override string name { get { return "throwgren"; } }
        public override string description { get { return "Throw_Grenade_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Throw_Grenade_2 : AuroraAnimation
    {
        public override int id { get { return 58; } }
        public override string name { get { return "throwgren1"; } }
        public override string description { get { return "Throw_Grenade_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Alignment_Stance_Good : AuroraAnimation
    {
        public override int id { get { return 59; } }
        public override string name { get { return "good"; } }
        public override string description { get { return "Alignment_Stance_Good"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Alignment_Stance_Neutral : AuroraAnimation
    {
        public override int id { get { return 60; } }
        public override string name { get { return "neutral"; } }
        public override string description { get { return "Alignment_Stance_Neutral"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Alignment_Stance_Evil : AuroraAnimation
    {
        public override int id { get { return 61; } }
        public override string name { get { return "evil"; } }
        public override string description { get { return "Alignment_Stance_Evil"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Casting_Outward_1 : AuroraAnimation
    {
        public override int id { get { return 62; } }
        public override string name { get { return "castout1"; } }
        public override string description { get { return "Casting_Outward_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Casting_Outward_Loop_1 : AuroraAnimation
    {
        public override int id { get { return 63; } }
        public override string name { get { return "castoutlp1"; } }
        public override string description { get { return "Casting_Outward_Loop_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Casting_Outward_2 : AuroraAnimation
    {
        public override int id { get { return 64; } }
        public override string name { get { return "castout2"; } }
        public override string description { get { return "Casting_Outward_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Casting_Outward_Loop_2 : AuroraAnimation
    {
        public override int id { get { return 65; } }
        public override string name { get { return "castoutlp2"; } }
        public override string description { get { return "Casting_Outward_Loop_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Casting_Outward_3 : AuroraAnimation
    {
        public override int id { get { return 66; } }
        public override string name { get { return "castout3"; } }
        public override string description { get { return "Casting_Outward_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Casting_Outward_Loop_3 : AuroraAnimation
    {
        public override int id { get { return 67; } }
        public override string name { get { return "castoutlp3"; } }
        public override string description { get { return "Casting_Outward_Loop_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Jedi_Mind_Trick_Wave : AuroraAnimation
    {
        public override int id { get { return 68; } }
        public override string name { get { return "persuade"; } }
        public override string description { get { return "Jedi_Mind_Trick_Wave"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Throw_Lightsaber : AuroraAnimation
    {
        public override int id { get { return 69; } }
        public override string name { get { return "throwsab"; } }
        public override string description { get { return "Throw_Lightsaber"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Throw_Lightsaber_Loop : AuroraAnimation
    {
        public override int id { get { return 70; } }
        public override string name { get { return "throwsablp"; } }
        public override string description { get { return "Throw_Lightsaber_Loop"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return true; } }
    }

    public class Anim_Catch_Lightsaber : AuroraAnimation
    {
        public override int id { get { return 71; } }
        public override string name { get { return "catchsab"; } }
        public override string description { get { return "Catch_Lightsaber"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Choke : AuroraAnimation
    {
        public override int id { get { return 72; } }
        public override string name { get { return "choke"; } }
        public override string description { get { return "Choke"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Fear : AuroraAnimation
    {
        public override int id { get { return 73; } }
        public override string name { get { return "fear"; } }
        public override string description { get { return "Fear"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Horror : AuroraAnimation
    {
        public override int id { get { return 74; } }
        public override string name { get { return "horror"; } }
        public override string description { get { return "Horror"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Caught_In_Whirlwind : AuroraAnimation
    {
        public override int id { get { return 75; } }
        public override string name { get { return "whirlwind"; } }
        public override string description { get { return "Caught_In_Whirlwind"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Sleeping_Standing : AuroraAnimation
    {
        public override int id { get { return 76; } }
        public override string name { get { return "sleep"; } }
        public override string description { get { return "Sleeping_Standing"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_spasm : AuroraAnimation
    {
        public override int id { get { return 77; } }
        public override string name { get { return "spasm"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Stance_Paralyzed : AuroraAnimation
    {
        public override int id { get { return 78; } }
        public override string name { get { return "paralyzed"; } }
        public override string description { get { return "Stance_Paralyzed"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Idle_On_Back : AuroraAnimation
    {
        public override int id { get { return 79; } }
        public override string name { get { return "prone"; } }
        public override string description { get { return "Idle_On_Back"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Death_1 : AuroraAnimation
    {
        public override int id { get { return 80; } }
        public override string name { get { return "die"; } }
        public override string description { get { return "Death_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Dead_Loop_1 : AuroraAnimation
    {
        public override int id { get { return 81; } }
        public override string name { get { return "dead"; } }
        public override string description { get { return "Dead_Loop_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Death_2 : AuroraAnimation
    {
        public override int id { get { return 82; } }
        public override string name { get { return "die1"; } }
        public override string description { get { return "Death_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Death_Loop_2 : AuroraAnimation
    {
        public override int id { get { return 83; } }
        public override string name { get { return "dead1"; } }
        public override string description { get { return "Death_Loop_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Knocked_Down_Loop : AuroraAnimation
    {
        public override int id { get { return 84; } }
        public override string name { get { return "g1x1"; } }
        public override string description { get { return "Knocked_Down_Loop"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Knocked_Down : AuroraAnimation
    {
        public override int id { get { return 85; } }
        public override string name { get { return "g1y1"; } }
        public override string description { get { return "Knocked_Down"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return true; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Stand_From_Knocked_Down : AuroraAnimation
    {
        public override int id { get { return 86; } }
        public override string name { get { return "g1z1"; } }
        public override string description { get { return "Stand_From_Knocked_Down"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Stun_Baton_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 87; } }
        public override string name { get { return "g1a1"; } }
        public override string description { get { return "SB_(Stun_Baton)_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return true; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 88; } }
        public override string name { get { return "g1a2"; } }
        public override string description { get { return "SB_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Take_Damage : AuroraAnimation
    {
        public override int id { get { return 89; } }
        public override string name { get { return "g1d1"; } }
        public override string description { get { return "SB_Take_Damage"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Dodge : AuroraAnimation
    {
        public override int id { get { return 90; } }
        public override string name { get { return "g1g1"; } }
        public override string description { get { return "SB_Dodge"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Wield_Idle_To_Melee : AuroraAnimation
    {
        public override int id { get { return 91; } }
        public override string name { get { return "g1w1"; } }
        public override string description { get { return "SB_Wield_Idle_To_Melee"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Melee_Idle : AuroraAnimation
    {
        public override int id { get { return 92; } }
        public override string name { get { return "g1r1"; } }
        public override string description { get { return "SB_Melee_Idle"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Melee_Fidget : AuroraAnimation
    {
        public override int id { get { return 93; } }
        public override string name { get { return "g1r2"; } }
        public override string description { get { return "SB_Melee_Fidget"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Single_Saber_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 94; } }
        public override string name { get { return "c2a1"; } }
        public override string description { get { return "SS_(Single_Saber)_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 95; } }
        public override string name { get { return "c2a2"; } }
        public override string description { get { return "SS_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 96; } }
        public override string name { get { return "c2a3"; } }
        public override string description { get { return "SS_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Attack_With_Parry : AuroraAnimation
    {
        public override int id { get { return 97; } }
        public override string name { get { return "c2a4"; } }
        public override string description { get { return "SS_Attack_With_Parry"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Attack_With_Kick : AuroraAnimation
    {
        public override int id { get { return 98; } }
        public override string name { get { return "c2a5"; } }
        public override string description { get { return "SS_Attack_With_Kick"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Parry_And_Dodge_1 : AuroraAnimation
    {
        public override int id { get { return 99; } }
        public override string name { get { return "c2p1"; } }
        public override string description { get { return "SS_Parry_And_Dodge_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Dodge_And_Parry : AuroraAnimation
    {
        public override int id { get { return 100; } }
        public override string name { get { return "c2p2"; } }
        public override string description { get { return "SS_Dodge_And_Parry"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Parry_1 : AuroraAnimation
    {
        public override int id { get { return 101; } }
        public override string name { get { return "c2p3"; } }
        public override string description { get { return "SS_Parry_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Parry_2 : AuroraAnimation
    {
        public override int id { get { return 102; } }
        public override string name { get { return "c2p4"; } }
        public override string description { get { return "SS_Parry_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Parry_And_Dodge_2 : AuroraAnimation
    {
        public override int id { get { return 103; } }
        public override string name { get { return "c2p5"; } }
        public override string description { get { return "SS_Parry_And_Dodge_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Defend_And_Damage_1 : AuroraAnimation
    {
        public override int id { get { return 104; } }
        public override string name { get { return "c2d1"; } }
        public override string description { get { return "SS_Defend_And_Damage_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Defend_And_Damage_2 : AuroraAnimation
    {
        public override int id { get { return 105; } }
        public override string name { get { return "c2d2"; } }
        public override string description { get { return "SS_Defend_And_Damage_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Defend_And_Damage_3 : AuroraAnimation
    {
        public override int id { get { return 106; } }
        public override string name { get { return "c2d3"; } }
        public override string description { get { return "SS_Defend_And_Damage_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Defend : AuroraAnimation
    {
        public override int id { get { return 107; } }
        public override string name { get { return "c2d4"; } }
        public override string description { get { return "SS_Defend"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Defend_And_Damage_4 : AuroraAnimation
    {
        public override int id { get { return 108; } }
        public override string name { get { return "c2d5"; } }
        public override string description { get { return "SS_Defend_And_Damage_4"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Deflection_1 : AuroraAnimation
    {
        public override int id { get { return 109; } }
        public override string name { get { return "c2n1"; } }
        public override string description { get { return "SS_Deflection_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Deflection_2 : AuroraAnimation
    {
        public override int id { get { return 110; } }
        public override string name { get { return "c2n2"; } }
        public override string description { get { return "SS_Deflection_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Perform_Critical_Strike_1 : AuroraAnimation
    {
        public override int id { get { return 111; } }
        public override string name { get { return "f2a1a"; } }
        public override string description { get { return "SS_Perform_Critical_Strike_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Perform_Flurry_1 : AuroraAnimation
    {
        public override int id { get { return 112; } }
        public override string name { get { return "f2a2a"; } }
        public override string description { get { return "SS_Perform_Flurry_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Perform_Power_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 113; } }
        public override string name { get { return "f2a3a"; } }
        public override string description { get { return "SS_Perform_Power_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Parry_Critical_Strike_1 : AuroraAnimation
    {
        public override int id { get { return 114; } }
        public override string name { get { return "f2p1a"; } }
        public override string description { get { return "SS_Parry_Critical_Strike_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Parry_Flurry_1 : AuroraAnimation
    {
        public override int id { get { return 115; } }
        public override string name { get { return "f2p2a"; } }
        public override string description { get { return "SS_Parry_Flurry_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Parry_Power_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 116; } }
        public override string name { get { return "f2p3a"; } }
        public override string description { get { return "SS_Parry_Power_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Damage_Critical_Strike_1 : AuroraAnimation
    {
        public override int id { get { return 117; } }
        public override string name { get { return "f2d1a"; } }
        public override string description { get { return "SS_Damage_Critical_Strike_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Damage_Flurry_1 : AuroraAnimation
    {
        public override int id { get { return 118; } }
        public override string name { get { return "f2d2a"; } }
        public override string description { get { return "SS_Damage_Flurry_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Damage_Power_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 119; } }
        public override string name { get { return "f2d3a"; } }
        public override string description { get { return "SS_Damage_Power_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Perform_Generic_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 120; } }
        public override string name { get { return "g2a1"; } }
        public override string description { get { return "SS_Perform_Generic_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Perform_Generic_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 121; } }
        public override string name { get { return "g2a2"; } }
        public override string description { get { return "SS_Perform_Generic_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Damage_Generic_Attack : AuroraAnimation
    {
        public override int id { get { return 122; } }
        public override string name { get { return "g2d1"; } }
        public override string description { get { return "SS_Damage_Generic_Attack"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return true; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Attack_Monster_1 : AuroraAnimation
    {
        public override int id { get { return 123; } }
        public override string name { get { return "m2a1"; } }
        public override string description { get { return "SS_Attack_Monster_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Attack_Monster_2 : AuroraAnimation
    {
        public override int id { get { return 124; } }
        public override string name { get { return "m2a2"; } }
        public override string description { get { return "SS_Attack_Monster_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Dodge_Monster_1 : AuroraAnimation
    {
        public override int id { get { return 125; } }
        public override string name { get { return "m2g1"; } }
        public override string description { get { return "SS_Dodge_Monster_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Dodge_Monster_2 : AuroraAnimation
    {
        public override int id { get { return 126; } }
        public override string name { get { return "m2g2"; } }
        public override string description { get { return "SS_Dodge_Monster_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Damage_Monster_1 : AuroraAnimation
    {
        public override int id { get { return 127; } }
        public override string name { get { return "m2d1"; } }
        public override string description { get { return "SS_Damage_Monster_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Damage_Monster_2 : AuroraAnimation
    {
        public override int id { get { return 128; } }
        public override string name { get { return "m2d2"; } }
        public override string description { get { return "SS_Damage_Monster_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Dodge_Generic_Attack : AuroraAnimation
    {
        public override int id { get { return 129; } }
        public override string name { get { return "g2g1"; } }
        public override string description { get { return "SS_Dodge_Generic_Attack"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Wield_Idle_To_Melee : AuroraAnimation
    {
        public override int id { get { return 130; } }
        public override string name { get { return "g2w1"; } }
        public override string description { get { return "SS_Wield_Idle_To_Melee"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Melee_Idle : AuroraAnimation
    {
        public override int id { get { return 131; } }
        public override string name { get { return "g2r1"; } }
        public override string description { get { return "SS_Melee_Idle"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Melee_Fidget : AuroraAnimation
    {
        public override int id { get { return 132; } }
        public override string name { get { return "g2r2"; } }
        public override string description { get { return "SS_Melee_Fidget"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Two_Handed_Saber_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 133; } }
        public override string name { get { return "c3a1"; } }
        public override string description { get { return "2HS_(Two_Handed_Saber)_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 134; } }
        public override string name { get { return "c3a2"; } }
        public override string description { get { return "2HS_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 135; } }
        public override string name { get { return "c3a3"; } }
        public override string description { get { return "2HS_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Attack_4 : AuroraAnimation
    {
        public override int id { get { return 136; } }
        public override string name { get { return "c3a4"; } }
        public override string description { get { return "2HS_Attack_4"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Attack_5 : AuroraAnimation
    {
        public override int id { get { return 137; } }
        public override string name { get { return "c3a5"; } }
        public override string description { get { return "2HS_Attack_5"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Defend_1 : AuroraAnimation
    {
        public override int id { get { return 138; } }
        public override string name { get { return "c3p1"; } }
        public override string description { get { return "2HS_Defend_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Dodge_And_Defend : AuroraAnimation
    {
        public override int id { get { return 139; } }
        public override string name { get { return "c3p2"; } }
        public override string description { get { return "2HS_Dodge_And_Defend"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Defend_2 : AuroraAnimation
    {
        public override int id { get { return 140; } }
        public override string name { get { return "c3p3"; } }
        public override string description { get { return "2HS_Defend_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Defend_3 : AuroraAnimation
    {
        public override int id { get { return 141; } }
        public override string name { get { return "c3p4"; } }
        public override string description { get { return "2HS_Defend_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Defend_And_Dodge : AuroraAnimation
    {
        public override int id { get { return 142; } }
        public override string name { get { return "c3p5"; } }
        public override string description { get { return "2HS_Defend_And_Dodge"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Defend_And_Damage_1 : AuroraAnimation
    {
        public override int id { get { return 143; } }
        public override string name { get { return "c3d1"; } }
        public override string description { get { return "2HS_Defend_And_Damage_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Defend_And_Damage_2 : AuroraAnimation
    {
        public override int id { get { return 144; } }
        public override string name { get { return "c3d2"; } }
        public override string description { get { return "2HS_Defend_And_Damage_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Defend_And_Damage_3 : AuroraAnimation
    {
        public override int id { get { return 145; } }
        public override string name { get { return "c3d3"; } }
        public override string description { get { return "2HS_Defend_And_Damage_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Defend : AuroraAnimation
    {
        public override int id { get { return 146; } }
        public override string name { get { return "c3d4"; } }
        public override string description { get { return "2HS_Defend"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Defend_And_Damage_4 : AuroraAnimation
    {
        public override int id { get { return 147; } }
        public override string name { get { return "c3d5"; } }
        public override string description { get { return "2HS_Defend_And_Damage_4"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Deflection_1 : AuroraAnimation
    {
        public override int id { get { return 148; } }
        public override string name { get { return "c3n1"; } }
        public override string description { get { return "2HS_Deflection_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Deflection_2 : AuroraAnimation
    {
        public override int id { get { return 149; } }
        public override string name { get { return "c3n2"; } }
        public override string description { get { return "2HS_Deflection_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Perform_Critical_Strike_1 : AuroraAnimation
    {
        public override int id { get { return 150; } }
        public override string name { get { return "f3a1a"; } }
        public override string description { get { return "2HS_Perform_Critical_Strike_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Perform_Flurry_1 : AuroraAnimation
    {
        public override int id { get { return 151; } }
        public override string name { get { return "f3a2a"; } }
        public override string description { get { return "2HS_Perform_Flurry_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Perform_Power_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 152; } }
        public override string name { get { return "f3a3a"; } }
        public override string description { get { return "2HS_Perform_Power_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Parry_Critical_Strike_1 : AuroraAnimation
    {
        public override int id { get { return 153; } }
        public override string name { get { return "f3p1a"; } }
        public override string description { get { return "2HS_Parry_Critical_Strike_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Parry_Flurry_1 : AuroraAnimation
    {
        public override int id { get { return 154; } }
        public override string name { get { return "f3p2a"; } }
        public override string description { get { return "2HS_Parry_Flurry_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Parry_Power_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 155; } }
        public override string name { get { return "f3p3a"; } }
        public override string description { get { return "2HS_Parry_Power_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Damage_Critical_Strike_1 : AuroraAnimation
    {
        public override int id { get { return 156; } }
        public override string name { get { return "f3d1a"; } }
        public override string description { get { return "2HS_Damage_Critical_Strike_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Damage_Flurry_1 : AuroraAnimation
    {
        public override int id { get { return 157; } }
        public override string name { get { return "f3d2a"; } }
        public override string description { get { return "2HS_Damage_Flurry_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Damage_Power_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 158; } }
        public override string name { get { return "f3d3a"; } }
        public override string description { get { return "2HS_Damage_Power_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Perform_Generic_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 159; } }
        public override string name { get { return "g3a1"; } }
        public override string description { get { return "2HS_Perform_Generic_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Perform_Generic_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 160; } }
        public override string name { get { return "g3a2"; } }
        public override string description { get { return "2HS_Perform_Generic_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Damage_Generic_Attack : AuroraAnimation
    {
        public override int id { get { return 161; } }
        public override string name { get { return "g3d1"; } }
        public override string description { get { return "2HS_Damage_Generic_Attack"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Attack_Monster_1 : AuroraAnimation
    {
        public override int id { get { return 162; } }
        public override string name { get { return "m3a1"; } }
        public override string description { get { return "2HS_Attack_Monster_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Attack_Monster_2 : AuroraAnimation
    {
        public override int id { get { return 163; } }
        public override string name { get { return "m3a2"; } }
        public override string description { get { return "2HS_Attack_Monster_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Dodge_Monster_1 : AuroraAnimation
    {
        public override int id { get { return 164; } }
        public override string name { get { return "m3g1"; } }
        public override string description { get { return "2HS_Dodge_Monster_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Dodge_Monster_2 : AuroraAnimation
    {
        public override int id { get { return 165; } }
        public override string name { get { return "m3g2"; } }
        public override string description { get { return "2HS_Dodge_Monster_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Damage_Monster_1 : AuroraAnimation
    {
        public override int id { get { return 166; } }
        public override string name { get { return "m3d1"; } }
        public override string description { get { return "2HS_Damage_Monster_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Damage_Monster_2 : AuroraAnimation
    {
        public override int id { get { return 167; } }
        public override string name { get { return "m3d2"; } }
        public override string description { get { return "2HS_Damage_Monster_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Dodge_Generic_Attack : AuroraAnimation
    {
        public override int id { get { return 168; } }
        public override string name { get { return "g3g1"; } }
        public override string description { get { return "2HS_Dodge_Generic_Attack"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Wield_Idle_To_Melee : AuroraAnimation
    {
        public override int id { get { return 169; } }
        public override string name { get { return "g3w1"; } }
        public override string description { get { return "2HS_Wield_Idle_To_Melee"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Melee_Idle : AuroraAnimation
    {
        public override int id { get { return 170; } }
        public override string name { get { return "g3r1"; } }
        public override string description { get { return "2HS_Melee_Idle"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Melee_Fidget : AuroraAnimation
    {
        public override int id { get { return 171; } }
        public override string name { get { return "g3r2"; } }
        public override string description { get { return "2HS_Melee_Fidget"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Dual_Saber_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 172; } }
        public override string name { get { return "c4a1"; } }
        public override string description { get { return "DS_(Dual_Saber)_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 173; } }
        public override string name { get { return "c4a2"; } }
        public override string description { get { return "DS_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 174; } }
        public override string name { get { return "c4a3"; } }
        public override string description { get { return "DS_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Attack_With_Parry : AuroraAnimation
    {
        public override int id { get { return 175; } }
        public override string name { get { return "c4a4"; } }
        public override string description { get { return "DS_Attack_With_Parry"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Attack_4 : AuroraAnimation
    {
        public override int id { get { return 176; } }
        public override string name { get { return "c4a5"; } }
        public override string description { get { return "DS_Attack_4"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Defend_1 : AuroraAnimation
    {
        public override int id { get { return 177; } }
        public override string name { get { return "c4p1"; } }
        public override string description { get { return "DS_Defend_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Dodge_And_Defend : AuroraAnimation
    {
        public override int id { get { return 178; } }
        public override string name { get { return "c4p2"; } }
        public override string description { get { return "DS_Dodge_And_Defend"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Defend_2 : AuroraAnimation
    {
        public override int id { get { return 179; } }
        public override string name { get { return "c4p3"; } }
        public override string description { get { return "DS_Defend_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Defend_3 : AuroraAnimation
    {
        public override int id { get { return 180; } }
        public override string name { get { return "c4p4"; } }
        public override string description { get { return "DS_Defend_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Defend_And_Dodge : AuroraAnimation
    {
        public override int id { get { return 181; } }
        public override string name { get { return "c4p5"; } }
        public override string description { get { return "DS_Defend_And_Dodge"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Defend_And_Damage_1 : AuroraAnimation
    {
        public override int id { get { return 182; } }
        public override string name { get { return "c4d1"; } }
        public override string description { get { return "DS_Defend_And_Damage_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Dodge_And_Damage : AuroraAnimation
    {
        public override int id { get { return 183; } }
        public override string name { get { return "c4d2"; } }
        public override string description { get { return "DS_Dodge_And_Damage"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Defend_And_Damage_2 : AuroraAnimation
    {
        public override int id { get { return 184; } }
        public override string name { get { return "c4d3"; } }
        public override string description { get { return "DS_Defend_And_Damage_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Defend_And_Break : AuroraAnimation
    {
        public override int id { get { return 185; } }
        public override string name { get { return "c4d4"; } }
        public override string description { get { return "DS_Defend_And_Break"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Defend_And_Damage_3 : AuroraAnimation
    {
        public override int id { get { return 186; } }
        public override string name { get { return "c4d5"; } }
        public override string description { get { return "DS_Defend_And_Damage_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Deflection_1 : AuroraAnimation
    {
        public override int id { get { return 187; } }
        public override string name { get { return "c4n1"; } }
        public override string description { get { return "DS_Deflection_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Deflection_2 : AuroraAnimation
    {
        public override int id { get { return 188; } }
        public override string name { get { return "c4n2"; } }
        public override string description { get { return "DS_Deflection_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Perform_Critical_Strike_1 : AuroraAnimation
    {
        public override int id { get { return 189; } }
        public override string name { get { return "f4a1a"; } }
        public override string description { get { return "DS_Perform_Critical_Strike_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Perform_Flurry_1 : AuroraAnimation
    {
        public override int id { get { return 190; } }
        public override string name { get { return "f4a2a"; } }
        public override string description { get { return "DS_Perform_Flurry_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Perform_Power_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 191; } }
        public override string name { get { return "f4a3a"; } }
        public override string description { get { return "DS_Perform_Power_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Parry_Critical_Strike_1 : AuroraAnimation
    {
        public override int id { get { return 192; } }
        public override string name { get { return "f4p1a"; } }
        public override string description { get { return "DS_Parry_Critical_Strike_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Parry_Flurry_1 : AuroraAnimation
    {
        public override int id { get { return 193; } }
        public override string name { get { return "f4p2a"; } }
        public override string description { get { return "DS_Parry_Flurry_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Parry_Power_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 194; } }
        public override string name { get { return "f4p3a"; } }
        public override string description { get { return "DS_Parry_Power_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Damage_Critical_Strike_1 : AuroraAnimation
    {
        public override int id { get { return 195; } }
        public override string name { get { return "f4d1a"; } }
        public override string description { get { return "DS_Damage_Critical_Strike_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Damage_Flurry_1 : AuroraAnimation
    {
        public override int id { get { return 196; } }
        public override string name { get { return "f4d2a"; } }
        public override string description { get { return "DS_Damage_Flurry_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Damage_Power_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 197; } }
        public override string name { get { return "f4d3a"; } }
        public override string description { get { return "DS_Damage_Power_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Perform_Generic_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 198; } }
        public override string name { get { return "g4a1"; } }
        public override string description { get { return "DS_Perform_Generic_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Perform_Generic_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 199; } }
        public override string name { get { return "g4a2"; } }
        public override string description { get { return "DS_Perform_Generic_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Damage_Generic_Attack : AuroraAnimation
    {
        public override int id { get { return 200; } }
        public override string name { get { return "g4d1"; } }
        public override string description { get { return "DS_Damage_Generic_Attack"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Attack_Monster_1 : AuroraAnimation
    {
        public override int id { get { return 201; } }
        public override string name { get { return "m4a1"; } }
        public override string description { get { return "DS_Attack_Monster_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Attack_Monster_2 : AuroraAnimation
    {
        public override int id { get { return 202; } }
        public override string name { get { return "m4a2"; } }
        public override string description { get { return "DS_Attack_Monster_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Dodge_Monster_1 : AuroraAnimation
    {
        public override int id { get { return 203; } }
        public override string name { get { return "m4g1"; } }
        public override string description { get { return "DS_Dodge_Monster_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Dodge_Monster_2 : AuroraAnimation
    {
        public override int id { get { return 204; } }
        public override string name { get { return "m4g2"; } }
        public override string description { get { return "DS_Dodge_Monster_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Damage_Monster_1 : AuroraAnimation
    {
        public override int id { get { return 205; } }
        public override string name { get { return "m4d1"; } }
        public override string description { get { return "DS_Damage_Monster_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Damage_Monster_2 : AuroraAnimation
    {
        public override int id { get { return 206; } }
        public override string name { get { return "m4d2"; } }
        public override string description { get { return "DS_Damage_Monster_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Dodge_Generic_Attack : AuroraAnimation
    {
        public override int id { get { return 207; } }
        public override string name { get { return "g4g1"; } }
        public override string description { get { return "DS_Dodge_Generic_Attack"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Wield_Idle_To_Melee : AuroraAnimation
    {
        public override int id { get { return 208; } }
        public override string name { get { return "g4w1"; } }
        public override string description { get { return "DS_Wield_Idle_To_Melee"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Melee_Idle : AuroraAnimation
    {
        public override int id { get { return 209; } }
        public override string name { get { return "g4r1"; } }
        public override string description { get { return "DS_Melee_Idle"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Melee_Fidget : AuroraAnimation
    {
        public override int id { get { return 210; } }
        public override string name { get { return "g4r2"; } }
        public override string description { get { return "DS_Melee_Fidget"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Single_Blaster_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 211; } }
        public override string name { get { return "b5a1"; } }
        public override string description { get { return "SB_(Single_Blaster)_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Attack_2_02 : AuroraAnimation
    {
        public override int id { get { return 212; } }
        public override string name { get { return "b5a2"; } }
        public override string description { get { return "SB_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Sniper_Shot_Attack : AuroraAnimation
    {
        public override int id { get { return 213; } }
        public override string name { get { return "b5a3"; } }
        public override string description { get { return "SB_Sniper_Shot_Attack"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Damage : AuroraAnimation
    {
        public override int id { get { return 214; } }
        public override string name { get { return "g5d1"; } }
        public override string description { get { return "SB_Damage"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Dodge_02 : AuroraAnimation
    {
        public override int id { get { return 215; } }
        public override string name { get { return "g5g1"; } }
        public override string description { get { return "SB_Dodge"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Wield_Idle_To_Melee_02 : AuroraAnimation
    {
        public override int id { get { return 216; } }
        public override string name { get { return "g5w1"; } }
        public override string description { get { return "SB_Wield_Idle_To_Melee"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Melee_Idle_02 : AuroraAnimation
    {
        public override int id { get { return 217; } }
        public override string name { get { return "g5r1"; } }
        public override string description { get { return "SB_Melee_Idle"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Melee_Fidget_02 : AuroraAnimation
    {
        public override int id { get { return 218; } }
        public override string name { get { return "g5r2"; } }
        public override string description { get { return "SB_Melee_Fidget"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Attack_and_Dodge : AuroraAnimation
    {
        public override int id { get { return 219; } }
        public override string name { get { return "f5p1"; } }
        public override string description { get { return "SB_Attack_and_Dodge"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Dodge_1 : AuroraAnimation
    {
        public override int id { get { return 220; } }
        public override string name { get { return "f5p2"; } }
        public override string description { get { return "SB_Dodge_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Dodge_2 : AuroraAnimation
    {
        public override int id { get { return 221; } }
        public override string name { get { return "f5p3"; } }
        public override string description { get { return "SB_Dodge_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Defend_1 : AuroraAnimation
    {
        public override int id { get { return 222; } }
        public override string name { get { return "f5d1"; } }
        public override string description { get { return "SB_Defend_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Defend_2 : AuroraAnimation
    {
        public override int id { get { return 223; } }
        public override string name { get { return "f5d2"; } }
        public override string description { get { return "SB_Defend_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Defend_3 : AuroraAnimation
    {
        public override int id { get { return 224; } }
        public override string name { get { return "f5d3"; } }
        public override string description { get { return "SB_Defend_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DB_Dual_Blasters_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 225; } }
        public override string name { get { return "b6a1"; } }
        public override string description { get { return "DB_(Dual_Blasters)_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DB_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 226; } }
        public override string name { get { return "b6a2"; } }
        public override string description { get { return "DB_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DB_Sniper_Shot_Attack : AuroraAnimation
    {
        public override int id { get { return 227; } }
        public override string name { get { return "b6a3"; } }
        public override string description { get { return "DB_Sniper_Shot_Attack"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DB_Damage : AuroraAnimation
    {
        public override int id { get { return 228; } }
        public override string name { get { return "g6d1"; } }
        public override string description { get { return "DB_Damage"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DB_Dodge : AuroraAnimation
    {
        public override int id { get { return 229; } }
        public override string name { get { return "g6g1"; } }
        public override string description { get { return "DB_Dodge"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DB_Wield_Idle_To_Melee : AuroraAnimation
    {
        public override int id { get { return 230; } }
        public override string name { get { return "g6w1"; } }
        public override string description { get { return "DB_Wield_Idle_To_Melee"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DB_Melee_Idle : AuroraAnimation
    {
        public override int id { get { return 231; } }
        public override string name { get { return "g6r1"; } }
        public override string description { get { return "DB_Melee_Idle"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_RF_Rifle_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 232; } }
        public override string name { get { return "b7a1"; } }
        public override string description { get { return "RF_(Rifle)_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_RF_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 233; } }
        public override string name { get { return "b7a2"; } }
        public override string description { get { return "RF_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_RF_Sniper_Shot_Attack : AuroraAnimation
    {
        public override int id { get { return 234; } }
        public override string name { get { return "b7a3"; } }
        public override string description { get { return "RF_Sniper_Shot_Attack"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_RF_Damage : AuroraAnimation
    {
        public override int id { get { return 235; } }
        public override string name { get { return "g7d1"; } }
        public override string description { get { return "RF_Damage"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_RF_Dodge : AuroraAnimation
    {
        public override int id { get { return 236; } }
        public override string name { get { return "g7g1"; } }
        public override string description { get { return "RF_Dodge"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_RF_Wield_Idle_To_Melee : AuroraAnimation
    {
        public override int id { get { return 237; } }
        public override string name { get { return "g7w1"; } }
        public override string description { get { return "RF_Wield_Idle_To_Melee"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_RF_Melee_Idle : AuroraAnimation
    {
        public override int id { get { return 238; } }
        public override string name { get { return "g7r1"; } }
        public override string description { get { return "RF_Melee_Idle"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_NT_Natural_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 239; } }
        public override string name { get { return "g8a1"; } }
        public override string description { get { return "NT_(Natural)_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_NT_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 240; } }
        public override string name { get { return "g8a2"; } }
        public override string description { get { return "NT_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_NT_Melee_Idle : AuroraAnimation
    {
        public override int id { get { return 241; } }
        public override string name { get { return "g8r1"; } }
        public override string description { get { return "NT_Melee_Idle"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_NT_Damage : AuroraAnimation
    {
        public override int id { get { return 242; } }
        public override string name { get { return "g8d1"; } }
        public override string description { get { return "NT_Damage"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_NT_Dodge : AuroraAnimation
    {
        public override int id { get { return 243; } }
        public override string name { get { return "g8g1"; } }
        public override string description { get { return "NT_Dodge"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Walk_Monster : AuroraAnimation
    {
        public override int id { get { return 244; } }
        public override string name { get { return "cwalk"; } }
        public override string description { get { return "Walk_Monster"; } }
        public override bool stationary { get { return false; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return true; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Walk_Injured_Monster : AuroraAnimation
    {
        public override int id { get { return 245; } }
        public override string name { get { return "cwalkinj"; } }
        public override string description { get { return "Walk_Injured_Monster"; } }
        public override bool stationary { get { return false; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return true; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Run_Monster : AuroraAnimation
    {
        public override int id { get { return 246; } }
        public override string name { get { return "crun"; } }
        public override string description { get { return "Run_Monster"; } }
        public override bool stationary { get { return false; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return true; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Idle_Monster_1 : AuroraAnimation
    {
        public override int id { get { return 247; } }
        public override string name { get { return "cpause1"; } }
        public override string description { get { return "Idle_Monster_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Idle_Monster_2 : AuroraAnimation
    {
        public override int id { get { return 248; } }
        public override string name { get { return "cpause2"; } }
        public override string description { get { return "Idle_Monster_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Head_Turn_Left_Monster : AuroraAnimation
    {
        public override int id { get { return 249; } }
        public override string name { get { return "chturnl"; } }
        public override string description { get { return "Head_Turn_Left_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Head_Turn_Right_Monster : AuroraAnimation
    {
        public override int id { get { return 250; } }
        public override string name { get { return "chturnr"; } }
        public override string description { get { return "Head_Turn_Right_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Victory_Taunt_Monster : AuroraAnimation
    {
        public override int id { get { return 251; } }
        public override string name { get { return "cvictory"; } }
        public override string description { get { return "Victory_Taunt_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Talk_Monster : AuroraAnimation
    {
        public override int id { get { return 252; } }
        public override string name { get { return "tlknorm"; } }
        public override string description { get { return "Talk_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Talk_Mouth_Phenomes_Monster : AuroraAnimation
    {
        public override int id { get { return 253; } }
        public override string name { get { return "talk"; } }
        public override string description { get { return "Talk_Mouth_Phenomes_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Taunt_Monster : AuroraAnimation
    {
        public override int id { get { return 254; } }
        public override string name { get { return "ctaunt"; } }
        public override string description { get { return "Taunt_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Choke_Monster : AuroraAnimation
    {
        public override int id { get { return 255; } }
        public override string name { get { return "choke"; } }
        public override string description { get { return "Choke_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Caught_In_Whirlwind_Monster : AuroraAnimation
    {
        public override int id { get { return 256; } }
        public override string name { get { return "whirlwind"; } }
        public override string description { get { return "Caught_In_Whirlwind_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Sleep_Monster : AuroraAnimation
    {
        public override int id { get { return 257; } }
        public override string name { get { return "sleep"; } }
        public override string description { get { return "Sleep_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Spasm_Monster : AuroraAnimation
    {
        public override int id { get { return 258; } }
        public override string name { get { return "cspasm"; } }
        public override string description { get { return "Spasm_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Paralyzed_Monster : AuroraAnimation
    {
        public override int id { get { return 259; } }
        public override string name { get { return "paralyzed"; } }
        public override string description { get { return "Paralyzed_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Disabled_Droid : AuroraAnimation
    {
        public override int id { get { return 260; } }
        public override string name { get { return "disabled"; } }
        public override string description { get { return "Disabled_Droid"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Knock_Back_Loop_Monster : AuroraAnimation
    {
        public override int id { get { return 261; } }
        public override string name { get { return "ckdbcklp"; } }
        public override string description { get { return "Knock_Back_Loop_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Knock_Back_Monster : AuroraAnimation
    {
        public override int id { get { return 262; } }
        public override string name { get { return "ckdbck"; } }
        public override string description { get { return "Knock_Back_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Stand_From_Prone_Monster : AuroraAnimation
    {
        public override int id { get { return 263; } }
        public override string name { get { return "cgustandb"; } }
        public override string description { get { return "Stand_From_Prone_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Death_Monster : AuroraAnimation
    {
        public override int id { get { return 264; } }
        public override string name { get { return "cdie"; } }
        public override string description { get { return "Death_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Dead_Loop_Monster : AuroraAnimation
    {
        public override int id { get { return 265; } }
        public override string name { get { return "cdead"; } }
        public override string description { get { return "Dead_Loop_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Generic_Attack_Monster_1 : AuroraAnimation
    {
        public override int id { get { return 266; } }
        public override string name { get { return "g0a1"; } }
        public override string description { get { return "Generic_Attack_Monster_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Generic_Attack_Monster_2 : AuroraAnimation
    {
        public override int id { get { return 267; } }
        public override string name { get { return "g0a2"; } }
        public override string description { get { return "Generic_Attack_Monster_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Melee_Idle_Monster : AuroraAnimation
    {
        public override int id { get { return 268; } }
        public override string name { get { return "creadyr"; } }
        public override string description { get { return "Melee_Idle_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Melee_Fidget_Monster : AuroraAnimation
    {
        public override int id { get { return 269; } }
        public override string name { get { return "creadyrtw"; } }
        public override string description { get { return "Melee_Fidget_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Damage_Monster : AuroraAnimation
    {
        public override int id { get { return 270; } }
        public override string name { get { return "cdamages"; } }
        public override string description { get { return "Damage_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Dodge_Monster : AuroraAnimation
    {
        public override int id { get { return 271; } }
        public override string name { get { return "cdodgeg"; } }
        public override string description { get { return "Dodge_Monster"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return true; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Attack_Monster_1 : AuroraAnimation
    {
        public override int id { get { return 272; } }
        public override string name { get { return "m0a1"; } }
        public override string description { get { return "Attack_Monster_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Attack_Monster_2 : AuroraAnimation
    {
        public override int id { get { return 273; } }
        public override string name { get { return "m0a2"; } }
        public override string description { get { return "Attack_Monster_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Dodge_Monster_1 : AuroraAnimation
    {
        public override int id { get { return 274; } }
        public override string name { get { return "m0p1"; } }
        public override string description { get { return "Dodge_Monster_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Dodge_Monster_2 : AuroraAnimation
    {
        public override int id { get { return 275; } }
        public override string name { get { return "m0p2"; } }
        public override string description { get { return "Dodge_Monster_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Damage_Monster_1 : AuroraAnimation
    {
        public override int id { get { return 276; } }
        public override string name { get { return "m0d1"; } }
        public override string description { get { return "Damage_Monster_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Damage_Monster_2 : AuroraAnimation
    {
        public override int id { get { return 277; } }
        public override string name { get { return "m0d2"; } }
        public override string description { get { return "Damage_Monster_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Blaster_Attack_Droid_1 : AuroraAnimation
    {
        public override int id { get { return 278; } }
        public override string name { get { return "b0a1"; } }
        public override string description { get { return "Blaster_Attack_Droid_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Blaster_Attack_Droid_2 : AuroraAnimation
    {
        public override int id { get { return 279; } }
        public override string name { get { return "b0a2"; } }
        public override string description { get { return "Blaster_Attack_Droid_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Turn_Left : AuroraAnimation
    {
        public override int id { get { return 280; } }
        public override string name { get { return "turnleft"; } }
        public override string description { get { return "Turn_Left"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Turn_Right : AuroraAnimation
    {
        public override int id { get { return 281; } }
        public override string name { get { return "turnright"; } }
        public override string description { get { return "Turn_Right"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_turnforward : AuroraAnimation
    {
        public override int id { get { return 282; } }
        public override string name { get { return "turnforward"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_castout1 : AuroraAnimation
    {
        public override int id { get { return 283; } }
        public override string name { get { return "castout1"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_castout2 : AuroraAnimation
    {
        public override int id { get { return 284; } }
        public override string name { get { return "castout2"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_castout3 : AuroraAnimation
    {
        public override int id { get { return 285; } }
        public override string name { get { return "castout3"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_powerup : AuroraAnimation
    {
        public override int id { get { return 286; } }
        public override string name { get { return "powerup"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_powered : AuroraAnimation
    {
        public override int id { get { return 287; } }
        public override string name { get { return "powered"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_powerdown : AuroraAnimation
    {
        public override int id { get { return 288; } }
        public override string name { get { return "powerdown"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_disabled : AuroraAnimation
    {
        public override int id { get { return 289; } }
        public override string name { get { return "disabled"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_attack : AuroraAnimation
    {
        public override int id { get { return 290; } }
        public override string name { get { return "attack"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_parry : AuroraAnimation
    {
        public override int id { get { return 291; } }
        public override string name { get { return "parry"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_dodge : AuroraAnimation
    {
        public override int id { get { return 292; } }
        public override string name { get { return "dodge"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return true; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_damage : AuroraAnimation
    {
        public override int id { get { return 293; } }
        public override string name { get { return "damage"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_default : AuroraAnimation
    {
        public override int id { get { return 294; } }
        public override string name { get { return "default"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_damage_02 : AuroraAnimation
    {
        public override int id { get { return 295; } }
        public override string name { get { return "damage"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_die : AuroraAnimation
    {
        public override int id { get { return 296; } }
        public override string name { get { return "die"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_dead : AuroraAnimation
    {
        public override int id { get { return 297; } }
        public override string name { get { return "dead"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_on : AuroraAnimation
    {
        public override int id { get { return 298; } }
        public override string name { get { return "on"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_off : AuroraAnimation
    {
        public override int id { get { return 299; } }
        public override string name { get { return "off"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_open : AuroraAnimation
    {
        public override int id { get { return 300; } }
        public override string name { get { return "open"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_close : AuroraAnimation
    {
        public override int id { get { return 301; } }
        public override string name { get { return "close"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_close2open : AuroraAnimation
    {
        public override int id { get { return 302; } }
        public override string name { get { return "close2open"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_open2close : AuroraAnimation
    {
        public override int id { get { return 303; } }
        public override string name { get { return "open2close"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_on2off : AuroraAnimation
    {
        public override int id { get { return 304; } }
        public override string name { get { return "on2off"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_off2on : AuroraAnimation
    {
        public override int id { get { return 305; } }
        public override string name { get { return "off2on"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_animloop01 : AuroraAnimation
    {
        public override int id { get { return 306; } }
        public override string name { get { return "animloop01"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_animloop02 : AuroraAnimation
    {
        public override int id { get { return 307; } }
        public override string name { get { return "animloop02"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_animloop03 : AuroraAnimation
    {
        public override int id { get { return 308; } }
        public override string name { get { return "animloop03"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_animloop04 : AuroraAnimation
    {
        public override int id { get { return 309; } }
        public override string name { get { return "animloop04"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_animloop05 : AuroraAnimation
    {
        public override int id { get { return 310; } }
        public override string name { get { return "animloop05"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_animloop06 : AuroraAnimation
    {
        public override int id { get { return 311; } }
        public override string name { get { return "animloop06"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_animloop07 : AuroraAnimation
    {
        public override int id { get { return 312; } }
        public override string name { get { return "animloop07"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_animloop08 : AuroraAnimation
    {
        public override int id { get { return 313; } }
        public override string name { get { return "animloop08"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_animloop09 : AuroraAnimation
    {
        public override int id { get { return 314; } }
        public override string name { get { return "animloop09"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_animloop10 : AuroraAnimation
    {
        public override int id { get { return 315; } }
        public override string name { get { return "animloop10"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_pause : AuroraAnimation
    {
        public override int id { get { return 316; } }
        public override string name { get { return "pause"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_default_02 : AuroraAnimation
    {
        public override int id { get { return 317; } }
        public override string name { get { return "default"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_damage_03 : AuroraAnimation
    {
        public override int id { get { return 318; } }
        public override string name { get { return "damage"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_die_02 : AuroraAnimation
    {
        public override int id { get { return 319; } }
        public override string name { get { return "die"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_dead_02 : AuroraAnimation
    {
        public override int id { get { return 320; } }
        public override string name { get { return "dead"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_opened1 : AuroraAnimation
    {
        public override int id { get { return 321; } }
        public override string name { get { return "opened1"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_opened2 : AuroraAnimation
    {
        public override int id { get { return 322; } }
        public override string name { get { return "opened2"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_closed : AuroraAnimation
    {
        public override int id { get { return 323; } }
        public override string name { get { return "closed"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_opening1 : AuroraAnimation
    {
        public override int id { get { return 324; } }
        public override string name { get { return "opening1"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_opening2 : AuroraAnimation
    {
        public override int id { get { return 325; } }
        public override string name { get { return "opening2"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_closing1 : AuroraAnimation
    {
        public override int id { get { return 326; } }
        public override string name { get { return "closing1"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_closing2 : AuroraAnimation
    {
        public override int id { get { return 327; } }
        public override string name { get { return "closing2"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Walk_Single_Saber : AuroraAnimation
    {
        public override int id { get { return 328; } }
        public override string name { get { return "walkSS"; } }
        public override string description { get { return "Walk_Single_Saber"; } }
        public override bool stationary { get { return false; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return true; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Walk_Dual_Saber : AuroraAnimation
    {
        public override int id { get { return 329; } }
        public override string name { get { return "walkDS"; } }
        public override string description { get { return "Walk_Dual_Saber"; } }
        public override bool stationary { get { return false; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return true; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Walk_Rifle : AuroraAnimation
    {
        public override int id { get { return 330; } }
        public override string name { get { return "walkRF"; } }
        public override string description { get { return "Walk_Rifle"; } }
        public override bool stationary { get { return false; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return true; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Walk_Stun_Baton : AuroraAnimation
    {
        public override int id { get { return 331; } }
        public override string name { get { return "walkST"; } }
        public override string description { get { return "Walk_Stun_Baton"; } }
        public override bool stationary { get { return false; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return true; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Run_Rifle : AuroraAnimation
    {
        public override int id { get { return 332; } }
        public override string name { get { return "runRF"; } }
        public override string description { get { return "Run_Rifle"; } }
        public override bool stationary { get { return false; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return true; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Run_Stun_Baton : AuroraAnimation
    {
        public override int id { get { return 333; } }
        public override string name { get { return "runST"; } }
        public override string description { get { return "Run_Stun_Baton"; } }
        public override bool stationary { get { return false; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return true; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_trans : AuroraAnimation
    {
        public override int id { get { return 334; } }
        public override string name { get { return "trans"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Run_Single_Saber : AuroraAnimation
    {
        public override int id { get { return 335; } }
        public override string name { get { return "runSS"; } }
        public override string description { get { return "Run_Single_Saber"; } }
        public override bool stationary { get { return false; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return true; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_usecomp : AuroraAnimation
    {
        public override int id { get { return 336; } }
        public override string name { get { return "usecomp"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_default_03 : AuroraAnimation
    {
        public override int id { get { return 337; } }
        public override string name { get { return "default"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_activate : AuroraAnimation
    {
        public override int id { get { return 338; } }
        public override string name { get { return "activate"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_deactivate : AuroraAnimation
    {
        public override int id { get { return 339; } }
        public override string name { get { return "deactivate"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_detect : AuroraAnimation
    {
        public override int id { get { return 340; } }
        public override string name { get { return "detect"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Blaster_Sniper_Shot_Attack_Droid : AuroraAnimation
    {
        public override int id { get { return 341; } }
        public override string name { get { return "b0a3"; } }
        public override string description { get { return "Blaster_Sniper_Shot_Attack_Droid"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_HC_Heavy_Carbine_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 342; } }
        public override string name { get { return "b9a1"; } }
        public override string description { get { return "HC_(Heavy_Carbine)_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_HC_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 343; } }
        public override string name { get { return "b9a2"; } }
        public override string description { get { return "HC_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_HC_Sniper_Shot_Attack : AuroraAnimation
    {
        public override int id { get { return 344; } }
        public override string name { get { return "b9a3"; } }
        public override string description { get { return "HC_Sniper_Shot_Attack"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_fblock : AuroraAnimation
    {
        public override int id { get { return 345; } }
        public override string name { get { return "fblock"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return true; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_off_02 : AuroraAnimation
    {
        public override int id { get { return 346; } }
        public override string name { get { return "off"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_pause2 : AuroraAnimation
    {
        public override int id { get { return 347; } }
        public override string name { get { return "pause2"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_cpause2 : AuroraAnimation
    {
        public override int id { get { return 348; } }
        public override string name { get { return "cpause2"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_pause3 : AuroraAnimation
    {
        public override int id { get { return 349; } }
        public override string name { get { return "pause3"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_weld : AuroraAnimation
    {
        public override int id { get { return 350; } }
        public override string name { get { return "weld"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Blaster_Power_Blast_Attack_Droid : AuroraAnimation
    {
        public override int id { get { return 351; } }
        public override string name { get { return "b0a4"; } }
        public override string description { get { return "Blaster_Power_Blast_Attack_Droid"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Power_Blast_Attack : AuroraAnimation
    {
        public override int id { get { return 352; } }
        public override string name { get { return "b5a4"; } }
        public override string description { get { return "SB_Power_Blast_Attack"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DB_Power_Blast_Attack : AuroraAnimation
    {
        public override int id { get { return 353; } }
        public override string name { get { return "b6a4"; } }
        public override string description { get { return "DB_Power_Blast_Attack"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_RF_Power_Blast_Attack : AuroraAnimation
    {
        public override int id { get { return 354; } }
        public override string name { get { return "b7a4"; } }
        public override string description { get { return "RF_Power_Blast_Attack"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_HC_Power_Blast_Attack : AuroraAnimation
    {
        public override int id { get { return 355; } }
        public override string name { get { return "b9a4"; } }
        public override string description { get { return "HC_Power_Blast_Attack"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_busted : AuroraAnimation
    {
        public override int id { get { return 356; } }
        public override string name { get { return "busted"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_turnleft : AuroraAnimation
    {
        public override int id { get { return 357; } }
        public override string name { get { return "turnleft"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_turnright : AuroraAnimation
    {
        public override int id { get { return 358; } }
        public override string name { get { return "turnright"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_weld_02 : AuroraAnimation
    {
        public override int id { get { return 359; } }
        public override string name { get { return "weld"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_talkinj : AuroraAnimation
    {
        public override int id { get { return 360; } }
        public override string name { get { return "talkinj"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Idle_Listen_Injured : AuroraAnimation
    {
        public override int id { get { return 361; } }
        public override string name { get { return "listeninj"; } }
        public override string description { get { return "Idle_Listen_Injured"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_talkinj_02 : AuroraAnimation
    {
        public override int id { get { return 362; } }
        public override string name { get { return "talkinj"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_equip : AuroraAnimation
    {
        public override int id { get { return 363; } }
        public override string name { get { return "equip"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_die3 : AuroraAnimation
    {
        public override int id { get { return 364; } }
        public override string name { get { return "die3"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_dead3 : AuroraAnimation
    {
        public override int id { get { return 365; } }
        public override string name { get { return "dead3"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Wield_Melee_To_Melee : AuroraAnimation
    {
        public override int id { get { return 366; } }
        public override string name { get { return "G4F1"; } }
        public override string description { get { return "DS_Wield_Melee_To_Melee"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return true; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Wield_Melee_To_Melee : AuroraAnimation
    {
        public override int id { get { return 367; } }
        public override string name { get { return "G2F1"; } }
        public override string description { get { return "SS_Wield_Melee_To_Melee"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return true; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Wield_Melee_To_Melee : AuroraAnimation
    {
        public override int id { get { return 368; } }
        public override string name { get { return "G3F1"; } }
        public override string description { get { return "2HS_Wield_Melee_To_Melee"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return true; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_g0a1 : AuroraAnimation
    {
        public override int id { get { return 369; } }
        public override string name { get { return "g0a1"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_b0a1 : AuroraAnimation
    {
        public override int id { get { return 370; } }
        public override string name { get { return "b0a1"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Get_Up_From_Dead_1 : AuroraAnimation
    {
        public override int id { get { return 371; } }
        public override string name { get { return "getupdead"; } }
        public override string description { get { return "Get_Up_From_Dead_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Get_Up_From_Dead_2 : AuroraAnimation
    {
        public override int id { get { return 372; } }
        public override string name { get { return "getupdead1"; } }
        public override string description { get { return "Get_Up_From_Dead_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_kd : AuroraAnimation
    {
        public override int id { get { return 373; } }
        public override string name { get { return "kd"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_kdtlkangry : AuroraAnimation
    {
        public override int id { get { return 374; } }
        public override string name { get { return "kdtlkangry"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_kdtlksad : AuroraAnimation
    {
        public override int id { get { return 375; } }
        public override string name { get { return "kdtlksad"; } }
        public override string description { get { return ""; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Force_Jump : AuroraAnimation
    {
        public override int id { get { return 376; } }
        public override string name { get { return "f2a4"; } }
        public override string description { get { return "SS_Force_Jump"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Force_Jump : AuroraAnimation
    {
        public override int id { get { return 377; } }
        public override string name { get { return "f3a4"; } }
        public override string description { get { return "2HS_Force_Jump"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Force_Jump : AuroraAnimation
    {
        public override int id { get { return 378; } }
        public override string name { get { return "f4a4"; } }
        public override string description { get { return "DS_Force_Jump"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Burn_Door_With_Lightsaber : AuroraAnimation
    {
        public override int id { get { return 379; } }
        public override string name { get { return "c2a6"; } }
        public override string description { get { return "SS_Burn_Door_With_Lightsaber"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Burn_Door_With_Lightsaber : AuroraAnimation
    {
        public override int id { get { return 380; } }
        public override string name { get { return "c3a6"; } }
        public override string description { get { return "2HS_Burn_Door_With_Lightsaber"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Burn_Door_With_Lightsaber : AuroraAnimation
    {
        public override int id { get { return 381; } }
        public override string name { get { return "c4a6"; } }
        public override string description { get { return "DS_Burn_Door_With_Lightsaber"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Perform_Critical_Strike_2 : AuroraAnimation
    {
        public override int id { get { return 382; } }
        public override string name { get { return "f2a1b"; } }
        public override string description { get { return "SS_Perform_Critical_Strike_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Perform_Critical_Strike_3 : AuroraAnimation
    {
        public override int id { get { return 383; } }
        public override string name { get { return "f2a1c"; } }
        public override string description { get { return "SS_Perform_Critical_Strike_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Perform_Flurry_2 : AuroraAnimation
    {
        public override int id { get { return 384; } }
        public override string name { get { return "f2a2b"; } }
        public override string description { get { return "SS_Perform_Flurry_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Perform_Flurry_3 : AuroraAnimation
    {
        public override int id { get { return 385; } }
        public override string name { get { return "f2a2c"; } }
        public override string description { get { return "SS_Perform_Flurry_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Perform_Power_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 386; } }
        public override string name { get { return "f2a3b"; } }
        public override string description { get { return "SS_Perform_Power_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Perform_Power_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 387; } }
        public override string name { get { return "f2a3c"; } }
        public override string description { get { return "SS_Perform_Power_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Parry_Critical_Strike_2 : AuroraAnimation
    {
        public override int id { get { return 388; } }
        public override string name { get { return "f2p1b"; } }
        public override string description { get { return "SS_Parry_Critical_Strike_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Parry_Critical_Strike_3 : AuroraAnimation
    {
        public override int id { get { return 389; } }
        public override string name { get { return "f2p1c"; } }
        public override string description { get { return "SS_Parry_Critical_Strike_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Parry_Flurry_2 : AuroraAnimation
    {
        public override int id { get { return 390; } }
        public override string name { get { return "f2p2b"; } }
        public override string description { get { return "SS_Parry_Flurry_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Parry_Flurry_3 : AuroraAnimation
    {
        public override int id { get { return 391; } }
        public override string name { get { return "f2p2c"; } }
        public override string description { get { return "SS_Parry_Flurry_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Parry_Power_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 392; } }
        public override string name { get { return "f2p3b"; } }
        public override string description { get { return "SS_Parry_Power_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Parry_Power_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 393; } }
        public override string name { get { return "f2p3c"; } }
        public override string description { get { return "SS_Parry_Power_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Damage_Critical_Strike_2 : AuroraAnimation
    {
        public override int id { get { return 394; } }
        public override string name { get { return "f2d1b"; } }
        public override string description { get { return "SS_Damage_Critical_Strike_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Damage_Critical_Strike_3 : AuroraAnimation
    {
        public override int id { get { return 395; } }
        public override string name { get { return "f2d1c"; } }
        public override string description { get { return "SS_Damage_Critical_Strike_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Damage_Flurry_2 : AuroraAnimation
    {
        public override int id { get { return 396; } }
        public override string name { get { return "f2d2b"; } }
        public override string description { get { return "SS_Damage_Flurry_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Damage_Flurry_3 : AuroraAnimation
    {
        public override int id { get { return 397; } }
        public override string name { get { return "f2d2c"; } }
        public override string description { get { return "SS_Damage_Flurry_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Damage_Power_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 398; } }
        public override string name { get { return "f2d3b"; } }
        public override string description { get { return "SS_Damage_Power_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Damage_Power_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 399; } }
        public override string name { get { return "f2d3c"; } }
        public override string description { get { return "SS_Damage_Power_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Perform_Generic_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 400; } }
        public override string name { get { return "g2a3"; } }
        public override string description { get { return "SS_Perform_Generic_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Perform_Generic_Attack_4 : AuroraAnimation
    {
        public override int id { get { return 401; } }
        public override string name { get { return "g2a4"; } }
        public override string description { get { return "SS_Perform_Generic_Attack_4"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SS_Perform_Generic_Attack_5 : AuroraAnimation
    {
        public override int id { get { return 402; } }
        public override string name { get { return "g2a5"; } }
        public override string description { get { return "SS_Perform_Generic_Attack_5"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Perform_Critical_Strike_2 : AuroraAnimation
    {
        public override int id { get { return 403; } }
        public override string name { get { return "f3a1b"; } }
        public override string description { get { return "2HS_Perform_Critical_Strike_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Perform_Critical_Strike_3 : AuroraAnimation
    {
        public override int id { get { return 404; } }
        public override string name { get { return "f3a1c"; } }
        public override string description { get { return "2HS_Perform_Critical_Strike_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Perform_Flurry_2 : AuroraAnimation
    {
        public override int id { get { return 405; } }
        public override string name { get { return "f3a2b"; } }
        public override string description { get { return "2HS_Perform_Flurry_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Perform_Flurry_3 : AuroraAnimation
    {
        public override int id { get { return 406; } }
        public override string name { get { return "f3a2c"; } }
        public override string description { get { return "2HS_Perform_Flurry_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Perform_Power_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 407; } }
        public override string name { get { return "f3a3b"; } }
        public override string description { get { return "2HS_Perform_Power_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Perform_Power_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 408; } }
        public override string name { get { return "f3a3c"; } }
        public override string description { get { return "2HS_Perform_Power_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Parry_Critical_Strike_2 : AuroraAnimation
    {
        public override int id { get { return 409; } }
        public override string name { get { return "f3p1b"; } }
        public override string description { get { return "2HS_Parry_Critical_Strike_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Parry_Critical_Strike_3 : AuroraAnimation
    {
        public override int id { get { return 410; } }
        public override string name { get { return "f3p1c"; } }
        public override string description { get { return "2HS_Parry_Critical_Strike_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Parry_Flurry_2 : AuroraAnimation
    {
        public override int id { get { return 411; } }
        public override string name { get { return "f3p2b"; } }
        public override string description { get { return "2HS_Parry_Flurry_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Parry_Flurry_3 : AuroraAnimation
    {
        public override int id { get { return 412; } }
        public override string name { get { return "f3p2c"; } }
        public override string description { get { return "2HS_Parry_Flurry_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Parry_Power_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 413; } }
        public override string name { get { return "f3p3b"; } }
        public override string description { get { return "2HS_Parry_Power_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Parry_Power_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 414; } }
        public override string name { get { return "f3p3c"; } }
        public override string description { get { return "2HS_Parry_Power_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Damage_Critical_Strike_2 : AuroraAnimation
    {
        public override int id { get { return 415; } }
        public override string name { get { return "f3d1b"; } }
        public override string description { get { return "2HS_Damage_Critical_Strike_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Damage_Critical_Strike_3 : AuroraAnimation
    {
        public override int id { get { return 416; } }
        public override string name { get { return "f3d1c"; } }
        public override string description { get { return "2HS_Damage_Critical_Strike_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Damage_Flurry_2 : AuroraAnimation
    {
        public override int id { get { return 417; } }
        public override string name { get { return "f3d2b"; } }
        public override string description { get { return "2HS_Damage_Flurry_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Damage_Flurry_3 : AuroraAnimation
    {
        public override int id { get { return 418; } }
        public override string name { get { return "f3d2c"; } }
        public override string description { get { return "2HS_Damage_Flurry_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Damage_Power_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 419; } }
        public override string name { get { return "f3d3b"; } }
        public override string description { get { return "2HS_Damage_Power_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Damage_Power_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 420; } }
        public override string name { get { return "f3d3c"; } }
        public override string description { get { return "2HS_Damage_Power_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Perform_Generic_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 421; } }
        public override string name { get { return "g3a3"; } }
        public override string description { get { return "2HS_Perform_Generic_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Perform_Generic_Attack_4 : AuroraAnimation
    {
        public override int id { get { return 422; } }
        public override string name { get { return "g3a4"; } }
        public override string description { get { return "2HS_Perform_Generic_Attack_4"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_2HS_Perform_Generic_Attack_5 : AuroraAnimation
    {
        public override int id { get { return 423; } }
        public override string name { get { return "g3a5"; } }
        public override string description { get { return "2HS_Perform_Generic_Attack_5"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Perform_Critical_Strike_2 : AuroraAnimation
    {
        public override int id { get { return 424; } }
        public override string name { get { return "f4a1b"; } }
        public override string description { get { return "DS_Perform_Critical_Strike_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Perform_Critical_Strike_3 : AuroraAnimation
    {
        public override int id { get { return 425; } }
        public override string name { get { return "f4a1c"; } }
        public override string description { get { return "DS_Perform_Critical_Strike_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Perform_Flurry_2 : AuroraAnimation
    {
        public override int id { get { return 426; } }
        public override string name { get { return "f4a2b"; } }
        public override string description { get { return "DS_Perform_Flurry_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Perform_Flurry_3 : AuroraAnimation
    {
        public override int id { get { return 427; } }
        public override string name { get { return "f4a2c"; } }
        public override string description { get { return "DS_Perform_Flurry_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Perform_Power_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 428; } }
        public override string name { get { return "f4a3b"; } }
        public override string description { get { return "DS_Perform_Power_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Perform_Power_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 429; } }
        public override string name { get { return "f4a3c"; } }
        public override string description { get { return "DS_Perform_Power_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Parry_Critical_Strike_2 : AuroraAnimation
    {
        public override int id { get { return 430; } }
        public override string name { get { return "f4p1b"; } }
        public override string description { get { return "DS_Parry_Critical_Strike_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Parry_Critical_Strike_3 : AuroraAnimation
    {
        public override int id { get { return 431; } }
        public override string name { get { return "f4p1c"; } }
        public override string description { get { return "DS_Parry_Critical_Strike_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Parry_Flurry_2 : AuroraAnimation
    {
        public override int id { get { return 432; } }
        public override string name { get { return "f4p2b"; } }
        public override string description { get { return "DS_Parry_Flurry_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Parry_Flurry_3 : AuroraAnimation
    {
        public override int id { get { return 433; } }
        public override string name { get { return "f4p2c"; } }
        public override string description { get { return "DS_Parry_Flurry_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Parry_Power_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 434; } }
        public override string name { get { return "f4p3b"; } }
        public override string description { get { return "DS_Parry_Power_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Parry_Power_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 435; } }
        public override string name { get { return "f4p3c"; } }
        public override string description { get { return "DS_Parry_Power_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Damage_Critical_Strike_2 : AuroraAnimation
    {
        public override int id { get { return 436; } }
        public override string name { get { return "f4d1b"; } }
        public override string description { get { return "DS_Damage_Critical_Strike_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Damage_Critical_Strike_3 : AuroraAnimation
    {
        public override int id { get { return 437; } }
        public override string name { get { return "f4d1c"; } }
        public override string description { get { return "DS_Damage_Critical_Strike_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Damage_Flurry_2 : AuroraAnimation
    {
        public override int id { get { return 438; } }
        public override string name { get { return "f4d2b"; } }
        public override string description { get { return "DS_Damage_Flurry_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Damage_Flurry_3 : AuroraAnimation
    {
        public override int id { get { return 439; } }
        public override string name { get { return "f4d2c"; } }
        public override string description { get { return "DS_Damage_Flurry_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Damage_Power_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 440; } }
        public override string name { get { return "f4d3b"; } }
        public override string description { get { return "DS_Damage_Power_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Damage_Power_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 441; } }
        public override string name { get { return "f4d3c"; } }
        public override string description { get { return "DS_Damage_Power_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Perform_Generic_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 442; } }
        public override string name { get { return "g4a3"; } }
        public override string description { get { return "DS_Perform_Generic_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Perform_Generic_Attack_4 : AuroraAnimation
    {
        public override int id { get { return 443; } }
        public override string name { get { return "g4a4"; } }
        public override string description { get { return "DS_Perform_Generic_Attack_4"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DS_Perform_Generic_Attack_5 : AuroraAnimation
    {
        public override int id { get { return 444; } }
        public override string name { get { return "g4a5"; } }
        public override string description { get { return "DS_Perform_Generic_Attack_5"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Hand_Deflection : AuroraAnimation
    {
        public override int id { get { return 445; } }
        public override string name { get { return "deflect"; } }
        public override string description { get { return "Hand_Deflection"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Sit_To_Meditate : AuroraAnimation
    {
        public override int id { get { return 446; } }
        public override string name { get { return "sit"; } }
        public override string description { get { return "Sit_To_Meditate"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Meditate_Sitting_Loop : AuroraAnimation
    {
        public override int id { get { return 447; } }
        public override string name { get { return "meditatesit"; } }
        public override string description { get { return "Meditate_Sitting_Loop"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Meditate_Standing_Loop : AuroraAnimation
    {
        public override int id { get { return 448; } }
        public override string name { get { return "meditatestand"; } }
        public override string description { get { return "Meditate_Standing_Loop"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Perform_Force_Crush : AuroraAnimation
    {
        public override int id { get { return 449; } }
        public override string name { get { return "forcecrush"; } }
        public override string description { get { return "Perform_Force_Crush"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Damage_Force_Crush : AuroraAnimation
    {
        public override int id { get { return 450; } }
        public override string name { get { return "crushdamage"; } }
        public override string description { get { return "Damage_Force_Crush"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Perform_Force_Rage : AuroraAnimation
    {
        public override int id { get { return 451; } }
        public override string name { get { return "forcerage"; } }
        public override string description { get { return "Perform_Force_Rage"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Touch_Heart : AuroraAnimation
    {
        public override int id { get { return 452; } }
        public override string name { get { return "touchheart"; } }
        public override string description { get { return "Touch_Heart"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Roll_Eyes : AuroraAnimation
    {
        public override int id { get { return 453; } }
        public override string name { get { return "rolleyes"; } }
        public override string description { get { return "Roll_Eyes"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Use_Item_On_Other : AuroraAnimation
    {
        public override int id { get { return 454; } }
        public override string name { get { return "itemequip"; } }
        public override string description { get { return "Use_Item_On_Other"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Stand_At_Attention : AuroraAnimation
    {
        public override int id { get { return 455; } }
        public override string name { get { return "standstill"; } }
        public override string description { get { return "Stand_At_Attention"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Nod_Yes : AuroraAnimation
    {
        public override int id { get { return 456; } }
        public override string name { get { return "nodyes"; } }
        public override string description { get { return "Nod_Yes"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Nod_No : AuroraAnimation
    {
        public override int id { get { return 457; } }
        public override string name { get { return "nodno"; } }
        public override string description { get { return "Nod_No"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Raise_Arm_Point_Lower_Arm : AuroraAnimation
    {
        public override int id { get { return 458; } }
        public override string name { get { return "point"; } }
        public override string description { get { return "Raise_Arm_Point_Lower_Arm"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Point_Forward : AuroraAnimation
    {
        public override int id { get { return 459; } }
        public override string name { get { return "pointloop"; } }
        public override string description { get { return "Point_Forward"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Raise_Arm_Point_Down_Lower_Arm : AuroraAnimation
    {
        public override int id { get { return 460; } }
        public override string name { get { return "pointdown"; } }
        public override string description { get { return "Raise_Arm_Point_Down_Lower_Arm"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Scanning : AuroraAnimation
    {
        public override int id { get { return 461; } }
        public override string name { get { return "scanning"; } }
        public override string description { get { return "Scanning"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return true; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Shrug : AuroraAnimation
    {
        public override int id { get { return 462; } }
        public override string name { get { return "shrug"; } }
        public override string description { get { return "Shrug"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_SB_Single_Blaster_Wield_Melee_To_Melee : AuroraAnimation
    {
        public override int id { get { return 463; } }
        public override string name { get { return "g5f1"; } }
        public override string description { get { return "SB_(Single_Blaster)_Wield_Melee_To_Melee"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return true; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_DB_Dual_Blaster_Wield_Melee_To_Melee : AuroraAnimation
    {
        public override int id { get { return 464; } }
        public override string name { get { return "g6f1"; } }
        public override string description { get { return "DB_(Dual_Blaster)_Wield_Melee_To_Melee"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return true; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_RF_Rifle_Wield_Melee_To_Melee : AuroraAnimation
    {
        public override int id { get { return 465; } }
        public override string name { get { return "g7f1"; } }
        public override string description { get { return "RF_(Rifle)_Wield_Melee_To_Melee"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return true; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_HC_Heavy_Carbine_Wield_Melee_To_Melee : AuroraAnimation
    {
        public override int id { get { return 466; } }
        public override string name { get { return "g9f1"; } }
        public override string description { get { return "HC_(Heavy_Carbine)_Wield_Melee_To_Melee"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return true; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Unarmed_Complex_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 467; } }
        public override string name { get { return "c10a1"; } }
        public override string description { get { return "UC_(Unarmed_Complex)_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 468; } }
        public override string name { get { return "c10a2"; } }
        public override string description { get { return "UC_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 469; } }
        public override string name { get { return "c10a3"; } }
        public override string description { get { return "UC_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Attack_4 : AuroraAnimation
    {
        public override int id { get { return 470; } }
        public override string name { get { return "c10a4"; } }
        public override string description { get { return "UC_Attack_4"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Attack_5 : AuroraAnimation
    {
        public override int id { get { return 471; } }
        public override string name { get { return "c10a5"; } }
        public override string description { get { return "UC_Attack_5"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Defend_1 : AuroraAnimation
    {
        public override int id { get { return 472; } }
        public override string name { get { return "c10p1"; } }
        public override string description { get { return "UC_Defend_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Defend_2 : AuroraAnimation
    {
        public override int id { get { return 473; } }
        public override string name { get { return "c10p2"; } }
        public override string description { get { return "UC_Defend_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Defend_3 : AuroraAnimation
    {
        public override int id { get { return 474; } }
        public override string name { get { return "c10p3"; } }
        public override string description { get { return "UC_Defend_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Defend_4 : AuroraAnimation
    {
        public override int id { get { return 475; } }
        public override string name { get { return "c10p4"; } }
        public override string description { get { return "UC_Defend_4"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Defend_5 : AuroraAnimation
    {
        public override int id { get { return 476; } }
        public override string name { get { return "c10p5"; } }
        public override string description { get { return "UC_Defend_5"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Damage_1 : AuroraAnimation
    {
        public override int id { get { return 477; } }
        public override string name { get { return "c10d1"; } }
        public override string description { get { return "UC_Damage_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Damage_2 : AuroraAnimation
    {
        public override int id { get { return 478; } }
        public override string name { get { return "c10d2"; } }
        public override string description { get { return "UC_Damage_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Damage_3 : AuroraAnimation
    {
        public override int id { get { return 479; } }
        public override string name { get { return "c10d3"; } }
        public override string description { get { return "UC_Damage_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Damage_4 : AuroraAnimation
    {
        public override int id { get { return 480; } }
        public override string name { get { return "c10d4"; } }
        public override string description { get { return "UC_Damage_4"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Damage_5 : AuroraAnimation
    {
        public override int id { get { return 481; } }
        public override string name { get { return "c10d5"; } }
        public override string description { get { return "UC_Damage_5"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Deflection_1 : AuroraAnimation
    {
        public override int id { get { return 482; } }
        public override string name { get { return "c10n1"; } }
        public override string description { get { return "UC_Deflection_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Deflection_2 : AuroraAnimation
    {
        public override int id { get { return 483; } }
        public override string name { get { return "c10n2"; } }
        public override string description { get { return "UC_Deflection_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Perform_Critical_Strike_1 : AuroraAnimation
    {
        public override int id { get { return 484; } }
        public override string name { get { return "f10a1a"; } }
        public override string description { get { return "UC_Perform_Critical_Strike_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Perform_Critical_Strike_2 : AuroraAnimation
    {
        public override int id { get { return 485; } }
        public override string name { get { return "f10a1b"; } }
        public override string description { get { return "UC_Perform_Critical_Strike_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Perform_Critical_Strike_3 : AuroraAnimation
    {
        public override int id { get { return 486; } }
        public override string name { get { return "f10a1c"; } }
        public override string description { get { return "UC_Perform_Critical_Strike_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Perform_Flurry_1 : AuroraAnimation
    {
        public override int id { get { return 487; } }
        public override string name { get { return "f10a2a"; } }
        public override string description { get { return "UC_Perform_Flurry_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Perform_Flurry_2 : AuroraAnimation
    {
        public override int id { get { return 488; } }
        public override string name { get { return "f10a2b"; } }
        public override string description { get { return "UC_Perform_Flurry_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Perform_Flurry_3 : AuroraAnimation
    {
        public override int id { get { return 489; } }
        public override string name { get { return "f10a2c"; } }
        public override string description { get { return "UC_Perform_Flurry_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Perform_Power_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 490; } }
        public override string name { get { return "f10a3a"; } }
        public override string description { get { return "UC_Perform_Power_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Perform_Power_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 491; } }
        public override string name { get { return "f10a3b"; } }
        public override string description { get { return "UC_Perform_Power_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Perform_Power_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 492; } }
        public override string name { get { return "f10a3c"; } }
        public override string description { get { return "UC_Perform_Power_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Parry_Critical_Strike_1 : AuroraAnimation
    {
        public override int id { get { return 493; } }
        public override string name { get { return "f10p1a"; } }
        public override string description { get { return "UC_Parry_Critical_Strike_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Parry_Critical_Strike_2 : AuroraAnimation
    {
        public override int id { get { return 494; } }
        public override string name { get { return "f10p1b"; } }
        public override string description { get { return "UC_Parry_Critical_Strike_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Parry_Critical_Strike_3 : AuroraAnimation
    {
        public override int id { get { return 495; } }
        public override string name { get { return "f10p1c"; } }
        public override string description { get { return "UC_Parry_Critical_Strike_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Parry_Flurry_1 : AuroraAnimation
    {
        public override int id { get { return 496; } }
        public override string name { get { return "f10p2a"; } }
        public override string description { get { return "UC_Parry_Flurry_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Parry_Flurry_2 : AuroraAnimation
    {
        public override int id { get { return 497; } }
        public override string name { get { return "f10p2b"; } }
        public override string description { get { return "UC_Parry_Flurry_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Parry_Flurry_3 : AuroraAnimation
    {
        public override int id { get { return 498; } }
        public override string name { get { return "f10p2c"; } }
        public override string description { get { return "UC_Parry_Flurry_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Parry_Power_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 499; } }
        public override string name { get { return "f10p3a"; } }
        public override string description { get { return "UC_Parry_Power_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Parry_Power_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 500; } }
        public override string name { get { return "f10p3b"; } }
        public override string description { get { return "UC_Parry_Power_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Parry_Power_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 501; } }
        public override string name { get { return "f10p3c"; } }
        public override string description { get { return "UC_Parry_Power_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Damage_Critical_Strike_1 : AuroraAnimation
    {
        public override int id { get { return 502; } }
        public override string name { get { return "f10d1a"; } }
        public override string description { get { return "UC_Damage_Critical_Strike_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Damage_Critical_Strike_2 : AuroraAnimation
    {
        public override int id { get { return 503; } }
        public override string name { get { return "f10d1b"; } }
        public override string description { get { return "UC_Damage_Critical_Strike_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Damage_Critical_Strike_3 : AuroraAnimation
    {
        public override int id { get { return 504; } }
        public override string name { get { return "f10d1c"; } }
        public override string description { get { return "UC_Damage_Critical_Strike_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Damage_Flurry_1 : AuroraAnimation
    {
        public override int id { get { return 505; } }
        public override string name { get { return "f10d2a"; } }
        public override string description { get { return "UC_Damage_Flurry_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Damage_Flurry_2 : AuroraAnimation
    {
        public override int id { get { return 506; } }
        public override string name { get { return "f10d2b"; } }
        public override string description { get { return "UC_Damage_Flurry_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Damage_Flurry_3 : AuroraAnimation
    {
        public override int id { get { return 507; } }
        public override string name { get { return "f10d2c"; } }
        public override string description { get { return "UC_Damage_Flurry_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Damage_Power_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 508; } }
        public override string name { get { return "f10d3a"; } }
        public override string description { get { return "UC_Damage_Power_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Damage_Power_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 509; } }
        public override string name { get { return "f10d3b"; } }
        public override string description { get { return "UC_Damage_Power_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Damage_Power_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 510; } }
        public override string name { get { return "f10d3c"; } }
        public override string description { get { return "UC_Damage_Power_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Perform_Generic_Attack_1 : AuroraAnimation
    {
        public override int id { get { return 511; } }
        public override string name { get { return "g10a1"; } }
        public override string description { get { return "UC_Perform_Generic_Attack_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Perform_Generic_Attack_2 : AuroraAnimation
    {
        public override int id { get { return 512; } }
        public override string name { get { return "g10a2"; } }
        public override string description { get { return "UC_Perform_Generic_Attack_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Perform_Generic_Attack_3 : AuroraAnimation
    {
        public override int id { get { return 513; } }
        public override string name { get { return "g10a3"; } }
        public override string description { get { return "UC_Perform_Generic_Attack_3"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Perform_Generic_Attack_4 : AuroraAnimation
    {
        public override int id { get { return 514; } }
        public override string name { get { return "g10a4"; } }
        public override string description { get { return "UC_Perform_Generic_Attack_4"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Perform_Generic_Attack_5 : AuroraAnimation
    {
        public override int id { get { return 515; } }
        public override string name { get { return "g10a5"; } }
        public override string description { get { return "UC_Perform_Generic_Attack_5"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Damage_Generic_Attack : AuroraAnimation
    {
        public override int id { get { return 516; } }
        public override string name { get { return "g10d1"; } }
        public override string description { get { return "UC_Damage_Generic_Attack"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Attack_Monster_1 : AuroraAnimation
    {
        public override int id { get { return 517; } }
        public override string name { get { return "m10a1"; } }
        public override string description { get { return "UC_Attack_Monster_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Attack_Monster_2 : AuroraAnimation
    {
        public override int id { get { return 518; } }
        public override string name { get { return "m10a2"; } }
        public override string description { get { return "UC_Attack_Monster_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Dodge_Monster_1 : AuroraAnimation
    {
        public override int id { get { return 519; } }
        public override string name { get { return "m10g1"; } }
        public override string description { get { return "UC_Dodge_Monster_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Dodge_Monster_2 : AuroraAnimation
    {
        public override int id { get { return 520; } }
        public override string name { get { return "m10g2"; } }
        public override string description { get { return "UC_Dodge_Monster_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Damage_Monster_1 : AuroraAnimation
    {
        public override int id { get { return 521; } }
        public override string name { get { return "m10d1"; } }
        public override string description { get { return "UC_Damage_Monster_1"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Damage_Monster_2 : AuroraAnimation
    {
        public override int id { get { return 522; } }
        public override string name { get { return "m10d2"; } }
        public override string description { get { return "UC_Damage_Monster_2"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return true; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Dodge_Generic_Attack : AuroraAnimation
    {
        public override int id { get { return 523; } }
        public override string name { get { return "g10g1"; } }
        public override string description { get { return "UC_Dodge_Generic_Attack"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return true; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Wield_Idle_To_Melee : AuroraAnimation
    {
        public override int id { get { return 524; } }
        public override string name { get { return "g10w1"; } }
        public override string description { get { return "UC_Wield_Idle_To_Melee"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_UC_Melee_Idle : AuroraAnimation
    {
        public override int id { get { return 525; } }
        public override string name { get { return "g10r1"; } }
        public override string description { get { return "UC_Melee_Idle"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Wrist_Launch : AuroraAnimation
    {
        public override int id { get { return 526; } }
        public override string name { get { return "b11a3"; } }
        public override string description { get { return "Wrist_Launch"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Droid_Utility_Conjure : AuroraAnimation
    {
        public override int id { get { return 527; } }
        public override string name { get { return "castout1"; } }
        public override string description { get { return "Droid_Utility_Conjure"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Droid_Utility_Cast : AuroraAnimation
    {
        public override int id { get { return 528; } }
        public override string name { get { return "castoutlp1"; } }
        public override string description { get { return "Droid_Utility_Cast"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Makashi_Form_Ready_1H : AuroraAnimation
    {
        public override int id { get { return 529; } }
        public override string name { get { return "g2r2"; } }
        public override string description { get { return "Makashi_Form_Ready_1H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Makashi_Form_Ready_2H : AuroraAnimation
    {
        public override int id { get { return 530; } }
        public override string name { get { return "g2r2"; } }
        public override string description { get { return "Makashi_Form_Ready_2H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Makashi_Form_Ready_1H_1H : AuroraAnimation
    {
        public override int id { get { return 531; } }
        public override string name { get { return "g2r2"; } }
        public override string description { get { return "Makashi_Form_Ready_1H_1H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Soresu_Form_Ready_1H : AuroraAnimation
    {
        public override int id { get { return 532; } }
        public override string name { get { return "g2r3"; } }
        public override string description { get { return "Soresu_Form_Ready_1H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Soresu_Form_Ready_2H : AuroraAnimation
    {
        public override int id { get { return 533; } }
        public override string name { get { return "g2r3"; } }
        public override string description { get { return "Soresu_Form_Ready_2H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Soresu_Form_Ready_1H_1H : AuroraAnimation
    {
        public override int id { get { return 534; } }
        public override string name { get { return "g2r3"; } }
        public override string description { get { return "Soresu_Form_Ready_1H_1H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Ataru_Form_Ready_1H : AuroraAnimation
    {
        public override int id { get { return 535; } }
        public override string name { get { return "g2r4"; } }
        public override string description { get { return "Ataru_Form_Ready_1H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Ataru_Form_Ready_2H : AuroraAnimation
    {
        public override int id { get { return 536; } }
        public override string name { get { return "g2r4"; } }
        public override string description { get { return "Ataru_Form_Ready_2H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Ataru_Form_Ready_1H_1H : AuroraAnimation
    {
        public override int id { get { return 537; } }
        public override string name { get { return "g2r4"; } }
        public override string description { get { return "Ataru_Form_Ready_1H_1H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Shien_Form_Ready_1H : AuroraAnimation
    {
        public override int id { get { return 538; } }
        public override string name { get { return "g2r5"; } }
        public override string description { get { return "Shien_Form_Ready_1H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Shien_Form_Ready_2H : AuroraAnimation
    {
        public override int id { get { return 539; } }
        public override string name { get { return "g2r5"; } }
        public override string description { get { return "Shien_Form_Ready_2H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Shien_Form_Ready_1H_1H : AuroraAnimation
    {
        public override int id { get { return 540; } }
        public override string name { get { return "g2r5"; } }
        public override string description { get { return "Shien_Form_Ready_1H_1H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Niman_Form_Ready_1H : AuroraAnimation
    {
        public override int id { get { return 541; } }
        public override string name { get { return "g2r6"; } }
        public override string description { get { return "Niman_Form_Ready_1H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Niman_Form_Ready_2H : AuroraAnimation
    {
        public override int id { get { return 542; } }
        public override string name { get { return "g2r6"; } }
        public override string description { get { return "Niman_Form_Ready_2H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Niman_Form_Ready_1H_1H : AuroraAnimation
    {
        public override int id { get { return 543; } }
        public override string name { get { return "g2r6"; } }
        public override string description { get { return "Niman_Form_Ready_1H_1H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Juyo_Form_Ready_1H : AuroraAnimation
    {
        public override int id { get { return 544; } }
        public override string name { get { return "g2r7"; } }
        public override string description { get { return "Juyo_Form_Ready_1H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Juyo_Form_Ready_2H : AuroraAnimation
    {
        public override int id { get { return 545; } }
        public override string name { get { return "g2r7"; } }
        public override string description { get { return "Juyo_Form_Ready_2H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Juyo_Form_Ready_1H_1H : AuroraAnimation
    {
        public override int id { get { return 546; } }
        public override string name { get { return "g2r7"; } }
        public override string description { get { return "Juyo_Form_Ready_1H_1H"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Sion_Cutting_Kreia_Hand : AuroraAnimation
    {
        public override int id { get { return 547; } }
        public override string name { get { return "cuthand"; } }
        public override string description { get { return "Sion_Cutting_Kreia_Hand"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_React_To_Left_Hand_Cut_Off : AuroraAnimation
    {
        public override int id { get { return 548; } }
        public override string name { get { return "lhandchop"; } }
        public override string description { get { return "React_To_Left_Hand_Cut_Off"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Collapse_Begin : AuroraAnimation
    {
        public override int id { get { return 549; } }
        public override string name { get { return "Collapse"; } }
        public override string description { get { return "Collapse_Begin"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Collapse_Loop : AuroraAnimation
    {
        public override int id { get { return 550; } }
        public override string name { get { return "Collapselp"; } }
        public override string description { get { return "Collapse_Loop"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Collapse_Stand : AuroraAnimation
    {
        public override int id { get { return 551; } }
        public override string name { get { return "Collapsestand"; } }
        public override string description { get { return "Collapse_Stand"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Bao_Dur_Power_Punch : AuroraAnimation
    {
        public override int id { get { return 552; } }
        public override string name { get { return "powerpunch"; } }
        public override string description { get { return "Bao_Dur_Power_Punch"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return true; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Raise_Arm_To_Point : AuroraAnimation
    {
        public override int id { get { return 553; } }
        public override string name { get { return "uppoint"; } }
        public override string description { get { return "Raise_Arm_To_Point"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Lower_Arm_From_Point : AuroraAnimation
    {
        public override int id { get { return 554; } }
        public override string name { get { return "downpoint"; } }
        public override string description { get { return "Lower_Arm_From_Point"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Lower_Cloak_Hood : AuroraAnimation
    {
        public override int id { get { return 555; } }
        public override string name { get { return "offhood"; } }
        public override string description { get { return "Lower_Cloak_Hood"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Raise_Cloak_Hood : AuroraAnimation
    {
        public override int id { get { return 556; } }
        public override string name { get { return "onhood"; } }
        public override string description { get { return "Raise_Cloak_Hood"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Dive_Roll : AuroraAnimation
    {
        public override int id { get { return 557; } }
        public override string name { get { return "diveroll"; } }
        public override string description { get { return "Dive_Roll"; } }
        public override bool stationary { get { return false; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return true; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

    public class Anim_Talking_Prone_On_Ground : AuroraAnimation
    {
        public override int id { get { return 558; } }
        public override string name { get { return "talkprone"; } }
        public override string description { get { return "Talking_Prone_On_Ground"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return true; } }
    }

    public class Anim_Talk_Die_Prone_On_Ground : AuroraAnimation
    {
        public override int id { get { return 559; } }
        public override string name { get { return "talkpronedie"; } }
        public override string description { get { return "Talk_Die_Prone_On_Ground"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return false; } }
        public override bool fireforget { get { return true; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return true; } }
    }

    public class Anim_HK47_Disabled : AuroraAnimation
    {
        public override int id { get { return 560; } }
        public override string name { get { return "disabled"; } }
        public override string description { get { return "HK47_Disabled"; } }
        public override bool stationary { get { return true; } }
        public override bool pause { get { return false; } }
        public override bool walking { get { return false; } }
        public override bool running { get { return false; } }
        public override bool looping { get { return true; } }
        public override bool fireforget { get { return false; } }
        public override bool overlay { get { return false; } }
        public override bool playoutofplace { get { return false; } }
        public override bool dialog { get { return false; } }
        public override bool damage { get { return false; } }
        public override bool parry { get { return false; } }
        public override bool dodge { get { return false; } }
        public override bool attack { get { return false; } }
        public override bool hideequippeditems { get { return false; } }
    }

}