using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GhostEvilRation.Function.GameScenes;
public class ChapterPlayGameManger : MonoBehaviour
{
    public CurrentSceneSaveData currentScenesSaveData;

    /// <summary>
    /// 직접 할당해야하는 변수

    [Header("hid room Resource")]
    public GameObject[] hidRoom;
    /// </summary>

    private void Start()
    {
        foreach (GameObject room in hidRoom)
        GraduallyVisible(room);
    }
    public void GraduallyVisible(GameObject visObject)
    {
        visObject.SetActive(true);
    }
}
