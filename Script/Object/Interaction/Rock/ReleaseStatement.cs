using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 다음 구역으로 갈때 열기용으로 사용.
/// </summary>
public class ReleaseStatement : InteractionBody 
{
    /// <summary>
    /// 직접 인자값을 넣어야 하는 부분 입니다.
    /// 
    
    /// </summary>
    public bool isLock = false;

    protected override void Interaction()
    {
        IsUnRock();
    }
    public void IsUnRock()
    {
        //해제상태
        if(!isLock)
        {
            //애니메이션 실행
        }
        isLock = true;

        this.gameObject.layer = 0;
    }
}
