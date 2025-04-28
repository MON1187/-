using UnityEngine;
using UnityEngine.UIElements;

using GhostEvilRation.Function.GameScenes;
using UnityEngine.SceneManagement;

public class ButtonFunction :  MonoBehaviour
{
    #region
    [Header("Load Scens Strig")]
    public string loadScene;
    public string unLoadScene;

    [Header("Option")]
    public GameObject optionAnnexationObject;

    [Header("Exit")]
    public GameObject exitPanel;

    [SerializeField] UIManager uiManager;

    public void B_Start()
    {
        GameManager.Instance.PlayScene(loadScene);
        GameManager.Instance.UnloadCurrentScene(unLoadScene);
    }
    public void B_Option()
    {
        Debug.Log("Round 2");

        uiManager.listorder.Add(optionAnnexationObject);
        uiManager.UB_Option_GameGraphic();
        optionAnnexationObject.SetActive(true);
    }

    // ������ Ȯ���ϱ� ���� �Լ�
    public void B_ExitCheack()
    {
        Debug.Log("Round 3");

        exitPanel.SetActive(true);
    }

    //���� �Ͻ� on, �ƴҽ� off
    public void B_ExitOn()
    {
        Application.Quit();
    }
    public void B_ExitOff()
    {
        exitPanel.SetActive(false);
    }
    #endregion
}
