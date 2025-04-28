using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class SwordEnergyTrigger : MonoBehaviour
{
    [HideInInspector] public float damag;
    private string target;

    [SerializeField] private Rigidbody2D rd;

    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    public void GetValue(float damaged, string targetTag)
    {
        damag = damaged;
        target = targetTag.ToLower();
    }
    public void CallMe(float moveSpeed)
    {
        Moveing(moveSpeed);
        StartCoroutine(LastLifeTime());
    }

    private void Moveing(float moveSpeed)
    {
        rd.velocity = Vector3.zero; //기존 움직임 초기화
        rd.AddForce(-transform.right * moveSpeed * 10, ForceMode2D.Impulse);
    }

    private IEnumerator LastLifeTime()
    {
        yield return TimeManager.WaitForSeconds(3);
        DestorySwordEnergy();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageball damageball = other.GetComponent<IDamageball>();

        if(other.gameObject.transform.tag == target && damageball != null)
        {
            Debug.Log("Hit");
            damageball.Damageball(damag);
        }
    }

    #region pool
    IObjectPool<SwordEnergyTrigger> swordEnergy;

    public void SetManagedPool(IObjectPool<SwordEnergyTrigger> pool)
    {
        swordEnergy = pool;
    }
    public void DestorySwordEnergy()
    {
        swordEnergy.Release(this);
    }
    #endregion
}
