using System;
using Configs;
using Configs.Obstacles;
using Models;

namespace Extensions
{
    public static class ObstaclesExtensions
    {
        public static ObstacleType GetObstacleType(this Obstacle target)
        {
            return target switch
            {
                Cube _ => ObstacleType.Cube,
                Cylinder _ => ObstacleType.Cylinder,
                Spawner _ => ObstacleType.Spawner,
                _ => throw new ArgumentOutOfRangeException(nameof(target))
            };
        }
    }
}