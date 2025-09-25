using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    [Header("Motion Properties")]
    public float maxSpeed = 1.0f;
    public float acceleratonTime = 1.0f;
    public float decelerationTime = 1.0f;

    private Vector3 velocity = Vector3.zero;


    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float acceleration = maxSpeed / acceleratonTime;
        float deceleration = maxSpeed / decelerationTime;

        bool playerAcceleration = false;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity += acceleration * Time.deltaTime * Vector3.left;
            playerAcceleration = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += acceleration * Time.deltaTime * Vector3.right;
            playerAcceleration = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += acceleration * Time.deltaTime * Vector3.up;
            playerAcceleration = true;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity += acceleration * Time.deltaTime * Vector3.down;
            playerAcceleration = true;
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        if (!playerAcceleration && velocity.magnitude > 0)
        {
            Vector3 decelerate = velocity.normalized * deceleration * Time.deltaTime;

            if (decelerate.magnitude > velocity.magnitude)
            {
                velocity = Vector3.zero;
            }
            else
            {
                velocity -= decelerate;
            }
            
        }

        transform.position += velocity * Time.deltaTime;


    }
    
}