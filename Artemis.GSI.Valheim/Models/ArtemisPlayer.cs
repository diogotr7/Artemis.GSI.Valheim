﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Artemis.GSI.Valheim.Models
{
    public class ArtemisPlayer
    {
        public float HealthCurrent;
        public float HealthMax;
        public float StaminaCurrent;
        public float StaminaMax;
        public float WeightCurrent;
        public float WeightMax;
        public bool InShelter;
        public List<string> Effects = new List<string>();

        internal string ToJson()
        {
            var builder = new StringBuilder();
            builder.Append('{');

            builder.AppendTypeAndValue(nameof(HealthCurrent), HealthCurrent);
            builder.Append(',');
            builder.AppendTypeAndValue(nameof(HealthMax), HealthMax);
            builder.Append(',');
            builder.AppendTypeAndValue(nameof(StaminaCurrent), StaminaCurrent);
            builder.Append(',');
            builder.AppendTypeAndValue(nameof(StaminaMax), StaminaMax);
            builder.Append(',');
            builder.AppendTypeAndValue(nameof(WeightCurrent), WeightCurrent);
            builder.Append(',');
            builder.AppendTypeAndValue(nameof(WeightMax), WeightMax);
            builder.Append(',');
            builder.AppendTypeAndValue(nameof(InShelter), InShelter);
            builder.Append(',');
            builder.AppendTypeAndValue(nameof(Effects), Effects);

            builder.Append('}');
            return builder.ToString();
        }
    }
}
