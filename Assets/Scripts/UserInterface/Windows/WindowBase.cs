using System;
using UnityEngine;

namespace UserInterface.Windows
{
    public abstract class WindowBase<TWindow,TWindowData> : MonoBehaviour, IWindow where TWindow : WindowBase<TWindow, TWindowData>
    {
        public void Apply(WindowBinder binder, TWindowData data)
        {
            switch (this)
            {
                case ObstaclesWindow window: binder.Bind(window, data as ObstaclesWindowData); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
        public GameObject GameObject => gameObject;
        public void Close()
        {
            UI.Windows.Close(this);
        }

        public static TWindow Open(TWindowData data) 
            => UI.Windows.Open<TWindow, TWindowData>(data);
    
    

    }
}