using UnityEngine;

public class DrawVectors : MonoBehaviour
{
    void Update()
    {
        // Create two Vector2 variables, "dVector" and "eVector"
        // Set their values to dVector: (0, 1) and eVector: (3, -2)

        Vector2 dVector = new Vector2(0, 1);
        Vector2 eVector = new Vector2(3, -2);

        // Use Debug.DrawLine to draw a yellow vector starting at the origin and ending at dVector.

        Debug.DrawLine(Vector2.zero, dVector, Color.yellow);

        // Use Debug.DrawLine to draw a grey vector starting at the origin and ending at eVector.

        Debug.DrawLine(Vector2.zero, eVector, Color.gray);

        Vector3 resultant = dVector + eVector;
        Vector2 resultant2 = dVector - eVector;
        Debug.DrawLine(Vector2.zero, resultant, Color.green);
        Debug.DrawLine(Vector2.zero, resultant2, Color.blue);

    }
}
