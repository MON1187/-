using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMagiTan : MonoBehaviour
{
    public float damaged;
    float moveSpeed = 300f;
    private Rigidbody2D rd;

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
    }
    public void CallME(float damag)
    {
        damaged = damag;

        rd.AddForce((transform.right * -1) * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            IDamageball damageball = other.GetComponent<IDamageball>();

            damageball.Damageball(damaged);
        }
    }
}
