using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform player;
    public Collider2D playerCollision;
    public Collider2D platform;

    public bool platformChange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics2D.IgnoreCollision(playerCollision, platform, platformChange);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.position;


        if (playerPos.y < 0)
        {
            platformChange = true;
        }

        if (playerPos.y > -1)
        {
            platformChange = false;
        }

    }
}
