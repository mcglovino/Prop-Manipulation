using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTo : MonoBehaviour
{

    public Vector3 targetPos;
    public Vector3 targetRot;

    void Start()
    {
        targetPos = GetComponent<TRS>().position;
        targetRot = GetComponent<TRS>().rotation;
        //targetPos = transform.position;
        //targetRot = transform.eulerAngles;
    }

    void Update()
    {
        Quat A = new Quat(targetRot.x, new Vector3(1, 0, 0));
        Quat B = new Quat(targetRot.y, new Vector3(0, 1, 0));
        Quat C = new Quat(targetRot.z, new Vector3(0, 0, 1));
        Quat D = A * B * C;
        GetComponent<TRS>().position = VectorMaths.Lerp(GetComponent<TRS>().position, targetPos);
   
        GetComponent<TRS>().rotateQuat = D;

    }
}
