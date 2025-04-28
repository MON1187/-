using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class ForestGatekeeper : Character
{
    #region varibale
    [SerializeField] private GameObject player;

    [Header("Page 1")]
    [SerializeField] private JudgmentRod judgmentRod;       //마법 검
    [SerializeField] private GameObject judgmentRodObj;     //마법 검
    [SerializeField] private SwampDespair swamp;            //스웨터
    [SerializeField] private GameObject soiledSweaterBall;  //절망의 늪 프리팹
    [SerializeField] private GameObject overBall;           //혹사 프리팹

    [Header("Page 2")]
    [SerializeField] private GameObject darkCraterObj;          //분화구 프리팹
    [SerializeField] private DarkCrater darkCreater;            //분화구 프리팹
    [SerializeField] private GameObject reinforcementsEnemy;    //노령 (적추가 생성) 프리팹
    [SerializeField] private Transform[] spawnPoint;        
    [SerializeField] private GameObject normalBall;             //발악 프리팹
    [SerializeField] private RegretStubbornness regretStubbornness;
    [SerializeField] private GameObject regretStubbornnessObj;

    [Header("UI")]
    [SerializeField] private Slider sliderHP;
    private bool page2 = false;
    private bool lastAttack = false;
    public bool isShield;
    #endregion

    #region 재정의 부문
    public override void Damageball(float damaged)
    {
        if(isShield) { return; }

        sliderHP.value = status.st_Health;

        base.Damageball(damaged);
    }
    #endregion

    #region asu
    private void Awake()
    {
        overWorkPool = new ObjectPool<OverWork>(CreateOverWork, OnGetOverWork, OnReleaseOverWork, OnDestoryOverWork, maxSize: 20);
        soiledSweaterPool = new ObjectPool<SoiledBall>(CreateSoiledSweater, OnGetSoiledWork, OnReleaseSoiledWork, OnDestorySoiledWork, maxSize: 20);
        forestNormalBallPool = new ObjectPool<ForestGatekeeperNormalBall>(CreateFirestNormalBall, OnGetFirestNormalBall, OnReleaseFirestNormalBall, OnDestoryFirestNormalBall, maxSize: 50);

        sliderHP.maxValue = status.st_Health;
        sliderHP.value = status.st_Health;
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");


        StartCoroutine(PlayTun());
       
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            PlayHarshAccident();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayStruggling();
        }
    }
    #endregion

    IEnumerator PlayTun()
    {
        Debug.Log("Next Tun");

        if (status.st_Health > 250) //1페이지
        {
            switch (PlayPattern1())
            {
                case 0:
                    PlayOverWork();
                    break;
                case 1:
                    PlaySoiledSweater();
                    break;
                case 2:
                    PlaySwampOfDspair();
                    break;
                case 3:
                    PlayRodOfDespair();
                    break;
            }
        }
        else
        {
            if(!page2)
            {
                page2 = true;
                SetNextAd();
            }

            if(status.st_Health < 100 && !lastAttack)
            {
                lastAttack = true;
                PlayRegretStubbornness();
                
            }

            //2페이지
            switch (PlayPattern2())
            {
                case 0:
                    PlayHarshAccident();
                    break;
                case 1:
                    DarkCrater();
                    break;
                case 2:
                    ShatteredGhost();
                    break;
                case 3:
                    PlayStruggling();
                    break;
            }
        }
        
        yield return null;
    }

    private void SetNextAd()
    {
        judgmentRodObj.SetActive(false);
    }

