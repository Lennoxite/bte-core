using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
namespace BTE
{
    class CompShearableGene : CompHasGatherableBodyResource
    {
		protected override int GatherResourcesIntervalDays
		{
			get
			{
				return this.interval;
			}
		}

		protected override int ResourceAmount
		{
			get
			{
				return this.amount;
			}
		}

		protected override ThingDef ResourceDef
		{
			get
			{
				return this.produce;
			}
		}

		protected override string SaveKey
		{
			get
			{
				return "woolGrowth";
			}
		}

		public CompProperties_ShearableGene Props
		{
			get
			{
				return (CompProperties_ShearableGene)this.props;
			}
		}

		protected override bool Active
		{
			get
			{
				if (!base.Active)
				{
					return false;
				}
				Pawn pawn = this.parent as Pawn;
				return pawn == null || (geneIsPresent && pawn.ageTracker.AgeBiologicalYears >= BTE_GeneDefOf.BTE_ShearableGene.minAgeActive);
			}
		}

		public override void PostExposeData()
		{
			base.PostExposeData();
			Scribe_Values.Look<float>(ref this.fullness, this.SaveKey, 0f, false);
			Scribe_Values.Look<int>(ref this.amount, "woolGeneAmount", 45, false);
			Scribe_Values.Look<int>(ref this.interval, "woolGeneDays", 10, false);
			Scribe_Values.Look<bool>(ref this.geneIsPresent, "woolGenePresent", false);
			Scribe_Defs.Look<ThingDef>(ref this.produce, "woolProduct");
			if (produce == null)
				produce = BTE_ThingDefOf.WoolSheep;
			if (amount == 0)
				amount = 45;
			if (interval == 0)
				interval = 10;
		}


		public override string CompInspectStringExtra()
		{
			if (!this.Active)
			{
				return null;
			}
			return "WoolGrowth".Translate() + ": " + base.Fullness.ToStringPercent();
		}

		public bool geneIsPresent;
		public ThingDef produce = BTE_ThingDefOf.WoolSheep;
		public int amount = 45;
		public int interval = 10;
	}
}
