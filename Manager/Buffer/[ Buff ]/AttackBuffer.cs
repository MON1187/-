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
        // ���ݷ��� ������Ŵ
        target.GetComponent<Character>().status.st_OffensePower += attackIncrease;
        Debug.Log("Attack buff applied: +" + attackIncrease + " Attack");
    }

    public override void RemoveEffect()
    {
        target.GetComponent<Character>().status.st_OffensePower -= attackIncrease;
        Debug.Log("Attack buff removed: -" + attackIncrease + " Attack");
    }
}
