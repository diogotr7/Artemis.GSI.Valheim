using Artemis.GSI.Valheim.Models;
using HarmonyLib;

namespace Artemis.GSI.Valheim.Patches
{
    [HarmonyPatch(typeof(EnvMan), "Update")]
    public static class EnvManPatches
    {
        public static readonly ArtemisEnvironment Environment = new ArtemisEnvironment();
        public static void Postfix(ref EnvMan __instance)
        {
            Environment.IsWet = __instance.IsWet();
        }
    }
}
