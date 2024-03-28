using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace BTE
{


    [StaticConstructorOnStartup]
    public static class HungerUtility
    {
        public static float HungerCost(Ability ab)
        {
            if (ab.comps != null)
            {
                using (List<AbilityComp>.Enumerator enumerator = ab.comps.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        CompAbilityEffect_HungerCost compAbilityEffect_HungerCost;
                        if ((compAbilityEffect_HungerCost = (enumerator.Current as CompAbilityEffect_HungerCost)) != null)
                        {
                            return compAbilityEffect_HungerCost.Props.HungerCost;
                        }
                    }
                }
            }
            return 0f;
        }
    }
}
