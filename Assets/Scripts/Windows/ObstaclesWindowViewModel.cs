using System;
using System.Collections.Generic;
using Models;

namespace Windows
{
    public class ObstaclesWindowViewModel
    {
        public ReactiveField<string> Title ;
        public IEnumerable<ObstacleModel> Obstacles;

        public Action OnObstaclesChanged;

        public ObstaclesWindowViewModel(ObstaclesWindowData data)
        {
            Title = new ReactiveField<string>(data.Title);
            Obstacles = data.Obstacles;
        }
    }
}