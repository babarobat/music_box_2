using UnityEngine;

namespace UserInterface
{
    [RequireComponent(typeof(UIButton))]
    public class UIButtonPressAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform _animatedRect;
        [SerializeField] private GameObject _pressedContainer;
        [SerializeField] private GameObject _normalContainer;

        private Vector3 _startScale;

        private void Awake()
        {
            _startScale = _animatedRect.localScale;

            var target = GetComponent<UIButton>();

            target.OnDown += OnPointerDown;
            target.OnUp += OnPointerUp;
        }
        
        private void OnPointerUp()
        {
            if (_animatedRect != null)
            {
                _animatedRect.localScale = _startScale;
            }

            if (_normalContainer != null)
            {
                _normalContainer.SetActive(true);
            }

            if (_pressedContainer != null)
            {
                _pressedContainer.SetActive(false);
            }
        }

        private void OnPointerDown()
        {
            if (_animatedRect != null)
            {
                _animatedRect.localScale = _startScale * 0.9f;
            }

            if (_normalContainer != null)
            {
                _normalContainer.SetActive(false);
            }

            if (_pressedContainer != null)
            {
                _pressedContainer.SetActive(true);
            }
        }
    }
}