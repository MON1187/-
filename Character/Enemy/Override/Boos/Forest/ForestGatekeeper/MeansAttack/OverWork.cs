using System.Collections;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;

/// <summary>
/// È¤»ç
/// </summary>
public class OverWork : MonoBehaviour
{
    [Header("Speed Value")]
    public float moveSpeed;
    [SerializeField] private float lifeTime = 5;

    [Header("Damag Value")]
    [SerializeField] private float damaged;

    private Rigidbody2D rd;

    float moveY;

    IEnumerator lifeCoroutine;

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        Quaternion s = Quaternion.Euler(0, 0, 35);
        transform.rotation = s;
    }

    public void CallMe(float damag, bool isMoveing, Vector3 targetPoint)
    {
        rd.velocity = Vector3.zero;

        lifeCoroutine = LifeTime();
        StartCoroutine(lifeCoroutine);

        if (!isMoveing) { rd.AddForce(transform.right * -1 * moveSpeed); }
        else
        {
            StartCoroutine(PattunMove(targetPoint));
        }
    }

    private IEnumerator PattunMove(Vector3 targetPoint)
    {
        float time = 0;
        Vector3 startPoint = transform.position, middlePoint, endPoint = targetPoint;
        middlePoint = (startPoint - endPoint).normalized / 2;
        middlePoint.y += 3;
        while (time < 2)
        {
            Vector3 p1 = Vector3.Lerp(startPoint, middlePoint, time);
            Vector3 p2 = Vector3.Lerp(middlePoint,endPoint, time);
            transform.position = Vector3.Lerp(p1,p2,time);

            time += Time.deltaTime / 2;
            yield return null;
        }
    }

    private IEnumerator LifeTime()
    {
        yield return TimeManager.WaitForSeconds(lifeTime);
        DestoryOverWork();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageball damageball = other.GetComponent<IDamageball>();
        if (damageball != null && other.gameObject.tag == "Player")
        {
            damageball.Damageball(damaged);

            StopCoroutine(lifeCoroutine);
            DestoryOverWork();
        }

        if(other.gameObject.tag == "OutObj")
        {
            StopCoroutine(lifeCoroutine);
            DestoryOverWork();
        }
    }

    #region Pool

    public IObjectPool<OverWork> _pool;

    public void SetManagedPool(IObjectPool<OverWork> pool)
    {
        _pool = pool;
    }
    public void DestoryOverWork()
    {
        _pool.Release(this);
    }
    #endregion
}
