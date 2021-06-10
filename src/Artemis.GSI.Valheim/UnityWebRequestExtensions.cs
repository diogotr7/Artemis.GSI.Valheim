using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Artemis.GSI.Valheim
{
    public static class UnityWebRequestExtensions
    {
        public static void SendWithTimeout(this UnityWebRequest request, TimeSpan timeout)
        {
            var startTime = DateTime.UtcNow;
            request.SendWebRequest();
            while (!request.isDone)
            {
                if (DateTime.UtcNow > startTime + timeout)
                {
                    throw new TimeoutException();
                }
            }
        }
    }
}
