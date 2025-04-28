using System;
using UnityEditor;
using UnityEngine;

public enum PieceType
{
    status_UpMaxHealth = 0,
    status_UpMaxMentality,
    status_Upoffense,
    status_UpDefance
}

[CreateAssetMenu(fileName = "new Picec", menuName = "GhostEvil/Achievements/new Picec")]
public class PieceData : ScriptableObject
{
    public string Id;
    public string Name;
    public PieceType PieceType;
    [Range(1, 3)] public int Lv = 1;

    [Header("On UI object")]
    public HidPieceData hidData;
}

[System.Serializable]
public class HidPieceData
{
    public bool pieceDataSetActive = true;

    [HideInInspector] public GameObject myUiObject;
}
#if UNITY_EDITOR
[CustomEditor(typeof(PieceData))]
public class OnPieceData : Editor
{
    PieceData test;
    public void OnEnable()
    {
        test = (PieceData)target;   //ERROR : UnityEngine.Object 형식을 TESTA 형식으로 변환할 수 없음.
    }
    public override void OnInspectorGUI()
    {
        // 기본 인스펙터 렌더링
        DrawDefaultInspector();

        // 조건에 따라 필드를 숨기거나 표시
        if (test.hidData.pieceDataSetActive)
        {
            // 조건이 참일 때만 표시
            test.hidData.myUiObject = EditorGUILayout.ObjectField("Conditional Field",test.hidData.myUiObject, typeof(GameObject),true) as GameObject;
        }
    }
}
#endif