using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera script to follow and rotate the target object
/// </summary>

public class LookAt : MonoBehaviour
{
    // Declare variables
    //Object to focus on
    public GameObject Target;
    //to clamp the FOV zoom
    float minFov = 5f;
    float maxFov = 120f;
    //zoom sens
    float sensitivity = 15f;
    //looking around speed
    float speed = 200f;

    void Update()
    {
        //Although this works it is not completely accurate as my positions to not match up with Unitys default.
        Vector3 lookAt = new Vector3(Target.GetComponent<TRS>().position.x, Target.GetComponent<TRS>().position.y, Target.GetComponent<TRS>().position.z);

        //Cam move the camera with any mouse button
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            transform.RotateAround(lookAt, Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * speed);
            transform.RotateAround(lookAt, Vector3.right, Input.GetAxis("Mouse Y") * Time.deltaTime * speed);
        }

        //Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(lookAt);

        //Scroll wheel affects FOV, to zoom.
        float fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}