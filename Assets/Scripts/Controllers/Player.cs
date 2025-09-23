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

    [Header("Radar Properties")]
    public float radarRadius = 1f;
    public int numberOfPoints = 6;

    void Update()
    {
        PlayerMovement();
        RadarScan(radarRadius, numberOfPoints);
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
    private void RadarScan(float radius, int numberOfPoints)
    {
        float angleStep = 360 / numberOfPoints;
        float radians = angleStep * Mathf.Deg2Rad;

        List<Vector3> points = new List<Vector3>();

        for (int i = 0; i < numberOfPoints; i++)
        {
            float adjustment = radians * i;
            Vector3 point = new Vector3(Mathf.Cos(radians + adjustment), Mathf.Sin(radians + adjustment)) * radius;

            points.Add(point);
        }

        Vector3 center = transform.position;

        for (int i = 0; i < points.Count - 1; i++)
        {
            Debug.DrawLine(center + points[i], center + points[i + 1], Color.green);
        }
        Debug.DrawLine(center + points[points.Count - 1], center + points[0], Color.green);
    }
}