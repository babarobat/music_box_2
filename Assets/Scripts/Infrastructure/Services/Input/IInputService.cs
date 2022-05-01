using Infrastructure.Services.Locator;
using UnityEngine;

namespace Infrastructure.Services.Input
{
    public interface IInputService : IService
    {
        Touch[] Touches { get; }
        bool IsTouchOverGameObject { get; }
        bool HasTouches { get; }
    }
}