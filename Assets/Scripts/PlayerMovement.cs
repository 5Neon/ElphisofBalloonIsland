using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    [Header("Player Settings")]
    public float speed = 5f;
    public float rotateSpeed = 10f;
    [Space(10)]

    Vector3 horizontalMovement;
    Vector3 verticalMovement;

    [Header("Jump Setting")]
    public float jumpForce;
    private bool readyToJump;

    Rigidbody rb;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundMask;
    bool isGrounded;

    private float waitTime = 1.2f;

    // 점프맵 전용
    [Header("Jump Map Settings")]
    private float timeCounter = 0;
    public float jumpMapSpeed = 0.4f;
    public float jumpMap_jumpForce = 8f;
    [HideInInspector]
    public float jumpMapRadiusSize = 15f;

    [HideInInspector]
    Vector3 deployPoint;

    // 열기구용
    //[Header("AirBalloon")]
    //public Transform AirBalloonTarget;
    //RaycastHit hit;


    private void Start()
    {
        transform.position = startPoint.position;     // 시작할 때 지정된 위치로 이동
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        readyToJump = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && readyToJump && isGrounded && GameManager.isTalking == false)
        {
            readyToJump = false;
            StartCoroutine(JumpDelay());
            Jump();
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundMask);

        horizontalMovement = Camera.main.transform.forward;
        horizontalMovement.y = 0;
        horizontalMovement = Vector3.Normalize(horizontalMovement);
        verticalMovement = Quaternion.Euler(new Vector3(0, 90, 0)) * horizontalMovement;

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && GameManager.isTalking == false)
        {
            Move();
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (!isGrounded)
        {
            GameManager.isGround = false;
            animator.SetBool("isGround", false);
        }
        else
        {
            GameManager.isJumped = false;
            GameManager.isGround = true;

            animator.SetBool("isJumping", false);
            animator.SetBool("isGround", true);
        }
    }

    void OnAirCheck()
    {
        RaycastHit check;

        if (!Physics.Raycast(transform.position, Vector3.down, out check, 5f))
        {
            GameManager.onAir = true;
            animator.SetBool("isFalling", true);
            animator.SetFloat("FallBlend", 1f);
        }
        else
        {
            GameManager.onAir = false;

            if (GameManager.isGround == true)
            {
                rb.drag = 0f;

                animator.SetBool("isFalling", false);
                animator.SetBool("isHanging", false);

                if (clone != null)
                {
                    StartCoroutine(DestroyBalloon());
                }
            }
            animator.SetFloat("FallBlend", 0f);
        }
    }

    void IslandCheck()
    {
        RaycastHit Islandcheck;
        if (Physics.Raycast(gameObject.transform.position, Vector3.down, out Islandcheck, Mathf.Infinity))
        {
            if (Islandcheck.collider.tag == "Island")
            {
                // 떨어지는 위치
                deployPoint = Islandcheck.collider.transform.Find("RedeployPoint").gameObject.transform.position;

                switch (Islandcheck.collider.name)
                {
                    default:
                        GameManager.state = GameManager.Island.Air;
                        break;
                    case "FirstIsland":
                        GameManager.state = GameManager.Island.FirstWorld;
                        break;
                    case "Puzzle_Maze_Island":
                        GameManager.state = GameManager.Island.Puzzle_Maze;
                        break;
                    case "Puzzle_Jump_Island":
                        GameManager.state = GameManager.Island.Puzzle_Jump;
                        break;
                    case "Story_Island-1":
                    case "Story_Island-2":
                        GameManager.state = GameManager.Island.Story;
                        break;
                    case "Ending_Island":
                        GameManager.state = GameManager.Island.Ending;
                        break;
                }
            }
            else
            {
                GameManager.state = GameManager.Island.Air;
            }

            if (Islandcheck.collider.name == "rainbow")
            {
                GameManager.state = GameManager.Island.Ending;
            }
        }
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 rightMovement = verticalMovement * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = horizontalMovement * speed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

    void Jump()
    {
        GameManager.isJumped = true;
        animator.SetBool("isJumping", true);
        animator.SetBool("isGround", false);

        //rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(waitTime);

        readyToJump = true;
    }
}
