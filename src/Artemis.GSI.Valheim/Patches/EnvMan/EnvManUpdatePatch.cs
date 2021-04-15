using Artemis.GSI.Valheim.Models;
using HarmonyLib;
using UnityEngine;
using Unity;

namespace Artemis.GSI.Valheim.Patches
{
    [HarmonyPatch(typeof(EnvMan), "Update")]
    public static class EnvManUpdatePatch
    {
        public static readonly ArtemisEnvironment Environment = new ArtemisEnvironment();
        public static void Postfix(ref EnvMan __instance)
        {
            Environment.IsWet = __instance.IsWet();

            Vector3 vecDir = __instance.GetWindDir();
            float rad = Mathf.Atan2(vecDir.x, vecDir.z);
            Environment.WindAngle = (rad >= 0 ? rad : (2 * Mathf.PI + rad)) * 360 / (2 * Mathf.PI);

            Environment.Biome = __instance.GetCurrentBiome();
            Environment.IsCold = __instance.IsCold();
            Environment.IsDaylight = __instance.IsDaylight();
            Environment.SunFog = __instance.GetSunFogColor();
        }
    }
}
