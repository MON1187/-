using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GhostEvilRation.Function.Animation
{
    public abstract class AnimationController : MonoBehaviour
    {
        [SerializeField] private Animator ani;

        /// <summary>
        /// 자신의 클립을 실행 합니다.
        /// </summary>
        /// <param name="clipName"></param>
        public static void PlayAnimation(Animator ani,string clipName)
        {
            if (ani == null)
            {
                Debug.Log("Null Animator");
                return;
            }

            ani.Play(clipName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isValue"></param>
        /// <param name="clipName"></param>
        public static void PlayAnimation(Animator ani, bool isValue, string clipName)
        {
            if (ani == null)
            {
                Debug.Log("Null Animator");
                return;
            }

            ani.SetBool(clipName, isValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clipName"></param>
        public static void PlayAnimationTrigger(Animator ani,string clipName)
        {
            if (ani == null)
            {
                Debug.Log("Null Animator");
                return;
            }

            ani.SetTrigger(clipName);
        }

    }
}