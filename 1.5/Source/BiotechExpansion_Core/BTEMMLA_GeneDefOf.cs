﻿using RimWorld;
using Verse;


namespace BTE
{
    [DefOf]
    public static class BTE_GeneDefOf
    {
        static BTE_GeneDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(BTE_GeneDefOf));
        }
        public static GeneDef BTE_MilkableGene;
        public static GeneDef BTE_ShearableGene;
    }
}
