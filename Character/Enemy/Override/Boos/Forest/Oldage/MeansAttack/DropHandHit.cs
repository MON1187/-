using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHandHit : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        IDamageball damageball = other.GetComponent<IDamageball>();
        if(damageball != null )
        {
            damageball.Damageball(10f);
        }
    }
}
