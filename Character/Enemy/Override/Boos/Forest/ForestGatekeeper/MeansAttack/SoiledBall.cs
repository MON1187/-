using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static TagNameSpace;

//절망의 늪 부모 객체 클래스
public class SoiledBall : MonoBehaviour
{
    public float damag;
    [SerializeField] private GameObject showObj;
    [SerializeField] private GameObject soiledFlooring;
    [SerializeField] SoiledSweater soiledSweater;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody2D rd;

    Quaternion rot = Quaternion.Euler(0, 0, 0);

    private void Awake()
    {
        soiledSweater = soiledFlooring.GetComponent<SoiledSweater>();
    }

    public void CallMe(float damaged)
    {
        damag = damaged;
        rd.bodyType = RigidbodyType2D.Dynamic;
        rd.AddForce(transform.up * 10, ForceMode2D.Impulse);
        GetHide(true,false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageball damageball = other.GetComponent<IDamageball>();
        if (damageball != null && other.gameObject.tag == Player)
        {
            damageball.Damageball(damag + 5);
            GetHide(false,false);
        }
        if (other.gameObject.layer == 8 || other.gameObject.layer == groundLayer)
        {
            GetHide(false, true);
            rd.bodyType = RigidbodyType2D.Kinematic;    //고정
            rd.velocity = Vector3.zero;
            transform.rotation = rot;   //회전 초기화
            soiledSweater.CallMe(damag);
        }
    }
    /// <summary>
    /// a = Show, b = SoiledFlooring
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    private void GetHide(bool a, bool b)
    {   
        showObj.SetActive(a);
        soiledFlooring.SetActive(b);
    }

    #region Pool
    public IObjectPool<SoiledBall> soiled;

    public void SetManagedPool(IObjectPool<SoiledBall> pool)
    {
        soiled = pool;
    }
    public void DestorySoiled()
    {
        soiled.Release(this);
    }

    #endregion 
}
