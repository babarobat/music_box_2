using Configs;
using Infrastructure.Services;
using Infrastructure.Services.Input;
using Models;
using UnityEngine.SceneManagement;
using UserInterface;

namespace Infrastructure.States
{
    public class BootstrapState : IPayloadState<Library>
    {
        private readonly ILoop _loop;
        private readonly ICoroutinesRunner _coroutines;

        public BootstrapState(ILoop loop, ICoroutinesRunner coroutines)
        {
            _loop = loop;
            _coroutines = coroutines;
        }

        public void Enter(Library library)
        {
            UI.SetLibrary(library);

            var model = new Model();
            model.ApplyChange(new ModelChange.SoundPacks { Packs = library.Packs });
            model.ApplyChange(new ModelChange.ObstaclesChange { Obstacles = library.Obstacles });

            AllServices.Register(new GameController(model));
            AllServices.Register(new InputService(_loop));
            AllServices.Register(new ScenesService(_coroutines));

            AllServices.Get<ScenesService>().Load("game");
        }

        public void Exit()
        {
        }
    }
}