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
    [HarmonyPatch(typeof(CombatLogSystem), nameof(CombatLogSystem.FinishMeleeAttackLogEntry))]
    public static class PostfixFinishMeleeAttackLogEntry
    {
        public static void Postfix(CombatLog combatLog, ref MeleeAttackLogEntry entry, DamageHitInfo hitInfo)
        {
            //integrate crit result
            MeleeAttackLogEntryExtra.SetExtras(entry, hitInfo.wasCrit);
        }
    }
}
