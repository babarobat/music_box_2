using System.Collections.Generic;
using Configs;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.States
{
    public class ConfigsService : IService
    {
        public IEnumerable<SoundPack> Packs { get; private set; }
        public IEnumerable<Obstacle> Obstacles { get; private set; }
        public void Init()
        {
            Packs = LoadAll<SoundPack>("configs/sound_packs");
            Obstacles = LoadAll<Obstacle>("configs/obstacles");
        }

        private IEnumerable<TConfig> LoadAll<TConfig>(string path) where TConfig : Object
        {
            return Resources.LoadAll<TConfig>(path);
        }
    }
}