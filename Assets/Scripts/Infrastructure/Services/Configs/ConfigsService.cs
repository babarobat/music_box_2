using System.Collections.Generic;
using Configs;
using UnityEngine;

namespace Infrastructure.Services.Configs
{
    public class ConfigsService : IConfigsService
    {
        public IEnumerable<SoundPack> Packs { get; private set; }
        public IEnumerable<Obstacle> Obstacles { get; private set; }
        public void Init()
        {
            Packs = LoadAll<SoundPack>("configs/sound_packs");
            Obstacles = LoadAll<Obstacle>("configs/obstacles");
        }

        public IEnumerable<TConfig> LoadAll<TConfig>(string path) where TConfig : Object
        {
            return Resources.LoadAll<TConfig>(path);
        }
    }
}