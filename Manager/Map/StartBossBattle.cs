using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class StartBossBattle : MonoBehaviour
{
    public GameObject bossObject;
    public GameObject[] barrierObject;

    private void Start()
    {
        foreach (var i in barrierObject)
            i.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            OnBarrier();
            StratBossBattle();
        }
    }
    void OnBarrier()
    {
        foreach(var i in barrierObject)
            i.SetActive(true);
    }

    void StratBossBattle()
    {
        bossObject.SetActive(true);
    }
}
