using System;
using System.Collections;
using System.Collections.Generic;

//Untiy
using UnityEngine;

namespace GhostEvilRation.Function.GameScenes
{
    public class CurrentSceneSaveData : MonoBehaviour
    {
        [SerializeField] private List<string> loadScenesData = new List<string>();
        [SerializeField] private List<string> currentSaveScenesData =new List<string>();

        public void NextChapterLoadScenes()
        {
            GameManager.Instance.PlayFadeOut();
            GameManager.Instance.PlayScene(loadScenesData);
        }

        public void UnChapterLoadScenes()
        {
            GameManager.Instance.UnloadCurrentScene(currentSaveScenesData);
        }
    }

}
