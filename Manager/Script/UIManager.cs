using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Option Object")]
    [SerializeField] private GameObject currentUI;
    [SerializeField] private GameObject optGraphic,optController,optSound;

    [Header("Achievement")]
    [SerializeField] private GameObject pieceAchievementUI;

    public List<GameObject> listorder = new List<GameObject>();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            listorder[listorder.Count - 1].SetActive(false);
            listorder.Remove(listorder[listorder.Count-1]); 
            currentUI = null;
        }
    }

    #region Option Regino
    public void UB_Option_GameGraphic() //�׷���
    {
        if (currentUI != null) { currentUI.SetActive(false); }      //���� ���� ui�� �ִٸ� �ش� UI�� ��Ȱ�� ��Ų��.
        currentUI = optGraphic;                                     //���� Ȱ��ȭ UI�� ����
        ADDBackOrder();
        optGraphic.SetActive(true);                                 //UIȰ��ȭ
    }

    public void UB_Option_Controller()  //��Ʈ�ѷ�
    {
        if (currentUI != null) { currentUI.SetActive(false); }
        currentUI = optController;
        ADDBackOrder();
        optController.SetActive(true);
    }
    public void UB_Option_Sound()       //����
    {
        if (currentUI != null) { currentUI.SetActive(false); }
        currentUI = optSound;
        ADDBackOrder();
        optSound.SetActive(true);
    }
    //public void B_Option_?()
    //{
        
    //}

    private void ADDBackOrder()
    {
        listorder.Add(currentUI);
        listorder.Remove(listorder[listorder.Count-1]);
    }
    #endregion

    #region Option->Sound
    
    [Header("Option -> Sound")]
    [SerializeField] private Slider sMain,sSFX, sBGM;
    
    public void US_SoundMaster(float volume)
    {
        SoundManager.Instance.S_VolumeManagement(AudioType.Master, volume);
    }
    public void US_SoundBGM(float volume)
    {
        SoundManager.Instance.S_VolumeManagement(AudioType.BGM, volume);
    }
    public void US_SoundSFX(float volume)
    {
        SoundManager.Instance.S_VolumeManagement(AudioType.SFX, volume);
    }

    #endregion

    #region Option -> GameGraphisc
    [Header("Option -> GameGraphisc")]
    private GameObject a;

    #endregion

    #region Option ->
    [Header("Option -> GameGraphisc")]
    private GameObject b;

    #endregion

    #region Achievement Piece

    public void OnPiecePanel()
    {
        pieceAchievementUI.SetActive(true);
        listorder.Add(pieceAchievementUI);
    }

    #endregion

}
