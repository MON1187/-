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
    public void UB_Option_GameGraphic() //그래픽
    {
        if (currentUI != null) { currentUI.SetActive(false); }      //현재 켜진 ui가 있다면 해당 UI를 비활성 시킨다.
        currentUI = optGraphic;                                     //현재 활성화 UI로 지정
        ADDBackOrder();
        optGraphic.SetActive(true);                                 //UI활성화
    }

    public void UB_Option_Controller()  //컨트롤러
    {
        if (currentUI != null) { currentUI.SetActive(false); }
        currentUI = optController;
        ADDBackOrder();
        optController.SetActive(true);
    }
    public void UB_Option_Sound()       //사운드
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
