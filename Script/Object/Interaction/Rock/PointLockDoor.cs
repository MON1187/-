using GhostEvilRation.Character.Player;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �÷��̾��� ���൵�� ���� �ر� ���ɿ��θ� �Ǵ��Ͽ� ���� �������� �Ѿ���� ���� �մϴ�.
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
