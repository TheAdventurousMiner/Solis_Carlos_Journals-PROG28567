using UnityEngine;

public class EnemyMechanic : MonoBehaviour
{
    public Transform player;
    public Transform blackhole;
    public float speed = 1f;
    public float blackholeRadius = 5f;

    private Transform currentTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToBlackHole = Vector2.Distance(transform.position, blackhole.position);

        if (distanceToBlackHole < blackholeRadius )
        {
            currentTarget = blackhole;
        }
        else
        {
            currentTarget = player;
        }

        Vector2 direction = currentTarget.position - transform.position;

        Vector2 movement = direction * speed * Time.deltaTime;

        transform.position += (Vector3)movement; 
    }

}
