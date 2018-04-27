using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maths
{

    public static float DegToRad(float deg)
    {
        float Rt = deg * (Mathf.PI / 180);
        return Rt;
    }

    public static float RadToDeg(float rad)
    {
        float Rt = rad * (180 / Mathf.PI);
        return Rt;
    }
}