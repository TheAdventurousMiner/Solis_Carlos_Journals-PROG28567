using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowGeneration : MonoBehaviour
{
    private bool drawSquares = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (drawSquares)
        {
            for (int i = 0; i < 5; i++)
            {
                float squareSpacing = i * 3;

                Vector2 squareCenter = new Vector2(Vector2.zero.x + squareSpacing, Vector2.zero.y);

                Vector2 topLeftCorner = new Vector2(squareCenter.x - 1f, squareCenter.y + 1f);
                Vector2 topRightCorner = new Vector2(squareCenter.x + 1f, squareCenter.y + 1f);
                Vector2 bottomRightCorner = new Vector2(squareCenter.x + 1f, squareCenter.y - 1f);
                Vector2 bottomLeftCorner = new Vector2(squareCenter.x - 1f, squareCenter.y - 1f);

                Debug.DrawLine(topLeftCorner, topRightCorner, Color.white);
                Debug.DrawLine(topRightCorner, bottomRightCorner, Color.white);
                Debug.DrawLine(bottomRightCorner, bottomLeftCorner, Color.white);
                Debug.DrawLine(bottomLeftCorner, topLeftCorner, Color.white);
            }
        }

    }

    public void squareGenerator()
    {
        drawSquares = true;
    }
}
