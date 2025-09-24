using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    private Vector2 newPoint;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }
    public void AsteroidMovement()
    {
        Vector2 currentPosition = transform.position;

        if (Vector2.Distance(currentPosition, newPoint) < arrivalDistance)
        {
            float randomPointX = Random.Range(-maxFloatDistance, maxFloatDistance);
            float randomPointY = Random.Range(-maxFloatDistance, maxFloatDistance);

            newPoint = currentPosition + new Vector2(randomPointX, randomPointY);
        }

        Vector2 newDirection = newPoint - currentPosition;
        Vector2 newPosition = currentPosition + newDirection * moveSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
}
