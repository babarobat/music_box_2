using Infrastructure;
using UnityEngine;

namespace Map
{
    public class ObstacleView : MonoBehaviour
    {
        private GameController _controller;

        public void Awake()
        {
            _controller = Services.Get<GameController>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _controller.HandleCollide(null);
        }
    }
}