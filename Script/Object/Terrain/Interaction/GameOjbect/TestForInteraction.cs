using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �׽�Ʈ �� �Դϴ�.
/// </summary>
public class TestForInteraction : InteractionBufferBody
{
    protected override void M_InteractionBuffer(int id, int robber, float longTime)
    {
        Debug.Log($"Buffer Id : {id}, robber : {robber}, platTime : {longTime}");
    }
}
