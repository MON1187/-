namespace GhostEvilRation.GameojbectSysteam
{
    using System.Collections;
    using UnityEngine;

    /// <summary>
    /// 풀더미 입니다.
    /// 보통 풀더미로 가리는 데로 사용됩니다.
    /// 가끔 적대형 캐릭터가 숨어 있거나, 숨겨진 길이 가려져 있는 경우가 있습니다.
    /// </summary>
    public class PileOfGrass : MonoBehaviour
    {
        //0 = normal, 1 = enemyspawn, 2 = blocking the way
        [SerializeField,Range(0,2)] private int index;
        [SerializeField] private float radius;              //반지름
        [SerializeField] private LayerMask hitLayer;
        [SerializeField] private GameObject hiddenObject;   //숨겨진 오브젝트 또는 맵 가리게

        public int useValue = 1;       //기본으로 1 가지고 있으며, index의 값이 1이상일때 사용된다.
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
        /// index = 1일경우 실행된다.
        /// 숨어져 있는 적을 등장 시킬때 사용된다.
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
        /// index = 2일때 실행된다.
        /// 숨겨져 있는 장소가 "페이드 아웃"이 진행될때 발동하기 위한 함수이다.
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
