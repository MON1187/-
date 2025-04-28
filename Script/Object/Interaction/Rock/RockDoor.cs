using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class RockDoor : InteractionBody
{
    /// <summary>
    /// ���� ���ڰ��� �־�� �ϴ� �κ� �Դϴ�.
    /// 
    public GameObject rockDoor;
    public GameObject[] rockLever;
    //public Effector2D effector;
    /// </summary>

    protected override void Interaction()
    {
        PlayTheLockCheackOpen();
    }
    private void PlayTheLockCheackOpen()
    {
        if(rockLever.Length > 0)
        {
            int a = 0;
            int b = rockLever.Length;
            for(int i = 0; i < b; i++)
            {
                bool isOpen = rockLever[i].GetComponent<ReleaseStatement>().isLock;
                Debug.Log($"{i} Round : {isOpen}");
                if( isOpen )
                {
                    a++;
                }
            }
            if(a == b)
            {
                this.gameObject.SetActive(false);
                this.gameObject.layer = 0;
                //���� ani 
            }
            else { Debug.Log("�ٺ�"); }
        }
        else
        {
            Debug.Log("��");
        }
    }
}
