using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using UnityEngine;
using Verse;

namespace BTE
{
    class PawnRenderNodeWorker_FlipWhenCrawlingOnlyDrafted : PawnRenderNodeWorker_FlipWhenCrawling
    {

        public override bool CanDrawNow(PawnRenderNode node, PawnDrawParms parms)
        {

            if (PawnUtility.IsAttacking(parms.pawn) || parms.pawn.Drafted)
            {
                return base.CanDrawNow(node, parms);
            } else
            {
                return false;
            }
        }
    }
}