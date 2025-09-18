using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBombAtOffset(new Vector3(0, 1, 0));
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnBombTrail(0.5f, 5);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnBombOnRandomCorner(5f);
        }

        DetectAsteroids(10f, asteroidTransforms);

        WarpPlayer(enemyTransform, 0f);
    }
    private void SpawnBombAtOffset(Vector3 inOffset)
    {
        Vector3 spawnPosition = transform.position + inOffset;
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }
    public void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)
    {
        Vector3 bombTrailDirection = Vector2.down;

        for (int i = 0; i < inNumberOfBombs; i++)
        {
            int spaceBehindPlayer = i + 1;
            Vector3 spawnPosition = transform.position + bombTrailDirection * inBombSpacing * spaceBehindPlayer;
            Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
        }
    }

    public void SpawnBombOnRandomCorner(float inDistance)
    {
        Vector3 spawnCorner = Vector3.zero;

        int randomCorner = Random.Range(0, 4);

        if (randomCorner == 0)
        {
            //Top left corner bomb
            spawnCorner = (Vector3.up + Vector3.left).normalized;
        }

        else if (randomCorner == 1)
        {
            //top right corner bomb
            spawnCorner = (Vector3.up + Vector3.right).normalized;
        }

        else if (randomCorner == 2)
        {
            //bottom left corner bomb
            spawnCorner = (Vector3.down + Vector3.left).normalized;
        }

        else if (randomCorner == 3)
        {
            //bottom right corner bomb
            spawnCorner = (Vector3.down + Vector3.right).normalized;
        }

        Vector3 spawnPosition = transform.position + spawnCorner * inDistance;

        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }

    public void WarpPlayer(Transform target, float ratio)
    {
        Vector3 newPlayerPosition = transform.position;

        if (ratio == 0f)
        {
            newPlayerPosition = transform.position;
        }
        else if (ratio == 1f)
        {
            newPlayerPosition = target.position;
        }
        else if (ratio == 0.5f)
        {
            newPlayerPosition = Vector3.Lerp(transform.position, target.position, ratio);
        }
        transform.position = newPlayerPosition;
    }
    

    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        Vector3 playerPosition = transform.position;

        for(int i = 0;i < inAsteroids.Count;i++)
        {
            Transform asteroid = inAsteroids[i];

            Vector3 asteroidDirection = asteroid.position - playerPosition;
            float dist = asteroidDirection.magnitude;

            if (dist < inMaxRange)
            {
                Vector3 normalizedDirection = asteroidDirection.normalized;
                Vector3 endPoint = playerPosition + normalizedDirection * 2.5f;

                Debug.DrawLine(playerPosition, endPoint, Color.green);
            }

        }
    }
}
