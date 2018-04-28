using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMaths
{

    //Vector3
    public static Vector3 Add(Vector3 A, Vector3 B)
    {
        Vector3 C = new Vector3((A.x + B.x), (A.y + B.y), (A.z + B.z));
        return C;
    }

    public static Vector3 Sub(Vector3 A, Vector3 B)
    {
        Vector3 C = new Vector3((A.x - B.x), (A.y - B.y), (A.z - B.z));
        return C;
    }

    public static float Len(Vector3 A)
    {
        float B = Mathf.Sqrt((A.x * A.x) + (A.y * A.y) + (A.z * A.z));
        return B;
    }

    public static float LenSq(Vector3 A)
    {
        float B = (A.x * A.x) + (A.y * A.y) + (A.z * A.z);
        return B;
    }

    public static float Distance(Vector3 A, Vector3 B)
    {
        float C = Len(Sub(A, B));
        return C;
    }

    public static Vector3 Scalar(Vector3 A, float B)
    {
        Vector3 C = new Vector3((A.x * B), (A.y * B), (A.z * B));
        return C;
    }

    public static Vector3 Divisor(Vector3 A, float B)
    {
        Vector3 C = new Vector3((A.x / B), (A.y / B), (A.z / B));
        return C;
    }

    public static Vector3 Normalized(Vector3 A)
    {
        Vector3 B = Divisor(A, Len(A));
        return B;
    }

    public static float Dot(Vector3 A, Vector3 B)
    {
        A = Normalized(A);
        B = Normalized(B);

        float C = A.x * B.x + A.y * B.y + A.z * B.z;

        return C;
    }

    public static Vector3 EulertoDir(Vector3 A)
    {
        Vector3 B = new Vector3();
        B.x = Mathf.Cos(A.y) * Mathf.Cos(A.x);
        B.y = Mathf.Sin(A.x);
        B.z = Mathf.Cos(A.x) * Mathf.Sin(A.y);
        return B;
    }

    public static Vector3 CrossProduct(Vector3 A, Vector3 B)
    {
        Vector3 C = new Vector3();

        C.x = A.y * B.z - A.z * B.y;
        C.y = A.z * B.x - A.x * B.z;
        C.z = A.x * B.y - A.y * B.x;

        return C;
    }

    public static Vector3 Lerp(Vector3 A, Vector3 B)
    {
        Vector3 D;
        float C = 0.25f;
        D = A * (1 - C) + B * C;
        return D;
    }

    public static Vector3 RotateVertexAroundAxis(float Angle, Vector3 Axis, Vector3 Vertex)
    {
        Vector3 rv = (Vertex * Mathf.Cos(Angle)) +
            Dot(Vertex, Axis) * Axis * (1 - Mathf.Cos(Angle)) +
            CrossProduct(Axis, Vertex) * Mathf.Sin(Angle);
        return rv;
    }

    public static Vector3 RotateByQuat(Vector3 A, Quat B)
    {
        Quat C = new Quat(0, A.x, A.y, A.z);
        Quat newC = B * C * Quat.Inverse(B);
        Vector3 D = new Vector3(newC.x, newC.y, newC.z);
        return D;
    }

    public static Vector3 AngleDifference(Vector3 Angle1, Vector3 Angle2)
    {
        Vector3 Difference = new Vector3();
        Difference.x = Angle2.x - Angle1.x;
        if (Difference.x > 180) Difference.x -= 360;
        else if (Difference.x < -180) Difference.x += 360;
        Difference.y = Angle2.y - Angle1.y;
        if (Difference.y > 180) Difference.y -= 360;
        else if (Difference.y < -180) Difference.y += 360;
        Difference.z = Angle2.z - Angle1.z;
        if (Difference.z > 180) Difference.z -= 360;
        else if (Difference.z < -180) Difference.z += 360;
        return Difference;
    }


    //Vector2
    public static Vector2 Add(Vector2 A, Vector2 B)
    {
        Vector2 C = new Vector2((A.x + B.x), (A.y + B.y));
        return C;
    }

    public static Vector2 Sub(Vector2 A, Vector2 B)
    {
        Vector2 C = new Vector2((A.x - B.x), (A.y - B.y));
        return C;
    }

    public static float Len(Vector2 A)
    {
        float B = Mathf.Sqrt((A.x * A.x) + (A.y * A.y));
        return B;
    }

    public static float LenSq(Vector2 A)
    {
        float B = (A.x * A.x) + (A.y * A.y);
        return B;
    }

    public static float Distance(Vector2 A, Vector2 B)
    {
        float C = Len(Sub(A, B));
        return C;
    }

    public static Vector2 Scalar(Vector2 A, float B)
    {
        Vector2 C = new Vector2((A.x * B), (A.y * B));
        return C;
    }

    public static Vector2 Divisor(Vector2 A, float B)
    {
        Vector2 C = new Vector2((A.x / B), (A.y / B));
        return C;
    }

    public static Vector2 Normalized(Vector2 A)
    {
        Vector2 B = Divisor(A, Len(A));
        return B;
    }

    public static float Dot(Vector2 A, Vector2 B)
    {
        A = Normalized(A);
        B = Normalized(B);

        float C = A.x * B.x + A.y * B.y;

        return C;
    }

    public static float VectorToRadians(Vector2 A)
    {
        float B = 0.0f;

        B = Mathf.Atan(A.y / A.x);

        return B;
    }

    public static Vector2 RadiansToVector(float A)
    {
        Vector2 B = new Vector2(Mathf.Cos(A), Mathf.Sin(A));

        return B;
    }
}