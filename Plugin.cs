using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace JammedControls
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class JammedControlsBase : BaseUnityPlugin
    {
        private const string modGUID = "Snowlance.JammedControls";
        private const string modName = "JammedControls";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);
        public static JammedControlsBase PluginInstance;

        public static ConfigEntry<bool> configRestrictTeleporter;
        public static ConfigEntry<bool> configRestrictInverseTeleporter;
        public static ConfigEntry<bool> configRestrictLever;
        public static ManualLogSource LoggerInstance { get; private set; }

        private void Awake()
        {
            if ((Object)(object)PluginInstance == (Object)null)
            {
                PluginInstance = this;
            }

            LoggerInstance = this.Logger;
            LoggerInstance.LogInfo($"Plugin {modName} loaded successfully.");

            configRestrictTeleporter = PluginInstance.Config.Bind("Restrictions", "Teleporter", true, "Restrict the use of the teleporter");
            configRestrictInverseTeleporter = PluginInstance.Config.Bind("Restrictions", "InverseTeleporter", true, "Restrict the use of the inverse teleporter");
            configRestrictLever = PluginInstance.Config.Bind("Restrictions", "Lever", true, "Restrict the use of the lever");

            harmony.PatchAll();
        }
    }
}
