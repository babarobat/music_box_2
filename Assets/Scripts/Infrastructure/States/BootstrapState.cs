using Infrastructure.Services.Assets;
using Infrastructure.Services.Configs;
using Infrastructure.Services.Factories;
using Infrastructure.Services.Input;
using Infrastructure.Services.Locator;
using Infrastructure.Services.Models;
using Infrastructure.Services.UI;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _state;
        private readonly ServiceLocator _services;
        private readonly ILoop _loop;

        public BootstrapState(GameStateMachine state, ILoop loop, ServiceLocator services)
        {
            _services = services;
            _state = state;
            _loop = loop;

            _services.Register<IInputService>(new InputService());
            _services.Register<IAssetsService>(new AssetsService());
            _services.Register<IConfigsService>(new ConfigsService());
            _services.Register<IModelService>(new ModelService());
            _services.Register<IFactoriesService>(new FactoriesService());
            _services.Register<IUIService>(new UIService());
        }

        public void Enter()
        {
            _services.Register(new GameController());

            _services.Get<IInputService>().Connect(_loop);
            _services.Get<IConfigsService>().Connect(_services.Get<IAssetsService>());
            _services.Get<GameController>().Connect(_services.Get<IConfigsService>(), _services.Get<IUIService>());
            _services.Get<IFactoriesService>().Connect(_services.Get<IConfigsService>(),
                _services.Get<IAssetsService>(), _services.Get<GameController>());
            _services.Get<IUIService>().Connect(_services.Get<IFactoriesService>());

            _services.Get<IUIService>().Init();
            _services.Get<IConfigsService>().Init();
            _services.Get<IModelService>().Init();

            _state.Enter<InitState>();
        }

        public void Exit()
        {
        }
    }
}