//System
using System;
using System.Collections.Generic;
using System.Collections;

//Unity
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GhostEvilRation.Function;
    
namespace GhostEvilRation.Function.GameScenes
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public WorldManager worldManager;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }

            Application.runInBackground = true;
            if (loadingBarOjbect != null) loadingBarOjbect.SetActive(false);
            if (loadingBarOjbect != null) fadeObject.SetActive(false);
        }

        [SerializeField] List<string> currentMapScene = new List<string>();
        [SerializeField] List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

        public GameObject loadingBarOjbect;
        public Image loadingBarSlider;
        public GameObject fadeObject;
        public CanvasGroup fadeCanvasGroup;

        private bool isFade;

        #region Load
        public void PlayScene(string loadScene)
        {
            SceneManager.LoadSceneAsync(loadScene,LoadSceneMode.Additive);
            currentMapScene.Add(loadScene);
        }
        public void PlayScene(List<string> loadScenes)
        {
            foreach (var scene in loadScenes) {
                SceneManager.LoadSceneAsync(scene,LoadSceneMode.Additive);

                if(currentMapScene.Contains(scene))
                currentMapScene.Add(scene);
            }
        }
        #endregion

        #region UnLoad
        public void UnloadCurrentScene(List<string> loadScenes)
        {
            foreach (var scene in currentMapScene)
            {
                try
                {
                    SceneManager.UnloadSceneAsync(scene);
                    currentMapScene.Remove(scene);
                }
                finally
                {
                    Debug.LogError($"none Field : {scene}");
                }
            }
        }
        public void UnloadCurrentScene()
        {
            foreach (var scenes in currentMapScene)
            {
                Debug.Log(scenes);
                SceneManager.UnloadSceneAsync(scenes);
                currentMapScene.Remove(scenes);
            }
        }
        public void UnloadCurrentScene(string unloadScene)
        {
            SceneManager.UnloadSceneAsync(unloadScene);
            currentMapScene.Remove(unloadScene);
        }
        #endregion

        #region
        // ���� = FadeIn -> FadeOut -> Loading

        public void PlayFadeIn()
        {
            StartCoroutine(FadeIn());
        }
        private IEnumerator FadeIn()
        {
            fadeObject.SetActive(true);
            float fadeDuration = 1f; // ���̵� �� ���� �ð�
            float startTime = Time.time;

            isFade = true;

            // ���̵� �� ȿ��
            while (Time.time - startTime < fadeDuration)
            {
                fadeCanvasGroup.alpha = Mathf.Lerp(1f, 0f, (Time.time - startTime) / fadeDuration);
                yield return null;
            }

            fadeCanvasGroup.alpha = 0f;

            isFade = false;

            //UnloadCurrentScene();
            //StartCoroutine(PlayLoadingScenes());
            PlayFadeOut();
        }

        private IEnumerator PlayLoadingScenes()
        {
            loadingBarOjbect.SetActive(true);
            float loadProgres = 0f;
            
            for (int i = 0; i < scenesToLoad.Count; i++)
            {
                while(!scenesToLoad[i].isDone)
                {
                    loadProgres += scenesToLoad[i].progress;
                    loadingBarSlider.fillAmount = loadProgres;
                    yield return null;
                }
            }

            PlayFadeOut();
        }

        public void PlayFadeOut()
        {
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeOut()
        {
            float fadeDuration = 1f;
            float startTime = Time.time;

            // ���̵� �ƿ� ȿ��
            while (Time.time - startTime < fadeDuration)
            {
                fadeCanvasGroup.alpha = Mathf.Lerp(0f, 1f, (Time.time - startTime) / fadeDuration);
                yield return 0;
            }

            fadeCanvasGroup.alpha = 1f;

            fadeObject.SetActive(false);
        }

        /// <summary>
        /// ���� ���̵� ������ Ȯ�� ( �ϰ��ִٸ� True, �ƴ϶�� False)
        /// </summary>
        /// <returns></returns>
        public bool IsProgress()
        {
            return isFade;
        }
        #endregion
    }

}
