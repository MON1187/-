using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    [SerializeField] private GameObject effectObj;
    [SerializeField] private GameObject AttackObj;
    [SerializeField] private Transform SetObj;

    public void Awak()
    {
        StartCoroutine(move());
    }
    public IEnumerator move()
    {
        effectObj.SetActive(true);
        AttackObj.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        yield return new WaitForSeconds(1f);
        effectObj.SetActive(false);

        AttackObj.SetActive(true);
        AttackObj.transform .position = SetObj.transform.position;
        AttackObj.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 50,ForceMode2D.Impulse);
    }
}
