using System;
using Verse;
using RimWorld;
using Verse.AI;
using System.Collections.Generic;
namespace BTE
{
	public class JobDriver_MilkPawn : JobDriver_GatherAnimalBodyResources
	{
		protected override float WorkTotal
		{
			get
			{
				return 400f;
			}
		}
		protected override CompHasGatherableBodyResource GetComp(Pawn animal)
		{
			return animal.TryGetComp<CompMilkableGene>();
		}

		protected override IEnumerable<Toil> MakeNewToils()
		{
			this.FailOnDespawnedNullOrForbidden(TargetIndex.A);
			this.FailOnDowned(TargetIndex.A);
			this.FailOnNotCasualInterruptible(TargetIndex.A);
			yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.Touch);
			Toil wait = ToilMaker.MakeToil("MakeNewToils");
			wait.initAction = delegate ()
			{
				Pawn actor = wait.actor;
				Pawn pawn = (Pawn)this.job.GetTarget(TargetIndex.A).Thing;
				actor.pather.StopDead();
				if (actor != pawn) // Don't interrupt yourself from toiling.
					PawnUtility.ForceWait(pawn, 15000, null, true, false);
			};
			wait.tickAction = delegate ()
			{
				Pawn actor = wait.actor;
				actor.skills.Learn(SkillDefOf.Animals, 0.13f, false);
				this.gatherProgress += actor.GetStatValue(StatDefOf.AnimalGatherSpeed, true, -1);
				if (this.gatherProgress >= this.WorkTotal)
				{
					this.GetComp((Pawn)((Thing)this.job.GetTarget(TargetIndex.A))).Gathered(this.pawn);
					actor.jobs.EndCurrentJob(JobCondition.Succeeded, true, true);
				}
			};
			wait.AddFinishAction(delegate
			{
				Pawn pawn = (Pawn)this.job.GetTarget(TargetIndex.A).Thing;
				if (pawn != null && pawn.CurJobDef == JobDefOf.Wait_MaintainPosture)
				{
					pawn.jobs.EndCurrentJob(JobCondition.InterruptForced, true, true);
				}
			});
			wait.FailOnDespawnedOrNull(TargetIndex.A);
			wait.FailOnCannotTouch(TargetIndex.A, PathEndMode.Touch);
			wait.AddEndCondition(delegate
			{
				if (!this.GetComp((Pawn)((Thing)this.job.GetTarget(TargetIndex.A))).ActiveAndFull)
				{
					return JobCondition.Incompletable;
				}
				return JobCondition.Ongoing;
			});
			wait.defaultCompleteMode = ToilCompleteMode.Never;
			wait.WithProgressBar(TargetIndex.A, () => this.gatherProgress / this.WorkTotal, false, -0.5f, false);
			wait.activeSkill = (() => SkillDefOf.Animals);
			yield return wait;
			yield break;
		}

		private float gatherProgress;

	}
}
