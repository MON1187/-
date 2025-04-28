using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDebuffer : StatusEffect
{
    private float attackIncrease;

    public AttackDebuffer(float duration, GameObject target, int stack) : base(duration, target,stack)
    {
        this.attackIncrease = stack;
    }

    public override void ApplyEffect()
    {
        // ���ݷ��� ���ҽ�Ŵ
        target.GetComponent<Character>().status.st_OffensePower -= attackIncrease;
        Debug.Log("Attack buff applied: +" + attackIncrease + " Attack");
    }

    public override void RemoveEffect()
    {
        target.GetComponent<Character>().status.st_OffensePower += attackIncrease;
        Debug.Log("Attack buff removed: -" + attackIncrease + " Attack");
    }
}
