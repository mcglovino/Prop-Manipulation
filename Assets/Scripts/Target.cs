using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public GameObject Goat;
    public GameObject GoAgain;
    public Material Red;
    public Material Orange;
    public Material Green;

    public float distance = 10;

    void Start () {
        GetComponent<MeshRenderer>().material = Green;
    }
	
	void Update () {
        //can relocate without the button
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Relocate();
        }

        if (VectorMaths.Distance(GetComponent<TRS>().position, Goat.GetComponent<TRS>().position) < 1
            && Quat.AngleDiff(GetComponent<TRS>().rotateQuat, Goat.GetComponent<TRS>().rotateQuat) < 15
            && Quat.AngleDiff(GetComponent<TRS>().rotateQuat, Goat.GetComponent<TRS>().rotateQuat) > -15
            && VectorMaths.Distance(GetComponent<TRS>().scale, Goat.GetComponent<TRS>().scale) < 0.2f)
        {
            GetComponent<MeshRenderer>().material = Green;
            GoAgain.SetActive(true);
        }
        else if (VectorMaths.Distance(GetComponent<TRS>().position, Goat.GetComponent<TRS>().position) < 2.5f
            && Quat.AngleDiff(GetComponent<TRS>().rotateQuat, Goat.GetComponent<TRS>().rotateQuat) < 20
            && Quat.AngleDiff(GetComponent<TRS>().rotateQuat, Goat.GetComponent<TRS>().rotateQuat) > -20
            && VectorMaths.Distance(GetComponent<TRS>().scale, Goat.GetComponent<TRS>().scale) < 0.5f)
        {
            GetComponent<MeshRenderer>().material = Orange;
            GoAgain.SetActive(false);
        }
        else
        {
            GetComponent<MeshRenderer>().material = Red;
            GoAgain.SetActive(false);
        }

        //clamps it within the area
        if (GetComponent<TRS>().position.x > 20)
            GetComponent<TRS>().position.x = 20;
        else if (GetComponent<TRS>().position.x < -20)
            GetComponent<TRS>().position.x = -20;
        if (GetComponent<TRS>().position.y > 20)
            GetComponent<TRS>().position.y = 20;
        else if (GetComponent<TRS>().position.y < -20)
            GetComponent<TRS>().position.y = -20;
        if (GetComponent<TRS>().position.z > 20)
            GetComponent<TRS>().position.z = 20;
        else if (GetComponent<TRS>().position.z < -20)
            GetComponent<TRS>().position.z = -20;
    }

    public void Relocate()
    {
        //spawns at a set distance away on a sphere around the main object
        GetComponent<LerpTo>().targetPos = VectorMaths.Add(Goat.GetComponent<TRS>().position, VectorMaths.Normalized(VectorMaths.EulertoDir(new Vector3(Random.Range(0, Mathf.PI * 2), Random.Range(0, Mathf.PI * 2), Random.Range(0, Mathf.PI * 2)))) * distance);
        GetComponent<LerpTo>().targetRot = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
        //only set random scale if the scale toggle is on
        if (InputManager.scale == true)
            GetComponent<LerpTo>().targetScale = new Vector3(Random.Range(0.5f, 3), Random.Range(0.5f, 3), Random.Range(0.5f, 3));
        else
            GetComponent<LerpTo>().targetScale = new Vector3(1, 1, 1);
        GetComponent<MeshRenderer>().material = Red;
        GoAgain.SetActive(false);

    }
}
