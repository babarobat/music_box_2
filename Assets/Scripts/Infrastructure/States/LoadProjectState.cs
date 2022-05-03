using Infrastructure.Scenes;
using Infrastructure.Services.Factories;
using Models;
using UnityEngine;

namespace Infrastructure.States
{
    public class LoadProjectState : IPayloadState<ProjectModel>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IFactoriesService _factory;

        private ProjectModel _project;

        public LoadProjectState(SceneLoader sceneLoader, IFactoriesService factory)
        {
            _factory = factory;
            _sceneLoader = sceneLoader;
        }

        public void Enter(ProjectModel project)
        {
            _project = project;
            _sceneLoader.Load("game", OnSceneLoaded);
        }

        private void OnSceneLoaded()
        {
            var root = GameObject.Find("map_objects").transform;
            foreach (var model in _project.Obstacles)
            {
                _factory.For<ObstaclesFactory>().CreateObstacle(model, root);
            }
        }

        public void Exit()
        {
        }
    }
}