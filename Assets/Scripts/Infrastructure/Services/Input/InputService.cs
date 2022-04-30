using UnityEngine;

namespace Infrastructure.Services.Input
{
    public class InputService : IService
    {
        public Touch[] Touches => _inputDetector.Touches;
        public bool IsTouchOverGameObject => _inputDetector.IsTouchOverGameObject;
        public bool HasTouches => _inputDetector.Touches.Length > 0;

        private readonly IInputDetector _inputDetector;
        private readonly ILoop _loop;
        private readonly ITick _tick;

        public InputService(ILoop loop)
        {
            _loop = loop;
            
            if (Application.isMobilePlatform)
            {
                _inputDetector = new MobileInput();
            }
            else
            {
                var standAloneInput = new StandaloneInput();
            
                _tick = standAloneInput;
                _inputDetector = standAloneInput;
            }

            _loop.OnTick += OnTick;
        }

        private void OnTick(float deltaTime)
        {
            _tick?.Tick(deltaTime);
        }
    }
}