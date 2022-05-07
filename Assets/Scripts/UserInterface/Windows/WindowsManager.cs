using UnityEngine;
using Object = UnityEngine.Object;

namespace UserInterface.Windows
{
    public class WindowsManager
    {
        private IWindow _opened;
        private Transform _root;

        private readonly WindowBinder _binder = new();

        public void SetRoot( Transform root)
        {
            _root = root;
        }
        
        public TWindow Open<TWindow, TWindowData>(TWindowData data)
            where TWindow: WindowBase<TWindow, TWindowData>
        {
            if (_opened is TWindow opened)
            {
                return opened;
            }

            var prefab = Resources.Load<TWindow>(WindowAssets.Map[typeof(TWindow)]);
            var window = Object.Instantiate(prefab, _root);

            _opened?.Close();
        
            window.Apply(_binder, data);

            window.gameObject.SetActive(true);
            _opened = window;

            return window;
        }
    
        public void Close(IWindow window)
        {
            if (_opened == window)
            {
                _opened.GameObject.SetActive(false);
                _opened = null;
            }
        }
    }
}