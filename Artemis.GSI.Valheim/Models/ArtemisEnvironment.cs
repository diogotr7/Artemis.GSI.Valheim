using UnityEngine;
using System;
using System.Text;

namespace Artemis.GSI.Valheim.Models
{
    public class ArtemisEnvironment
    {
        public bool IsWet;
        public bool IsCold;
        public bool IsDaylight;
        public float WindAngle;
        public Heightmap.Biome Biome;
        public Color SunFog;

        public string ToJson()
        {
            var builder = new StringBuilder();
            builder.Append('{');

            builder.AppendTypeAndValue(nameof(IsWet), IsWet);
            builder.Append(',');
            builder.AppendTypeAndValue(nameof(IsCold), IsCold);
            builder.Append(',');
            builder.AppendTypeAndValue(nameof(IsDaylight), IsDaylight);
            builder.Append(',');
            builder.AppendTypeAndValue(nameof(WindAngle), WindAngle);
            builder.Append(',');
            builder.AppendTypeAndValue(nameof(Biome), Biome.ToString());
            builder.Append(',');
            builder.AppendTypeAndValue(nameof(SunFog), SunFog);

            builder.Append('}');
            return builder.ToString();
        }
    }
}
