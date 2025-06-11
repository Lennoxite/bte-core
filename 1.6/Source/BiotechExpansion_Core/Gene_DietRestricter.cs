using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace BTE
{
	class Gene_DietRestricter : Gene
	{
		public override void Notify_IngestedThing(Thing thing, int numTaken)
		{
			GeneFoodsDisallowed badFood = def.GetModExtension<GeneFoodsDisallowed>();
			if (badFood == null)
            {
				return;
            }
			if (badFood.foodKind == FoodKind.Meat) //Herbivore
			{
				if (FoodUtility.UnacceptableVegetarian(thing.def))
				{
					//pawn.health.AddHediff(HediffDefOf.FoodPoisoning, null, null, null);
					FoodUtility.AddFoodPoisoningHediff(pawn, thing, FoodPoisonCause.DangerousFoodType);
				}
			} else if (badFood.foodKind == FoodKind.NonMeat) //Carnivore
			{
				if (FoodUtility.UnacceptableCarnivore(thing.def) && thing.def.ingestible.foodType != FoodTypeFlags.Fluid)
				{
					//pawn.health.AddHediff(HediffDefOf.FoodPoisoning, null, null, null);
					FoodUtility.AddFoodPoisoningHediff(pawn, thing, FoodPoisonCause.DangerousFoodType);
				}
			}
		}
	}
}
