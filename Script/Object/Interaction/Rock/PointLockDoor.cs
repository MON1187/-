using GhostEvilRation.Character.Player;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 플레이어의 진행도에 따라 해금 가능여부를 판단하여 다음 지역으로 넘어갈지를 결정 합니다.
/// </summary>
public class PointLockDoor : InteractionBody
{
    public int lockPoint;
    [SerializeField] private GameObject lockDoor;
    [SerializeField] private Animator ani;

    protected override void Interaction()
    {
        //  ani.SetTrigger("id");
        lockDoor.SetActive(false);
    }
}
