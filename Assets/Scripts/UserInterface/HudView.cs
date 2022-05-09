using Infrastructure;
using UnityEngine;

namespace UserInterface
{
    public class HudView : MonoBehaviour
    {
        [SerializeField] private UIButton _obstaclesButton;

        private GameController _controller;

        private void Awake()
        {
            _obstaclesButton.OnClick += OnObstaclesButtonClick;
        }

        public void Connect(GameController controller)
        {
            _controller = controller;
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