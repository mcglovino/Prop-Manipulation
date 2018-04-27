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
        GetComponent<TRS>().position = VectorMaths.Lerp(GetComponent<TRS>().position, targetPos);
        GetComponent<TRS>().rotation = VectorMaths.Lerp(GetComponent<TRS>().rotation, VectorMaths.Divisor(targetRot, (180 / Mathf.PI)));
        //transform.position = VectorMaths.Lerp(transform.position, targetPos);
        //GetComponent<TRS>().rotation = VectorMaths.Lerp(transform.eulerAngles, VectorMaths.Divisor(targetRot, (180 / Mathf.PI)));
    }
}
