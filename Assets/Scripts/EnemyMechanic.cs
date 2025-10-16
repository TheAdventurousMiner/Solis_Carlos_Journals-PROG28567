using UnityEngine;

public class EnemyMechanic : MonoBehaviour
{
    public Transform player;
    public Transform blackhole;
    public float speed = 1f;
    public float blackholeRadius = 5f;
    public float angularSpeed = 60f;

    private Transform currentTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToBlackHole = Vector2.Distance(transform.position, blackhole.position);

        if (distanceToBlackHole < blackholeRadius )
        {
            currentTarget = blackhole;
        }
        else
        {
            currentTarget = player;
        }

        Vector2 direction = currentTarget.position - transform.position;

        Vector2 movement = direction * speed * Time.deltaTime;

        float upAngle = CalculateDegAngleFromVector(transform.up);
        float directionAngle = CalculateDegAngleFromVector(direction);

        float deltaAngle = Mathf.DeltaAngle(upAngle, directionAngle);
        float sign = Mathf.Sign(deltaAngle);

        float angleStep = angularSpeed * Time.deltaTime * sign;

        if (Mathf.Abs(angleStep) < Mathf.Abs(deltaAngle))
        {
            transform.Rotate(0, 0, angleStep);
        }
        else
        {
            transform.Rotate(0, 0, deltaAngle);
        }

        float dot = Vector3.Dot(transform.up, direction);

        transform.position += (Vector3)movement; 
    }
    private float CalculateDegAngleFromVector(Vector2 vec)
    {
        return Mathf.Atan2 (vec.y, vec.x) * Mathf.Rad2Deg;
    }
}
