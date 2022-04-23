using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;

    private GameController _controller;

    private void Awake()
    {
        _controller = Services.Get<GameController>();
    }

    private void Start()
    {
        _controller.Sound.OnPlaySound += OnPlaySound;
    }

    private void OnPlaySound(SoundData data)
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}

public class SoundData
{
    public AudioClip AudioClip;
}
