using UnityEngine;

namespace Infrastructure.Services.Input
{
    public interface IInputDetector 
    {
        bool IsTouchOverGameObject { get;} 
        Touch[] Touches { get;} 
    }
}