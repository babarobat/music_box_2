using Infrastructure;
using Infrastructure.Services.Locator;
using UnityEngine;

namespace UserInterface
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private UIButton _obstaclesButton;

        private GameController _controller;

        private void Awake()
        {
            _controller = ServiceLocator.Container.Get<GameController>();
        
            _obstaclesButton.OnClick += OnObstaclesButtonClick;
        }
        
        private void OnObstaclesButtonClick()
        {
            _controller.OpenObstaclesWindow();
        }

        private void OnDestroy()
        {
            _obstaclesButton.OnClick -= OnObstaclesButtonClick;
        }
    }
}