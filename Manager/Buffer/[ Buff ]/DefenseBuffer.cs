using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBuffer : StatusEffect
{

    public DefenseBuffer(float duration, GameObject target, int stack) : base(duration, target,stack)
    {
    }
    
    public override void ApplyEffect()
    {
        // ���ݷ��� ������Ŵ
        target.GetComponent<Character>().status.st_Defense += stack;
        Debug.Log("Defense buff applied: +" + stack + " Defense");
    }

    public override void RemoveEffect()
    {
        target.GetComponent<Character>().status.st_Defense -= stack;
        Debug.Log("Defense buff removed: -" + stack + " Defense");
    }
}
