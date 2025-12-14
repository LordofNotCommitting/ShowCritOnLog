/*
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
    [HarmonyPatch(typeof(DamageSystem), nameof(DamageSystem.CalculateHitInfo))]
    public static class PostfixProcessCreatureAccuracyExample
    {
        public static void Postfix(DamageHitInfo __result, int distance, float baseAccuracy, float baseDodge, float critChanceBonus, DmgInfo damage, float overallDmgMult, float woundBaseChance, int rangeBegins = 0, int range = 1, float falloff = 0f, bool autoCrit = false, bool autoHit = false, float critDamageBonus = 0f, float woundChanceMult = 1f, bool noCrit = false, bool isMaxHitChance = false, bool wasThrown = false)
        {


            //Plugin.Logger.Log("--- main menu awake");
            float hitrollf;
            float hitchancef;
            bool miss = __result.wasMiss;
            __result.TryGetExtras(out hitrollf, out hitchancef);
            int hitroll = Mathf.FloorToInt(hitrollf * 100);
            int hitchance = Mathf.FloorToInt(hitchancef * 100);
            int intdodge = Mathf.FloorToInt(baseDodge * 100);
            


            CombatLog combatLog = Plugin.State.Get<CombatLog>();
            RaidMetadata raidMetadata = Plugin.State.Get<RaidMetadata>();

            String temp_missorhit = "[ ";
            if (miss)
            {
                temp_missorhit += "Miss" + " ] ";
            }
            else
            {
                temp_missorhit += "Hit ] ";
            }
            temp_missorhit += "Hit Chance: " + hitchance + ", Dodge: " + intdodge + ", Hit Roll: " + hitroll;
            //make hit log here?
            MessageLogEntry temp_hitlog = new MessageLogEntry();

            temp_hitlog.MessageTag = temp_missorhit;
            temp_hitlog.Color = Color.white;

            /Plugin.Logger.Log(temp_hitlog.MessageTag);
            CombatLogSystem.AddEntry(raidMetadata, combatLog, temp_hitlog);
        }
    }
}
*/