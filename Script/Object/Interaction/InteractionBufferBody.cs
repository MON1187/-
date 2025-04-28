using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 버프 상호작용 관련해서 수신을 받습니다.
/// </summary>
public abstract class InteractionBufferBody : InteractionBody
{
    public int bufferId = default;      //버프 id // 참고 주소 : https://docs.google.com/spreadsheets/d/1htjDemvRUaFRsnB-qmhjB-IRTm4PrXfva6Lbkd4E368/edit?gid=1116420557#gid=1116420557
    public int robber;                  //강도
    public float inTime = 0f;           //지속 시간

    protected override void Interaction()
    {
        M_InteractionBuffer(this.bufferId,this.robber ,this.inTime);
    }

    protected virtual void M_InteractionBuffer(int id ,int robber , float longTime)
    {

    }
}
