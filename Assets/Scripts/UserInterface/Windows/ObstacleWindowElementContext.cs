using System;
using Configs;

namespace UserInterface.Windows
{
    public struct ObstacleWindowElementContext
    {
        public Obstacle Data;

        public Action<Obstacle> OnClick;
    }
}