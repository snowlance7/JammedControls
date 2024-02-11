using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JammedControls;
using static JammedControls.JammedControlsBase;

namespace JammedControls.Patches
{
    [HarmonyPatch]
    internal class ShipTeleporterPatch
    {
        [HarmonyPatch(typeof(ShipTeleporter), "PressTeleportButtonOnLocalClient")]
        [HarmonyPrefix]
        private static bool PressTeleportButtonOnLocalClientPatch(ShipTeleporter __instance)
        {
            if (__instance.isInverseTeleporter && configRestrictInverseTeleporter.Value && !GameNetworkManager.Instance.isHostingGame)
            {
                HUDManager.Instance.DisplayTip("Its jammed!", "Only the host can use this...");
                return false;
            }
            else if (configRestrictTeleporter.Value && !GameNetworkManager.Instance.isHostingGame)
            {
                HUDManager.Instance.DisplayTip("Its jammed!", "Only the host can use this...");
                return false;
            }

            return true;
        }
    }
}
