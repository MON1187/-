using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 쇠약
/// </summary>
public class VulnerableDebuffer : StatusEffect
{

    public VulnerableDebuffer(float duration, GameObject target, int stack) : base(duration, target, stack)
    {
    }

    public override void ApplyEffect()
    {
        // 받는 데미지량 증가 시킴
        target.GetComponent<Character>().status.st_ExtraDamage += stack;
        Debug.Log("Attack buff applied: +" + stack + " Attack");
    }

    public override void RemoveEffect()
    {
        target.GetComponent<Character>().status.st_ExtraDamage -= stack;
        Debug.Log("Attack buff removed: -" + stack + " Attack");
    }
}
