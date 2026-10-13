using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
namespace BTE
{
    public class GeneMaterialProduced : DefModExtension
    {
        public ThingDef produces;
        public int intervalDays;
        public int amount;
        bool femaleOnly = false;
    }
}
