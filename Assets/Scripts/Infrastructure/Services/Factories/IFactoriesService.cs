using Infrastructure.Services.Assets;
using Infrastructure.Services.Configs;
using Infrastructure.Services.Locator;

namespace Infrastructure.Services.Factories
{
    public interface IFactoriesService : IService
    {
        T For<T>() where T : AFactory;
        void Connect(IConfigsService configs, IAssetsService assets, GameController controller);
    }
}