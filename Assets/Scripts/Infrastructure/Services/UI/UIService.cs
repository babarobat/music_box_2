using System;
using System.Collections.Generic;
using Infrastructure.Services.Factories;
using Infrastructure.Services.UI.Hud;
using Infrastructure.Services.UI.Windows;
using Infrastructure.States;
using Object = UnityEngine.Object;

namespace Infrastructure.Services.UI
{
    public class UIService : IUIService
    {
        private UIRoot _root;
        private IFactoriesService _factory;
        private Dictionary<Type, IUIPart> _components;

        public void Connect(IFactoriesService factory)
        {
            _factory = factory;

            _components = new Dictionary<Type, IUIPart>
            {
                [typeof(WindowsManager)] = new WindowsManager(_factory),
                [typeof(HudManager)] = new HudManager(_factory),
            };
        }

        public void Init()
        {
            _root = _factory.For<UIFactory>().CreateUIRoot();
            Object.DontDestroyOnLoad(_root);

            At<WindowsManager>().SetRoot(_root.WindowsRoot);
            At<HudManager>().SetRoot(_root.HudRoot);

            At<HudManager>().Init();
        }

        public T At<T>() where T : class, IUIPart
        {
            return _components[typeof(T)] as T;
        }
    }
}