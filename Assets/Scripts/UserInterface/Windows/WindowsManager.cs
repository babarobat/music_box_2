using System;
using Infrastructure.Services.Assets;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UserInterface.Windows
{
    [Obsolete("should be refactored. simplification needed")]
    public class WindowsManager
    {
        private IWindow _opened;
        private Transform _root;

        private readonly WindowBinder _binder = new();
        private IAssetsService _assets;

        public void SetRoot( Transform root)
        {
            _root = root;
        }

        public void Connect(IAssetsService assets)
        {
            _assets = assets;
        }
        
        public TWindow Open<TWindow, TWindowData>(TWindowData data)
            where TWindow: WindowBase<TWindow, TWindowData>
        {
            if (_opened is TWindow opened)
            {
                return opened;
            }

            var prefab = _assets.Load<TWindow>(WindowAssets.Map[typeof(TWindow)]);
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