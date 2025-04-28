using System.Collections;
using System.Collections.Generic;
using static TagNameSpace;
using UnityEngine;

public class RegretStubbornness : MonoBehaviour
{
    private PlayerBodyController BodyController;
    IEnumerator TickDamag;

    [SerializeField] private float damaged = default;
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void CallMe(float damag)
    {
        damaged = damag;
        gameObject.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (BodyController == null && other.gameObject.tag == Player) { BodyController = other.GetComponent<PlayerBodyController>(); } 
        if(other.gameObject.tag == Player)
        {
            TickDamag = TickDamaged();
            StartCoroutine(TickDamag);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == Player)
        {
            StopCoroutine(TickDamag);
        }
    }

    private IEnumerator TickDamaged()
    {
        while (true)
        {
            yield return TimeManager.WaitForSeconds(.2f);
            BodyController.Damageball(damaged);
        }
    }
}
