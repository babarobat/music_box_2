using UnityEngine;

namespace Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        public Touch[] Touches => _inputDetector.Touches;
        public bool IsTouchOverGameObject => _inputDetector.IsTouchOverGameObject;
        public bool HasTouches => _inputDetector.Touches.Length > 0;

        private IInputDetector _inputDetector;
        private ILoop _loop;
        private ITick _tick;

        public void Connect(ILoop loop)
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