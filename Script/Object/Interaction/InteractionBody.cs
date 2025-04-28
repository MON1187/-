using UnityEngine;

/// <summary>
/// 상호적용 다중 상속을 위한 추상화 클래스 입니다.
/// 일반 상호작용을 수신을 받습니다.
/// </summary>
public abstract class InteractionBody : MonoBehaviour
{
    public void InteractnionCallDebug()
    {
        CallDebug();
    }

    private void CallDebug()
    {
        Interaction();
    }

    protected virtual void Interaction()
    {

    }
}
