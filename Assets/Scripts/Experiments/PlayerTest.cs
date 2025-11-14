using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public float speed = 0.01f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 moveLeft = transform.position + Vector3.left * speed;
            transform.position = moveLeft;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 moveRight = transform.position + Vector3.right * speed;
            transform.position = moveRight;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 moveUp = transform.position + Vector3.up * 0.01f;
            transform.position = moveUp;
        }
    }
}
