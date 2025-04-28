namespace GhostEvilRation.GameojbectSysteam
{
    using GhostEvilRation.Character.Player;
    using UnityEngine;

    /// <summary>
    /// 늪 지형 입니다.
    /// 충돌중인 객체들의 이동속도를 줄입니다.
    /// </summary>
    public class SwampTerrain : MonoBehaviour
    {
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private float decrease;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other != null)
            {
                //지금은 플레이어만을 대상으로 하지만 몬스터를 만들땐 레이어를 변경하여 제작.
                PlayerController controller = other.gameObject.GetComponent<PlayerController>();
                if (controller != null)
                {
                    //플레이어 라면 플레이어 속감
                }
                //else if (other.transform.gameObject.GetComponent<EnemyBody>() != null)
                //{
                //    //몬스터라면 속감
                //}
                else
                {
                    //아무것도 아니라면 그냥 무시.
                    return;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other != null)
            {
                //지금은 플레이어만을 대상으로 하지만 몬스터를 만들땐 레이어를 변경하여 제작.
                //else if (other.transform.gameObject.GetComponent<EnemyBody>() != null)
                //{
                //    //몬스터라면 몬스터 속도 복구
                //}
                {
                    //아무것도 아니라면 그냥 무시.
                    return;
                }
            }
        }
    }
}
