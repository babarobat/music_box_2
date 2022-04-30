using System.Collections.Generic;
using Configs;

namespace Infrastructure.Services.Configs
{
    public interface IConfigsService : IService
    {
        IEnumerable<SoundPack> Packs { get; }
        IEnumerable<Obstacle> Obstacles { get; }
        void Init();
    }
}