using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    // Update is called once per frame
    void Update()
    {
        DrawConstillation();
    }
    public void DrawConstillation()
    {
        drawingTime += Time.deltaTime;

        for (int i = 0; i < starTransforms.Count - 1; i++)
        {
            Debug.DrawLine(starTransforms[i].position, starTransforms[i + 1].position, Color.white, drawingTime);
        }
       
    }
}
