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
        test = (PieceData)target;   //ERROR : UnityEngine.Object ������ TESTA �������� ��ȯ�� �� ����.
    }
    public override void OnInspectorGUI()
    {
        // �⺻ �ν����� ������
        DrawDefaultInspector();

        // ���ǿ� ���� �ʵ带 ����ų� ǥ��
        if (test.hidData.pieceDataSetActive)
        {
            // ������ ���� ���� ǥ��
            test.hidData.myUiObject = EditorGUILayout.ObjectField("Conditional Field",test.hidData.myUiObject, typeof(GameObject),true) as GameObject;
        }
    }
}
#endif