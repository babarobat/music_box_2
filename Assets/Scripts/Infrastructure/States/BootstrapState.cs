using Infrastructure.Services;
using Infrastructure.Services.Configs;
using Infrastructure.Services.Input;
using Infrastructure.Services.Locator;
using Infrastructure.Services.Model;
using Models;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _state;
        private readonly ServiceLocator _services;

        public BootstrapState(GameStateMachine state, ILoop loop, ServiceLocator services)
        {
            _services = services;
            _state = state;
            
            _services.Register<IModelService>(new ModelService(new Model()));
            _services.Register<IInputService>(new InputService(loop));
            _services.Register<IConfigsService>(new ConfigsService());
            
            _services.Register(new GameController(_services.Get<IConfigsService>()));
        }

        public void Enter()
        {
            _services.Get<IConfigsService>().Init();
            _services.Get<IModelService>().Init();
            
            _state.Enter<InitState>();
        }

        public void Exit()
        {
        }
    }
}