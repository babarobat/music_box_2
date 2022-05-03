using System.Linq;
using Infrastructure.Services.Input;
using Infrastructure.Services.Locator;
using UnityEngine;

namespace Map
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _dragSpeed = 25;
    
        private IInputService _input;
        private bool _isDragging;
        private Vector3 _cameraStartPos;
        private Vector3 _dragStartPos;
        private Vector3 _touchPosition;
    
        private Vector3 TouchPosition
        {
            get
            {
                if (!_input.Touches.Any())
                {
                    return Vector3.zero;
                }

                _touchPosition.x = _input.Touches[0].position.x;
                _touchPosition.y = _input.Touches[0].position.y;
                _touchPosition.z = _camera.nearClipPlane;

                return _touchPosition;
            }
        }

        private void Awake()
        {
            _input = ServiceLocator.Container.Get<IInputService>();
        }
    
        private void Update()
        {
            if (_input.Touches.Length == 1 && !_input.IsTouchOverGameObject && _input.Touches[0].phase == TouchPhase.Began)
            {
                if (!_isDragging)
                {
                    _dragStartPos = TouchPosition;
                    _cameraStartPos = transform.position;
                }

                _isDragging = true;
            }

            if (!_input.Touches.Any())
            {
                _isDragging = false;
            }

            if (!_isDragging)
            {
                return;
            }

            var startToWorld = _camera.ScreenToWorldPoint(_dragStartPos);
            var mouseToWorld = _camera.ScreenToWorldPoint(TouchPosition);
            var difference = (Vector2)(mouseToWorld - startToWorld);

            transform.position = _cameraStartPos + (Vector3)difference * (_dragSpeed * -1);
        }
    }
}