using System;
using Models;

namespace UserInterface.Windows
{
    public struct ObstacleWindowElementContext
    {
        public ObstacleModel Model;

        public Action<ObstacleModel> OnClick;
    }
}