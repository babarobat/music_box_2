using System.Collections.Generic;
using Infrastructure.Services.Locator;
using UnityEngine;

namespace Infrastructure.Services.Assets
{
    public interface IAssetsService : IService
    {
        TConfig Load<TConfig>(string path) where TConfig : Object;
        IEnumerable<TConfig> LoadAll<TConfig>(string path) where TConfig : Object;
    }
}