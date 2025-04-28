using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestGateSword : MonoBehaviour
{
    [SerializeField] private float damaged;

    [SerializeField] ForestGatekeeper keerper;

    private void Awake()
    {
        damaged = keerper.status.st_OffensePower;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageball damageball = other.GetComponent<IDamageball>();

        if(damageball != null )
        {
            damageball.Damageball(damaged + 5);
        }
    }
}
