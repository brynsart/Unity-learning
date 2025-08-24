using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow5 : MonoBehaviour
{

    public Transform target;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position; // Offset is distance between target and camera
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = target.position - offset; // The camera will always be at a fixed distance from the ball
    }
}