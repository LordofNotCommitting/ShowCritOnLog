using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using MGSC;
using UnityEngine;

namespace ShowCritOnLog
{
    public static class Plugin
    {

        public static ConfigDirectories ConfigDirectories = new ConfigDirectories();

        public static ModConfig Config { get; private set; }

        public static Logger Logger = new Logger();


        public static string delimiter = "|";
        public static string true_str = "1";
        public static string false_str = "0";

        public static State State;

        [Hook(ModHookType.AfterConfigsLoaded)]
        public static void AfterConfig(IModContext context)
        {

            Plugin.State = context.State;
            Directory.CreateDirectory(ConfigDirectories.ModPersistenceFolder);

            Config = ModConfig.LoadConfig(ConfigDirectories.ConfigPath);

            new Harmony("LoC_" + ConfigDirectories.ModAssemblyName).PatchAll();
        }

    }
}
