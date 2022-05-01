using Infrastructure;
using Infrastructure.Services;
using Infrastructure.Services.Locator;
using UnityEngine;

namespace Sound
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private GameController _controller;

        private void Awake()
        {
            _controller = ServiceLocator.Container.Get<GameController>();
        }

        private void Start()
        {
            _controller.Sound.OnPlaySound += OnPlaySound;
        }

        private void OnPlaySound(AudioClip data)
        {
            _audioSource.PlayOneShot(data);
        }
    }
}