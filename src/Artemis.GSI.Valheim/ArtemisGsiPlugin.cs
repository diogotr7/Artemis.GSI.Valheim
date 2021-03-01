using Artemis.GSI.Valheim.Patches;
using BepInEx;
using HarmonyLib;
using System.IO;
using System.Timers;
using UnityEngine;
using UnityEngine.Networking;

namespace Artemis.GSI.Valheim
{
    [BepInPlugin("com.artemis.gsi", "Artemis GSI", "0.1")]
    public class ArtemisGsiPlugin : BaseUnityPlugin
    {
        public static ArtemisWebClient ArtemisWebClient => _artemisWebClient;
        private static ArtemisWebClient _artemisWebClient;

        public void Awake()
        {
            try
            {
                _artemisWebClient = new ArtemisWebClient(Logger);
            }
            catch (System.Exception e)
            {
                Logger.LogError(e);
                return;
            }
            Harmony harmony = new Harmony("com.artemis.gsi");
            harmony.PatchAll();

            ArtemisWebClient.StartTimer();
        }

        public void OnApplicationQuit()
        {
            ArtemisWebClient.StopTimer();
        }
    }
}
