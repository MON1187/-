using UnityEngine;

public abstract class StatusEffect : MonoBehaviour
{
    protected internal float duration;      //���� �ð�
    protected internal int stack;
    protected GameObject target;            //������ �� ���

    public StatusEffect(float duration, GameObject target, int stack)
    {
        this.duration = duration;
        this.target = target;
        this.stack = stack;
    }

    public abstract void ApplyEffect();
    public abstract void RemoveEffect();
}