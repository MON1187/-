using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 구슬 입나다.
/// 총 4가지의 보프로 주의 아군을 강하게 만들어 줍니다.
/// </summary>
public class Marble : MonoBehaviour
{
    /// <summary>
    /// 종류 설명 글
    /// 0(Red).     상대를 특이한 공간으로 이동 시킵니다.
    /// 1(Blue).    일시적으로 마왕을 강하게 만듭니다.(전 스텟 상승)
    /// 2(Yellow).  몇초간 같이 싸울 자신의 환영체를 만듭니다.
    /// 3.(Green).  일정 시간을 거쳐 자신의 체력의 일부를 회복합니다.
    /// 4(Orange).  플레이어를 향해 날아가는 구체를 생성합니다.
    /// 5(Black).   다른 색의 모든 행동을 합니다.
    /// </summary>
    public int curFunctionIndex;    //무슨 종류인지 설정 하기 위한 용도
                                    

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
