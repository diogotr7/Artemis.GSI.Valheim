using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.GSI.Valheim.Models
{
    public class ArtemisTeleportEvent : ISerializable
    {
        public string Tag;

        public string ToJson()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('{');

            builder.AppendTypeAndValue(nameof(Tag), Tag);

            builder.Append('}');
            return builder.ToString();
        }
    }
}
