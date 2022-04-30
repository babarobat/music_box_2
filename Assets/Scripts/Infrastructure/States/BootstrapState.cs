using Configs;
using Input;
using Models;
using UnityEngine.SceneManagement;
using UserInterface;

namespace Infrastructure.States
{
    public class BootstrapState : IPayloadState<Library>
    {
        private ILoop _loop;

        public BootstrapState(ILoop loop)
        {
            _loop = loop;
        }

        public void Enter(Library library)
        {
            UI.SetLibrary(library);
            
            var model = new Model();
            model.ApplyChange(new ModelChange.SoundPacks { Packs = library.Packs });
            model.ApplyChange(new ModelChange.ObstaclesChange { Obstacles = library.Obstacles });
            
            Services.Register(new GameController(model));
            Services.Register(new InputService(_loop));
            
            SceneManager.LoadSceneAsync("game", LoadSceneMode.Additive);
        }

        public void Exit()
        {
        }
    }
}