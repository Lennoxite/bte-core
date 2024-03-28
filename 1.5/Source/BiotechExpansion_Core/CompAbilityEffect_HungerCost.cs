using System;
using Verse;
using Verse.AI;
using RimWorld;
namespace BTE
{
    public class CompAbilityEffect_HungerCost : CompAbilityEffect
    {
        public new CompProperties_AbilityHungerCost Props
        {
            get
            {
                return (CompProperties_AbilityHungerCost)this.props;
            }
        }

        private bool HasEnoughHunger
        {
            get
            {
                Need food = this.parent.pawn.needs.TryGetNeed(NeedDefOf.Food);
                return food != null && food.CurLevel >= this.Props.HungerCost;
            }
        }

        public override bool CanCast
        {
            get
            {
                return this.HasEnoughHunger && base.CanCast;
            }
        }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            Need food = this.parent.pawn.needs.TryGetNeed(NeedDefOf.Food);
            if (food != null)
            {
                food.CurLevel -= this.Props.HungerCost;
            }
        }

        public override bool GizmoDisabled(out string reason)
        {
            Need food = this.parent.pawn.needs.TryGetNeed(NeedDefOf.Food);
            if (food == null)
            {
                reason = null;
                return false;
            }
            if (food.CurLevel < this.Props.HungerCost)
            {
                reason = "Ability Disabled: Not enough food";
                return true;
            }
            float num = this.TotalHungerCostOfQueuedAbilities();
            float num2 = this.Props.HungerCost + num;
            if (this.Props.HungerCost > 1E-45f && num2 > food.CurLevel)
            {
                reason = "Ability Disabled: Not enough food";
                return true;
            }
            reason = null;
            return false;
        }

        public override bool AICanTargetNow(LocalTargetInfo target)
        {
            return this.HasEnoughHunger;
        }

        private float TotalHungerCostOfQueuedAbilities()
        {
            Pawn_JobTracker jobs = this.parent.pawn.jobs;
            object obj;
            if (jobs == null)
            {
                obj = null;
            }
            else
            {
                Job curJob = jobs.curJob;
                obj = ((curJob != null) ? curJob.verbToUse : null);
            }
            Verb_CastAbility verb_CastAbility = obj as Verb_CastAbility;
            float num;
            if (verb_CastAbility == null)
            {
                num = 0f;
            }
            else
            {
                Ability ability = verb_CastAbility.ability;
                num = ((ability != null) ? HungerUtility.HungerCost(ability) : 0f);
            }
            float num2 = num;
            if (this.parent.pawn.jobs != null)
            {
                for (int i = 0; i < this.parent.pawn.jobs.jobQueue.Count; i++)
                {
                    Verb_CastAbility verb_CastAbility2;
                    if ((verb_CastAbility2 = (this.parent.pawn.jobs.jobQueue[i].job.verbToUse as Verb_CastAbility)) != null)
                    {
                        float num3 = num2;
                        Ability ability2 = verb_CastAbility2.ability;
                        num2 = num3 + ((ability2 != null) ? HungerUtility.HungerCost(ability2) : 0f);
                    }
                }
            }
            return num2;
        }
    }
}
