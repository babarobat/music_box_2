using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Scenes
{
    public class SceneLoader 
    {
        private readonly ICoroutinesRunner _coroutinesRunner;
        public SceneLoader(ICoroutinesRunner coroutinesRunner)
        {
            _coroutinesRunner = coroutinesRunner;
        }

        public void Load(string name, Action onLoad = null)
        {
            if (IsSceneLoaded(name))
            {
                onLoad?.Invoke();
                return;
            }

            _coroutinesRunner.StartCoroutine(LoadInternal(name, onLoad));
        }

        private static bool IsSceneLoaded(string name) => SceneManager.GetActiveScene().name == name;

        public IEnumerator LoadInternal(string name, Action onLoad = null)
        {
            var sceneLoadingHandle = SceneManager.LoadSceneAsync(name);
            yield return new WaitUntil(() => sceneLoadingHandle.isDone);
            onLoad?.Invoke();
        }
    }
}