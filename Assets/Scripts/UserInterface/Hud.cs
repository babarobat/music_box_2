using Windows;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private Button _soundPacksButton;

        private GameController _controller;

        private void Awake()
        {

            _controller = Services.Get<GameController>();
        
            _soundPacksButton.onClick.AddListener(OnSoundPacksClick);
        }
        
        private void OnSoundPacksClick()
        {
            _controller.OpenObstaclesWindow();
        }
    }
}