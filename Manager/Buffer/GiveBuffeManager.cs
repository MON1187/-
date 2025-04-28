using System;
using UnityEngine;

namespace GhostEvilRation.GameojbectSysteam.Buffe
{
    public abstract class GiveBuffeManager : MonoBehaviour , InBuffe
    {
        public void In_OutBuffe(int id, float durationTime)
        {
            GiveBuffe(id);
        }
        /// <summary>
        /// 호출받은 객체에게 줘야할 id를 확인후 해당 id의 버프를 반환 합니다.
        /// </summary>
        /// <param name="id"></param>
        private Buffe GiveBuffe(int id)
        {
            if(Enum.IsDefined(typeof(Buffe), id))
            {
                return (Buffe)id;
            }
            else
            {
                throw new ArgumentException("Not Thing");
            }
        }

    }

    public enum Buffe
    {
        /// <summary>
        /// 해로운 버프 목록 입니다.
        /// </summary>
        weakness = 1,           // 쇠약
        decreasedHealing,       // 치유감소
        bleeding,               // 출혈
        poison,                 // 독
        panic,                  // 패닉
        deceleration,           // 감속
        disheveled,             // 흐트러짐
        damageReduction,        // 피해약화
        weaknessDefense,        // 방어력 약화
        stiffness,              // 경직
        
        /// <summary>
        /// 이로운 버프 목록 입니다.
        /// </summary>
        courage = 24,
        fast,
        sap
    }
}
