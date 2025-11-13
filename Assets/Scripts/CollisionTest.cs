using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    public Collider2D player;
    public Collider2D obstacle;

    public bool collisionChange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics2D.IgnoreCollision(player, obstacle, collisionChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
