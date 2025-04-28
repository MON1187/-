using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Timeline;

namespace GhostEvilRation.Function
{
    public class ReturnFunction : MonoBehaviour
    {
        /// <summary>
        /// 자신과 상대 사이에 "특정" 방해물이 있는지 확인합니다.
        /// </summary>
        /// <param name="myTransform"></param>
        /// <param name="targetPos"></param>
        /// <param name="breackLayer"></param>
        /// <returns></returns>
        public static bool IsBetweenOjbect(Transform myTransform, Transform targetPos, LayerMask breackLayer)
        {
            if(myTransform == null || targetPos == null) return false;

            Vector3 rayDirection = (myTransform.position - targetPos.position).normalized;

            //사이에 방해물이 있다면 Flase, 비어있다면 Ture를 반환
            RaycastHit2D hit = Physics2D.Raycast(targetPos.position, rayDirection, Mathf.NegativeInfinity, breackLayer);

            return !hit;
        }

        /// <summary>
        /// 자신의 타겟의 사이의 있는 태그를 반환합니다.
        /// </summary>
        /// <param name="myTransform"></param>
        /// <param name="targetPos"></param>
        /// <returns></returns>
        public static string GetBetweenTags(Transform myTransform,Transform targetPos, LayerMask breackLayer)
        {
            if (myTransform == null || targetPos == null) return null;

            string hitObjectData = default;

            Vector3 rayDirection = (myTransform.position - targetPos.position).normalized;

            RaycastHit2D hit = Physics2D.Raycast(targetPos.position, rayDirection, Mathf.NegativeInfinity, breackLayer);

            if (hit.collider != null)
            {
                hitObjectData = hit.transform.gameObject.tag;
            }
            
            return hitObjectData;
        }

        public static int GetMoveingDirection(Vector3 myPos, Vector3 targetPoint)
        {
            return myPos.x - targetPoint.x > 0 ? 1 : -1;
        }
    }
}
