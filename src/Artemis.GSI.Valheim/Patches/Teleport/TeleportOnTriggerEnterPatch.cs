using HarmonyLib;
using Artemis.GSI.Valheim.Models;

namespace Artemis.GSI.Valheim.Patches
{
    [HarmonyPatch(typeof(TeleportWorld), "Teleport")]
    public static class TeleportOnTriggerEnterPatch
    {
        public static void Postfix(ref TeleportWorld __instance, Player player)
        {
            ArtemisGsiPlugin.ArtemisWebClient.SendEvent("teleport","{}");
        }
    }
}
