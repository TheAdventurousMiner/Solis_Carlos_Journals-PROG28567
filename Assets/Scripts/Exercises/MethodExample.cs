using UnityEngine;

public class MethodExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 vec = new Vector2(3, 4);
        Vector2 anotherVec = new Vector2(8, 0);

        float magnitude = GetMagnitude(vec);
        float anotherMagnitude = GetMagnitude(anotherVec);

        print(magnitude);
        print(anotherMagnitude);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        DrawRectangle(mousePos, Vector2.one * 3, Color.yellow);

        print(NormalizeVector(new Vector2(3, 4)));
        print(NormalizeVector(new Vector2(-3, 2)));
        print(NormalizeVector(new Vector2(1.5f, -3.5f)));
    }
    public static float GetMagnitude(Vector2 v)
    {
        return Mathf.Sqrt(Mathf.Pow(v.x, 2) + Mathf.Pow(v.y, 2));

    }

    public static void DrawRectangle(Vector2 pos, Vector2 size, Color color)
    {
        float halfWidth = size.x / 2;
        float halfHeight = size.y / 2;

        Vector2 topLeft = new Vector2(pos.x - halfWidth, pos.y + halfWidth);
        Vector2 topRight = topLeft + Vector2.right * size.x;
        Vector2 bottomRight = new Vector2(pos.x + halfWidth, pos.y - halfHeight);
        Vector2 bottomLeft = bottomRight + Vector2.left * size.x;

        Debug.DrawLine(topLeft, topRight, color);
        Debug.DrawLine(topRight, bottomRight, color);
        Debug.DrawLine(bottomRight, bottomLeft, color);
        Debug.DrawLine(bottomLeft, topLeft, color);

    }

    private Vector2 NormalizeVector(Vector2 v)
    {
        //float magnitude = GetMagnitude(v);
        float magnitude = v.magnitude;

        Vector2 normalized = new Vector2(v.x / magnitude, v.y / magnitude);
        return normalized;
    }
}
