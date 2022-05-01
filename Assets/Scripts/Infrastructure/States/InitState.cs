using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services.Configs;
using Infrastructure.Services.Model;
using Models;

namespace Infrastructure.States
{
    public class InitState : IState
    {
        private readonly IModelService _modelService;
        private readonly IConfigsService _configsService;
        private readonly GameStateMachine _state;

        public InitState(GameStateMachine state, IModelService modelService, IConfigsService configsService)
        {
            _modelService = modelService;
            _configsService = configsService;
            _state = state;
        }

        public void Enter()
        {
            if (_modelService.Model.User.Projects.IsEmpty)
            {
                AddDefaultProject();
            }

            _state.Enter<LoadProjectState, ProjectModel>(_modelService.Model.User.Projects.All.First());
        }
        
        private void AddDefaultProject()
        {
            _modelService.Model.ApplyChange(new ModelChange.ProjectsChange
            {
                Projects = new List<ModelChange.ProjectsChange.ProjectDTO>
                {
                    new ModelChange.ProjectsChange.ProjectDTO
                    {
                        Name = "New Project",
                        Obstacles = _configsService.UserDefault.LevelDefault.Obstacles
                            .Select(x => (x.Data, x.Position, x.Rotation)).ToList()
                    }
                }
            });
        }

        public void Exit()
        {
        }
    }
}