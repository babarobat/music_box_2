using System;
using System.Collections.Generic;
using Models;
using UnityEngine;

namespace UserInterface.Windows
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
        public void HandleClick(ObstacleModel target)
        {
            Debug.Log($"[{GetType()}]: {target.Data.name} clicked");
        }
    }
}