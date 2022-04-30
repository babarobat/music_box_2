using Infrastructure.Scenes;
using Models;
using UnityEngine;

namespace Infrastructure.States
{
    public class LoadProjectState : IPayloadState<ProjectModel>
    {
        private readonly SceneLoader _sceneLoader;
        private ProjectModel _project;

        public LoadProjectState(SceneLoader sceneLoader)
        {
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
                var rotation = Quaternion.Euler(model.Rotation.x, model.Rotation.y, model.Rotation.z);
                var obstacleView = Object.Instantiate(model.Data.Prefab, model.Position, rotation, root);
            }
        }

        public void Exit()
        {
        }
    }
}