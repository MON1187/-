using GhostEvilRation.Character.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    /// <summary>
    /// 직접 할당 값
    [SerializeField] private Transform pos;
    [SerializeField] private Rigidbody2D playerRd;
    [SerializeField] private float waveMoveSpeed;
    /// </summary>

    /// </summary>
    /// 자동 할당 값
    private HingeJoint2D hj;
    private Rigidbody2D rd;
    /// </summary>

    private bool input;         //루프를 잡고 있는지 확인용
    private float posValue;

    private void Start()
    {
        hj = GetComponent<HingeJoint2D>();
        rd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (input)
        {
            if (Input.GetKey(OldPlayerSington.instance.k_JumpKey))
            {
                Vector3 movepos = new Vector3(posValue * rd.velocity.x, 1 * OldPlayerSington.instance.jumpForce, 0);

                OldPlayerSington.isJump = true;

                OldPlayerSington.isRope = false;
                input = false;

                playerRd.velocity = movepos;

                return;
            }

            OldPlayerSington.isRope = true;
            OldPlayerSington.isJump= false;

            posValue = Input.GetAxisRaw("Horizontal");

            rd.AddForce(new Vector2(posValue * waveMoveSpeed * Time.deltaTime, 0), ForceMode2D.Impulse);

            pos.position = transform.position;
        }
         else return;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other != null)
        {
            PlayerController controller = other.GetComponent<PlayerController>();
            if (controller != null)
            {
                //hj.connectedBody = playerRd;
                if (!OldPlayerSington.isRope)
                    input = true;
                else return;
            }
        }
    }
}
