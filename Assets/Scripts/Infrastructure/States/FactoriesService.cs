using System;
using System.Collections.Generic;
using Infrastructure.Services.Assets;
using Infrastructure.Services.Configs;
using Infrastructure.Services.Factories;

namespace Infrastructure.States
{
    public class FactoriesService : IFactoriesService
    {
        private Dictionary<Type, AFactory> _factories;

        public void Connect(IConfigsService configs, IAssetsService assets, GameController controller)
        {
            _factories = new Dictionary<Type, AFactory>
            {
                [typeof(ObstaclesFactory)] = new ObstaclesFactory(configs),
                [typeof(UIFactory)] = new UIFactory(assets, controller),
            };
        }

        public T For<T>() where T : AFactory
        {
            return _factories[typeof(T)] as T;
        }
    }
}