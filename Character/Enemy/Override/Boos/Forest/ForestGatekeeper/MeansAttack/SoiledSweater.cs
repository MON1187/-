using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// Àý¸ÁÀÇ ´Ë
/// </summary>
public class SoiledSweater : MonoBehaviour
{
    public float damaged;
    [SerializeField] private float lifeTime = 15;

    [SerializeField] private SoiledBall soiledBall;
    WaitForSeconds leelifeTime;
    private void Awake()
    {
        leelifeTime = new WaitForSeconds(lifeTime);
    }


    public void CallMe(float damag)
    {
        damaged = damag;
        StartCoroutine(LastLifeTime());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageball damageball = other.GetComponent<IDamageball>();
        if(damageball != null)
        {
            
            Rigidbody2D rd = other.GetComponent<Rigidbody2D>();

            rd.AddForce(other.transform.up * 15f,ForceMode2D.Impulse);

            damageball.Damageball(damaged);
            soiledBall.DestorySoiled();
        }
    }

    private IEnumerator LastLifeTime()
    {
        yield return leelifeTime;
        soiledBall.DestorySoiled();
    }

    #region Pool
    public IObjectPool<SoiledSweater> soiled;

    public void SetManagedPool(IObjectPool<SoiledSweater> pool)
    {
        soiled = pool;
    }
    public void DestorySoiled()
    {
        soiled.Release(this);
    }

    #endregion 
}
