using Infrastructure.Services;
using Infrastructure.Services.Configs;
using Infrastructure.Services.Input;
using Models;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly ILoop _loop;
        private readonly ICoroutinesRunner _coroutines;
        private GameStateMachine _state;

        public BootstrapState(GameStateMachine state, ILoop loop, ICoroutinesRunner coroutines)
        {
            _loop = loop;
            _coroutines = coroutines;
            _state = state;
        }

        public void Enter()
        {
            var model = new Model();

            var configsService = new ConfigsService();
            configsService.Init();

            AllServices.Register(new GameController(model));

            AllServices.Register<IInputService>(new InputService(_loop));
            AllServices.Register<IConfigsService>(configsService);

            model.ApplyChange(new ModelChange.SoundPacks { Packs = configsService.Packs });
            model.ApplyChange(new ModelChange.ObstaclesChange { Obstacles = configsService.Obstacles });

            _state.Enter<LoadLevelState>();
        }

        public void Exit()
        {
        }
    }
}