using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 절망의 봉
/// </summary>
public class JudgmentRod : MonoBehaviour
{
    [SerializeField] private Collider2D swordCollider;
    [SerializeField] private Animator ani;

    private string atack = "Attack";
    private void Awake()
    {
        swordCollider.enabled = false;
    }
    public void CallMe()
    {
        Attack();
    }
    private void Attack()
    {
        StartCoroutine(RodofDespair());
    }

    private IEnumerator RodofDespair()
    {
        swordCollider.enabled = true;
        //실행할 애니메이션 실행.

        ani.SetTrigger(atack);
        yield return new WaitForSeconds(4.5f);
        swordCollider.enabled = false;
    }
}
