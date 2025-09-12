using UnityEngine;

public class AddVectors : MonoBehaviour
{
    public Transform redTransform;
    public Transform blueTransform;

    void Update()
    {
        // Exercise: Visualizing Vector Addition
        // Create a new Vector2 called "rPlusB" which adds rTransform's position to bTransform's position.​

        Vector2 rPlusb = redTransform.position + blueTransform.position;

        // When the B key is held down, draw a blue line from the origin to bTransform's position.​

        if(Input.GetKey(KeyCode.B))
        {
            Debug.DrawLine(Vector2.zero, blueTransform.position, Color.blue);
        }

        // When the R key is held down, draw a red line from the origin to rTransform's position.​

        if (Input.GetKey(KeyCode.R))
        {
            Debug.DrawLine(Vector2.zero, redTransform.position, Color.red);
        }

        // When the R and B keys are both held down, draw a magenta from the origin to rPlusB.​

        if (Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.R))
        {
            Debug.DrawLine(Vector2.zero, rPlusb, Color.magenta);
        }

        // Exercise: Calculating Magnitude
        // Calculate the magnitude of bPlusR using the mathematical formula
        // for calculating the length of a vector – Pythagorean Theroem.​

        float xSquared = Mathf.Pow(rPlusb.x, 2);
        float ySquared = Mathf.Pow(rPlusb.y, 2);
        float magnitude = Mathf.Sqrt(xSquared + ySquared);

        // Output the magnitude to the console using either Debug.Log or print.

        Debug.Log(magnitude);
    }
}
