using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace BTE
{
	public class Gene_ExcessMilkProduction : Gene
	{


		private ThingDef produce;
        private int amount = 0;
        private int interval = 0;
		private int intervalLeft = 0;

        public override void PostAdd()
		{
			base.PostAdd();
			produce = this.def.GetModExtension<GeneMaterialProduced>().produces;
			amount = this.def.GetModExtension<GeneMaterialProduced>().amount;
			interval = this.def.GetModExtension<GeneMaterialProduced>().intervalDays*60000;
            intervalLeft = this.def.GetModExtension<GeneMaterialProduced>().intervalDays * 60000;
            //this.pawn.ageTracker.CurLifeStage.milkable = true;
            //	AddComp(0);
        }


        public override void Tick()
        {
            base.Tick();
            if ((pawn.IsColonist || pawn.IsPrisonerOfColony) && pawn.Map != null)
            {
                //Log.Message("Ticking for" + pawn.Name.ToStringFull);
                intervalLeft--;
                if (intervalLeft <= 0)
                {
                    intervalLeft = interval;

                    Thing thng = GenSpawn.Spawn(produce, pawn.Position, pawn.Map, WipeMode.VanishOrMoveAside);
                    thng.stackCount = amount;
                }
                
            }
        }

        public override void PostMake()
		{
			base.PostMake();
			//this.pawn.ageTracker.CurLifeStage.milkable = true;
		}

		public override void PostRemove()
		{

			base.PostRemove();
		}


        public override void ExposeData()
        {
			base.ExposeData();
            Scribe_Values.Look<int>(ref intervalLeft, "milkIntervalLeft", this.def.GetModExtension<GeneMaterialProduced>().intervalDays * 60000, false);
            Scribe_Defs.Look(ref produce, "milkProduce");
            Scribe_Values.Look<int>(ref interval, "milkInterval", this.def.GetModExtension<GeneMaterialProduced>().intervalDays * 60000, false);
            Scribe_Values.Look<int>(ref amount, "milkamount", this.def.GetModExtension<GeneMaterialProduced>().amount, false);
            produce = this.def.GetModExtension<GeneMaterialProduced>().produces;
        }

    }
}
