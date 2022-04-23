using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    private InputSystem _inputSystem;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _inputSystem = new InputSystem();

        Services.Register(new GameController());
        Services.Register(_inputSystem);

        SceneManager.LoadSceneAsync("game", LoadSceneMode.Additive);
    }

    private void Update()
    {
        _inputSystem.Tick(Time.deltaTime);
    }
}