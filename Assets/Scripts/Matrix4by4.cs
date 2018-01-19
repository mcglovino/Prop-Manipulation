using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix4by4
{
    public Matrix4by4(Vector4 column1, Vector4 column2, Vector4 column3, Vector4 column4)
    {
        values = new float[4, 4];

        //Column 1
        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = column1.w;

        //Column 2
        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = column2.w;

        //Column 3
        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = column3.w;

        //Column 4
        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = column4.w;

    }
    public Matrix4by4(Vector3 column1, Vector3 column2, Vector3 column3, Vector3 column4)
    {
        values = new float[4, 4];

        //Column 1
        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = 0;

        //Column 2
        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = 0;

        //Column 3
        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = 0;

        //Column 4
        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = 1;
    }

    public float[,] values;

    public static Vector4 operator *(Matrix4by4 lhs, Vector4 vector)
    {
        Vector4 result;

        result.x = (lhs.values[0, 0] * vector.x) + (lhs.values[0, 1] * vector.y) + (lhs.values[0, 2] * vector.z) + (lhs.values[0, 3] * vector.w);
        result.y = (lhs.values[1, 0] * vector.x) + (lhs.values[1, 1] * vector.y) + (lhs.values[1, 2] * vector.z) + (lhs.values[1, 3] * vector.w);
        result.z = (lhs.values[2, 0] * vector.x) + (lhs.values[2, 1] * vector.y) + (lhs.values[2, 2] * vector.z) + (lhs.values[2, 3] * vector.w);
        result.w = (lhs.values[3, 0] * vector.x) + (lhs.values[3, 1] * vector.y) + (lhs.values[3, 2] * vector.z) + (lhs.values[3, 3] * vector.w);

        return result;
    }

    public static Matrix4by4 operator *(Matrix4by4 lhs, Matrix4by4 rhs)
    {
        Matrix4by4 result = new Matrix4by4(
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 1),
            Vector3.zero);

        result.values[0, 0] = (lhs.values[0, 0] * rhs.values[0, 0]) + (lhs.values[0, 1] * rhs.values[1, 0]) + (lhs.values[0, 2] * rhs.values[2, 0]) + (lhs.values[0, 3] * rhs.values[3, 0]);
        result.values[0, 1] = (lhs.values[0, 0] * rhs.values[0, 1]) + (lhs.values[0, 1] * rhs.values[1, 1]) + (lhs.values[0, 2] * rhs.values[2, 1]) + (lhs.values[0, 3] * rhs.values[3, 1]);
        result.values[0, 2] = (lhs.values[0, 0] * rhs.values[0, 2]) + (lhs.values[0, 1] * rhs.values[1, 2]) + (lhs.values[0, 2] * rhs.values[2, 2]) + (lhs.values[0, 3] * rhs.values[3, 2]);
        result.values[0, 3] = (lhs.values[0, 0] * rhs.values[0, 3]) + (lhs.values[0, 1] * rhs.values[1, 3]) + (lhs.values[0, 2] * rhs.values[2, 3]) + (lhs.values[0, 3] * rhs.values[3, 3]);

        result.values[1, 0] = (lhs.values[1, 0] * rhs.values[0, 0]) + (lhs.values[1, 1] * rhs.values[1, 0]) + (lhs.values[1, 2] * rhs.values[2, 0]) + (lhs.values[1, 3] * rhs.values[3, 0]);
        result.values[1, 1] = (lhs.values[1, 0] * rhs.values[0, 1]) + (lhs.values[1, 1] * rhs.values[1, 1]) + (lhs.values[1, 2] * rhs.values[2, 1]) + (lhs.values[1, 3] * rhs.values[3, 1]);
        result.values[1, 2] = (lhs.values[1, 0] * rhs.values[0, 2]) + (lhs.values[1, 1] * rhs.values[1, 2]) + (lhs.values[1, 2] * rhs.values[2, 2]) + (lhs.values[1, 3] * rhs.values[3, 2]);
        result.values[1, 3] = (lhs.values[1, 0] * rhs.values[0, 3]) + (lhs.values[1, 1] * rhs.values[1, 3]) + (lhs.values[1, 2] * rhs.values[2, 3]) + (lhs.values[1, 3] * rhs.values[3, 3]);

        result.values[2, 0] = (lhs.values[2, 0] * rhs.values[0, 0]) + (lhs.values[2, 1] * rhs.values[1, 0]) + (lhs.values[2, 2] * rhs.values[2, 0]) + (lhs.values[2, 3] * rhs.values[3, 0]);
        result.values[2, 1] = (lhs.values[2, 0] * rhs.values[0, 1]) + (lhs.values[2, 1] * rhs.values[1, 1]) + (lhs.values[2, 2] * rhs.values[2, 1]) + (lhs.values[2, 3] * rhs.values[3, 1]);
        result.values[2, 2] = (lhs.values[2, 0] * rhs.values[0, 2]) + (lhs.values[2, 1] * rhs.values[1, 2]) + (lhs.values[2, 2] * rhs.values[2, 2]) + (lhs.values[2, 3] * rhs.values[3, 2]);
        result.values[2, 3] = (lhs.values[2, 0] * rhs.values[0, 3]) + (lhs.values[2, 1] * rhs.values[1, 3]) + (lhs.values[2, 2] * rhs.values[2, 3]) + (lhs.values[2, 3] * rhs.values[3, 3]);

        result.values[3, 0] = (lhs.values[3, 0] * rhs.values[0, 0]) + (lhs.values[3, 1] * rhs.values[1, 0]) + (lhs.values[3, 2] * rhs.values[2, 0]) + (lhs.values[3, 3] * rhs.values[3, 0]);
        result.values[3, 1] = (lhs.values[3, 0] * rhs.values[0, 1]) + (lhs.values[3, 1] * rhs.values[1, 1]) + (lhs.values[3, 2] * rhs.values[2, 1]) + (lhs.values[3, 3] * rhs.values[3, 1]);
        result.values[3, 2] = (lhs.values[3, 0] * rhs.values[0, 2]) + (lhs.values[3, 1] * rhs.values[1, 2]) + (lhs.values[3, 2] * rhs.values[2, 2]) + (lhs.values[3, 3] * rhs.values[3, 2]);
        result.values[3, 3] = (lhs.values[3, 0] * rhs.values[0, 3]) + (lhs.values[3, 1] * rhs.values[1, 3]) + (lhs.values[3, 2] * rhs.values[2, 3]) + (lhs.values[3, 3] * rhs.values[3, 3]);

        return result;
    }

    public Vector4 GetRow(int row, Matrix4by4 matrix)
    {
        Vector4 rv;

        rv.x = matrix.values[row, 0];
        rv.y = matrix.values[row, 1];
        rv.z = matrix.values[row, 2];
        rv.w = matrix.values[row, 3];

        return rv;
    }

    public Matrix4by4 TranlateInverse(Matrix4by4 A)
    {
        A.values[0, 3] = -values[0, 3];
        A.values[1, 3] = -values[1, 3];
        A.values[2, 3] = -values[2, 3];

        return A;
    }

    public Matrix4by4 RotateInverse(Matrix4by4 A)
    {
        A = new Matrix4by4(GetRow(0, A), GetRow(1, A), GetRow(2, A), GetRow(3, A));

        return A;
    }

    public Matrix4by4 ScaleInverse(Matrix4by4 A)
    {
        A.values[0, 0] = 1 / values[0, 0];
        A.values[1, 1] = 1 / values[1, 1];
        A.values[2, 2] = 1 / values[2, 2];

        return A;
    }
}

