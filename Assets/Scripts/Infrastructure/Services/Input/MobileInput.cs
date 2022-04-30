using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure.Services.Input
{
    public class MobileInput : IInputDetector
    {
        public bool IsTouchOverGameObject => EventSystem.current.IsPointerOverGameObject();
        public Touch[] Touches => UnityEngine.Input.touches;
    }
}