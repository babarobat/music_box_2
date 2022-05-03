using System;
using Configs.Obstacles;
using Extensions;
using Infrastructure.Services.Configs;
using Models;
using UnityEngine;
using Object = UnityEngine.Object;
using Spawner = Configs.Obstacles.Spawner;

namespace Infrastructure.Services.Factories
{
    public class ObstaclesFactory : AFactory
    {
        private readonly IConfigsService _configs;

        public ObstaclesFactory(IConfigsService configs)
        {
            _configs = configs;
        }

        public GameObject CreateObstacle(ObstacleMapModel model, Transform root)
        {
            var quaternion = Quaternion.Euler(model.RotationData.X, model.RotationData.Y, model.RotationData.Z);
            var prefab = GetPrefab(model);
            return Object.Instantiate(prefab, model.PositionData.ToVector3(), quaternion, root);
        }

        private GameObject GetPrefab(ObstacleMapModel model)
        {
            return model.ObstacleType switch
            {
                ObstacleType.Cube => GetPrefab<Cube>(model),
                ObstacleType.Cylinder => GetPrefab<Cylinder>(model),
                ObstacleType.Spawner => GetPrefab<Spawner>(model),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private GameObject GetPrefab<T>(ObstacleMapModel model) where T : Obstacle
        {
            return _configs.Get<T>(model.ObstacleName).Prefab;
        }
    }
}