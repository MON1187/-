using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBufBody : MonoBehaviour
{
    private List<StatusEffect> activeEffects = new List<StatusEffect>();

    public void ApplyBuff(StatusEffect effect)
    {
        if (!activeEffects.Contains(effect))     //�̹� �����ִ� �������� Ȯ��.
        {
            effect.ApplyEffect();
            activeEffects.Add(effect);
        }
        else Debug.Log("������");

        StartCoroutine(RemoveEffectAfterDuration(effect));
    }

    private IEnumerator RemoveEffectAfterDuration(StatusEffect effect)
    {
        yield return new WaitForSeconds(effect.duration);
        effect.RemoveEffect();
        activeEffects.Remove(effect);
    }

    public void RemoveAllEffects()
    {
        foreach (StatusEffect effect in activeEffects)
        {
            effect.RemoveEffect();
        }
        activeEffects.Clear();
    }
}

//�Բ� ���� �������̽�
/// <summary>
/// using static ManagerBuf;
/// using static BufNameSpace;
/// </summary>