using System.Collections.Generic;
using Configs;
using Infrastructure.Services.Locator;
using User = Configs.User;

namespace Infrastructure.Services.Configs
{
    public interface IConfigsService : IService
    {
        IEnumerable<SoundPack> Packs { get; }
        IEnumerable<Obstacle> Obstacles { get; }
        User UserDefault { get; }
        void Init();
        T Get<T>(string name)  where T: Config;
        IEnumerable<T> GetAll<T>() where T : Config;
    }
}