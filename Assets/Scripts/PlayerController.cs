using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum FacingDirection
    {
        left = -1, right = 1
    }

    public enum CharacterState
    { 
        Idle, Walking, Jumping, Dead
    }

    private CharacterState state = CharacterState.Idle;

    [SerializeField] private Rigidbody2D body2D;

    [Header("Walk Properties")]
    public float maxSpeed = 5f;
    public float accelerationTime = 0.5f;
    public float decelerationTime = 0.25f;
    
    //variables for dashing mechanic
    [Header("Dash Properties")]
    public float speedMultiplier = 2f;
    private bool isDashing = false;
    public float dashDuration = 2f;
    public float dashCooldown = 1f;
    public float cooldownTimer;
    private float dashTimer = 0f;
    private bool canDash = true;

    [Header("Jump Properties")]
    public float apexHeight = 3.5f;
    public float apexTime = 0.5f;
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.55f;
    public Vector2 groundCheckSize = new(0.75f, .2f);
    //variables for double jump mechanic
    public int maxJumps = 2;
    private int jumpCount = 0;

    private Vector2 velocity;
    private float acceleration;
    private float deceleration;

    private float gravity;
    private float jumpVel;

    private Vector2 playerInput;
    private bool jumpPressed = false;

    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;

        gravity = -2 * apexHeight / (apexTime * apexTime);
        jumpVel = 2 * apexHeight / apexTime;

        body2D.gravityScale = 0;

        dashTimer = dashDuration;
    }

    void Update()
    {
        playerInput = new()
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = Input.GetButtonDown("Jump") ? 1 : 0
        };

        if (playerInput.y == 1) jumpPressed = true;

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            isDashing = true;
            dashTimer = dashDuration;
            canDash = false;
            cooldownTimer = 0f;
        }

        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            
            if (dashTimer <= 0)
            {
                isDashing = false;
                cooldownTimer = dashCooldown;
            }
        }
        if (!canDash && !isDashing)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                canDash = true;
            }
        }
    }

    private void FixedUpdate()
    {
        MovementUpdate();
    }

    private void MovementUpdate()
    {
        ProcessWalkInput();
        ProcessJumpInput();

        body2D.linearVelocity = velocity;
    }

    /// <summary>
    /// Modifies velocity.x based on playerInput.x.
    /// </summary>
    private void ProcessWalkInput()
    {
        float currentMaxSpeed;
        float currentAcceleration;

        if (isDashing)
        {
            currentMaxSpeed = maxSpeed * speedMultiplier;
            currentAcceleration = acceleration * speedMultiplier;
        }
        else
        {
            currentMaxSpeed = maxSpeed;
            currentAcceleration = acceleration;
        }

        if (playerInput.x != 0)
        {
            if (Mathf.Sign(playerInput.x) != Mathf.Sign(velocity.x)) velocity.x *= -1;
            velocity.x += playerInput.x * currentAcceleration * Time.fixedDeltaTime;

            velocity.x = Mathf.Clamp(velocity.x, -currentMaxSpeed, currentMaxSpeed);
        }
        else if (Mathf.Abs(velocity.x) > 0.005f)
        {
            velocity.x += -Mathf.Sign(velocity.x) * deceleration * Time.fixedDeltaTime;
        }
        else
        {
            velocity.x = 0;
        }
    }

    /// <summary>
    /// Modifies velocity.y based on playerInput.y.
    /// </summary>
    private void ProcessJumpInput()
    {
        if (IsGrounded())
        {
            jumpCount = 0;
        }

        if (jumpPressed && jumpCount < maxJumps)
        {
            velocity.y = jumpVel;
            jumpPressed = false;
            jumpCount++;
        }
        else if (!IsGrounded())
        {
            velocity.y += gravity * Time.fixedDeltaTime;
            velocity.y = Mathf.Max(velocity.y, -jumpVel);
            jumpPressed = false;
        }
        else
            velocity.y = 0;
    }

    public bool IsWalking()
    {
        return playerInput.x != 0;
    }
    public bool IsGrounded()
    {
        Vector3 origin = transform.position + Vector3.down * groundCheckDistance;
        
        DrawGroundCheck(origin);

        return Physics2D.OverlapBox(origin, groundCheckSize, 0, groundLayer);
    }

    private void DrawGroundCheck(Vector3 origin)
    {
        float halfW = groundCheckSize.x * 0.5f;
        float halfH = groundCheckSize.y * 0.5f;

        Debug.DrawLine(origin + new Vector3(halfW, halfH), origin + new Vector3(halfW, -halfH), Color.yellow);
        Debug.DrawLine(origin + new Vector3(halfW, -halfH), origin + new Vector3(-halfW, -halfH), Color.yellow);
        Debug.DrawLine(origin + new Vector3(-halfW, -halfH), origin + new Vector3(-halfW, halfH), Color.yellow);
        Debug.DrawLine(origin + new Vector3(-halfW, halfH), origin + new Vector3(halfW, halfH), Color.yellow);
    }

    public FacingDirection GetFacingDirection()
    {
        return (FacingDirection)playerInput.x;
    }
}
