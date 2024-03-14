using System;
using System.Collections.Generic;
using RimWorld;
using Verse;
namespace BTE
{
	public class ConditionalStatAffecter_Unarmed : ConditionalStatAffecter
	{
		public override string Label
		{
			get
			{
				return "While Unarmed";
			}
		}

		public override bool Applies(StatRequest req)
		{
			if (!ModsConfig.BiotechActive)
			{
				return false;
			}
			Pawn pawn;
			if (req.HasThing && (pawn = (req.Thing as Pawn)) != null && pawn.equipment != null)
			{
				if (pawn.equipment.Primary == null)
					return true;
				else
					return false;
			}
			return false;
		}
	}
}
