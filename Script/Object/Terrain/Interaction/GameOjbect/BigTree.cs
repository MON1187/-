using UnityEngine;
using GhostEvilRation.GameojbectSysteam.Buffe;
using GhostEvilRation.Character.Player;
/// <summary>
/// �Ÿ� �Դϴ�.
/// ��ȸ�� �Ҹ� ������Ʈ�̸�, �Ҹ��, �ش簴ü���� ����(id = 26)�̶� ������ �ݴϴ�.
/// ���� ��ȣ�ۿ� �ϰ� ����, ����� �ٲ�ϴ�.
/// </summary>
public class BigTree : InteractionBufferBody , InBuffe
{
    //id�� �⺻ 26
    //inTime�� �⺻ 5��
    protected override void M_InteractionBuffer(int id, int robber, float longTime)
    {
        In_OutBuffe(id, longTime);
    }
    public void In_OutBuffe(int id, float longTime)
    {
        
    }
}
