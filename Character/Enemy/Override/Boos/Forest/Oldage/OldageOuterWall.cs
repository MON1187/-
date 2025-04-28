using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

//1Page

public class OldageOuterWall : Character
{
    [SerializeField] private GameObject player;
    [SerializeField] private SpriteRenderer effectMaterial;
    Color reColor;
    [Header("Attack pattern")]
    [SerializeField] private GameObject treeRoots;
    [SerializeField] private GameObject seedBoom;

    [SerializeField] private Transform LickPoint1;
    [SerializeField] private Transform LickPoint2;


    [SerializeField] private GameObject hellPoint01;
    [SerializeField] private GameObject hellPoint02;
    [Header("Next Page")]
    [SerializeField] private GameObject core;

    IObjectPool<BoomSeedPool> _seed;

    private void Awake()
    {
        _seed = new ObjectPool<BoomSeedPool>(CreateSeed, OnGetSeed, OnReleaseSeed, OnDestorySeed, maxSize : 20);
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        reColor = effectMaterial.color;

        hpBar.maxValue = status.st_MaxHealth;
        hpBar.value = status.st_Health;

        StartCoroutine(playTun());
    }
    private void Update()
    {
        HpBar(status.st_Health);
    }

    #region ������ �κ� 

    public override void Died()
    {
        //��Ʈ�� �ִٸ� �ִϸ��̼� ����
        if (status.st_Health <= 0)
        {
            core.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    #endregion

    #region hit Effect
    public override void HitEffect()
    {
        effectMaterial.color = new Color(1f, 1f, 1f, 1f); // ������ �������� �Ͼ��

        StartCoroutine(FadeOutEffect());
    }

    private IEnumerator FadeOutEffect()
    {
        Color currentColor = effectMaterial.color;
        float fadeDuration = 1.0f; // ���̵� �ƿ��� �ɸ��� �ð� (��)
        float fadeSpeed = 1.0f / fadeDuration;

        while (currentColor.a > 0f)
        {
            currentColor.a -= Time.deltaTime * fadeSpeed;
            effectMaterial.color = currentColor;
            yield return null;
        }

        // ������ �������� ��
        effectMaterial.color = reColor;
    }
    #endregion

    #region ����

    IEnumerator playTun()
    {
        yield return null;
        switch (PlayPatten())
        {
            case 0:
                Rooting();
                break;
            case 1:
                CursedSeedBomb();
                break;
            case 2:
                GreatVitality();
                break;
        }
    }

    private int PlayPatten()
    {
        int index = Random.Range(0, 100);

        if (index <= 60) { return 0; }  //0~60
        else if (index >= 61 && index <= 90) { return 1; }   //61 ~ 90
        else { return 2; }  //90~100
    }

    #region �Ѹ��ȱ�
    public void Rooting()
    {
        StartCoroutine(MakeRooting(treeRoots, 15));
    }

    IEnumerator MakeRooting(GameObject obj, int spawonCount)
    {
        int index = 0;
        float minX = player.transform.position.x - 4;
        float maxX = player.transform.position.x + 4;

        float randomX = default;
        Vector3 spawonPos = default;

        while (index < spawonCount)
        {
            randomX = Random.Range(minX, maxX);
            spawonPos = new Vector3(randomX, transform.position.y - 5.55f, 0);

            index++;
            GameObject a = Instantiate(obj, spawonPos, Quaternion.identity);
            a.GetComponent<SkillRooting>().CallAttack(status.st_OffensePower);

            yield return TimeManager.WaitForSeconds(0.125f);
        }

        yield return TimeManager.WaitForSeconds(4.5f);
        StartCoroutine(playTun());
    }

    #endregion

    #region ���ֹ��� ���� ��ź
    public void CursedSeedBomb()
    {
        StartCoroutine(Scattering(seedBoom, 15));
    }

    IEnumerator Scattering(GameObject obj, int count)
    {
        float x;
        float y;

        Vector2 spawonPos = default;
        int index = 0;
        while (index < count)
        {
            index ++;
            x = Random.Range(LickPoint1.position.x, LickPoint2.position.x);
            y = Random.Range(LickPoint1.position.y, LickPoint2.position.y);
            spawonPos = new Vector2 (x, y);

            _BoomSeed(spawonPos);

            yield return null;
        }

        yield return TimeManager.WaitForSeconds(7.5f);
        StartCoroutine(playTun());
    }

    private void _BoomSeed(Vector2 vec)
    {
        var seed = _seed.Get();

        seed.GetComponent<Rigidbody2D>().gravityScale = Random.Range(0.3f, 1f);
        seed.transform.position = vec;

        seed.CallShot();
    }

    #endregion

    #region ������ �����
    public void GreatVitality()
    {
        StartCoroutine(GreatVitalityed());
    }

    IEnumerator GreatVitalityed()
    {
        hellPoint01.SetActive(true);
        hellPoint02.SetActive(true);
        hellPoint01.GetComponent<OldageHell>().CallHell();
        hellPoint02.GetComponent<OldageHell>().CallHell();

        yield return TimeManager.WaitForSeconds(6.5f);
        StartCoroutine(playTun());
    }
    #endregion

    #endregion
    #region Object Pool

    public BoomSeedPool CreateSeed()
    {
        BoomSeedPool seed = Instantiate(seedBoom).GetComponent<BoomSeedPool>();    //���ο� FallingApple ��ü ����
        seed.SetManagedPool(_seed);            //��ü�� BoomSeed Ǯ���� �����ϵ��� ����
        return seed;                               //��ü ��ȯ
    }
    private void OnGetSeed(BoomSeedPool seed)
    {
        seed.gameObject.SetActive(true);
    }
    private void OnReleaseSeed(BoomSeedPool seed)
    {
        seed.gameObject.SetActive(false);
    }
    private void OnDestorySeed(BoomSeedPool seed)
    {
        Destroy(seed.gameObject);
    }

    #endregion

    [Header("UI")]
    public Slider hpBar;
    private void HpBar(float a)
    {
        hpBar.value = a;
    }

}
