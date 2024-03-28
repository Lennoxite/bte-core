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
    class PawnRenderNode_AttachmentHeadAlternating : PawnRenderNode_AttachmentHead
    {
        public PawnRenderNode_AttachmentHeadAlternating(Pawn pawn, PawnRenderNodeProperties props, PawnRenderTree tree) : base(pawn, props, tree) {

        }

        public Graphic Graphics
        {
            get {
                return graphics[currentIndex]; 
            }
        }

        protected override void EnsureMaterialsInitialized()
        {
            if (this.graphics.Empty() && this.HasGraphic(this.tree.pawn))
            {
                this.GraphicsFor(this.tree.pawn);
                texSize = this.props.texPaths.Count;
                graphic = graphics[0];
                
            }
        }

        public virtual List<Graphic> GraphicsFor(Pawn pawn)
        {

            
            if (this.props.texPaths.NullOrEmpty())
            {
                return null;
            }

            Shader shader = this.ShaderFor(pawn);
            if (shader == null)
            {
                return null;
            }

            foreach (string str in this.props.texPaths)
            {
                graphics.Add(GraphicDatabase.Get<Graphic_Multi>(str, shader, Vector2.one, this.ColorFor(pawn)));
            }
            return graphics;
        }

        public void alternateGraphic()
        {
            Log.Message("New graphic for! " + this.tree.pawn.Name.ToString());
            currentIndex = Rand.Range(0, texSize);
            requestRecache = true;

        }

        //public override Graphic GraphicFor(Pawn pawn)
        //{
        //    return base.GraphicFor(pawn);
        //}

        public List<Graphic> graphics = new List<Graphic>();
        public int currentIndex = 0;

        private int texSize = 0;
    }

}

