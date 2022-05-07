using System;
using System.Collections.Generic;
using System.Linq;
using Configs;
using Configs.Obstacles;
using Infrastructure.Services.Assets;
using Object = UnityEngine.Object;

namespace Infrastructure.Services.Configs
{
    public class ConfigsService : IConfigsService
    {
        public IEnumerable<SoundPack> Packs { get; private set; }
        public IEnumerable<Obstacle> Obstacles { get; private set; }
        public User UserDefault { get; private set; }

        private readonly Dictionary<Type, Dictionary<string, Config>> _all = new();
        private readonly IAssetsService _assets;

        public ConfigsService(IAssetsService assets)
        {
            _assets = assets;
        }

        public void Init()
        {
            Packs = LoadAll<SoundPack>("configs/sound_packs");
            Obstacles = LoadAll<Obstacle>("configs/obstacles");
            UserDefault = Load<User>("configs/user_default/user_default");

            foreach (var config in LoadAll<Config>("configs"))
            {
                var type = config.GetType();
                if (_all.TryGetValue(type, out var result))
                {
                    result.Add(config.Name, config);
                    return;
                }

                _all[type] = new Dictionary<string, Config> { [config.Name] = config };
            }
        }

        public T Get<T>(string name) where T : Config
        {
            return _all[typeof(T)][name] as T;
        }

        public IEnumerable<T> GetAll<T>() where T : Config
        {
            return _all
                .Where(x => x.Key == typeof(T) || x.Key.IsSubclassOf(typeof(T)))
                .SelectMany(x => x.Value.Values)
                .Select(x => x as T);
        }

        private IEnumerable<TConfig> LoadAll<TConfig>(string path) where TConfig : Object
        {
            return _assets.LoadAll<TConfig>(path);
        }

        private TConfig Load<TConfig>(string path) where TConfig : Object
        {
            return _assets.Load<TConfig>(path);
        }
    }
}