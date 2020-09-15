using UnityEngine;
using UnityEngine.UIElements;

namespace AuroraEngine
{
	public class Item : AuroraObject
	{
		public static Item Create(AuroraUTI uti)
		{
			GameObject gameObject;

			//get the resource reference for this object, which we'll use as it's in-engine name
			string name = uti.TemplateResRef;

			//get the appearance row number in baseitems.2da
			int appearance = uti.BaseItem;

			//get the model name for this appearance id
			string modelRef = Resources.Load2DA("baseitems")[appearance, "defaultmodel"];

			//create a new game object and load the model into the scene
			gameObject = Resources.LoadModel(modelRef);
			gameObject.name = name;

			//add the template component to the new object
			Item item = gameObject.AddComponent<Item>();
            item.template = uti;

			return item;
        }

		public enum WeaponType
		{
			RANGED, MELEE
		}

		public WeaponType GetWeaponType()
		{
			AuroraUTI item = (AuroraUTI)this.template;
			int isRanged = int.Parse(Resources.From2DA("baseitems", item.BaseItem, "rangedweapon"));

			if (isRanged > 0)
            {
				return WeaponType.RANGED;
            }
			return WeaponType.MELEE;
		}
	}
}