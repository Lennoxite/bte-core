using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace BTE
{
    public class PawnRenderNodeWorker_VariableRotator : PawnRenderNodeWorker_FlipWhenCrawling
    {

        public override Quaternion RotationFor(PawnRenderNode node, PawnDrawParms parms)
        {
            Quaternion floater = base.RotationFor(node, parms);
            if (node.Props is PawnRenderNodeProperties_VariableRotator rotator)
            {
                var rotation = ( (float)Find.TickManager.TicksGame * rotator.degreesPerTick ) % 360;
                floater *= rotation.ToQuat();
            }
            return floater;

        }

    }
}
