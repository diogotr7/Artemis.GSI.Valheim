using Artemis.GSI.Valheim.Models;
using HarmonyLib;

namespace Artemis.GSI.Valheim.Patches
{
    [HarmonyPatch(typeof(Player), "Update")]
    public static class PlayerPatches
    {
        public static readonly ArtemisPlayer Player = new ArtemisPlayer();

        public static void Postfix(ref Player __instance)
        {
            Player.HealthCurrent = __instance.GetHealth();
            Player.HealthMax = __instance.GetMaxHealth();
            Player.StaminaCurrent = __instance.GetStamina();
            Player.StaminaMax = __instance.GetMaxStamina();
            Player.WeightCurrent = __instance.GetInventory().GetTotalWeight();
            Player.WeightMax = __instance.GetMaxCarryWeight();
            Player.InShelter = __instance.InShelter();
            Player.Effects = __instance.GetSEMan().GetStatusEffects().ConvertAll(se => se.name);
        }
    }
}
