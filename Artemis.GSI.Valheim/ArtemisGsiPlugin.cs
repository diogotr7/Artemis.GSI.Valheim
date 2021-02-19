using Artemis.GSI.Valheim.Patches;
using BepInEx;
using HarmonyLib;
using System;
using System.Timers;
using UnityEngine;
using UnityEngine.Networking;

namespace Artemis.GSI.Valheim
{
    [BepInPlugin("com.artemis.gsi", "Artemis GSI", "0.1")]
    public class ArtemisGsiPlugin : BaseUnityPlugin
    {
        private Timer timer;
        private static string uri = "http://localhost:9696/plugins/f2c7c7cc-0ef8-4836-aa81-1fedb6836892";
        private static string playerEndpoint = $"{uri}/player";
        private static string envEndpoint = $"{uri}/environment";

        void Awake()
        {
            //TODO: dynamically set URI port based on config file.
            timer = new Timer(100);
            timer.Elapsed += OnTimerElapsed;

            var harmony = new Harmony("com.artemis.gsi");
            harmony.PatchAll();

            timer.Start();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            SendJson(playerEndpoint, JsonUtility.ToJson(PlayerPatches.Player));
            SendJson(envEndpoint, JsonUtility.ToJson(EnvManPatches.Environment));
        }

        private static void SendJson(string uri, string json)
        {
            try
            {
                var request = UnityWebRequest.Put(uri, json);
                request.method = "POST";
                request.SetRequestHeader("Content-Type", "application/json");
                request.SendWebRequest();
            }
            catch
            {

            }
        }
    }
}
