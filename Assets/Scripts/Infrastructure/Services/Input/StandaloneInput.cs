using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure.Services.Input
{
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
            if (UnityEngine.Input.GetMouseButton(0) || UnityEngine.Input.GetMouseButtonUp(0))
            {
                var currentPosition = UnityEngine.Input.mousePosition;

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
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                return TouchPhase.Began;
            }

            if (UnityEngine.Input.GetMouseButtonUp(0))
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
}