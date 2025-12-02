using UnityEngine;
using System.Collections;

public class BoulderSpawner : MonoBehaviour
{
    public GameObject boulderPrefab;
    public float boulderSpawnDelay = 4f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        while (true)
        {

            GameObject boulder = Instantiate(boulderPrefab, transform.position, Quaternion.identity, transform);

            Rigidbody2D body2D = boulder.GetComponent<Rigidbody2D>();
            body2D.AddForce(Random.insideUnitCircle, ForceMode2D.Impulse);

            yield return new WaitForSeconds(boulderSpawnDelay);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
