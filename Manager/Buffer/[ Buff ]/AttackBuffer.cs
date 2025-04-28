using System.Data;
using UnityEngine;

public class AttackBuffer : StatusEffect
{
    private float attackIncrease;

    public AttackBuffer(float duration, GameObject target, int stack) : base(duration, target, stack)
    {
        this.attackIncrease = stack;
    }

    public override void ApplyEffect()
    {
        // 공격력을 증가시킴
        target.GetComponent<Character>().status.st_OffensePower += attackIncrease;
        Debug.Log("Attack buff applied: +" + attackIncrease + " Attack");
    }

    public override void RemoveEffect()
    {
        target.GetComponent<Character>().status.st_OffensePower -= attackIncrease;
        Debug.Log("Attack buff removed: -" + attackIncrease + " Attack");
    }
}
