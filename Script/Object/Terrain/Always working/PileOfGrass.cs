namespace GhostEvilRation.GameojbectSysteam
{
    using System.Collections;
    using UnityEngine;

    /// <summary>
    /// Ǯ���� �Դϴ�.
    /// ���� Ǯ���̷� ������ ���� ���˴ϴ�.
    /// ���� ������ ĳ���Ͱ� ���� �ְų�, ������ ���� ������ �ִ� ��찡 �ֽ��ϴ�.
    /// </summary>
    public class PileOfGrass : MonoBehaviour
    {
        //0 = normal, 1 = enemyspawn, 2 = blocking the way
        [SerializeField,Range(0,2)] private int index;
        [SerializeField] private float radius;              //������
        [SerializeField] private LayerMask hitLayer;
        [SerializeField] private GameObject hiddenObject;   //������ ������Ʈ �Ǵ� �� ������

        public int useValue = 1;       //�⺻���� 1 ������ ������, index�� ���� 1�̻��϶� ���ȴ�.
        private float minDepth = 0f;
        private float maxDepth = 4f;

        public float tickTime = 0.1f;

        WaitForSeconds tick;
        private void Awake()
        {
            tick = new WaitForSeconds(tickTime);
        }
        private void Start()
        {
            if (hiddenObject != null && index == 2)
            {
                hiddenObject.SetActive(true);
            }
        }
        private void Update()
        {
            switch (index)
            {
                case 0: //normal
                        //no job
                    return;
                case 1: //enemyspawn
                    SpawnEnemy();
                    return;
                case 2: //blocking the way
                    blockingTheWay();
                    return;
            }
        }

        /// <summary>
        /// index = 1�ϰ�� ����ȴ�.
        /// ������ �ִ� ���� ���� ��ų�� ���ȴ�.
        /// </summary>
        void SpawnEnemy()
        {
            if(useValue > 0)
            {
                Collider2D[] hitCollider = Physics2D.OverlapCircleAll(transform.position, radius, hitLayer, minDepth, maxDepth);
                bool hit = hitCollider.Length > 0;

                if (hit)
                {
                    int spawnindex = useValue;
                    useValue = 0;
                    for (int i = 0; i < spawnindex; i++)
                    {
                        Debug.Log("spawn Enemy");
                    }
                }
            }
        }
        /// <summary>
        /// index = 2�϶� ����ȴ�.
        /// ������ �ִ� ��Ұ� "���̵� �ƿ�"�� ����ɶ� �ߵ��ϱ� ���� �Լ��̴�.
        /// </summary>
        void blockingTheWay()
        {
            if(useValue > 0)
            {
                Collider2D[] hitCollider = Physics2D.OverlapCircleAll(transform.position, radius, hitLayer, minDepth, maxDepth);
                bool hit = hitCollider.Length > 0;

                if(hit)
                {
                    StartCoroutine(outFade());
                    useValue -= 1;
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        private IEnumerator outFade()
        {
            hiddenObject.SetActive(false);
            yield return tick;
            //while(?)
            //{
            //    yield return tick;

            //    //Pad effect
            //}

        }
    }
}
