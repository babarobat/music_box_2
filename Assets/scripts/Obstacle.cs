using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    private GameController _controller;
    
    public void Awake()
    {
        _controller = Services.Get<GameController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _controller.HandleCollide(_audioClip);
    }
}