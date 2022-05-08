using System;
using UnityEngine;

namespace Infrastructure.Services.UI.Windows
{
    public interface IWindow
    {
        GameObject GameObject { get; }
        void Close();
        void Open();
        event Action<IWindow> OnClosed;
        public event Action OnOpenEvent;
    }
}