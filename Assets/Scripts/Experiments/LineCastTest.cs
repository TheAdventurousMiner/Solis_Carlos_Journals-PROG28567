using UnityEngine;

public class LineCastTest : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    Color lineColor;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(startPoint.position, endPoint.position, lineColor);

        RaycastHit2D hit = Physics2D.Linecast(startPoint.position, endPoint.position);

        if (hit.collider != null)
        {
            lineColor = Color.red;

            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Player has been detected!");
            }
        }
        else
        {
            lineColor = Color.green;

            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Nothing has been detected");
            }
        }
    }
}