#region 1 Page

    private int PlayPattern1()
    {
        int index = Random.Range(0, 100);

        if (index <= 45) { return 0; }  //0~45
        else if (index >= 61 && index <= 65) { return 1; }   //46 ~ 65
        else if(index >= 61 && index <= 85) { return 2; }  //66~ 85
        else { return 3; }  //86~100
    }

    #region 혹사
    private void PlayOverWork()
    {
        StartCoroutine(AttackOverWork(7));
    }

    private IEnumerator AttackOverWork(int count)
    {
        int newX = 0;
        int newY = 0;

        for(int i = 0; i < count; i++)
        {
            newX = Random.Range(0, 5);
            newY = Random.Range(0, 5);

            var overWorkBall = overWorkPool.Get();
            //위치 지정
            Vector3 spawnPos = new Vector3(transform.position.x + newX, transform.position.y + newY, 0);
            overWorkBall.transform.position = spawnPos;
            //방향 지정
            Quaternion quaternion = Quaternion.Euler(0, 0, GeyZ(spawnPos));
            overWorkBall.transform.rotation = quaternion;

            StartCoroutine(CallOverWork(overWorkBall));
            yield return TimeManager.WaitForSeconds(.1f);
        }
        yield return TimeManager.WaitForSeconds(1f);
        StartCoroutine(PlayTun());
    }

    private IEnumerator CallOverWork(OverWork overWorkBall)
    {
        yield return TimeManager.WaitForSeconds(0.5f);
        overWorkBall.CallMe(status.st_OffensePower,false,default);
    }

    float GeyZ(Vector3 overBall)
    {
        Vector3 distance = (overBall - player.transform.position).normalized;
        float distanceZ = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        return distanceZ;
    }
    #endregion

    #region 더러워진 스웨터
    private void PlaySoiledSweater()
    {
        StartCoroutine(SoieldSweater());
    }
    
    private IEnumerator SoieldSweater()
    {
        swamp.GetShield();
        yield return TimeManager.WaitForSeconds(4);
        StartCoroutine(PlayTun());
    }

    #endregion

    #region 절망의 늪
    private void PlaySwampOfDspair()
    {
        StartCoroutine(SwampOfDspair(4));
    }

    private IEnumerator SwampOfDspair(float playCount)
    {
        Quaternion quaternion;
        float z = 0;
        for(int i = 0; i < playCount; i ++)
        {
            z = Random.Range(-45, 45);
            quaternion = Quaternion.Euler(0, 0, z);
            SpawnDspair(transform.position + (Vector3.up * 2), quaternion);
            yield return TimeManager.WaitForSeconds(.1f);
        }

        yield return TimeManager.WaitForSeconds(3f);

        StartCoroutine(PlayTun());
    }

    private void SpawnDspair(Vector3 spawonPosition, Quaternion rot)
    {
        var dspair = soiledSweaterPool.Get();
        dspair.transform.position = spawonPosition;
        dspair.transform.rotation = rot;
        dspair.CallMe(status.st_OffensePower);
    }
    #endregion

    #region 절망의 봉
    private void PlayRodOfDespair()
    {
        StartCoroutine(RodOfDesoair());
    }

    private IEnumerator RodOfDesoair()
    {
        judgmentRod.CallMe();
        yield return TimeManager.WaitForSeconds(7f);
        StartCoroutine(PlayTun());
    }
    #endregion

#endregion

