using System.Collections.Generic;
using UnityEngine;

public class UnitCircleValues : MonoBehaviour
{
    public float radius = 1f;
    public Vector3 center = Vector3.zero;
    public List<float> angles = new ();

    [Space(10)]
    public float lineDuration = 1f;

    private float elapsedTime = 0f;

    private int currentIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10;  i++)
        {
            angles.Add(Random.value * 360f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) || elapsedTime > lineDuration)
        {
            elapsedTime = 0f;
            currentIndex = (currentIndex + 1) % angles.Count;
        }

        Vector3 point = GetPointOnUnitCircle(angles[currentIndex]);

        Debug.DrawLine(center, center + point, Color.green);
    }

    private Vector2 GetPointOnUnitCircle(float angle)
    {
        float radians = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(radians), Mathf.Sin(radians)) * radius;
    }
}
