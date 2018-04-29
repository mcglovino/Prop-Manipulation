using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    public GameObject Target;
    //public GameObject Parent;

    float minFov = 5f;
    float maxFov = 120f;
    //zoom sens
    float sensitivity = 15f;

    //looking around speed
    float speed = 200f;

    float angle = 10;


    void Update()
    {
        Vector3 lookAt = new Vector3(-Target.GetComponent<TRS>().position.x, Target.GetComponent<TRS>().position.y, -Target.GetComponent<TRS>().position.z);


        if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            transform.RotateAround(lookAt, Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * speed);
            transform.RotateAround(lookAt, Vector3.right, Input.GetAxis("Mouse Y") * Time.deltaTime * speed);
        }
        //transform.Rotate((-Input.GetAxis("Mouse Y") * Time.deltaTime * speed), (Input.GetAxis("Mouse X") * Time.deltaTime * speed), 0);

        //Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(lookAt);

        float fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}