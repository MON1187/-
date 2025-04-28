using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���Ǳ� �Դϴ�.
/// �÷��̾��� Hp�� ȸ�� ��Ű�� ������� ������ �ֽ��ϴ�.
/// �ı��Ͽ� ������� ������ �ֽ��ϴ�.
/// �׷��� ������.
/// </summary>
public class VendingMachineendingmachine : InteractionBufferBody, IDamageball
{
    public int leftDrink = 1; // �⺻ 1 �Դϴ�.

    [SerializeField] private int dropValue_Min = 0;
    [SerializeField] private int dropValue_Max = 10;

    protected override void M_InteractionBuffer(int id, int robber, float longTime)
    {
        Debug.Log($"Buffer Id : {id}, robber : {robber}, platTime : {longTime}");
        DropItem();
    }
    private void DropItem()
    {
        int i = Random.Range(0, dropValue_Max);

        if (i < dropValue_Min)
            Debug.Log("����");
    }
    public void Damageball(float damaged)
    {

    }
    public void Died()
    {

    }
}
