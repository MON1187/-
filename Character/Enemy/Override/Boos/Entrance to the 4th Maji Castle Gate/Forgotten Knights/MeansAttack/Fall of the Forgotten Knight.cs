using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static TagNameSpace;
public class FalloftheForgottenKnight : MonoBehaviour
{
    private float damag;

    public new GameObject renderer;
    [SerializeField] private CircleCollider2D circleCollider;
    private GameObject target;

    public void CallMe(float damaed)
    {
        damag = damaed;
        StartCoroutine(AttackDamagball());
    }

    private IEnumerator AttackDamagball()
    {
        renderer.SetActive(true);
        circleCollider.enabled = true;
        for (int i = 0; i < 20; i++)
        {
            if (target != null)
            {
                target.GetComponent<IDamageball>().Damageball(damag);
            }

            yield return TimeManager.WaitForSeconds(.1f);
        }
        circleCollider.enabled=false;
        renderer.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == Player)
        {
            target = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == Player)
        {
            target = default;
        }
    }
}
