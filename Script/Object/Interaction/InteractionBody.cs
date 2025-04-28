using UnityEngine;

/// <summary>
/// ��ȣ���� ���� ����� ���� �߻�ȭ Ŭ���� �Դϴ�.
/// �Ϲ� ��ȣ�ۿ��� ������ �޽��ϴ�.
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
