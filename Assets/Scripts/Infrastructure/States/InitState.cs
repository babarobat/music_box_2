using System.Linq;
using Infrastructure.Services.Configs;
using Infrastructure.Services.Models;
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
                _modelService.Save();
            }
            
            _state.Enter<LoadProjectState, ProjectModel>(_modelService.Model.User.Projects.All.First());
        }
        
        private void AddDefaultProject()
        {
            var defaultLevel = _configsService.UserDefault.LevelDefault;
            var projectModel = _modelService.Model.User.Projects.Create(defaultLevel.Visual.Name);
            projectModel.AddObstacles(defaultLevel.Obstacles);
        }

        public void Exit()
        {
        }
    }
}