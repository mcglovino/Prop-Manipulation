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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Relocate();
        }

        if (VectorMaths.Distance(GetComponent<TRS>().position, Goat.GetComponent<TRS>().position) < 1)
        {
            GetComponent<MeshRenderer>().material = Green;
            GoAgain.SetActive(true);
        }
        else if (VectorMaths.Distance(GetComponent<TRS>().position, Goat.GetComponent<TRS>().position) < 2.5f)
        {
            GetComponent<MeshRenderer>().material = Orange;
            GoAgain.SetActive(false);
        }
        else
        {
            GetComponent<MeshRenderer>().material = Red;
            GoAgain.SetActive(false);
        }

        if (GetComponent<TRS>().position.x > 10 || GetComponent<TRS>().position.x < -10
            || GetComponent<TRS>().position.y > 7 || GetComponent<TRS>().position.y < -7
            || GetComponent<TRS>().position.z > 10 || GetComponent<TRS>().position.z < -2)
        {
            Relocate();
        }
    }

    public void Relocate()
    {
        //GetComponent<LerpTo>().targetPos = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-7.0f, 7.0f), Random.Range(-2.0f, 10.0f));
        GetComponent<LerpTo>().targetPos = VectorMaths.Add(Goat.GetComponent<TRS>().position, VectorMaths.Normalized(VectorMaths.EulertoDir(new Vector3(Random.Range(0, Mathf.PI * 2), Random.Range(0, 360), Random.Range(0, 360)))) * 6);
        GetComponent<LerpTo>().targetRot = new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
        GetComponent<MeshRenderer>().material = Red;
        GoAgain.SetActive(false);

    }
}
