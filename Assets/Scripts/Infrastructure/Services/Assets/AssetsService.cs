using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Infrastructure.Services.Assets
{
    public class AssetsService : IAssetsService
    {
        private readonly Dictionary<Type, AAssetsProvider> _providers;
        private readonly AAssetsProvider _defaultProvider;
        
        public AssetsService()
        {
            _providers = new Dictionary<Type, AAssetsProvider>
            {
                [typeof(AAssetsProvider.Resources)] = new AAssetsProvider.Resources(),
            };
            _defaultProvider = From<AAssetsProvider.Resources>();
        }

        public AAssetsProvider From<T>() where T : AAssetsProvider, new()
        {
            return _providers[typeof(T)];
        }

        public T Load<T>(string path) where T : Object
        {
            return _defaultProvider.Load<T>(path);
        }

        public IEnumerable<T> LoadAll<T>(string path) where T : Object
        {
            return _defaultProvider.LoadAll<T>(path);
        }
    }
}