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
            yield return "Hunger cost" + ": " + Mathf.RoundToInt(this.HungerCost * 100f);
            yield break;
        }

        public float HungerCost;
    }
}
