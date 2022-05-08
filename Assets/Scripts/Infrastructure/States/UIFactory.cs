using Infrastructure.Services.Assets;
using Infrastructure.Services.Factories;
using Infrastructure.Services.UI;
using Infrastructure.Services.UI.Windows;
using UnityEngine;
using UserInterface;

namespace Infrastructure.States
{
    public class UIFactory : AFactory
    {
        private readonly IAssetsService _assets;
        private readonly WindowBinder _binder = new();
        private GameController _controller;

        public UIFactory(IAssetsService assets, GameController controller)
        {
            _assets = assets;
            _controller = controller;
        }

        public UIRoot CreateUIRoot()
        {
            return LoadAndInstantiate<UIRoot>("ui/common/root/ui_root");
        }

        public HudView CreateHud(Transform at)
        {
            var hud = LoadAndInstantiate<HudView>("ui/hud/hud", at);
            hud.Connect(_controller);
            return hud;
        }

        public TWindow CreateWindow<TWindow, TWindowData>(Transform at, TWindowData data)
            where TWindow : WindowBase<TWindow, TWindowData>
        {
            var window = LoadAndInstantiate<TWindow>(WindowAssets.Map[typeof(TWindow)], at);
            _binder.Bind(window, data);

            return window;
        }

        private T LoadAndInstantiate<T>(string from, Transform at = null) where T : Object
        {
            var prefab = _assets.Load<T>(from);
            return Object.Instantiate(prefab, at);
        }
    }
}