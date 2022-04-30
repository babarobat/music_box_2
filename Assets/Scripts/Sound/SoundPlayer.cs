using Infrastructure;
using Infrastructure.Services;
using UnityEngine;

namespace Sound
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private GameController _controller;

        private void Awake()
        {
            _controller = AllServices.Get<GameController>();
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