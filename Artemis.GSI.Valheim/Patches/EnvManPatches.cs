using Artemis.GSI.Valheim.Models;
using HarmonyLib;
using System.Text;

namespace Artemis.GSI.Valheim.Patches
{
    [HarmonyPatch(typeof(EnvMan), "Update")]
    public static class EnvManPatches
    {
        public static readonly ArtemisEnvironment Environment = new ArtemisEnvironment();
        public static void Postfix(ref EnvMan __instance)
        {
            Environment.IsWet = __instance.IsWet();
            Environment.WindAngle = __instance.m_debugWindAngle;
            Environment.Biome = __instance.GetCurrentBiome();
            Environment.IsCold  = __instance.IsCold();
            Environment.IsDaylight = __instance.IsDaylight();
            Environment.SunFog = __instance.GetSunFogColor();
        }
    }
}
