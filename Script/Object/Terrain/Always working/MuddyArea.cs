using GhostEvilRation.Character.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ManagerBuf;
using static BufNameSpace;

/// <summary>
/// 진흙지대 입니다.
/// 늪 지형과 달리, 버프를 거는 형식으로, 충돌중이 아니라도 유한적인 시간동안 해당 객체에게 행동에 대한 제약을 주는 버프를 겁니다.
/// 버프는 감속 입니다. (id Value : 6)
/// </summary>
public class MuddyArea : MonoBehaviour
{
    [SerializeField] private float durationTime = 3f;//기본 3초 입니다.
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
            //아랜 몬스터 스크립트가 나온다면 업데이트
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
            //아랜 몬스터 스크립트가 나온다면 업데이트
            //else if()
        }
    }
}
