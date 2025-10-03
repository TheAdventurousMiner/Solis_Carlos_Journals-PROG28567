using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;

    [Header("Motion Properties")]
    public float orbitRadius;
    public float orbitSpeed;
    private float angle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(orbitRadius, orbitSpeed, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {

        angle += speed * Time.deltaTime;

        float radians = angle * Mathf.Deg2Rad;
        
        Vector3 point = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians)) * radius;
        
        transform.position = planetTransform.position + point;
              
            
    }
}
