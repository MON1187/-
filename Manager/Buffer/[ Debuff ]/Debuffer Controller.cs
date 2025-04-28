using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DebufferController : MonoBehaviour
{

    #region 이속 저하
    public class LowSpeed : StatusEffect
    {
        public LowSpeed(float duration, GameObject target, int stack) : base(duration, target, stack)
        {

        }

        public override void ApplyEffect()
        {
            target.GetComponent<Character>().status.st_MoveSpeed += stack;
        }

        public override void RemoveEffect()
        {
            target.GetComponent<Character>().status.st_MoveSpeed -= stack;
        }
    }
    #endregion

    #region 방어력 약화
    public class DefenseDown : StatusEffect
    {
        public DefenseDown(float duration, GameObject target, int stack) : base(duration, target, stack)
        {
        }

        public override void ApplyEffect()
        {
            target.GetComponent<Character>().status.st_Defense += stack;
        }

        public override void RemoveEffect()
        {
            target.GetComponent<Character>().status.st_OffensePower -= stack;
        }
    }
    #endregion

    #region 출혈
    /// <summary>
    /// 출혈
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="targetBody"></param>
    /// <param name="tickInterval"></param>
    /// <returns></returns>
    public class Bleeding : StatusEffect
    {
        private Coroutine bleedingCoroutine;
        private Character characterBody;

        public Bleeding(float duration, GameObject target, int stack) : base(duration, target, stack)
        {
            characterBody = target.GetComponent<Character>();
        }

        public override void ApplyEffect()
        {
            bleedingCoroutine = StartCoroutine(BleedingDamaged(duration, characterBody, 3));
        }

        public override void RemoveEffect()
        {
            StopCoroutine(bleedingCoroutine);
        }


        public IEnumerator BleedingDamaged(float duration, Character targetBody, int tickInterval)
        {
            if (targetBody != null)
            {
                while(true)
                {
                    targetBody.status.st_Health -= Mathf.Round(targetBody.status.st_Health * .1f);

                    Debug.Log(Mathf.Round(targetBody.status.st_Health * .1f));
                    Debug.Log($"targetBody.status.st_Health : {targetBody.status.st_Health} -= {Mathf.Round(targetBody.status.st_Health * .1f)}");

                    yield return TimeManager.WaitForSeconds(tickInterval);
                }
            }
        }
    }
    #endregion

    #region 독
    public class Poison : StatusEffect
    {
        private Coroutine poisonCoroutine;
        private Character characterBody;

        public Poison(float duration, GameObject target, int stack) : base(duration, target, stack)
        {
            characterBody = target.GetComponent<Character>();
        }

        public override void ApplyEffect()
        {
            poisonCoroutine = StartCoroutine(PositionDamaged(duration, characterBody, stack));
        }

        public override void RemoveEffect()
        {
            StopCoroutine(poisonCoroutine);
        }

        public IEnumerator PositionDamaged(float duration, Character targetBody, int stack)
        {
            if (targetBody != null)
                while (true)
                {
                    targetBody.status.st_Health -= stack;
                    yield return TimeManager.WaitForSeconds(5f);
                }
        }
    }

    #endregion

    #region 취약
        public class Vulnerable : StatusEffect
        {
            Character characterBody;
            public Vulnerable(float duration, GameObject target, int stack) : base(duration, target, stack)
            {
                characterBody = target.GetComponent<Character>();
            }

            public override void ApplyEffect()
            {
                characterBody.st_VulnMult += stack;
            }

            public override void RemoveEffect()
            {
                characterBody.st_VulnMult -= stack;
            }
        }

        #endregion

    #region 피해 약화
    public class Reduction : StatusEffect
    {
        Character characterBody;

        public Reduction(float duration, GameObject target, int stack) : base(duration, target, stack)
        {
            characterBody = target.GetComponent<Character>();
        }

        public override void ApplyEffect()
        {
            characterBody.status.st_ExtraDamage -= stack;
        }

        public override void RemoveEffect()
        {
            characterBody.status.st_ExtraDamage += stack;
        }
    }

    #endregion
}