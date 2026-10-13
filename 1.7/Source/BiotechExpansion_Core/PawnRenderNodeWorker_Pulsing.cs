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
    class PawnRenderNodeWorker_Pulsing : PawnRenderNodeWorker
    {

        public override Vector3 OffsetFor(PawnRenderNode node, PawnDrawParms parms, out Vector3 pivot)
        {
            Vector3 floater = base.OffsetFor(node, parms, out pivot);
            floater.z += 0.05f + 0.05f * Mathf.Sin((float)Find.TickManager.TicksGame / 30f);
            return floater;

        }

    }

}
