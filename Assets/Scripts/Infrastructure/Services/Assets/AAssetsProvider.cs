using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Services.Assets
{
    public abstract class AAssetsProvider
    {
        public abstract T Load<T>(string path) where T : Object;
        public abstract IEnumerable<T> LoadAll<T>(string path) where T : Object;
        
        public sealed class Resources: AAssetsProvider
        {
            public override T Load<T>(string path)
            {
                return UnityEngine.Resources.Load<T>(path);
            }

            public override IEnumerable<T> LoadAll<T>(string path)
            {
                return UnityEngine.Resources.LoadAll<T>(path);
            }
        }
    }
}