#region 2 Page
    private int PlayPattern2()
    {
        int index = Random.Range(0, 100);

        if (index <= 45) { return 0; }  //0~40
        else if (index >= 61 && index <= 65) { return 1; }   //41 ~ 55
        else if (index >= 61 && index <= 85) { return 2; }  //56~ 70
        else { return 3; }  //71~100
    }

    #region 혹독한 사고

    private void PlayHarshAccident()
    {
        StartCoroutine(AttackHarshAccident(25));
    }

    private IEnumerator AttackHarshAccident(int count)
    {
        int newX = 0;
        int newY = 0;

        for (int i = 0; i < count; i++)
        {
            newX = Random.Range(0, 5);
            newY = Random.Range(0, 5);

            var overWorkBall = overWorkPool.Get();
            //위치 지정
            Vector3 spawnPos = new Vector3(transform.position.x + newX, transform.position.y + newY, 0);
            overWorkBall.transform.position = spawnPos;
            //방향 지정
            Quaternion quaternion = Quaternion.Euler(0, 0, GeyZ(spawnPos));
            overWorkBall.transform.rotation = quaternion;

            StartCoroutine(CallHarshAccident(overWorkBall));
            yield return TimeManager.WaitForSeconds(.075f);
        }

        StartCoroutine(PlayTun());
    }

    private IEnumerator CallHarshAccident(OverWork overWorkBall)
    {
        yield return TimeManager.WaitForSeconds(0.5f);

        bool isMoveing = Random.Range(0, 100) < 75 ? false : true;
        Debug.Log(isMoveing);
        overWorkBall.CallMe(status.st_OffensePower, isMoveing, player.transform.position);
    }
    #endregion

    #region 어두운 분화구
    private void DarkCrater()
    {
        StartCoroutine(PlayDarkCrater());
    }

    private IEnumerator PlayDarkCrater()
    {
        Vector3 spawnVec = new Vector3(player.transform.position.x, transform.position.y + 2, 0);
        darkCraterObj.transform.position = spawnVec;
        yield return TimeManager.WaitForSeconds(1);
        darkCraterObj.SetActive(true);
        darkCreater.CallMe(status.st_OffensePower);
        yield return TimeManager.WaitForSeconds(2);

        StartCoroutine(PlayTun());
        darkCraterObj.SetActive(false);
    }
    #endregion

    #region 헤집어진 망령
    private void ShatteredGhost()
    {
        StartCoroutine(SpawnShatteredGhost());
    }
    private IEnumerator SpawnShatteredGhost()
    {
        Instantiate(reinforcementsEnemy, spawnPoint[0].transform.position, Quaternion.identity);
        yield return TimeManager.WaitForSeconds(.5f);
        Instantiate(reinforcementsEnemy, spawnPoint[1].transform.position, Quaternion.identity);
        yield return TimeManager.WaitForSeconds(1f);
        StartCoroutine(PlayTun());
    }

    #endregion

    #region 후회,고집
    private void PlayRegretStubbornness()
    {
        StartCoroutine(RegretStubbornness());
    }

    private IEnumerator RegretStubbornness()
    {
        yield return TimeManager.WaitForSeconds(5f);
        regretStubbornnessObj.SetActive(true);
        regretStubbornness.CallMe(status.st_OffensePower);
    }

    #endregion

    #region 발악
    private void PlayStruggling()
    {
        StartCoroutine(IEStruggling(13));
    }
    private IEnumerator IEStruggling(float playCount)
    {
        Quaternion quaternion;
        float z = 0;
        for (int i = 0; i < playCount; i++)
        {
            z = Random.Range(-45, 45);
            quaternion = Quaternion.Euler(0, 0, z);
            Struggling(transform.position + (Vector3.up * 2), quaternion);
            yield return TimeManager.WaitForSeconds(.05f);
        }

        yield return TimeManager.WaitForSeconds(3f);

        StartCoroutine(PlayTun());
    }

    private void Struggling(Vector3 spawonPosition, Quaternion rot)
    {
        var dspair = forestNormalBallPool.Get();
        Debug.Log(dspair.gameObject.GetComponent<ForestGatekeeperNormalBall>());
        dspair.transform.position = spawonPosition;
        dspair.transform.rotation = rot;
        dspair.CallMe(status.st_OffensePower);
    }
    #endregion
    #endregion

    #region Pool

    #region 혹막
    IObjectPool<OverWork> overWorkPool;

    private OverWork CreateOverWork()
    {
        OverWork overWork = Instantiate(overBall).GetComponent<OverWork>();
        overWork.SetManagedPool(overWorkPool);
        return overWork;
    }
    private void OnGetOverWork(OverWork over)
    {
        over.gameObject.SetActive(true);
    }
    private void OnReleaseOverWork(OverWork over)
    {
        over.gameObject.SetActive(false);
    }
    private void OnDestoryOverWork(OverWork over)
    {
        Destroy(over.gameObject);
    }
    #endregion

    #region 절망의 늪
    IObjectPool<SoiledBall> soiledSweaterPool;

    private SoiledBall CreateSoiledSweater()
    {
        SoiledBall _soiledSweater = Instantiate(soiledSweaterBall).GetComponent<SoiledBall>();
        _soiledSweater.SetManagedPool(soiledSweaterPool);
        return _soiledSweater;
    }
    private void OnGetSoiledWork(SoiledBall sweater)
    {
        sweater.gameObject.SetActive(true);
    }
    private void OnReleaseSoiledWork(SoiledBall sweater)
    {
        sweater.gameObject.SetActive(false);
    }
    private void OnDestorySoiledWork(SoiledBall sweater)
    {
        Destroy(sweater.gameObject);
    }
    #endregion

    #region NormalBall
    IObjectPool<ForestGatekeeperNormalBall> forestNormalBallPool;

    private ForestGatekeeperNormalBall CreateFirestNormalBall()
    {
        ForestGatekeeperNormalBall _soiledSweater = Instantiate(normalBall).GetComponent<ForestGatekeeperNormalBall>();
        _soiledSweater.SetManagedPool(forestNormalBallPool);
        return _soiledSweater;
    }
    private void OnGetFirestNormalBall(ForestGatekeeperNormalBall sweater)
    {
        sweater.gameObject.SetActive(true);
    }
    private void OnReleaseFirestNormalBall(ForestGatekeeperNormalBall sweater)
    {
        sweater.gameObject.SetActive(false);
    }
    private void OnDestoryFirestNormalBall(ForestGatekeeperNormalBall sweater)
    {
        Destroy(sweater.gameObject);
    }
    #endregion

    #endregion
}
