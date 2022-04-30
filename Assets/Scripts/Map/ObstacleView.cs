using Infrastructure;
using Infrastructure.Services;
using UnityEngine;

namespace Map
{
    public class ObstacleView : MonoBehaviour
    {
        private GameController _controller;

        public void Awake()
        {
            _controller = AllServices.Get<GameController>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _controller.HandleCollide(null);
        }
    }
}