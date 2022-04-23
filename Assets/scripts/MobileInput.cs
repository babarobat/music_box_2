using UnityEngine;
using UnityEngine.EventSystems;

public class MobileInput : IInputDetector
{
    public bool IsTouchOverGameObject => EventSystem.current.IsPointerOverGameObject();
    public Touch[] Touches => Input.touches;
}