using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Applies changes to the vertices of the models with matrix transformations
/// </summary>

public class TRS : MonoBehaviour
{

    Vector3[] ModelSpaceVertices;
    MeshFilter MF;

    //X, Y, Z
    public Vector3 scale = new Vector3(1.0f, 1.0f, 1.0f);
    //X, Y, Z
    public Vector3 position = new Vector3(0.0f, 0.0f, 0.0f);
    //R, P, Y
    public Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);

    public Quat rotateQuat = new Quat(0, new Vector3(0,0,0));


    void Start()
    {
        GetMesh();
    }
    //Gets the mesh and puts it into our own vector array for changing
    //seperated so it can be called externall from change model script
    public void GetMesh()
    {
        MF = GetComponent<MeshFilter>();

        ModelSpaceVertices = MF.mesh.vertices;
    }

    void Update()
    {
        //keep them the same length, with changes to the model etc
        Vector3[] TransformedVertices = new Vector3[ModelSpaceVertices.Length];

        //Left over from when euler angles where in place
        /*Matrix4by4 rollMatrix = new Matrix4by4(
            new Vector3(Mathf.Cos(rotation.z), Mathf.Sin(rotation.z), 0),
            new Vector3(-Mathf.Sin(rotation.z), Mathf.Cos(rotation.z), 0),
            new Vector3(0, 0, 1),
            Vector3.zero);
        Matrix4by4 pitchMatrix = new Matrix4by4(
           new Vector3(1, 0, 0),
           new Vector3(0, Mathf.Cos(rotation.x), Mathf.Sin(rotation.x)),
           new Vector3(0, -Mathf.Sin(rotation.x), Mathf.Cos(rotation.x)),
           Vector3.zero);
        Matrix4by4 yawMatrix = new Matrix4by4(
            new Vector3(Mathf.Cos(rotation.y), 0, -Mathf.Sin(rotation.y)),
            new Vector3(0, 1, 0),
            new Vector3(Mathf.Sin(rotation.y), 0, Mathf.Cos(rotation.y)),
            Vector3.zero);*/

        Matrix4by4 translateMatrix = new Matrix4by4(
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 1),
            new Vector3(position.z, position.x, position.y));
        //Matrix4by4 rotMatrix = yawMatrix * (pitchMatrix * rollMatrix);
        Matrix4by4 scaleMatrix = new Matrix4by4(
            new Vector3(1, 0, 0) * scale.x,
            new Vector3(0, 1, 0) * scale.y,
            new Vector3(0, 0, 1) * scale.z,
            Vector3.zero);

        //Scale, Rotate, and then translate
        Matrix4by4 M = translateMatrix * (rotateQuat.QuatToMatrix() * scaleMatrix);

        //Make the changes t the mesh
        for (int i = 0; i < TransformedVertices.Length; i++)
        {
            TransformedVertices[i] = M * ModelSpaceVertices[i];
        }
        //apply the changes
        MF.mesh.vertices = TransformedVertices;
        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}