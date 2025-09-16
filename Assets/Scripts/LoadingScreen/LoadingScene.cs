using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace EventBus
{
    public class LoadingScene : PersistentSingleton<LoadingScene>
    {
        public string _sceneToLoad { get; private set; }
        public GameState _stateToLoad { get; private set; }



    public void LoadSceneWithLs(string sceneName, GameState loadingState)
        {

            _sceneToLoad = sceneName;
            _stateToLoad = loadingState;

            SceneManager.LoadScene(SceneList.LoadingScreen);
        }

    }
}
