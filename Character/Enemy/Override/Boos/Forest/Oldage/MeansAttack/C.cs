using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour
{
    public void nTriggerEnter2D(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            IDamageball damageball = other.GetComponent<IDamageball>();
            damageball.Damageball(15);
        }

        if (other.gameObject.CompareTag("End"))
        {
            gameObject.SetActive(false);
        }
    }
}
