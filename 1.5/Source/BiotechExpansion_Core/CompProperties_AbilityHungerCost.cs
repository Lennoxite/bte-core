using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;
namespace BTE
{
    public class CompProperties_AbilityHungerCost : CompProperties_AbilityEffect
    {
        public CompProperties_AbilityHungerCost()
        {
            this.compClass = typeof(CompAbilityEffect_HungerCost);
        }

        public override IEnumerable<string> ExtraStatSummary()
        {
            yield return "Food cost" + ": " + this.hungerCost;
            yield break;
        }

        public float hungerCost;
    }
}
