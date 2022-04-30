using System;
using System.Collections;

namespace Infrastructure.Services.Scenes
{
    public interface IScenesService : IService
    {
        void Load(string name, Action onLoad = null);
        IEnumerator LoadInternal(string name, Action onLoad = null);
    }
}