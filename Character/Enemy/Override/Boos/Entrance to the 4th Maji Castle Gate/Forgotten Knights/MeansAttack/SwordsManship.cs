using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsManship : MonoBehaviour
{
    [SerializeField] private GameObject[] swordCollider;
    [SerializeField] private SwordsTrigger[] swordsTrigger;
    private void Awake()
    {
        for(int i = 0; i < swordCollider.Length; i++)
        {
            swordCollider[i].SetActive(false);
        }
    }

    public void CallMe(int index, float waitTime, float strength)
    {
        swordsTrigger[index].GetStrength(strength);
        StartCoroutine(OnCollider(index,waitTime));
    }

    private IEnumerator OnCollider(int index,float waitTime)
    {
        swordCollider[index].SetActive(true);
        yield return TimeManager.WaitForSeconds(waitTime);
        swordCollider[index].SetActive(false);
    }
}
