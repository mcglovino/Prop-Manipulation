using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTo : MonoBehaviour
{

    public Vector3 targetPos;
    public Vector3 targetRot;

    void Start()
    {
        targetPos = transform.position;
        targetRot = transform.eulerAngles;
    }

    void Update()
    {
        transform.position = VectorMaths.Lerp(transform.position, targetPos);
        //GetComponent<TRS>().rotation = VectorMaths.Lerp(transform.eulerAngles, VectorMaths.Divisor(targetRot, (180 / Mathf.PI)));
    }
}
