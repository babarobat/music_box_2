using System;
using UnityEngine;

namespace Infrastructure.Services.UI.Windows
{
    public abstract class WindowBase<TWindow, TWindowData> : MonoBehaviour, IWindow
        where TWindow : WindowBase<TWindow, TWindowData>
    {
        public event Action<IWindow> OnClosed;
        public event Action OnOpenEvent;
        public GameObject GameObject => gameObject;

        public void Close()
        {
            OnClose(()=> OnClosed?.Invoke(this));
        }
        public void Open()
        {
            OnOpen();
        }

        protected virtual void OnClose(Action onCloseComplete) => onCloseComplete.Invoke();
        protected virtual void OnOpen(){}
    }
}