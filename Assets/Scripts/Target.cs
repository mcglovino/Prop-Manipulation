using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Checks when the object and target object are close to eachother
/// changes the target objects colour
/// keeps the target object within the area
/// relocated the target object (through button when within threshold, and with 'Z key as overload/for testing)
/// </summary>

public class Target : MonoBehaviour {
    //get objects and materials
    public GameObject Object;
    public GameObject GoAgain;
    public Material Red;
    public Material Orange;
    public Material Green;
    //set distance for the target object to spawn away from the main object
    public float distance = 10;

    //thresholds for the object to be a match
    public float AngleThreshold = 20;
    public float DistanceThreshold = 1;
    public float ScaleThreshold = 0.2f;
    
    void Start () {
        //starts green as it is next to the main object
        GetComponent<MeshRenderer>().material = Green;
    }
	
	void Update () {
        //can relocate without the button, overload for testing
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Relocate();
        }
        //If the distance rotation and scale are within thier thresholds set the object to green and activate the relocate button
        if (VectorMaths.Distance(GetComponent<TRS>().position, Object.GetComponent<TRS>().position) < DistanceThreshold
            && Quat.AngleDiff(GetComponent<TRS>().rotateQuat, Object.GetComponent<TRS>().rotateQuat) < AngleThreshold
            && Quat.AngleDiff(GetComponent<TRS>().rotateQuat, Object.GetComponent<TRS>().rotateQuat) > -AngleThreshold
            && VectorMaths.Distance(GetComponent<TRS>().scale, Object.GetComponent<TRS>().scale) < ScaleThreshold)
        {
            GetComponent<MeshRenderer>().material = Green;
            GoAgain.SetActive(true);
        }
        //If the object is within a larger threshold set the object to orange to give the user indication of thier progress
        else if (VectorMaths.Distance(GetComponent<TRS>().position, Object.GetComponent<TRS>().position) < (DistanceThreshold * 2.5f)
            && Quat.AngleDiff(GetComponent<TRS>().rotateQuat, Object.GetComponent<TRS>().rotateQuat) < (AngleThreshold + 8)
            && Quat.AngleDiff(GetComponent<TRS>().rotateQuat, Object.GetComponent<TRS>().rotateQuat) > -(AngleThreshold + 8)
            && VectorMaths.Distance(GetComponent<TRS>().scale, Object.GetComponent<TRS>().scale) < (ScaleThreshold * 2.5f))
        {
            GetComponent<MeshRenderer>().material = Orange;
            GoAgain.SetActive(false);
        }
        //target is red if it is not within the thresholds
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
    //relocates the target object
    public void Relocate()
    {
        //spawns at a set distance away on a sphere around the main object
        GetComponent<LerpTo>().targetPos = VectorMaths.Add(Object.GetComponent<TRS>().position, VectorMaths.Normalized(VectorMaths.EulertoDir(new Vector3(Random.Range(0, Mathf.PI * 2), Random.Range(0, Mathf.PI * 2), Random.Range(0, Mathf.PI * 2)))) * distance);
        //has a random rotation
        GetComponent<LerpTo>().targetRot = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
        //only set random scale if the scale toggle is on
        if (InputManager.scale == true)
            GetComponent<LerpTo>().targetScale = new Vector3(Random.Range(0.5f, 3), Random.Range(0.5f, 3), Random.Range(0.5f, 3));
        else
            GetComponent<LerpTo>().targetScale = new Vector3(1, 1, 1);
        //resets the material to red, and turns the button off
        GetComponent<MeshRenderer>().material = Red;
        GoAgain.SetActive(false);

    }
}
