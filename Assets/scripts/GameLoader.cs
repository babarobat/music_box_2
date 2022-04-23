using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        Services.Register(new GameController());

        SceneManager.LoadSceneAsync("game", LoadSceneMode.Additive);
    }
}
