using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMapGameManager : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] GameObject playerObj;
    [SerializeField] GameObject _camera;
    [SerializeField] GameObject changeCam;

    [SerializeField] GameObject bossWallCollider;
    [SerializeField] GameObject bossObj;
    private BossWildBboar boss;
    [SerializeField] GameObject reource_03;

    bool isBossBattleStart;
    bool isEndBattle = false;
    private void Start()
    {
        boss = bossObj.GetComponent<BossWildBboar>();
    }

    private void Update()
    {
        CamTriggerCheackHandel();

        if(isBossBattleStart && !isEndBattle)
            if(boss.status.st_Health <= 0)
            {
                Debug.Log("Set Camera");
                bossWallCollider.SetActive(false);
                changeCam.SetActive(false);
                _camera.SetActive(true);
                isEndBattle = true;
            }
    }

    void CamTriggerCheackHandel()
    {
        int targetLayer = RaycastCheack.GetLayerMask("CameraZone");
        RaycastHit2D ray = RaycastCheack.PerformRaycast(playerObj.transform.position, targetLayer);

        CamTirrgerCheack(ray);
    }

    void CamTirrgerCheack(RaycastHit2D hit)
    {
        if(hit.collider == null) return;

        switch(hit.collider.name)
        {
            case "Normal":
                changeCam.SetActive(false);
                _camera.SetActive(true);
                return;
            case "Boss":
                if (isBossBattleStart) return;

                changeCam.SetActive(true);
                _camera.SetActive(false);

                bossObj.SetActive(true);
                isBossBattleStart = true;
                return;
        }

    }
}
