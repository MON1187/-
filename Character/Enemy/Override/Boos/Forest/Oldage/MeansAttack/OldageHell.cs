using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OldageHell : MonoBehaviour,IDamageball
{
    public float st_health = 25;

    [SerializeField] private Character bossbase;

    public void CallHell()
    {
        StartCoroutine(hell());
    }

    private IEnumerator hell()
    {
        st_health = 25;
        while (true) 
        {
            yield return new WaitForSeconds(3);

            bossbase.status.st_Health += 8f;
        }
    }

    public void Damageball(float damaged)
    {
        st_health -= damaged;

        if(st_health < 0)
        {
            gameObject.SetActive(false);
        }
    }

    void IDamageball.Died()
    {
        throw new System.NotImplementedException();
    }
}
