using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using UnityEngine;
namespace BTE
{
    class PawnRenderNodeWorker_ScaleWithSeverity : PawnRenderNodeWorker
    {

        public override Vector3 ScaleFor(PawnRenderNode node, PawnDrawParms parms)
        {
            Vector3 scale = base.ScaleFor(node, parms);
            if (node.hediff != null)
            {
                scale *= 2 * node.hediff.Severity; // Scale is 1 at 0.5 severity, 2 at 1.
            }
            return scale;

        }

    }

}
