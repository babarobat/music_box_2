using Infrastructure;
using Infrastructure.Services.Locator;
using UnityEngine;

namespace Map
{
    public class ObstacleView : MonoBehaviour
    {
        private GameController _controller;

        public void Awake()
        {
            _controller = ServiceLocator.Container.Get<GameController>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _controller.HandleCollide(null);
        }
    }
}