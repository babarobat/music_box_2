using System;
using Configs.Obstacles;

namespace UserInterface.Windows
{
    public struct ObstacleWindowElementContext
    {
        public Obstacle Data;

        public Action<Obstacle> OnClick;
    }
}