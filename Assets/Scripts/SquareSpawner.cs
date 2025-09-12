using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{

    Vector2 squarePosition;

    Color semiTransparent = new Color(255, 255, 255, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Set the position of the square to spawn at the location from where the mouse was last
        //clicked.

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if(Input.GetMouseButtonDown(0))
        {
            squarePosition = new Vector2(mousePosition.x, mousePosition.y);
        }

        //Set the position for the corners of the square

        Vector2 topLeftCorner = new Vector2(squarePosition.x - 1f, squarePosition.y + 1f);
        Vector2 topRightCorner = new Vector2(squarePosition.x + 1f, squarePosition.y + 1f);
        Vector2 bottomRightCorner = new Vector2(squarePosition.x + 1f, squarePosition.y - 1f);
        Vector2 bottomLeftCorner = new Vector2(squarePosition.x - 1f, squarePosition.y - 1f);

        //Set the position of the semi-trasnparent square

        Vector2 topLeftCornerMouse = new Vector2(mousePosition.x - 1f, mousePosition.y + 1f);
        Vector2 topRightCornerMouse = new Vector2(mousePosition.x + 1f, mousePosition.y + 1f);
        Vector2 bottomRightCornerMouse = new Vector2(mousePosition.x + 1f, mousePosition.y - 1f);
        Vector2 bottomLeftCornerMouse = new Vector2(mousePosition.x - 1f, mousePosition.y - 1f);

        //Connect the corners using Debug.Drawline and draw the square

        Debug.DrawLine(topLeftCorner, topRightCorner, Color.white);
        Debug.DrawLine(topRightCorner, bottomRightCorner, Color.white);
        Debug.DrawLine(bottomRightCorner, bottomLeftCorner, Color.white);
        Debug.DrawLine(bottomLeftCorner, topLeftCorner, Color.white);

        //Draw the square that follows the mouse
        Debug.DrawLine(topLeftCornerMouse, topRightCornerMouse, semiTransparent);
        Debug.DrawLine(topRightCornerMouse, bottomRightCornerMouse, semiTransparent);
        Debug.DrawLine(bottomRightCornerMouse, bottomLeftCornerMouse, semiTransparent);
        Debug.DrawLine(bottomLeftCornerMouse, topLeftCornerMouse, semiTransparent);
    }
}
