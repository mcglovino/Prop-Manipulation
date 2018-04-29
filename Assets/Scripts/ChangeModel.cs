using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModel : MonoBehaviour {

    public GameObject main, target;
    public Mesh goat, wolf, deer, gun;


    void Update () {
        if (Input.GetKeyDown(KeyCode.U))
        {
            main.GetComponent<MeshFilter>().mesh = gun;
            target.GetComponent<MeshFilter>().mesh = gun;
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
