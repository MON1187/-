using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeTheRoot : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    [SerializeField] private GameObject setPoint;
    [SerializeField] private GameObject endPoint;
    [SerializeField] private GameObject effectPoint;
    private Rigidbody2D rd;

    private void Awake()
    {
        rd = hand.GetComponent<Rigidbody2D>();
    }
    public void CallMe()
    {
        StartCoroutine(DropHand());
    }
    
    private IEnumerator DropHand()
    {
        effectPoint.SetActive(true);
        hand.transform.position = setPoint.transform.position;

        float forcePoswer = setPoint.transform.position.y - endPoint.transform.position.y;
        yield return new WaitForSeconds(2.25f);
        effectPoint.SetActive(false);
        hand.SetActive(true);

        rd.AddForce(Vector2.down * forcePoswer * 20, ForceMode2D.Impulse);

        yield return new WaitForSeconds(.25f);
        hand.SetActive(false);
    }
}
