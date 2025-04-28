using UnityEngine;
using GhostEvilRation.GameojbectSysteam.Buffe;
using GhostEvilRation.Character.Player;
/// <summary>
/// 거목 입니다.
/// 일회성 소모성 오브젝트이며, 소모시, 해당객체에게 수액(id = 26)이란 버프를 줍니다.
/// 또한 상호작용 하고 난후, 모습이 바뀝니다.
/// </summary>
public class BigTree : InteractionBufferBody , InBuffe
{
    //id는 기본 26
    //inTime은 기본 5초
    protected override void M_InteractionBuffer(int id, int robber, float longTime)
    {
        In_OutBuffe(id, longTime);
    }
    public void In_OutBuffe(int id, float longTime)
    {
        
    }
}
