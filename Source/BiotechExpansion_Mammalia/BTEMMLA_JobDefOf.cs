using RimWorld;
using Verse;


namespace BTE
{
    [DefOf]
    public static class BTE_JobDefOf
    {
        static BTE_JobDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(BTE_JobDefOf));
        }

        public static JobDef BTEMa_MilkPawn;
        public static JobDef BTEMa_ShearPawn;

    }
}
