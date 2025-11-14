using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform player;
    public Transform platform;
    public Collider2D playerCollision;
    public Collider2D platformCollision;

    private bool platformChange = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.position;
        Vector3 platformPos = platform.position;

        bool goThroughPlatform = playerPos.y < platformPos.y;


        if (goThroughPlatform != platformChange)
        {
            platformChange = goThroughPlatform;
            Physics2D.IgnoreCollision(playerCollision, platformCollision, platformChange);
        }

    }
}
