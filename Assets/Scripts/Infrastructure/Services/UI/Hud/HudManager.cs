using Infrastructure.Services.Factories;
using Infrastructure.States;
using UnityEngine;
using UserInterface;

namespace Infrastructure.Services.UI.Hud
{
    public class HudManager : IUIPart
    {
        private HudView _hud;
        private Transform _root;
        
        private readonly IFactoriesService _factory;

        public HudManager(IFactoriesService factory)
        {
            _factory = factory;
        }

        public void SetRoot(Transform root)
        {
            _root = root;
        }

        public void Init()
        {
            _hud = _factory.For<UIFactory>().CreateHud(_root);
        }
    }
}