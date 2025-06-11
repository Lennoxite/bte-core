using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using Verse.AI;
namespace BTE
{
	public class WorkGiver_MilkPawn : WorkGiver_GatherAnimalBodyResources
	{
		protected override JobDef JobDef
		{
			get
			{
				return BTE_JobDefOf.BTE_MilkPawn;
			}
		}

		public override bool ShouldSkip(Pawn pawn, bool forced = false)
		{
			List<Pawn> list = pawn.Map.mapPawns.SpawnedPawnsInFaction(pawn.Faction);
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].RaceProps.Humanlike)
				{
					CompHasGatherableBodyResource comp = this.GetComp(list[i]);
					if (comp != null && comp.ActiveAndFull)
					{
						return false;
					}
				}
			}
			return true;
		}
		public override bool HasJobOnThing(Pawn pawn, Thing t, bool forced = false)
		{
			Pawn pawn2 = t as Pawn;
			if (pawn2 == null || !pawn2.RaceProps.Humanlike)
			{
				return false;
			}
			CompHasGatherableBodyResource comp = this.GetComp(pawn2);
			return comp != null && comp.ActiveAndFull && !pawn2.Downed && (pawn2.roping == null || !pawn2.roping.IsRopedByPawn) && PawnUtility.CanCasuallyInteractNow(pawn2, false, false, false) && pawn.CanReserve(pawn2, 1, -1, null, forced);
		}
		protected override CompHasGatherableBodyResource GetComp(Pawn animal)
		{
			return animal.TryGetComp<CompMilkableGene>();
		}
	}
}
