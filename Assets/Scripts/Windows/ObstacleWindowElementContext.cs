using System;
using Models;

namespace Windows
{
    public struct ObstacleWindowElementContext
    {
        public ObstacleModel Model;

        public Action<ObstacleModel> OnClick;
    }
}