using Infrastructure.Services.Locator;
using Models;

namespace Infrastructure.Services.Models
{
    public interface IModelService : IService
    {
        Model Model { get; }
        void Init();
        void Save();
    }
}