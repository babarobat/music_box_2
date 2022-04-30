using System.Collections.Generic;
using System.Linq;
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

            AllServices.Register(new GameController(configsService));

            AllServices.Register<IInputService>(new InputService(_loop));
            AllServices.Register<IConfigsService>(configsService);

            model.ApplyChange(new ModelChange.ProjectsChange
            {
                Projects = new List<ModelChange.ProjectsChange.ProjectDTO>
                {
                    new ModelChange.ProjectsChange.ProjectDTO
                    {
                        Name = "New Project",
                        Obstacles = configsService.UserDefault.DefaultLevel.Obstacles.Select(x => (x.Data, x.Position, x.Rotation)).ToList()
                    }
                }
            });

            _state.Enter<LoadProjectState, ProjectModel>(model.User.Projects.First());
        }

        public void Exit()
        {
        }
    }
}