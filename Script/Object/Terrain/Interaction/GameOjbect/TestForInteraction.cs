using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 테스트 용 입니다.
/// </summary>
public class TestForInteraction : InteractionBufferBody
{
    protected override void M_InteractionBuffer(int id, int robber, float longTime)
    {
        Debug.Log($"Buffer Id : {id}, robber : {robber}, platTime : {longTime}");
    }
}
