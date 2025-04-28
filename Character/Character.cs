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
    [HideInInspector] public float st_VulnMult;        //��� ��

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
    public string id = default;             //���̵�
    public float st_Health = default;       //���� ü��
    public float st_Mentality = default;    //���� ���ŷ�
    public float st_Defense = default;      //����
    public float st_OffensePower = default; //���ݷ�
    public float st_MoveSpeed = default;    //�̵� �ӵ�
    public float st_JumpForce = default;    //���� ����

    public float st_MaxHealth = default;    //�ִ� ü��
    public float st_MaxMentality = default; //�ִ� ���ŷ�

    public int st_ExtraDamage = default;    //������ ������

    public int maxJumpCount = 0;            //���� �ִ�ġ
    public int jumpCount = 0;               //���� ���� Ƚ ��
}