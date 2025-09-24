using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public float maxSpeed = 1.0f;
    public float accelerationTime = 1.0f;

    private Vector3 velocity = Vector3.zero;
    private void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        Vector3 enemyDirection = playerTransform.position - transform.position;

        float acceleration = maxSpeed / accelerationTime;

        velocity += enemyDirection * acceleration * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        transform.position += velocity * Time.deltaTime;
    }

}
