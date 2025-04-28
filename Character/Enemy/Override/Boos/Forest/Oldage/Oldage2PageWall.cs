using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//2ÆäÀÌÁö
public class Oldage2PageWall : Character
{
    [SerializeField] private GameObject player;

    [Header("Attack pattern")]
    [SerializeField] private GameObject treeRoots;
    [SerializeField] private GameObject Ball;
    [SerializeField] private A a;
    [SerializeField] private GameObject attackRoot;
    private TakeTheRoot tackkRoot;


    [SerializeField] private GameObject endPoint1;
    [SerializeField] private GameObject endPoint2;

    private void Start()
    {
        tackkRoot = attackRoot.GetComponent<TakeTheRoot>();
        player = GameObject.FindWithTag("Player");

        hpBar.maxValue = status.st_MaxHealth;
        hpBar.value = status.st_Health;

        StartCoroutine(playTun());
    }
    private void Update()
    {
        HpBar(status.st_Health);

        if (Input.GetKeyDown(KeyCode.Alpha1))
            CarpenterDriving();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SpoutingMagicalEnergy();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            TakingRoot();
    }
    IEnumerator playTun()
    {
        yield return null;
        switch (PlayPatten())
        {
            case 0:
                CarpenterDriving();
                break;
            case 1:
                SpoutingMagicalEnergy();
                break;
            case 2:
                TakingRoot();
                break;
            case 3:
                MyosuWalking();
                break;
        }
    }

    private int PlayPatten()
    {
        int index = Random.Range(0, 100);
        Debug.Log(index);
        if (index <= 30) { return 0; }  //0~60
        else if (index >= 31 && index <= 50) { return 1; }  //31 ~ 50
        else if (index >= 51 && index <= 75 ){ return 2; }  //51~75
        else { return 3; }  //76~100
    }
    #region »Ñ¸®²È±â
    public void CarpenterDriving()       //³ª¹«°ÉÀÌ ±Í °ÉÀ×
    {
        StartCoroutine(MakeRooting(treeRoots, 45));
    }

    IEnumerator MakeRooting(GameObject obj, int spawonCount)
    {
        int index = 0;
        float minX = endPoint1.transform.position.x;
        float maxX = endPoint2.transform.position.x;

        float randomX = default;
        Vector3 spawonPos = default;

        while (index < spawonCount)
        {
            randomX = Random.Range(minX, maxX);
            spawonPos = new Vector3(randomX, transform.position.y - 5.55f, 0);

            index++;
            GameObject a = Instantiate(obj, spawonPos, Quaternion.identity);
            a.GetComponent<SkillRooting>().CallAttack(status.st_OffensePower - 5);

            yield return TimeManager.WaitForSeconds(0.05f);
        }

        yield return TimeManager.WaitForSeconds(2.5f);
        StartCoroutine(playTun());
    }

    #endregion

    #region ¸¶±â »Õ
    public void SpoutingMagicalEnergy()     //¸¶±â »Õ±â »Õ»Õ
    {
        StartCoroutine(ShotMagicalEnergy());
    }

    IEnumerator ShotMagicalEnergy()
    {
        for(int i = 0; i < 3; i++)
        {
            Quaternion a = Quaternion.Euler(0, 0, GeyZ());
            GameObject c = Instantiate(Ball, transform.position, a);
            c.GetComponent<SkillMagiTan>().CallME((int)(status.st_OffensePower + 5));
            yield return TimeManager.WaitForSeconds(1f);
        }
        StartCoroutine(playTun());
    }

    float GeyZ()
    {
        Vector3 distance = (transform.position - player.transform.position).normalized;
        float distanceZ = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;

        return distanceZ;
    }
    #endregion

    #region ÀÌ»¡ Ä¼¾Ç
    public void TakingRoot()                //³»·Á³ö ¾ÆÁ÷ ´Ù »ì¼ö ÀÖ¾î!
    {
        StartCoroutine(TakingRooting());
    }

    private IEnumerator TakingRooting()
    {
        Vector2 setPos = new Vector2(player.transform.position.x, attackRoot.transform.position.y);
        attackRoot.transform.position = setPos;
        tackkRoot.CallMe();

        yield return new WaitForSeconds(3f);
        StartCoroutine(playTun());
    }
    #endregion
    #region ¹¦¼ö°È±â
    public void MyosuWalking()              //¾ÆÁ÷ ÇÑ¹ß ³²¾Ò´Ù.
    {
        StartCoroutine(PlayWalking());
    }
    IEnumerator PlayWalking()
    {
        a.Awak();
        yield return new WaitForSeconds(3f);
        StartCoroutine(playTun());
    }
    #endregion

    #region
    [SerializeField] GameObject treeBody;
    public override void Died()
    {
        if (status.st_Health <= 0)
            treeBody.SetActive(false);
    }
    #endregion

    #region U*I
    [Header("UI")]
    public Slider hpBar;
    private void HpBar(float a)
    {
        hpBar.value = a;
    }
    #endregion 
}
