using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 자판기 입니다.
/// 플레이어의 Hp를 회복 시키는 음료수를 뽑을수 있습니다.
/// 파괴하여 음료수를 얻을수 있습니다.
/// 그러지 마세요.
/// </summary>
public class VendingMachineendingmachine : InteractionBufferBody, IDamageball
{
    public int leftDrink = 1; // 기본 1 입니다.

    [SerializeField] private int dropValue_Min = 0;
    [SerializeField] private int dropValue_Max = 10;

    protected override void M_InteractionBuffer(int id, int robber, float longTime)
    {
        Debug.Log($"Buffer Id : {id}, robber : {robber}, platTime : {longTime}");
        DropItem();
    }
    private void DropItem()
    {
        int i = Random.Range(0, dropValue_Max);

        if (i < dropValue_Min)
            Debug.Log("ㅊㅊ");
    }
    public void Damageball(float damaged)
    {

    }
    public void Died()
    {

    }
}
