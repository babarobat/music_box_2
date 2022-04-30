using Infrastructure.Services.Scenes;

namespace Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load("game");
        }

        public void Exit()
        {
        }
    }
}