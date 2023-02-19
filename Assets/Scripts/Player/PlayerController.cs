using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Burst.CompilerServices;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public GameObject Model;

    private Vector3 velocity;
    float jumpTime;
    int[] Lane = new int[3];
    private bool canJump = false;
    private bool isRoll = false;
    [SerializeField] private float playerHight;
    [SerializeField] private float maxSlope;

    RaycastHit slopeHit;

    [SerializeField] private float jumpHeight;
    [SerializeField] private LayerMask wallMask;

    private float currentSpeed;
    private float force;

    [SerializeField] private Animator _ani;

    public bool CanJump { get { return canJump; }}
    public float Force { get { return force; }}

    private void Start()
    {
        Lane[0] = -1;
        Lane[1] = 0;
        Lane[2] = 1;
    }

    float yVelocity;

    void Update()
    {
        Move();
        groundCheck();

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.A) && GameManager.Ins.CurrentLane != 1)
        {
            Turn(GameManager.Ins.CurrentLane, GameManager.Ins.CurrentLane - 1);
            //GameManager.Ins.CurrentLane--;
        }
        if(Input.GetKeyDown(KeyCode.D) && GameManager.Ins.CurrentLane != 3)
        {
            Turn(GameManager.Ins.CurrentLane, GameManager.Ins.CurrentLane + 1);
            //GameManager.Ins.CurrentLane++;
        }
        if (Input.GetKeyDown(KeyCode.W) && canJump && !isRoll)
        {
            Jump();
            RollDone();
        }
        if (Input.GetKeyDown(KeyCode.S) && !isRoll)
        {
            if (!canJump && yVelocity > 0)
                yVelocity = -5f;

            RollHandle();
        }
#endif


    }

    private void FixedUpdate()
    {
        if (GameManager.Ins.IsPlaying)
            GameManager.Ins.Speed += Time.deltaTime;

        if (!isRoll)
        {
            Model.transform.rotation = Quaternion.identity;
            Model.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
            Model.transform.localPosition = new Vector3(0, Model.transform.localPosition.y, 0);
    }

    private void Move()
    {
        if (OnSlope())
        {
            velocity = GetSlopeDirecton() * GameManager.Ins.Speed;
        }
        else
        {
            velocity = Vector3.forward * GameManager.Ins.Speed;
            velocity.y = yVelocity;
        }
        rb.velocity = velocity;

    }

    public void Turn(int crrLane, int toLane)
    {
        int Director = toLane - crrLane;
        float xPos = (wallCheck()) / 3;
        Vector3 toPos = this.transform.position + this.transform.right * Director * xPos + Vector3.forward * rb.velocity.magnitude * .2f ;
        toPos.x = Lane[toLane - 1] * xPos;
        //rb.transform.DOJump(toPos, .2f, 1, .2f);
        rb.DOMove(toPos, .2f);
        GameManager.Ins.CurrentLane += Director;
    }

    private float wallCheck()
    {
        RaycastHit wallLeft;
        RaycastHit wallRight;


        Physics.Raycast(transform.position, -transform.TransformDirection(Vector3.right), out wallLeft, Mathf.Infinity, wallMask);
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out wallRight, Mathf.Infinity, wallMask);

        return Vector3.Distance(wallRight.point, wallLeft.point);
    }

    public void Jump()
    {
        _ani.SetTrigger("Jump");
        yVelocity = Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight);
        jumpTime = Time.time;
        canJump = false;
    }

    public void RollHandle()
    {
        isRoll = true;
        rb.useGravity = false;
        rb.GetComponent<CapsuleCollider>().enabled = false;
        _ani.SetTrigger("Slide");
    }

    public void RollDone()
    {
        isRoll = false;
        rb.useGravity = true;
        rb.GetComponent<CapsuleCollider>().enabled = true;
    }
    private void groundCheck()
    {
        // set gravity idea
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, .5f) && Time.time >= jumpTime + .5f)
        {
            canJump = true;
            yVelocity = 0;
        }
        else
        {
            canJump = false;
            yVelocity += Physics.gravity.y * Time.deltaTime * 2;
        }
    }

    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHight * .5f + .5f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlope && angle != 0;
        }
        return false;
    }

    private Vector3 GetSlopeDirecton()
    {
        return Vector3.ProjectOnPlane(velocity, slopeHit.normal).normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Force"))
        {
            GameManager.Ins.ForceManager.poolUnActive(other.gameObject);
            force += 10;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Trap"))
        {
            Debug.Log("Lose");
            Time.timeScale = 0;
        }
    }


}
