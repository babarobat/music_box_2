using Infrastructure;
using UnityEngine;

namespace Input
{
    public class InputSystem : ITick, IService
    {
        public Touch[] Touches => _inputDetector.Touches;
        public bool IsTouchOverGameObject => _inputDetector.IsTouchOverGameObject;
        public bool HasTouches => _inputDetector.Touches.Length > 0;

        private readonly IInputDetector _inputDetector;
        private readonly ITick _tick;

        public InputSystem()
        {
            if (UnityEngine.Application.isMobilePlatform)
            {
                _inputDetector = new MobileInput();
            }
            else
            {
                var standAloneInput = new StandaloneInput();
            
                _tick = standAloneInput;
                _inputDetector = standAloneInput;
            }
        }

        public void Tick(float deltaTime)
        {
            _tick?.Tick(deltaTime);
        }
    }
}