using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the movement of the object
/// Smooths the translate and scale
/// does necessary conversions and clamps before matrix transformations
/// </summary>

public class LerpTo : MonoBehaviour
{

    public Vector3 targetPos;
    public Vector3 targetRot;
    public Vector3 targetScale;

    void Start()
    {
        targetPos = GetComponent<TRS>().position;
        targetRot = GetComponent<TRS>().rotation;
        targetScale = GetComponent<TRS>().scale;
        //targetPos = transform.position;
        //targetRot = transform.eulerAngles;
    }

    void Update()
    {
        //Multiply the rotations into one quaternion
        Quat A = new Quat(targetRot.x, new Vector3(1, 0, 0));
        Quat B = new Quat(targetRot.y, new Vector3(0, 1, 0));
        Quat C = new Quat(targetRot.z, new Vector3(0, 0, 1));
        Quat D = A * B * C;

        //LERP the position to the target position
        GetComponent<TRS>().position = VectorMaths.Lerp(GetComponent<TRS>().position, new Vector3(targetPos.x, targetPos.y, targetPos.z));

        //keeps scale within possible limits, so you cant input it higher
        if (targetScale.x > 3)
            targetScale.x = 3;
        else if (targetScale.x < 0.5f)
            targetScale.x = 0.5f;
        if (targetScale.y > 3)
            targetScale.y = 3;
        else if (targetScale.y < 0.5f)
            targetScale.y = 0.5f;
        if (targetScale.z > 3)
            targetScale.z = 3;
        else if (targetScale.z < 0.5f)
            targetScale.z = 0.5f;
        //LERP the scale to the target scale
        GetComponent<TRS>().scale = VectorMaths.Lerp(GetComponent<TRS>().scale, targetScale);

        //Set rotation to D
        GetComponent<TRS>().rotateQuat = D;
        //GetComponent<TRS>().rotateQuat = Quat.SLERP(GetComponent<TRS>().rotateQuat, D, 5.0f);

    }
}
