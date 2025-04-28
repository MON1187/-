using System.Collections;
using UnityEngine;
using GhostEvilRation.Function;

public class EnemyBaseMoveComtroller : MonoBehaviour, Movement
{
    [SerializeField] private NormalEnemyBase normalEnemyBase;

    public Transform setTrasnform;              //Standardize yourself when you're not being tracked
    private bool isAutoMoveing = false;         //Determine whether automatic movement has started or not
    private bool isAutoNextMoveing = false;     //Make sure you're heading to the next point

    //Unity Assets
    public Rigidbody2D rd;

    //GhostEvilRatiion Assets
    public CheckTargetPos ctargetPos;

    #region Status
    public float MoveSpeed { get => normalEnemyBase.status.st_MoveSpeed; set => normalEnemyBase.status.st_MoveSpeed = value; }
    public float JumpForce { get => normalEnemyBase.status.st_JumpForce; set => normalEnemyBase.status.st_JumpForce = value; }

    #endregion


    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        ctargetPos = GetComponentInChildren<CheckTargetPos>();
        setTrasnform = transform;
    }
    private void Update()
    {
        CheckFrontBlock();
        MoveHandler(MoveSpeed);
    }

    #region Move
    public virtual void MoveHandler(float moveSpeed)
    {
        if (MoveSpeed <= 0) { return; }  //¼Óµµ°¡ ¾ø´Ù¸é ÄÆ¶ß.
        if (ctargetPos.IsTargetTransform())
        {
            TrackingMovement(moveSpeed, ctargetPos.GetTargetTransform());
        }
        else
        {
            if (!isAutoMoveing) { isAutoMoveing = true;}

            if (isAutoNextMoveing) { return; }
            //Fuck it's Perfect! but. . .
            else {
                isAutoNextMoveing = true;
                StartCoroutine(AutomaticMovement(moveSpeed, setTrasnform, AutoMoveNextPoint(setTrasnform)));
            }
        }
    }

    //Auto Moveing.
    public virtual IEnumerator AutomaticMovement(float moveSpeed, Transform myPos, Vector3 targetPos)
    {
        //This is the problem Fuck.
        float distance = Mathf.Round((Vector3.Distance(myPos.position, targetPos)));
        //float distance = Mathf.Round((myPos.position.x - movePoint.x));
        while (true)
        {
            if (CheckFrontBlock()) { break; }
            distance = Mathf.Round((Vector3.Distance(myPos.position, targetPos)));
            Debug.Log(distance);
            if (distance < 1) { Debug.Log("Stop"); break; }
            else
            {
                rd.velocity = new Vector2(-ReturnFunction.GetMoveingDirection(transform.position, targetPos) * moveSpeed, rd.velocity.y);
            }
            yield return null;
        }
        yield return TimeManager.WaitForSeconds(3f);

        isAutoNextMoveing = false;
        MoveHandler(MoveSpeed);
    }

    //Take a picture of a certain space based on your location
    public virtual Vector3 AutoMoveNextPoint(Transform myPos)
    {
        Vector3 myVec = myPos.position;
        Vector3 randomPos = myVec + Random.insideUnitSphere * 5;

        randomPos.x += Random.Range(2,4);
        randomPos.y = myVec.y;
        randomPos.z = myVec.z;

        //Debug.Log(randomPos);
        return randomPos;
    }

    /// <summary>
    /// After receiving the location of the target, move to that location. If you miss it, move to the last position and execute 'MoveHandel' again.
    /// </summary>
    /// <param name="moveSpeed"></param>
    /// <param name="targetPos"></param>
    /// <returns></returns>
    public virtual IEnumerator TrackingMovement(float moveSpeed, Transform targetPos)
    {
        Transform movePoint = targetPos;
        while (transform.position != targetPos.position)
        {
            rd.velocity = new Vector2(ReturnFunction.GetMoveingDirection(transform.position, targetPos.position) * moveSpeed, rd.velocity.y);

            yield return TimeManager.WaitForSeconds(.1f);
        }
        yield return TimeManager.WaitForSeconds(3f);
        MoveHandler(MoveSpeed);
    }
    #endregion

    #region Jump
    public virtual void Jumping(float jumpForce)
    {

    }

    public virtual void JumpController()
    {

    }
    #endregion

    #region GroundCheck
    public LayerMask groundLayer;
    Vector2 checkPoint;

    public bool CheckFrontBlock()
    {
        checkPoint = transform.position + transform.right * 1f;
        checkPoint.y -= 1f;
        bool checkGround = Physics2D.OverlapCircle(checkPoint, 1f, groundLayer);

        return !checkGround;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkPoint, 1f);
    }
    #endregion
}
