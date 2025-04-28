using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���
/// </summary>
public class VulnerableDebuffer : StatusEffect
{

    public VulnerableDebuffer(float duration, GameObject target, int stack) : base(duration, target, stack)
    {
    }

    public override void ApplyEffect()
    {
        // �޴� �������� ���� ��Ŵ
        target.GetComponent<Character>().status.st_ExtraDamage += stack;
        Debug.Log("Attack buff applied: +" + stack + " Attack");
    }

    public override void RemoveEffect()
    {
        target.GetComponent<Character>().status.st_ExtraDamage -= stack;
        Debug.Log("Attack buff removed: -" + stack + " Attack");
    }
}
