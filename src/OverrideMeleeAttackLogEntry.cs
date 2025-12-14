using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Windows;

namespace ShowCritOnLog
{
    [HarmonyPatch(typeof(MeleeAttackLogEntry), nameof(MeleeAttackLogEntry.GetFormattedOutput))]
    public static class OverrideMeleeAttackLogEntry
    {
        public static bool Prefix(ref MeleeAttackLogEntry __instance, ref string __result)
        {
            //parse input
            //int index = __instance.DmgType.IndexOf(Plugin.delimiter, StringComparison.Ordinal);

            string returnval = "";
            //Plugin.Logger.Log("aaaa" + __instance.DmgType);

            __instance.TryGetExtras(out bool wascrit);


            /*
            if (index >= 0)
            {
                temp_crit_result = __instance.DmgType.Substring(0, index);
                temp_damage_type = __instance.DmgType.Substring(index + Plugin.delimiter.Length);
            }
            else {
                temp_damage_type = __instance.DmgType;
            }
            */

            //this mod only fixes melee and ranged attack colors, which will not match other damage intake color such as fire, grenade, etc.
            //hold off color change for now.
            Color temp_damage_color = Colors.Yellow;
            string damage_append = "";

            if (wascrit) 
            {
                damage_append = "!";
                //temp_damage_color = Colors.Yellow;
            }

            if (string.IsNullOrEmpty(__instance.WeaponId))
            {
                returnval = Localization.Get("ui.combatlog.MeleeAttackBare").Replace("%ATTACKER%", __instance.Attacker.Localize()).Replace("%VICTIM%", __instance.Victim.Localize()).Replace("%DMGTYPE%", Localization.Get("ui.damage." + __instance.DmgType).WrapInColor(Colors.Yellow)).Replace("%DMG%", (__instance.FinalDmg.ToString() + damage_append).WrapInColor(temp_damage_color));
            }
            else 
            {
                returnval = Localization.Get("ui.combatlog.MeleeAttackWeapon").Replace("%ATTACKER%", __instance.Attacker.Localize()).Replace("%VICTIM%", __instance.Victim.Localize()).Replace("%DMGTYPE%", Localization.Get("ui.damage." + __instance.DmgType).WrapInColor(Colors.Yellow)).Replace("%DMG%", (__instance.FinalDmg.ToString() + damage_append).WrapInColor(temp_damage_color)).Replace("%WEAPON%", Localization.Get("item." + __instance.WeaponId + ".name").WrapInColor(Colors.White));
            }

            __result = returnval;
            return false;
        }
    }
}
