using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        Quat A = new Quat(targetRot.x, new Vector3(1, 0, 0));
        Quat B = new Quat(targetRot.y, new Vector3(0, 1, 0));
        Quat C = new Quat(targetRot.z, new Vector3(0, 0, 1));
        Quat D = A * B * C;

        //tergetpos xyz switched after different models added and things went wierd
        GetComponent<TRS>().position = VectorMaths.Lerp(GetComponent<TRS>().position, new Vector3(targetPos.y, targetPos.z, targetPos.x));

        //keeps scale within possible limits
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
        GetComponent<TRS>().scale = VectorMaths.Lerp(GetComponent<TRS>().scale, targetScale);

        GetComponent<TRS>().rotateQuat = D;

    }
}
