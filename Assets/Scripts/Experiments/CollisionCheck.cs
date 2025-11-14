using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public Collider2D player;
    public Collider2D platform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool goThroughPlatform = Physics2D.GetIgnoreCollision(player, platform);

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("The player can go through the platform. " + goThroughPlatform);
        }
    }
}
