using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private CharacterMovementData robertMoveData;
    [SerializeField] private CollisionData robertCollisionData;
    private bool isGrounded;
    private bool isCollidingWall;

    private PlayerAnimation playerAnimation;
    private Rigidbody2D playerRigid2D;

    float maxSpeed = 17;
    private int horizontalDir = 0;
    private float scaleX;

    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerRigid2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
       robertMoveData.Speed = 0;
       scaleX = transform.localScale.x;
    }

    private void Update()
    {
        HorizontalMove();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        if (isGrounded == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                robertMoveData.Jump(playerRigid2D);
                isGrounded = false;
            }
            playerAnimation.PlayerJumpsAnim(isGrounded);
        }
        else
        {
            robertMoveData.Fall(playerRigid2D);
        }
    }

    private void HorizontalMove()
    {
        if (Input.GetKey(KeyCode.D))
        {
            robertMoveData.Speed += robertMoveData.Acceleration;
            horizontalDir = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            robertMoveData.Speed += robertMoveData.Acceleration;
            horizontalDir = -1;
        }
        else
        {
            robertMoveData.Speed = 0;
        }
        transform.Translate(
            robertMoveData.GetHorizontalTarget(maxSpeed, horizontalDir));
    }

    private void AnimatePlayer()
    {
        if (horizontalDir > 0)
        {
            transform.localScale =
                new Vector2(scaleX, transform.localScale.y);
        }
        else
        {
            transform.localScale =
                new Vector2(-scaleX, transform.localScale.y);
        }
        playerAnimation.PlayerRunsAnim(robertMoveData.Speed);  // Animation for horizontal run
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == robertCollisionData.GroundCollisionData)
        {
            isGrounded = true;
        }
        if(collision.gameObject.tag == robertCollisionData.WallCollisionData)
        {
            isCollidingWall = true;
        }
    }
}