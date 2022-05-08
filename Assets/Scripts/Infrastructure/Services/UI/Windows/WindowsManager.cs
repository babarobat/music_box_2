using Infrastructure.Services.Factories;
using Infrastructure.States;
using UnityEngine;

namespace Infrastructure.Services.UI.Windows
{
    public class WindowsManager : IUIPart
    {
        private IWindow _opened;
        private Transform _root;

        private readonly IFactoriesService _factory;

        public WindowsManager(IFactoriesService factory)
        {
            _factory = factory;
        }

        public void SetRoot(Transform root)
        {
            _root = root;
        }

        public TWindow Open<TWindow, TWindowData>(TWindowData data)
            where TWindow : WindowBase<TWindow, TWindowData>
        {
            if (_opened is TWindow opened)
            {
                return opened;
            }

            var window = _factory.For<UIFactory>().CreateWindow<TWindow, TWindowData>(_root, data);

            _opened?.Close();

            window.OnClosed += OnWindowClosed;
            window.GameObject.SetActive(true);
            window.Open();
            
            _opened = window;

            return window;
        }

        private void OnWindowClosed(IWindow window)
        {
            if (_opened == window)
            {
                _opened = null;
            }
            
            window.GameObject.SetActive(false);
            window.OnClosed -= OnWindowClosed;
        }
    }
}