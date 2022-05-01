using System.Collections.Generic;
using Configs;
using Infrastructure.Services.Locator;

namespace Infrastructure.Services.Configs
{
    public interface IConfigsService : IService
    {
        IEnumerable<SoundPack> Packs { get; }
        IEnumerable<Obstacle> Obstacles { get; }
        User UserDefault { get; }
        void Init();
    }
}