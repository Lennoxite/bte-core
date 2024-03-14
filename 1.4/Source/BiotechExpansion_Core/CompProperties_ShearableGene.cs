using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
namespace BTE
{
    class CompProperties_ShearableGene : CompProperties
    {
		public CompProperties_ShearableGene()
		{
			this.compClass = typeof(CompShearableGene);
		}

	}

}
