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

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float acceleration = maxSpeed / acceleratonTime;

        if (Input.GetKey(KeyCode.LeftArrow))        
            velocity += acceleration * Time.deltaTime * Vector3.left;

        if (Input.GetKey(KeyCode.RightArrow))
            velocity += acceleration * Time.deltaTime * Vector3.right;

        if (Input.GetKey(KeyCode.UpArrow))
            velocity += acceleration * Time.deltaTime * Vector3.up;

        if (Input.GetKey(KeyCode.DownArrow))
            velocity += acceleration * Time.deltaTime * Vector3.down;

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.position += velocity * Time.deltaTime;

    }

}