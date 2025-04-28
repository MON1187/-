using GhostEvilRation.Character.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ManagerBuf;
using static BufNameSpace;

/// <summary>
/// �������� �Դϴ�.
/// �� ������ �޸�, ������ �Ŵ� ��������, �浹���� �ƴ϶� �������� �ð����� �ش� ��ü���� �ൿ�� ���� ������ �ִ� ������ �̴ϴ�.
/// ������ ���� �Դϴ�. (id Value : 6)
/// </summary>
public class MuddyArea : MonoBehaviour
{
    [SerializeField] private float durationTime = 3f;//�⺻ 3�� �Դϴ�.
    [SerializeField] private LayerMask targetLayer;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer != targetLayer)
        {
            GetBufBody playerBody = other.GetComponent<GetBufBody>();
            if (playerBody != null)
            {
                playerBody.ApplyBuff(GetBuf(playerBody, down_spd, 2, durationTime));
            }
            //�Ʒ� ���� ��ũ��Ʈ�� ���´ٸ� ������Ʈ
            //else if()
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer != targetLayer)
        {
            GetBufBody playerBody = other.GetComponent<GetBufBody>();
            if (playerBody != null)
            {
                playerBody.ApplyBuff(GetBuf(playerBody, down_spd, 2, durationTime));
            }
            //�Ʒ� ���� ��ũ��Ʈ�� ���´ٸ� ������Ʈ
            //else if()
        }
    }
}
