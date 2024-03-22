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
    class PawnRenderNodeWorker_OnlyDraftedPulsing : PawnRenderNodeWorker_OnlyDrafted
    {

        public override Vector3 OffsetFor(PawnRenderNode node, PawnDrawParms parms, out Vector3 pivot)
        {
			Vector3 floater = base.OffsetFor(node, parms, out pivot);
			floater.z += 0.05f + 0.05f * (float)Math.Sin(Find.TickManager.TicksGame/30);
            return floater;
			
        }
        /*protected override Material GetMaterial(PawnRenderNode node, PawnDrawParms parms)
		{
			if (alternatingNode == null)
			{
				if (!cacheRenderNode(node))
				{
					return null;
				}
			}
			currentGraphic = alternatingNode.Graphics;
			if (currentGraphic == null)
			{
				return null;
			}
			if (node.Props.flipGraphic && parms.facing.IsHorizontal)
			{
				parms.facing = parms.facing.Opposite;
			}
			Material material = currentGraphic.NodeGetMat(parms);
			if (!parms.Portrait && parms.flags.FlagSet(PawnRenderFlags.Invisible))
			{
				material = InvisibilityMatPool.GetInvisibleMat(material);
			}
			return material;
		}

        public override Vector3 OffsetFor(PawnRenderNode node, PawnDrawParms parms, out Vector3 pivot)
		{
			ticks--;
			if (ticks <= 0)
            {
				ticks = tickInterval;

				if (alternatingNode == null)
				{
					if (!cacheRenderNode(node))
					{
						return base.OffsetFor(node, parms, out pivot);
					}
				}

				alternatingNode.alternateGraphic();
			}



			return base.OffsetFor(node, parms, out pivot);
        }

        private bool cacheRenderNode(PawnRenderNode node)
        {
			if ((alternatingNode = (node as PawnRenderNode_AttachmentHeadAlternating)) != null)
            {
				return true;
            }
			return false;
        }
		private Graphic currentGraphic = null;
		private PawnRenderNode_AttachmentHeadAlternating alternatingNode = null;


		private int ticks = 0;
		private int tickInterval = 180;*/
    }

}
