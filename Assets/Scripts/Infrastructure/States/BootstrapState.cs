using Configs;
using Input;
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

            Services.Register(new GameController(model));
            Services.Register(new InputService(_loop));
            Services.Register(new ScenesService(_coroutines));

            Services.Get<ScenesService>().Load("game");
        }

        public void Exit()
        {
        }
    }
}