using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UserInterface
{
    public class UIButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnClick;
        public event Action OnDown;
        public event Action OnUp;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            OnDown?.Invoke();
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            OnUp?.Invoke();
        }
    }
}