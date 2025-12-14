/*
using HarmonyLib;
using MGSC;
using ShowCritOnLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Rewired.Demos.CustomPlatform.MyPlatformControllerExtension;

namespace ShowCritOnLog
{
    [HarmonyPatch(typeof(DamageHitInfo)), HarmonyPatch(MethodType.Constructor)]
    [HarmonyPatch(new Type[] {
    typeof(int), typeof(float), typeof(DmgInfo), typeof(float),
    typeof(float), typeof(int), typeof(int), typeof(float),
    typeof(bool), typeof(bool), typeof(float), typeof(bool)
})]
    public static class PostfixDamageHitInfoCtorExample
    {

        static void Postfix(
    ref DamageHitInfo __instance,
    int distance,
    float overallDmgMult,
    DmgInfo dmgInfo,
    float accuracy,
    float critBonus = 0f,
    int rangeBegins = 0,
    int range = 1,
    float falloff = 0f,
    bool autoCrit = false,
    bool autoHit = false,
    float critDamageBonus = 0f,
    bool noCrit = false
)
        {
            __instance.info = dmgInfo;
            if (!string.IsNullOrEmpty(__instance.info.damage))
            {
                __instance.isPhysical = Data.DamageTypes.GetRecord(__instance.info.damage, true).IsPhysical;
            }

            int num = UnityEngine.Random.Range(dmgInfo.minDmg, dmgInfo.maxDmg + 1);
            float num2 = UnityEngine.Random.Range(0f, 1f);
            float num3 = UnityEngine.Random.Range(0f, 1f);

            DamageHitInfoExtra.SetExtras(__instance, num3, accuracy);

            __instance.wasCrit = (autoCrit || num2 <= dmgInfo.critChance + critBonus) && !noCrit;
            __instance.wasMiss = (num3 > accuracy && !autoHit);

            if (__instance.wasCrit)
            {
                num = Mathf.RoundToInt((float)num * (dmgInfo.critDmg + critDamageBonus));
            }

            num = DamageSystem.FalloffDamage(num, distance, rangeBegins, range, falloff, out __instance.wasOutOfRange);

            int b = Mathf.RoundToInt((float)num * overallDmgMult);
            __instance.finalDmg = Mathf.Max(1, b);
            __instance.dirtyDmg = __instance.finalDmg;
            // Now the object exists, safe to attach extra data
        }


        public static void TryGetExtras(DamageHitInfo __instance, out float a, out float b)
        {
            DamageHitInfoExtra.TryGetExtras(__instance, out var temp_a, out var temp_b);
            a = temp_a;
            b = temp_b;
        }

    }

}


*/
