using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
namespace BTE
{
    public class CompMilkableGene : CompHasGatherableBodyResource
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
				return "milkFullness";
			}
		}

		public CompProperties_MilkableGene Props
		{
			get
			{
				return (CompProperties_MilkableGene)this.props;
			}
		}

		public override void PostExposeData()
		{
			base.PostExposeData();
			Scribe_Values.Look<float>(ref this.fullness, this.SaveKey, 0f, false);
			Scribe_Values.Look<int>(ref this.amount, "milkGeneAmount", 14, false);
			Scribe_Values.Look<int>(ref this.interval, "milkGeneDays", 1, false);
			Scribe_Values.Look<bool>(ref this.geneIsPresent, "milkGenePresent", false); 
			Scribe_Defs.Look<ThingDef>(ref this.produce, "milkProduct");
			if (produce == null)
				produce = BTE_ThingDefOf.Milk;
			if (amount == 0)
				amount = 14;
			if (interval == 0)
				interval = 1;
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
				return (!this.Props.milkFemaleOnly || pawn == null || pawn.gender == Gender.Female)
					&& geneIsPresent
					&& pawn.ageTracker.AgeBiologicalYears >= BTE_GeneDefOf.BTEMa_ExcessMilkProduction.minAgeActive;
			}
		}

		public override string CompInspectStringExtra()
		{
			if (!this.Active)
			{
				return null;
			}
			return "MilkFullness".Translate() + ": " + base.Fullness.ToStringPercent();
		}
		public bool geneIsPresent;

		public ThingDef produce = BTE_ThingDefOf.Milk;
		public int amount = 14;
		public int interval = 1;
	}


}
