using UnityEngine;

namespace Input
{
    public interface IInputDetector 
    {
        bool IsTouchOverGameObject { get;} 
        Touch[] Touches { get;} 
    }
}