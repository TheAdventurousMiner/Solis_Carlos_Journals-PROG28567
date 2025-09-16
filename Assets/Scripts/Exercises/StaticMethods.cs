using UnityEngine;

public class StaticMethods : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 vec = new Vector2(6, 18);

        float magnitude = MethodExample.GetMagnitude(vec);

        print($"This is inside StaticMethods: {magnitude} ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
