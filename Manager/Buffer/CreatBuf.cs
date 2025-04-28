using UnityEngine;

public abstract class StatusEffect : MonoBehaviour
{
    protected internal float duration;      //지속 시간
    protected internal int stack;
    protected GameObject target;            //버프를 줄 대상

    public StatusEffect(float duration, GameObject target, int stack)
    {
        this.duration = duration;
        this.target = target;
        this.stack = stack;
    }

    public abstract void ApplyEffect();
    public abstract void RemoveEffect();
}