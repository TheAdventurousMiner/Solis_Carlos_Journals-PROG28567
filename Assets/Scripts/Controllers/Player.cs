using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public GameObject powerupPrefab;

    [Header("Motion Properties")]
    public float maxSpeed = 1.0f;
    public float acceleratonTime = 1.0f;

    private Vector3 velocity = Vector3.zero;

    [Header("Radar Properties")]
    public float radarRadius = 1f;
    public int numberOfPoints = 6;
    private Color radarColour;

    [Header("Powerup Properties")]
    public float powerupRadius;
    public int amountOfPowerups;

    void Update()
    {
        PlayerMovement();
        RadarScan(radarRadius, numberOfPoints);

        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnPowerups(powerupRadius, amountOfPowerups);
        }
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

        float enemyDetected = Vector3.Distance(center, enemyTransform.position);

        if (enemyDetected < radius)
        {
            radarColour = Color.red;
        }
        else
        {
            radarColour = Color.green;
        }

        for (int i = 0; i < points.Count - 1; i++)
        {
            Debug.DrawLine(center + points[i], center + points[i + 1], radarColour);
        }
        Debug.DrawLine(center + points[points.Count - 1], center + points[0], radarColour);
    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        float angleStep = 360f / numberOfPowerups;
        float radians = angleStep * Mathf.Deg2Rad;

        Vector3 center = transform.position;

        for (int i = 0;i < numberOfPowerups;i++)
        {
            float adjustment = radians * i;
            Vector3 direction = new Vector3(Mathf.Cos(radians + adjustment), Mathf.Sin(radians + adjustment)) * radius;
            Vector3 spawnPosition = center + direction * radius;

            Instantiate(powerupPrefab, spawnPosition, Quaternion.identity);
        }
    }

}