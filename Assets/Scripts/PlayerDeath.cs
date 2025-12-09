using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public PlayerVisuals playerVisuals;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player collides with a gameObject with a "Boulder" Tag,
        //play the death animation from the player visuals script
        if (collision.gameObject.CompareTag("Boulder"))
        {

            playerVisuals.animator.Play("Death");

        }
    }
}
