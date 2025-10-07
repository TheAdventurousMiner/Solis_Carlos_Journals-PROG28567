using UnityEngine;

public class TrigExamples : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.DrawLine(Vector3.zero, mousePosInWorld, Color.cyan);

        float angle = Mathf.Atan2(mousePosInWorld.y , mousePosInWorld.x) * Mathf.Rad2Deg;
        //float angle = Mathf.Atan(mousePosInWorld.y / mousePosInWorld.x) * Mathf.Rad2Deg;

        //float zero = 0f;
        //float angle = Mathf.Atan(1 / zero) * Mathf.Rad2Deg;

        Debug.Log($"<color=yellow><size=16>{angle}</size></color>.");
    }
}
