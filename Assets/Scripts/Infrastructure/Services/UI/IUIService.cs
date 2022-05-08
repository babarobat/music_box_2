using Infrastructure.Services.Factories;
using Infrastructure.Services.Locator;

namespace Infrastructure.Services.UI
{
    public interface IUIService : IService
    {
        void Init();
        public T At<T>() where T : class, IUIPart;
        void Connect(IFactoriesService factory);
    }
}