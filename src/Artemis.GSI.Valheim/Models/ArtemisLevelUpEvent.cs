using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.GSI.Valheim.Models
{
    public class ArtemisLevelUpEvent : ISerializable
    {
        public Skills.SkillType SkillType;
        public float Level;

        public string ToJson()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('{');

            builder.AppendTypeAndValue(nameof(SkillType), SkillType.ToString());
            builder.Append(',');
            builder.AppendTypeAndValue(nameof(Level), Level);

            builder.Append('}');
            return builder.ToString();
        }
    }
}
