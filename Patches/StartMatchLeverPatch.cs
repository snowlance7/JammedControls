using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JammedControls.JammedControlsBase;

namespace JammedControls.Patches
{
    [HarmonyPatch]
    internal class StartMatchLeverPatch
    {
        [HarmonyPatch]
        internal class ShipTeleporterPatch
        {
            [HarmonyPatch(typeof(StartMatchLever), "PullLever")]
            [HarmonyPrefix]
            private static bool PullLeverPatch(StartMatchLever __instance)
            {
                if (!GameNetworkManager.Instance.isHostingGame && configRestrictLever.Value)
                {
                    HUDManager.Instance.DisplayTip("Its jammed!", "Only the host can use this...");
                    return false;
                }

                return true;
            }
        }
    }
}
