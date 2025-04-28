using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRooting : MonoBehaviour
{
    [SerializeField] private GameObject attackObj;
    [SerializeField] private GameObject effectObj;
    private BoxCollider2D myCollider;
    private float st_offence;
    public void Awake()
    {
        myCollider = GetComponent<BoxCollider2D>();
        myCollider.enabled = false;
    }

    public void CallAttack(float damaged)
    {
        st_offence = damaged;
        myCollider.enabled = false;

        StartCoroutine(A());
    }

    public IEnumerator A()
    {
        yield return new WaitForSeconds(1.25f);
        effectObj.SetActive(false);
        float time = 0;
        while(time < 1)
        {
            time += Time.time;
            attackObj.transform.position = Vector3.Lerp(attackObj.transform.position,transform.position,time);

            yield return new WaitForSeconds(0.1f);
        }
        myCollider.enabled = true;
        attackObj.transform.position = transform.position;

        StartCoroutine (Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(2.5f);
        gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        IDamageball damageball = other.GetComponent<IDamageball>();
        if (damageball != null)
        {
            damageball.Damageball(st_offence);
        }
    }
}
