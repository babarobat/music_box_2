using Infrastructure.Services.Locator;

namespace Infrastructure.Services.Factories
{
    public interface IFactoriesService : IService
    {
        T For<T>() where T : AFactory;
    }
}