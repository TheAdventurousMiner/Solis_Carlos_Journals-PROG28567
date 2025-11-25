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

    [Header("Jump Properties")]
    public float apexHeight = 3.5f;
    public float apexTime = 0.5f;


    void Start()
    {
        
    }

    void Update()
    {
        // The input from the player needs to be determined and
        // then passed in the to the MovementUpdate which should
        // manage the actual movement of the character.
        Vector2 playerInput = new Vector2();
        MovementUpdate(playerInput);
    }

    private void MovementUpdate(Vector2 playerInput)
    {

    }

    private void ProcessWalkInput()
    {
        //if(playerInput.x)
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
