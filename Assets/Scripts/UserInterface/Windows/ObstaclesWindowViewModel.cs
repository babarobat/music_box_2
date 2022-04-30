using System;
using System.Collections.Generic;
using Configs;
using UnityEngine;

namespace UserInterface.Windows
{
    public class ObstaclesWindowViewModel
    {
        public ReactiveField<string> Title ;
        public IEnumerable<Obstacle> Obstacles;
        public event Action OnObstaclesChanged;
        
        public ObstaclesWindowViewModel(ObstaclesWindowData data)
        {
            Title = new ReactiveField<string>(data.Title);
            Obstacles = data.Obstacles;
        }
        public void HandleClick(Obstacle target)
        {
            Debug.Log($"[{GetType()}]: {target.name} clicked");
        }
    }
}