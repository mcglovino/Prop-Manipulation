using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Math functions not related to vectors or quaternions
/// </summary>

public class Maths
{
    //Conversions from degrees to radians, and vice vera
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