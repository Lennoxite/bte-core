using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace BTE
{
    public class PawnRenderNodeProperties_VariableRotator : PawnRenderNodeProperties
    {
        public PawnRenderNodeProperties_VariableRotator()
        {
            workerClass = typeof(PawnRenderNodeWorker_Eye);
            nodeClass = typeof(PawnRenderNode_AttachmentHead);
        }

        public float degreesPerTick = 1f;
    }
}
