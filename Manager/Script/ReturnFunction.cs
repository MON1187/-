using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Timeline;

namespace GhostEvilRation.Function
{
    public class ReturnFunction : MonoBehaviour
    {
        /// <summary>
        /// �ڽŰ� ��� ���̿� "Ư��" ���ع��� �ִ��� Ȯ���մϴ�.
        /// </summary>
        /// <param name="myTransform"></param>
        /// <param name="targetPos"></param>
        /// <param name="breackLayer"></param>
        /// <returns></returns>
        public static bool IsBetweenOjbect(Transform myTransform, Transform targetPos, LayerMask breackLayer)
        {
            if(myTransform == null || targetPos == null) return false;

            Vector3 rayDirection = (myTransform.position - targetPos.position).normalized;

            //���̿� ���ع��� �ִٸ� Flase, ����ִٸ� Ture�� ��ȯ
            RaycastHit2D hit = Physics2D.Raycast(targetPos.position, rayDirection, Mathf.NegativeInfinity, breackLayer);

            return !hit;
        }

        /// <summary>
        /// �ڽ��� Ÿ���� ������ �ִ� �±׸� ��ȯ�մϴ�.
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
