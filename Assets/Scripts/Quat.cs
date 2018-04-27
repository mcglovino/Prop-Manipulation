using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quat
{

    public float w, x, y, z;
    public Vector3 v;

    public Quat(float Angle, float xT, float yT, float zT)
    {
        w = Angle; x = xT; y = yT; z = zT;
        v = new Vector3(x, y, z);
    }

    public Quat(float Angle, Vector3 Axis)
    {
        float halfAngle = Angle / 2;

        //if in degrees
        halfAngle = Maths.DegToRad(halfAngle);

        w = Mathf.Cos(halfAngle);
        x = Axis.x * Mathf.Sin(halfAngle);
        y = Axis.y * Mathf.Sin(halfAngle);
        z = Axis.z * Mathf.Sin(halfAngle);
        v = new Vector3(x, y, z);
    }

    public static Quat operator *(Quat lhs, Quat rhs)
    {
        Quat rv = new Quat(0, new Vector3(0, 0, 0));
        Debug.Log("lhsw * rhsw " + (lhs.w * rhs.w));
        rv.w = lhs.w * rhs.w - VectorMaths.Dot(lhs.v, rhs.v);
        Debug.Log("New W " + rv.w);
        Debug.Log("lhs w * rhs v : (" + (lhs.w * rhs.v).x + ", " + (lhs.w * rhs.v).y + ", " + (lhs.w * rhs.v).z + ")");
        Debug.Log("rhs w *lhs v : (" + (rhs.w * lhs.v).x + ", " + (rhs.w * lhs.v).y + ", " + (rhs.w * lhs.v).z + ")");
        rv.v = ((lhs.w * rhs.v) + (rhs.w * lhs.v) + (VectorMaths.CrossProduct(rhs.v, lhs.v)));
        rv.x = rv.v.x;
        rv.y = rv.v.y;
        rv.z = rv.v.z;

        Debug.Log("Q*: " + rv.w + ", " + rv.x + ", " + rv.y + ", " + rv.z);

        return rv;
    }

    public static Quat Inverse(Quat A)
    {
        Quat B = new Quat(A.w, -A.x, -A.y, -A.z);
        B.v = -A.v;
        return B;
    }
}