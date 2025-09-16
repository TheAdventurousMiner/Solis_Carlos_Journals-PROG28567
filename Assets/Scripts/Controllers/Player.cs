using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;
    
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
}
