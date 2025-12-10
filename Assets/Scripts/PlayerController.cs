using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("Motion Properties")]
    public float maxSpeed = 1.0f;
    public float accelerationsTime, decelerationTime;
    public float acceleration, deceleration;
    private Vector2 velocity;

    private Rigidbody2D body2D;

    [Header("Ground Properties")]
    public float groundCheckDistance = 0.6f;
    public Vector2 groundCheckOffset = new Vector2(0f, -0.5f);
    public LayerMask groundLayer;

    public enum FacingDirection
    {
        left, right
    }

    private FacingDirection facingDirection = FacingDirection.right;

    void Start()
    {
        acceleration = maxSpeed / accelerationsTime;
        deceleration = maxSpeed / decelerationTime;

        body2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // The input from the player needs to be determined and
        // then passed in the to the MovementUpdate which should
        // manage the actual movement of the character.
        Vector2 playerInput = new Vector2();
        {
            playerInput.x = Input.GetAxisRaw("Horizontal");
        }

        //float horizontalMovement = Input.GetAxisRaw("Horizontal");

        MovementUpdate(playerInput);

        //test if player is walking
        Debug.Log("Velocity X: " + velocity.x + " IsWalking: " + IsWalking());

        bool groundChecker = IsGrounded();
        Debug.Log("IsGrounded" + groundChecker);

    }

    private void MovementUpdate(Vector2 playerInput)
    {
        if (playerInput.magnitude > 0)
        {
            if (playerInput.x > 0)
            {
                facingDirection = FacingDirection.right;
            }
            else if (playerInput.x < 0)
            {
                facingDirection = FacingDirection.left;
            }

            velocity += playerInput.normalized * acceleration * Time.deltaTime;

            if (velocity.magnitude > maxSpeed)
            {
                velocity = velocity.normalized * maxSpeed;
            }
        }
        else
        {
            velocity -= velocity.normalized * deceleration * Time.deltaTime;

            if (Mathf.Abs(velocity.x) < 0.01f)
            {
                velocity = Vector2.zero;
            }
        }

        body2D.linearVelocity = new Vector2(velocity.x, velocity.y);

    }

    public bool IsWalking()
    {
        if (Mathf.Abs(velocity.x)  > 0.01f)
        {
            return true;

        }
        else
        {
            return false;
        }

    }
    public bool IsGrounded()
    {
        Vector2 origin = (Vector2)transform.position + groundCheckOffset;
        RaycastHit2D touchGround = Physics2D.Raycast(origin, Vector2.down, groundCheckDistance, groundLayer);

        if (touchGround.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public FacingDirection GetFacingDirection()
    {
        return facingDirection;
    }

}
