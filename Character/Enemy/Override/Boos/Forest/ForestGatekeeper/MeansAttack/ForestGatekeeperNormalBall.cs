using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ForestGatekeeperNormalBall : MonoBehaviour
{
    float damaged;
    [SerializeField] float lifeTime = 5;


   [SerializeField] private Rigidbody2D rd;
    WaitForSeconds wiatTime;

    private void Awake()
    {
        if(rd == null) rd = GetComponent<Rigidbody2D>();

        wiatTime = new WaitForSeconds(lifeTime);
    }

    public void CallMe(float damag)
    {
        damaged = damag;
        rd.AddForce(transform.up * 10f, ForceMode2D.Impulse);
        StartCoroutine(DestoryTime());
    }

    private IEnumerator DestoryTime()
    {
        yield return wiatTime;
        DestoryForestNormalBall();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageball damageball = other.GetComponent<IDamageball>();
        if (damageball != null && other.gameObject.tag == "Player")
        {
            damageball.Damageball(damaged);
            DestoryForestNormalBall();
        }

        if (other.gameObject.tag == "OutObj")
        DestoryForestNormalBall();
    }



    #region Pool
    IObjectPool<ForestGatekeeperNormalBall> forestNormalBallPool;
    public void SetManagedPool(IObjectPool<ForestGatekeeperNormalBall> pool)
    {
        forestNormalBallPool = pool;
    }
    public void DestoryForestNormalBall()
    {
        forestNormalBallPool.Release(this);
    }
    #endregion
}
