using RimWorld;
using Verse;

namespace BTE
{
	[DefOf]
	public static class BTE_ThingDefOf
	{
		static BTE_ThingDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(BTE_ThingDefOf));
		}

		public static ThingDef Milk;
		public static ThingDef WoolSheep;



	}

}