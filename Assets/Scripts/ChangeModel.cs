using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Changes the models of the target and main object to different meshes
/// </summary>

public class ChangeModel : MonoBehaviour {

    //Get gameobjects for both objects whos meshes will change
    public GameObject main, target;
    //The meshes that can be changed to
    public Mesh goat, wolf, deer, gun;


    void Update () {
        //A key for each mesh, changes to it
        if (Input.GetKeyDown(KeyCode.U))
        {
            //sets the meshes of both objcts to the desired mesh
            main.GetComponent<MeshFilter>().mesh = gun;
            target.GetComponent<MeshFilter>().mesh = gun;
            //Updates MEsh variables in TRS script
            main.GetComponent<TRS>().GetMesh();
            target.GetComponent<TRS>().GetMesh();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            main.GetComponent<MeshFilter>().mesh = deer;
            target.GetComponent<MeshFilter>().mesh = deer;
            main.GetComponent<TRS>().GetMesh();
            target.GetComponent<TRS>().GetMesh();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            main.GetComponent<MeshFilter>().mesh = wolf;
            target.GetComponent<MeshFilter>().mesh = wolf;
            main.GetComponent<TRS>().GetMesh();
            target.GetComponent<TRS>().GetMesh();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            main.GetComponent<MeshFilter>().mesh = goat;
            target.GetComponent<MeshFilter>().mesh = goat;
            main.GetComponent<TRS>().GetMesh();
            target.GetComponent<TRS>().GetMesh();
        }
    }
}
