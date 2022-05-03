using System;
using Configs;
using Extensions;
using Infrastructure.Scenes;
using Infrastructure.Services.Configs;
using Models;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.States
{
    public class LoadProjectState : IPayloadState<ProjectModel>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IConfigsService _configs;
        private ProjectModel _project;

        public LoadProjectState(SceneLoader sceneLoader, IConfigsService configsService)
        {
            _configs = configsService;
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
                var quaternion = Quaternion.Euler(model.RotationData.X, model.RotationData.Y, model.RotationData.Z);
                var prefab =  model.ObstacleType switch
                {
                    ObstacleType.Cube => _configs.Get<Cube>(model.ObstacleName).Prefab,
                    ObstacleType.Cylinder => _configs.Get<Cylinder>(model.ObstacleName).Prefab,
                    ObstacleType.Spawner => _configs.Get<Spawner>(model.ObstacleName).Prefab,
                    _ => throw new ArgumentOutOfRangeException()
                };
                var obstacleView = Object.Instantiate(prefab, model.PositionData.ToVector3(), quaternion, root);
            }
        }

        public void Exit()
        {
        }
    }
}