using Artemis.GSI.Valheim.Models;
using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine.Networking;

namespace Artemis.GSI.Valheim
{
    public class ArtemisWebClient
    {
        private const string CONFIG_PATH = @"C:\ProgramData\Artemis\webserver.txt";
        private const string PLUGIN_GUID = "f2c7c7cc-0ef8-4836-aa81-1fedb6836892";

        private readonly ManualLogSource _logger;
        private readonly Timer timer;
        private readonly string _baseUri;

        public ArtemisWebClient(ManualLogSource logger)
        {
            _logger = logger;

            if (!File.Exists(CONFIG_PATH))
                throw new FileNotFoundException("Artemis webserver file not found");

            try
            {
                string baseUri = File.ReadAllText(CONFIG_PATH);
                _baseUri = $"{baseUri.Replace("*", "localhost")}plugins/{PLUGIN_GUID}";

                _logger.LogInfo($"Found artemis web api uri: {_baseUri}");
            }
            catch (IOException)
            {
                _logger.LogError("Artemis: Error reading webserver config file");
                throw;
            }

            timer = new Timer(100);
            timer.Elapsed += OnTimerElapsed;
        }

        public void StartTimer() => timer.Start();
        public void StopTimer() => timer.Stop();

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            SendPlayerUpdate(Patches.PlayerUpdatePatch.Player);
            SendEnvironmentUpdate(Patches.EnvManUpdatePatch.Environment);
        }

        private void SendJson(string endpoint, string json)
        {
            try
            {
                UnityWebRequest request = UnityWebRequest.Put($"{_baseUri}/{endpoint}", json);
                request.method = "POST";
                request.SetRequestHeader("Content-Type", "application/json");
                request.SendWebRequest();
            }
            catch(Exception e) {
                _logger.LogError(e);
            }
        }

        private string lastPlayerJson;
        public void SendPlayerUpdate(ArtemisPlayer player)
        {
            var json = player.ToJson();
            if (json != lastPlayerJson)
            {
                lastPlayerJson = json;
                SendJson("player", lastPlayerJson);
            }
        }

        private string lastEnvironmentJson;
        public void SendEnvironmentUpdate(ArtemisEnvironment env)
        {
            var json = env.ToJson();
            if (json != lastEnvironmentJson)
            {
                lastEnvironmentJson = json;
                SendJson("environment", lastEnvironmentJson);
            }
        }

        public void SendEvent(string endpoint, string args)
        {
            SendJson(endpoint, args);
        }
    }
}
