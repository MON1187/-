using UnityEngine;
using static TagNameSpace;

public class SwordsTrigger : MonoBehaviour
{
    [SerializeField] private float damag;

    public void GetStrength(float strength)
    {
        damag = strength;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageball damageball = collision.transform.GetComponent<IDamageball>();
        if (damageball != null && collision.gameObject.tag == Player)
        {
            damageball.Damageball(damag);
        }
    }
}
