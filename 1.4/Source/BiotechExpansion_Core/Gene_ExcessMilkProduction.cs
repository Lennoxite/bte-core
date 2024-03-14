using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace BTE
{
	public class Gene_ExcessMilkProduction : Gene
	{

		//public ThingComp LinkedComp
		//{
		//	get
		//	{
		//		ThingComp milkComp = this.pawn.GetComp<CompMilkable>();
		//		return milkComp;
		//	}
		//}

		public override void PostAdd()
		{
			base.PostAdd();
			CompMilkableGene comp = this.pawn.GetComp<CompMilkableGene>();

			if (comp != null)
			{
				comp.geneIsPresent = true;
				comp.produce = this.def.GetModExtension<GeneMaterialProduced>().produces;
				comp.amount = this.def.GetModExtension<GeneMaterialProduced>().amount;
				comp.interval = this.def.GetModExtension<GeneMaterialProduced>().intervalDays;
			}
			//this.pawn.ageTracker.CurLifeStage.milkable = true;
			//	AddComp(0);
		}

		//public void AddComp(float full)
		//{
			//CompMilkable newComp = new CompMilkable();
			//CompProperties_Milkable prop = new CompProperties_Milkable();
			//newComp.parent = this.pawn;
			//prop.milkAmount = 14;
			//prop.milkIntervalDays = 1;
			//prop.milkFemaleOnly = false;
			//prop.milkDef = BTE_ThingDefOf.Milk;
			//newComp.Initialize(prop);
			//newComp.Fullness = full;

			//this.pawn.AllComps.Add(newComp);
		//	this.pawn.ageTracker.CurLifeStage.milkable = true;
		//}

		public override void PostMake()
		{
			base.PostMake();
			//this.pawn.ageTracker.CurLifeStage.milkable = true;
		}

		public override void PostRemove()
		{

			//	if (LinkedComp != null)
			//	{
			//		LinkedComp.parent = null;
			//		this.pawn.AllComps.Remove(LinkedComp);
			//		this.pawn.ageTracker.CurLifeStage.milkable = false;
			//	}
			//this.pawn.ageTracker.CurLifeStage.milkable = false;

			CompMilkableGene comp = this.pawn.GetComp<CompMilkableGene>();

			if (comp != null)
			{
				comp.geneIsPresent = false;
			}
			base.PostRemove();
		}


	}
}
