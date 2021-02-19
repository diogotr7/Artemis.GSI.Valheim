using Artemis.Core.DataModelExpansions;
using System.Collections.Generic;

namespace Artemis.Plugins.Modules.Valheim.DataModels
{
    public class ValheimDataModel : DataModel
    {
        public PlayerData Player { get; set; } = new PlayerData();
        public Enviroment Environment { get; set; } = new Enviroment();
    }

    public enum Biome
    {
        None = 0,
        Meadows = 1,
        Swamp = 2,
        Mountain = 4,
        BlackForest = 8,
        Plains = 16,
        AshLands = 32,
        DeepNorth = 64,
        Ocean = 256,
        Mistlands = 512,
        BiomesMax = 513
    }

    public class PlayerData
    {
        public float HealthCurrent { get; set; }
        public float HealthMax { get; set; }
        public float StaminaCurrent { get; set; }
        public float StaminaMax { get; set; }
        public float WeightCurrent { get; set; }
        public float WeightMax { get; set; }
        public Biome Biome { get; set; }
        public bool InShelter { get; set; }
    }

    public class Enviroment
    {
        public bool IsWet { get; set; }
    }
}