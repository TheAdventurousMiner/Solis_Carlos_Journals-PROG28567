using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("Motion Properties")]
    public float maxSpeed = 1.0f;
    public float accelerationsTime, decelerationTime;
    public float acceleration, deceleration;
    private Vector2 velocity;

    private Rigidbody2D body2D;

    public enum FacingDirection
    {
        left, right
    }

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
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        if (playerInput.magnitude > 0)
        {
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
        return false;
    }
    public bool IsGrounded()
    {
        return false;
    }

    public FacingDirection GetFacingDirection()
    {
        return FacingDirection.left;
    }
}
