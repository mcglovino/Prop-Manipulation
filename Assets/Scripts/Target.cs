using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public GameObject Goat;
    public GameObject GoAgain;
    public Material Red;
    public Material Orange;
    public Material Green;

    void Start () {
        GetComponent<MeshRenderer>().material = Green;
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Relocate();
        }
        Debug.Log(VectorMaths.Distance(GetComponent<TRS>().position, Goat.GetComponent<TRS>().position));

        if (VectorMaths.Distance(GetComponent<TRS>().position, Goat.GetComponent<TRS>().position) < 1)
        {
            GetComponent<MeshRenderer>().material = Green;
            GoAgain.SetActive(true);
        }
        else if (VectorMaths.Distance(GetComponent<TRS>().position, Goat.GetComponent<TRS>().position) < 2.5f)
        {
            GetComponent<MeshRenderer>().material = Orange;
        }
        else
        {
            GetComponent<MeshRenderer>().material = Red;
        }
    }

    public void Relocate()
    {
        GetComponent<LerpTo>().targetPos = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-7.0f, 7.0f), Random.Range(-2.0f, 10.0f));

        GetComponent<LerpTo>().targetRot = new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));

        GoAgain.SetActive(false);
        GetComponent<MeshRenderer>().material = Red;

        GetComponent<LerpTo>().targetPos = VectorMaths.Add(Goat.GetComponent<TRS>().position, VectorMaths.Normalized(VectorMaths.EulertoDir(new Vector3(Mathf.PI*2, Mathf.PI * 2, Mathf.PI * 2))) * 6);
    }
}
