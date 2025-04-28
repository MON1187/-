using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class BoomSeedPool : MonoBehaviour
{
    Rigidbody2D rd;
    IEnumerator destoryCoroutine;

    WaitForSeconds waitSeconds = new WaitForSeconds(10f);

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    public void CallShot()
    {
        destoryCoroutine = Destory();

        StartCoroutine(destoryCoroutine);
    }    

    private IEnumerator Destory()
    {
        yield return waitSeconds;
        DestorySeed();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            if(other.gameObject.CompareTag("Boss"))
            {
                return;
            }    

            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Hit");
                IDamageball damageball = other.GetComponent<IDamageball>();
                damageball.Damageball(4);

                gameObject.SetActive(false);

            }
            else if (other.gameObject.CompareTag("OutObj"))
            {
                gameObject.SetActive(false);
            }

            StopCoroutine(destoryCoroutine);
            DestorySeed();
        }
    }
    #region Pool
    public IObjectPool<BoomSeedPool> _seed;
    public void SetManagedPool(IObjectPool<BoomSeedPool> seed)
    {
        _seed = seed;
    }

    public void DestorySeed()
    {
        _seed.Release(this);
    }
    #endregion
}
