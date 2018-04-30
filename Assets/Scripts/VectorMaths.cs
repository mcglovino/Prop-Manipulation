using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mathematical equations used for Vector2, and Vector3
/// </summary>

public class VectorMaths
{

    //Vector3
    //Add two vectors
    public static Vector3 Add(Vector3 A, Vector3 B)
    {
        Vector3 rv = new Vector3((A.x + B.x), (A.y + B.y), (A.z + B.z));
        return rv;
    }
    //Subtract one vector from the other, A- B
    public static Vector3 Sub(Vector3 A, Vector3 B)
    {
        Vector3 rv = new Vector3((A.x - B.x), (A.y - B.y), (A.z - B.z));
        return rv;
    }
    //Find the length of a vector
    public static float Len(Vector3 A)
    {
        float rv = Mathf.Sqrt((A.x * A.x) + (A.y * A.y) + (A.z * A.z));
        return rv;
    }
    //Find the squared length of a vector
    public static float LenSq(Vector3 A)
    {
        float B = (A.x * A.x) + (A.y * A.y) + (A.z * A.z);
        return B;
    }
    //Find the distance between two vectors
    public static float Distance(Vector3 A, Vector3 B)
    {
        float C = Len(Sub(A, B));
        return C;
    }
    //Multiply a vector by a float
    public static Vector3 Scalar(Vector3 A, float B)
    {
        Vector3 C = new Vector3((A.x * B), (A.y * B), (A.z * B));
        return C;
    }
    //Divide a vector by a float
    public static Vector3 Divisor(Vector3 A, float B)
    {
        Vector3 C = new Vector3((A.x / B), (A.y / B), (A.z / B));
        return C;
    }
    //Normalize a vector - makes it a unit vector
    //Makes its length 1 unit
    public static Vector3 Normalized(Vector3 A)
    {
        Vector3 B = Divisor(A, Len(A));
        return B;
    }
    //Finds the dot product of two vectors
    //Finds out whether they are facing the same way or not
    //return 1 - same dirention, -1 - opposite direction, 0 - perpendicular
    public static float Dot(Vector3 A, Vector3 B)
    {
        A = Normalized(A);
        B = Normalized(B);

        float C = A.x * B.x + A.y * B.y + A.z * B.z;

        return C;
    }
    //Finds the Dot product of two vectors, without normalisation
    public static float DotNoN(Vector3 A, Vector3 B)
    {
        float C = A.x * B.x + A.y * B.y + A.z * B.z;

        return C;
    }
    //Converts a euler angle vector into a direction
    public static Vector3 EulertoDir(Vector3 A)
    {
        Vector3 B = new Vector3();
        B.x = Mathf.Cos(A.y) * Mathf.Cos(A.x);
        B.y = Mathf.Sin(A.x);
        B.z = Mathf.Cos(A.x) * Mathf.Sin(A.y);
        return B;
    }
    //Finds the cross product of two vectors
    //returns a new vector equidistant from the two
    public static Vector3 CrossProduct(Vector3 A, Vector3 B)
    {
        Vector3 C = new Vector3();

        C.x = A.y * B.z - A.z * B.y;
        C.y = A.z * B.x - A.x * B.z;
        C.z = A.x * B.y - A.y * B.x;

        return C;
    }
    //Returns a value of one vector scaled closer to the other
    public static Vector3 Lerp(Vector3 A, Vector3 B)
    {
        Vector3 D;
        float C = 0.25f;
        D = A * (1 - C) + B * C;
        return D;
    }
    //Rotates a vertex around an axis, with a given angle
    public static Vector3 RotateVertexAroundAxis(float Angle, Vector3 Axis, Vector3 Vertex)
    {
        Vector3 rv = (Vertex * Mathf.Cos(Angle)) +
            Dot(Vertex, Axis) * Axis * (1 - Mathf.Cos(Angle)) +
            CrossProduct(Axis, Vertex) * Mathf.Sin(Angle);
        return rv;
    }
    //Rotates a vertex around a Quaternion, with a given angle
    public static Vector3 RotateByQuat(Vector3 A, Quat B)
    {
        Quat C = new Quat(A);
        Quat newC = B * C * B.Inverse();
        Vector3 D = newC.GetAxis();
        return D;
    }


    //Vector2 overloads
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