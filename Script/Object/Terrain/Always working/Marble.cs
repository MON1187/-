using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �Գ���.
/// �� 4������ ������ ���� �Ʊ��� ���ϰ� ����� �ݴϴ�.
/// </summary>
public class Marble : MonoBehaviour
{
    /// <summary>
    /// ���� ���� ��
    /// 0(Red).     ��븦 Ư���� �������� �̵� ��ŵ�ϴ�.
    /// 1(Blue).    �Ͻ������� ������ ���ϰ� ����ϴ�.(�� ���� ���)
    /// 2(Yellow).  ���ʰ� ���� �ο� �ڽ��� ȯ��ü�� ����ϴ�.
    /// 3.(Green).  ���� �ð��� ���� �ڽ��� ü���� �Ϻθ� ȸ���մϴ�.
    /// 4(Orange).  �÷��̾ ���� ���ư��� ��ü�� �����մϴ�.
    /// 5(Black).   �ٸ� ���� ��� �ൿ�� �մϴ�.
    /// </summary>
    public int curFunctionIndex;    //���� �������� ���� �ϱ� ���� �뵵
                                    

    private void Update()
    {
        switch(curFunctionIndex)
        {
            case 0:
                Function_Red();
            return;
            case 1:
                Function_Blue();
            return;
            case 2:
                Function_Yellow();
            return;
            case 3:
                Function_Green();
            return;
            case 4:
                Function_Orange();
            return;
            case 5:
                Function_Black();
            return;
        }
    }

    public void Function_Red()
    {

    }
    public void Function_Blue() 
    {
    
    }
    public void Function_Yellow()
    {

    }
    public void Function_Green() 
    {
    
    }
    public void Function_Orange()
    {

    }
    public void Function_Black()
    {

    }

}
