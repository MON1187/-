using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using static UnityEngine.EventSystems.EventTrigger;
using System;

public abstract class Character : MonoBehaviour, IDamageball
{
    [SerializeField] private Data _data;

    public CharacterStatusData status;

    [Header("influence value")]
    [HideInInspector] public float st_VulnMult;        //쇠약 용

    public virtual void LoadData()
    {
        if (status.id == default || _data == null) { return; }

        for (int i = 0; i < _data.NormalEnemyData.Count; i++)
        {
            if (_data.NormalEnemyData[i].id == status.id)
            {
                status.st_Health = _data.NormalEnemyData[i].st_Health;
                status.st_MaxHealth = _data.NormalEnemyData[i].st_Health;
                status.st_Mentality = _data.NormalEnemyData[i].st_Mentality;
                status.st_MaxMentality = _data.NormalEnemyData[i].st_Mentality;
                status.st_Defense = _data.NormalEnemyData[i].st_Defense;
                status.st_OffensePower = _data.NormalEnemyData[i].st_OffensePower;
                status.st_MoveSpeed = _data.NormalEnemyData[i].st_MoveSpeed;
                //Debug.Log($"st_Health : {_data.NormalEnemyData[i].st_Health}" +
                //            $"st_Mentality : {_data.NormalEnemyData[i].st_Mentality}" +
                //            $"st_Defense : {_data.NormalEnemyData[i].st_Defense}" +
                //            $"st_OffensePower : {_data.NormalEnemyData[i].st_OffensePower}" +
                //            $"st_MoveSpeed = {_data.NormalEnemyData[i].st_MoveSpeed}");
                break;
            }
        }
    }

    public virtual void Damageball(float damaged)
    {
        Damaged(damaged);
    }

    public virtual void Damaged(float damaged)
    {
        HitEffect();
        if (damaged >= status.st_Defense)
        {
            if (damaged == status.st_Defense)
            {
                status.st_Health--;
            }
            else { status.st_Health -= Mathf.Round((damaged + (.2f * st_VulnMult)) - status.st_Defense); }
        }

        Died();
    }

    public virtual void HitEffect()
    {
        Debug.Log("Hiy Effect");
        //throw new System.NotImplementedException();
    }

    public virtual void Died()
    {
        if(status.st_Health <= 0)
        {
            transform.gameObject.SetActive(false);
        }
    }
}

[Serializable]
public class CharacterStatusData
{
    [Header("Stats")]
    public string id = default;             //아이디
    public float st_Health = default;       //현재 체력
    public float st_Mentality = default;    //현재 정신력
    public float st_Defense = default;      //방어력
    public float st_OffensePower = default; //공격력
    public float st_MoveSpeed = default;    //이동 속도
    public float st_JumpForce = default;    //점프 강도

    public float st_MaxHealth = default;    //최대 체력
    public float st_MaxMentality = default; //최대 정신력

    public int st_ExtraDamage = default;    //데미지 증가용

    public int maxJumpCount = 0;            //점프 최대치
    public int jumpCount = 0;               //현재 점프 횟 수
}