using System.IO;
using UnityEngine;

namespace AuroraEngine
{
	public static partial class Resources
	{
        public static AuroraDLG LoadDialogue(string resref)
        {
            AuroraDLG ad = data.Get<AuroraDLG>(resref, ResourceType.DLG);
            return ad;
        }

        public static Creature LoadCreature(string resref, AuroraGIT.ACreature gitData)
		{
            AuroraUTC ac = data.Get<AuroraUTC>(resref, ResourceType.UTC);
            Creature c = Creature.Create(ac, gitData);
            return c;
		}

		public static Placeable LoadPlaceable(string resref, AuroraGIT.APlaceable gitData)
		{
            AuroraUTP ap = data.Get<AuroraUTP>(resref, ResourceType.UTP);
            Placeable p = Placeable.Create(ap, gitData);
            return p;
        }

        public static SoundPoint LoadSound(string resref, AuroraGIT.ASound gitData)
        {
            AuroraUTS ap = data.Get<AuroraUTS>(resref, ResourceType.UTS);
            SoundPoint p = SoundPoint.Create(ap, gitData);
            return p;
        }

        public static Store LoadStore(string resref, AuroraGIT.AStore gitData)
        {
            AuroraUTM ap = data.Get<AuroraUTM>(resref, ResourceType.UTM);
            Store p = Store.Create(ap, gitData);
            return p;
        }

        public static Waypoint LoadWaypoint(string resref, AuroraGIT.AWaypoint gitData)
        {
            AuroraUTW ap = data.Get<AuroraUTW>(resref, ResourceType.UTW);
            Waypoint p = Waypoint.Create(ap, gitData);
            return p;
        }

        public static Trigger LoadTrigger(string resref, AuroraGIT.ATrigger gitData)
        {
            AuroraUTT at = data.Get<AuroraUTT>(resref, ResourceType.UTT);
            Trigger t = Trigger.Create(at, gitData);
            return t;
        }

        public static Encounter LoadEncounter(string resref, AuroraGIT.AEncounter gitData)
        {
            AuroraUTE ae = data.Get<AuroraUTE>(resref, ResourceType.UTE);
            Encounter e = Encounter.Create(ae, gitData);
            return e;
        }

        public static Door LoadDoor(string resref, AuroraGIT.ADoor gitData)
		{
            AuroraUTD ad = data.Get<AuroraUTD>(resref, ResourceType.UTD);
            Door d = Door.Create(ad, gitData);
            return d;
        }

		public static Item LoadItem(string resref)
		{
            AuroraUTI ai = data.Get<AuroraUTI>(resref, ResourceType.UTI);
			Item i = Item.Create(ai);
            return i;
        }
        public static AuroraGUI LoadGUI(string resref)
        {
            return data.Get<AuroraGUI>(resref, ResourceType.GUI);
        }
    }
}
