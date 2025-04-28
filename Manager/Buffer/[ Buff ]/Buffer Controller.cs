using GhostEvilRation.GameojbectSysteam.Buffe;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BufNameSpace;
public class BufferController
{
    #region 추가 데미지
    public class Enhancement : StatusEffect
    {
        private Character characterBody;
        public Enhancement(float duration, GameObject target, int stack) : base(duration, target, stack)
        {
            characterBody = target?.GetComponent<Character>();
        }

        public override void ApplyEffect()
        {
            characterBody.status.st_ExtraDamage += stack;
        }

        public override void RemoveEffect()
        {
            characterBody.status.st_ExtraDamage -= stack;
        }
    }
    #endregion
    
    #region 격노
    public class Rage : StatusEffect
    {
        Character characterBody;
        int extrStack;
        public Rage(float duration, GameObject target, int stack, int extrStack) : base(duration, target, stack)
        {
            characterBody = target?.GetComponent<Character>();
            this.extrStack = extrStack;
        }

        public override void ApplyEffect()
        {
            characterBody.status.st_ExtraDamage += extrStack;
            characterBody.status.st_OffensePower += stack;
        }

        public override void RemoveEffect()
        {
            characterBody.status.st_ExtraDamage -= extrStack;
            characterBody.status.st_OffensePower -= stack;

            GetBufBody targetBufBody = target.GetComponent<GetBufBody>();
            ManagerBuf.GetBuf(targetBufBody, stiffness, 1, 3);
        }
    }

    #endregion

    #region 보호
    public class Protect : StatusEffect
    {
        private Character characterBody;
        public Protect(float duration, GameObject target, int stack) : base(duration, target, stack)
        {
            characterBody = target?.GetComponent<Character>();
        }

        public override void ApplyEffect()
        {
            characterBody.st_VulnMult -= stack;
        }

        public override void RemoveEffect()
        {
            characterBody.st_VulnMult += stack;
        }
    }

    #endregion
}
