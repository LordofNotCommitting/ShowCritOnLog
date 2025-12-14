using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ShowCritOnLog
{
    [HarmonyPatch(typeof(CombatLogSystem), nameof(CombatLogSystem.FinishRangeAttackLogEntry))]
    public static class PostfixFinishRangeAttackLogEntry
    {
        public static void Postfix(CombatLog combatLog, ref RangeAttackLogEntry entry, DamageHitInfo hitInfo)
        {
            //integrate crit result
            RangeAttackLogEntryExtra.SetExtras(entry, hitInfo.wasCrit);

        }
    }
}
