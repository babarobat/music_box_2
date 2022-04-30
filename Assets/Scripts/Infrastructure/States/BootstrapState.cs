using Infrastructure.Services;
using Infrastructure.Services.Configs;
using Infrastructure.Services.Input;
using Infrastructure.Services.Scenes;
using Models;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly ILoop _loop;
        private readonly ICoroutinesRunner _coroutines;

        public BootstrapState(ILoop loop, ICoroutinesRunner coroutines)
        {
            _loop = loop;
            _coroutines = coroutines;
        }

        public void Enter()
        {
            var model = new Model();
            
            var scenesService = new ScenesService(_coroutines);
            var configsService = new ConfigsService();
            configsService.Init();
            
            AllServices.Register(new GameController(model));
            AllServices.Register<IInputService>(new InputService(_loop));
            AllServices.Register<IScenesService>(scenesService);
            AllServices.Register<IConfigsService>(configsService);

            model.ApplyChange(new ModelChange.SoundPacks { Packs = configsService.Packs });
            model.ApplyChange(new ModelChange.ObstaclesChange { Obstacles = configsService.Obstacles });

            scenesService.Load("game");
        }

        public void Exit()
        {
        }
    }
}