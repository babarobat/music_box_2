using System.Collections.Generic;
using Configs;
using UnityEngine;

namespace Infrastructure.Services.Configs
{
    public interface IConfigsService : IService
    {
        IEnumerable<SoundPack> Packs { get; }
        IEnumerable<Obstacle> Obstacles { get; }
        void Init();
        IEnumerable<TConfig> LoadAll<TConfig>(string path) where TConfig : Object;
    }
}