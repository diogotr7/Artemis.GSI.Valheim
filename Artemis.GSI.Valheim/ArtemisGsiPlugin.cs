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
        private const string CONFIG_PATH = @"C:\ProgramData\Artemis\webserver.txt";
        private const string PLUGIN_GUID = "f2c7c7cc-0ef8-4836-aa81-1fedb6836892";
        private Timer timer;
        private string uri;
        private string playerEndpoint;
        private string envEndpoint;

        private void Awake()
        {
            if (!File.Exists(CONFIG_PATH))
            {
                Debug.Log("Artemis webserver file not found, exiting");
                return;
            }

            try
            {
                string baseUri = File.ReadAllText(CONFIG_PATH);
                uri = $"{baseUri}plugins/{PLUGIN_GUID}";
                playerEndpoint = $"{uri}/player";
                envEndpoint = $"{uri}/environment";

                Debug.Log($"Found artemis web api uri: {uri}");
            }
            catch (IOException)
            {
                Debug.Log("Artemis: Error reading webserver config file");
                return;
            }
            timer = new Timer(100);
            timer.Elapsed += OnTimerElapsed;

            Harmony harmony = new Harmony("com.artemis.gsi");
            harmony.PatchAll();

            Logger.LogInfo(PlayerPatches.Player.ToJson());
            Logger.LogInfo(EnvManPatches.Environment.ToJson());

            timer.Start();
        }

        private void OnApplicationQuit()
        {
            timer?.Stop();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            SendJson(playerEndpoint, PlayerPatches.Player.ToJson());
            SendJson(envEndpoint, EnvManPatches.Environment.ToJson());
        }

        private static void SendJson(string uri, string json)
        {
            try
            {
                UnityWebRequest request = UnityWebRequest.Put(uri, json);
                request.method = "POST";
                request.SetRequestHeader("Content-Type", "application/json");
                request.SendWebRequest();
            }
            catch { }
        }
    }
}
