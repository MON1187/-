using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���� ��ȣ�ۿ� �����ؼ� ������ �޽��ϴ�.
/// </summary>
public abstract class InteractionBufferBody : InteractionBody
{
    public int bufferId = default;      //���� id // ���� �ּ� : https://docs.google.com/spreadsheets/d/1htjDemvRUaFRsnB-qmhjB-IRTm4PrXfva6Lbkd4E368/edit?gid=1116420557#gid=1116420557
    public int robber;                  //����
    public float inTime = 0f;           //���� �ð�

    protected override void Interaction()
    {
        M_InteractionBuffer(this.bufferId,this.robber ,this.inTime);
    }

    protected virtual void M_InteractionBuffer(int id ,int robber , float longTime)
    {

    }
}
