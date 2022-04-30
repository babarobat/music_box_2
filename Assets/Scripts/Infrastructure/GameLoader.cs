using Configs;
using Input;
using Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UserInterface;

namespace Infrastructure
{
    public class GameLoader : MonoBehaviour
    {
        [SerializeField] private Lybrary _lybrary;
    
        private InputSystem _inputSystem;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            UI.SetLibrary(_lybrary);
        
            var model = new Model();
            model.ApplyChange(new ModelChange.SoundPacks { Packs = _lybrary.Packs });
            model.ApplyChange(new ModelChange.ObstaclesChange { Obstacles = _lybrary.Obstacles });

            _inputSystem = new InputSystem();

            Services.Register(new GameController(model));
            Services.Register(_inputSystem);

            SceneManager.LoadSceneAsync("game", LoadSceneMode.Additive);
        }

        private void Update()
        {
            _inputSystem.Tick(Time.deltaTime);
        }
    }
}