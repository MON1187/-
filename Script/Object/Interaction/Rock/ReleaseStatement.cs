using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �������� ���� ��������� ���.
/// </summary>
public class ReleaseStatement : InteractionBody 
{
    /// <summary>
    /// ���� ���ڰ��� �־�� �ϴ� �κ� �Դϴ�.
    /// 
    
    /// </summary>
    public bool isLock = false;

    protected override void Interaction()
    {
        IsUnRock();
    }
    public void IsUnRock()
    {
        //��������
        if(!isLock)
        {
            //�ִϸ��̼� ����
        }
        isLock = true;

        this.gameObject.layer = 0;
    }
}
