using UnityEngine;

public class AddTorqueTest : MonoBehaviour
{
    public float rotateAmount = 5f;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddTorque(rotateAmount);
        }

        if (Input.GetMouseButtonDown(1))
        {
            rb.AddTorque(-rotateAmount);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.AddTorque(rotateAmount, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.AddTorque(-rotateAmount, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddTorque(rotateAmount, ForceMode2D.Force);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.AddTorque(-rotateAmount, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddTorque(rotateAmount, ForceMode2D.Impulse);
        }
    }
}
