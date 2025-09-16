using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace EventBus
{
    public class LoadingScreen : MonoBehaviour
    {
        public Slider _progressBar;

        public TMP_Text _loadingText;

        private string _sceneLoading;

        private GameState _stateToLoad;

        private float _animationDelay = 2f;



        private void Awake()
        {
            StartAsyncLoading();
        }


        public void StartAsyncLoading()
        {
            Time.timeScale = 1;

            _sceneLoading = LoadingScene.Instance._sceneToLoad;
            _stateToLoad = LoadingScene.Instance._stateToLoad;

            StartCoroutine(LoadSceneAsync());
        }


        IEnumerator LoadSceneAsync()
        {
            AsyncOperation gameScene = SceneManager.LoadSceneAsync(_sceneLoading);

            gameScene.allowSceneActivation = false;
            
            float targetProgress = 0f;

            while (!gameScene.isDone)
            {
                if (gameScene.progress >= 0.9f)
                {
                    targetProgress = 1f;
                }
                else
                {
                    targetProgress = Mathf.Clamp01(gameScene.progress / 0.9f);
                }

                if (_progressBar != null)
                {
                    _progressBar.value = Mathf.Lerp(_progressBar.value, targetProgress, Time.deltaTime * _animationDelay);
                }

                if (_loadingText != null)
                {
                    _loadingText.text = (_progressBar.value * 100F).ToString("F0") + "%";
                }

                if (gameScene.progress >= 0.9f && _progressBar.value >= 0.99f)
                {
                    if (GameManager.Instance != null)
                    {
                        GameManager.Instance.ChangeGameState(_stateToLoad);
                    }

                    gameScene.allowSceneActivation = true;
                }
                Debug.Log(_sceneLoading);
                yield return null;

            }
        }

    }

}
