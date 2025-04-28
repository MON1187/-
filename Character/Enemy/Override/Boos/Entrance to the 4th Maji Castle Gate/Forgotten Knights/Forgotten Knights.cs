using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using static TagNameSpace;
using static ManagerBuf;
using static BufNameSpace;
using UnityEngine.Timeline;

public class ForgottenKnights : NormalEnemyBase, IDamageball
{
    [Header("Perfab")]
    [HideInInspector]public GameObject playerObj;
    [SerializeField] private GetBufBody bufBody;

    [Header("Pgae Perfab")]
    [SerializeField] GameObject swordEnergyObj;
    [SerializeField] SwordsManship swordsManship;
    [SerializeField] FalloftheForgottenKnight falloftheForgottenKnight;

    public float setY;

    private void Awake()
    {
        swordEnergypool = new ObjectPool<SwordEnergyTrigger>(CreateSwordEnergy, OnGetSwordEnergy, OnReleaseSwordEnergy, OnDestorySwordEnergy, maxSize : 5);
    }

    public void Start()
    {
        setY = transform.position.y;
        playerObj = GameObject.FindWithTag("Player");

        StartCoroutine(PlayTun());
    }

    private void Update()
    {
        //if ((Input.GetKeyDown(KeyCode.A)))
        //{
        //    PlaySwordsmanship();
        //}
        //if ((Input.GetKeyDown(KeyCode.S)))
        //{
        //    PlayGreatswordCleave();
        //}
        //if ((Input.GetKeyDown(KeyCode.D)))
        //{
        //    PlayCollapse();
        //}
        //if ((Input.GetKeyDown(KeyCode.F)))
        //{
        //    PlayGodBless();
        //}
    }
    #region Page

    private IEnumerator PlayTun()
    {
        switch (PlayPattern())
        {
            case 0:
                PlaySwordsmanship();
                break;
            case 1:
                PlayGreatswordCleave();
                break;
            case 2:
                PlayCollapse();
                break;
            case 3:
                PlayGodBless();
                break;
        }

        yield return null;
    }

    private int PlayPattern()
    {
        int index = Random.Range(0, 100);

        if (index <= 45) { return 0; }  //0~45
        else if (index >= 61 && index <= 65) { return 1; }   //46 ~ 65
        else if (index >= 66 && index <= 80) { return 2; }  //66 ~` 80
        else { return 3; }  //81 ~ 100
    }

    #region ��˼�
    void PlaySwordsmanship()
    {
        StartCoroutine(Swordsmanship());
    }
    private IEnumerator Swordsmanship()
    {
        //�ڽ��� ��ġ�� Ÿ���� ������ �̵��ϰԲ� �ϴ� �ڵ� �ۼ�
        float curtime = 0;

        Vector3 movePoint = GetMovePoint();
        while(curtime < 1)
        {
            if (transform.position == movePoint) break;

            curtime += Time.deltaTime;
            Vector3 moveLerp = Vector3.Lerp(transform.position, movePoint, curtime);
            transform.position = moveLerp;

            yield return null;
        }

        for (int i = 0; i < 3; i++)
        {
            LookingTarget();

            float a = 0;
            Vector3 attackMoveingPoint = transform.position + transform.right * -2;
            swordsManship.CallMe(i, .5f,status.st_OffensePower + status.st_ExtraDamage);
            while (a < .5f)
            {
                if(transform.position ==  attackMoveingPoint) break;
                a += Time.deltaTime;
                Vector3 moveLerp = Vector3.Lerp(transform.position, attackMoveingPoint, a);
                transform.position = moveLerp;

                yield return null;
            }

            yield return TimeManager.WaitForSeconds(.5f);
        }

        StartCoroutine(BackMoveing());
        yield return TimeManager.WaitForSeconds(3);
        StartCoroutine(PlayTun());
    }

    private IEnumerator BackMoveing()
    {
        LookingTarget();
        float time = 0;

        Vector3 movePoint = transform.position + transform.right * 5f;

        while(time < 1)
        {
            time += Time.deltaTime;

            Vector3 moveLerp = Vector3.Lerp(transform.position,movePoint, time);
            transform.position = moveLerp;

            yield return null;
        }
    }

    private Vector3 GetMovePoint()
    {
        Vector3 movePoint = default;
        if (TargetDistance() > 0) { movePoint = playerObj.transform.position + transform.right * 1; /*Debug.Log("A");*/ }   //������
        else { movePoint = playerObj.transform.position + transform.right * -1;/* Debug.Log("B");*/ }                       //����
        //�ݴ�� ����..

        movePoint.y = setY;

        return movePoint;
    }
    #endregion


    #region ��� ������
    void PlayGreatswordCleave()
    {
        StartCoroutine(GreatswordCleave());
    }

    private IEnumerator GreatswordCleave()
    {
        LookingTarget();

        var swordEnerg = swordEnergypool.Get();
        swordEnerg.GetValue(status.st_OffensePower,Player);
        swordEnerg.CallMe(status.st_MoveSpeed);

        swordEnerg.transform.position = transform.position + transform.right * 1f;   //��ġ ����
        swordEnerg.transform.rotation = transform.rotation;     //���� ����

        yield return TimeManager.WaitForSeconds(2);
        StartCoroutine(PlayTun());
    }
    #endregion


    #region �ذ�
    void PlayCollapse()
    {
        StartCoroutine(Collapse());
    }
    private IEnumerator Collapse()
    {
        falloftheForgottenKnight.CallMe(status.st_OffensePower);

        yield return TimeManager.WaitForSeconds(5);
        StartCoroutine(PlayTun());
    }

    #endregion


    #region ��ȣ
    void PlayGodBless()
    {
        StartCoroutine(GodBless());
    }

    IEnumerator GodBless()
    {
        Debug.Log("�ܴ����� ��");
        bufBody.ApplyBuff(GetBuf(bufBody, up_def, 3, 4));

        yield return  TimeManager.WaitForSeconds(3);
        StartCoroutine(PlayTun());
    }
    #endregion


    #endregion

    private void LookingTarget()
    {
        if (TargetDistance() > 0) transform.rotation = Quaternion.Euler(0,0,0);
        else transform.rotation = Quaternion.Euler(0,180,0);
    }
    /// <summary>
    /// �ڽ��� �������� Ÿ���� �������̶�� -1 | �����̶�� 1�� ��ȯ �մϴ�
    /// </summary>
    /// <returns></returns>
    private float TargetDistance()
    {
        float distance = transform.position.x - playerObj.transform.position.x > 0 ? 1 : -1;
        return distance;
    }

    #region Pool

    #region SwordEnergy
    IObjectPool<SwordEnergyTrigger> swordEnergypool;

    private SwordEnergyTrigger CreateSwordEnergy()
    {
        SwordEnergyTrigger _soiledSweater = Instantiate(swordEnergyObj).GetComponent<SwordEnergyTrigger>();
        _soiledSweater.SetManagedPool(swordEnergypool);
        return _soiledSweater;
    }
    private void OnGetSwordEnergy(SwordEnergyTrigger sweater)
    {
        sweater.gameObject.SetActive(true);
    }
    private void OnReleaseSwordEnergy(SwordEnergyTrigger sweater)
    {
        sweater.gameObject.SetActive(false);
    }
    private void OnDestorySwordEnergy(SwordEnergyTrigger sweater)
    {
        Destroy(sweater.gameObject);
    }
    #endregion

    #endregion

}
