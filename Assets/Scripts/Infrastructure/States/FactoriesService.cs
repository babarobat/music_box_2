using System;
using System.Collections.Generic;
using Infrastructure.Services.Configs;
using Infrastructure.Services.Factories;

namespace Infrastructure.States
{
    public class FactoriesService : IFactoriesService
    {
        private readonly Dictionary<Type, AFactory> _factories;

        public FactoriesService(IConfigsService configs)
        {
            _factories = new Dictionary<Type, AFactory>
            {
                [typeof(ObstaclesFactory)] = new ObstaclesFactory(configs),
            };
        }

        public T For<T>() where T : AFactory
        {
            return _factories[typeof(T)] as T;
        }
    }
}