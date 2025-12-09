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
            //Spawn the boulder prefab at the object's location
            GameObject boulder = Instantiate(boulderPrefab, transform.position, Quaternion.identity, transform);

            //Get the rigidbody component from the boulder and apply instant force to it
            Rigidbody2D body2D = boulder.GetComponent<Rigidbody2D>();
            body2D.AddForce(Random.insideUnitCircle, ForceMode2D.Impulse);

            //wait for an amount of seconds to spawn the boulder again
            yield return new WaitForSeconds(boulderSpawnDelay);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
