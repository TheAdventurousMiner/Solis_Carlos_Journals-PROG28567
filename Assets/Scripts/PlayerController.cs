using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Track the direction the player is facing
    public enum FacingDirection
    {
        left = -1, right = 1
    }

    //Track the current state of the player
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
        //calculations for acceleration and deceleration rates
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
        //calculate the gravity and jump velocity
        gravity = -2 * apexHeight / (apexTime * apexTime);
        jumpVel = 2 * apexHeight / apexTime;

        body2D.gravityScale = 0;

        dashTimer = dashDuration;
    }

    void Update()
    {
        //Get player inputs for vertical and horizontal movement
        playerInput = new()
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = Input.GetButtonDown("Jump") ? 1 : 0
        };

        if (playerInput.y == 1) jumpPressed = true;
        //Press left shift to dash if the player can
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            isDashing = true;
            dashTimer = dashDuration;
            canDash = false;
            cooldownTimer = 0f;
        }
        //update the dash timer
        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            
            if (dashTimer <= 0)
            {
                isDashing = false;
                cooldownTimer = dashCooldown;
            }
        }
        //uodate the dash cooldown
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
        //increase the speed and acceleration if the player is dashing
        //and set it back to the regular speed and acceleration if the 
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
            //Flip velocity direction if the player changes the input
            if (Mathf.Sign(playerInput.x) != Mathf.Sign(velocity.x)) velocity.x *= -1;
            velocity.x += playerInput.x * currentAcceleration * Time.fixedDeltaTime;

            velocity.x = Mathf.Clamp(velocity.x, -currentMaxSpeed, currentMaxSpeed);
        }
        else if (Mathf.Abs(velocity.x) > 0.005f)
        {
            //apply deceleration if there is no input
            velocity.x += -Mathf.Sign(velocity.x) * deceleration * Time.fixedDeltaTime;
        }
        else
        {
            //stop completely if the deceleration is done
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
            //reset the jump count on the ground
            jumpCount = 0; 
        }

        if (jumpPressed && jumpCount < maxJumps)
        {
            //continue jumping if the jump count is less than the number of
            //max jumps and if jump is pressed.
            velocity.y = jumpVel;
            jumpPressed = false;
            jumpCount++;
        }
        else if (!IsGrounded())
        {
            //apply gravity and limit fall speed
            velocity.y += gravity * Time.fixedDeltaTime;
            velocity.y = Mathf.Max(velocity.y, -jumpVel);
            //reset jump input
            jumpPressed = false;
        }
        else
            //stop vertical movement on the ground
            velocity.y = 0;
    }

    public bool IsWalking()
    {
        //returns true if the player is moving horizontally
        return playerInput.x != 0;
    }
    public bool IsGrounded()
    {
        Vector3 origin = transform.position + Vector3.down * groundCheckDistance;
        
        DrawGroundCheck(origin);
        //check if player is touching the ground
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
        //return current facing direction based on input
        return (FacingDirection)playerInput.x;
    }
}
