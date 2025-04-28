using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 더러워진 스웨터
/// </summary>
public class SwampDespair : MonoBehaviour, IDamageball
{
    public float st_Stamina;
    public float Re_st_Stamina;

    [SerializeField] private BoxCollider2D myCollider;
    [SerializeField] private GameObject shieldObj;
    [SerializeField] private ForestGatekeeper forestGatekeeper;

    private void Awake()
    {
        Re_st_Stamina = st_Stamina;

        myCollider.enabled = false;
        shieldObj.SetActive(false);
    }

    public void GetShield()
    {
        st_Stamina = Re_st_Stamina;
        myCollider.enabled = true;
        shieldObj.SetActive(true);
    }

    public void Damageball(float damaged)
    {
        if (damaged < 3)
        { return; }
        else { st_Stamina -= damaged - 3; }

        Died();
    }

    public void Died()
    {
        BreackShield();
    }

    public void BreackShield()
    {
        if(st_Stamina <= 0)
        {
            forestGatekeeper.isShield = false;
            myCollider.enabled = false;
            shieldObj.SetActive(false);
        }
    }

}
