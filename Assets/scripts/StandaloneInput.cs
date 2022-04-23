using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class StandaloneInput : IInputDetector, ITick
{
    public bool IsTouchOverGameObject => EventSystem.current.IsPointerOverGameObject();
    public Touch[] Touches { get; private set; } = Array.Empty<Touch>();
    
    private Vector3 _previousPosition;
    private bool _isMoved;

    public void Tick(float deltaTime)
    {
        Touches = GetTouches();
    }

    private Touch[] GetTouches()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
        {
            var currentPosition = Input.mousePosition;

            _isMoved = _previousPosition != currentPosition;

            if (_isMoved)
            {
                _previousPosition = currentPosition;
            }

            return new[]
            {
                new Touch
                {
                    position = _previousPosition,
                    phase = GetPhase(),
                }
            };
        }

        return Array.Empty<Touch>();
    }

    private TouchPhase GetPhase()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return TouchPhase.Began;
        }

        if (Input.GetMouseButtonUp(0))
        {
            return TouchPhase.Ended;
        }

        if (_isMoved)
        {
            return TouchPhase.Moved;
        }
        else
        {
            return TouchPhase.Stationary;
        }
    }
}