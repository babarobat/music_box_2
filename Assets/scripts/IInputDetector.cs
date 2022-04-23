using UnityEngine;

public interface IInputDetector 
{
    bool IsTouchOverGameObject { get;} 
    Touch[] Touches { get;} 
}