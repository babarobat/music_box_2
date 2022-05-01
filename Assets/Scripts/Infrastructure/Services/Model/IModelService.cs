using Infrastructure.Services.Locator;

namespace Infrastructure.Services.Model
{
    public interface IModelService : IService
    {
        Models.Model Model { get; }
        void Init();
    }
}