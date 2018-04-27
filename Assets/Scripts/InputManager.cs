using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public GameObject Target;
    public float x, y, z, roll, pitch, yaw;

    public void rotRoll(string input)
    {
        roll = float.Parse(input) / (180 / Mathf.PI);
    }
    public void rotPitch(string input)
    {
        pitch = float.Parse(input) / (180 / Mathf.PI);
    }
    public void rotYaw(string input)
    {
        yaw = float.Parse(input) / (180 / Mathf.PI);
    }

    public void posX(string input)
    {
        x = float.Parse(input);
    }
    public void posY(string input)
    {
        y = float.Parse(input);
    }
    public void posZ(string input)
    {
        z = float.Parse(input);
    }

    public void go()
    {
        Target.GetComponent<LerpTo>().targetPos = new Vector3(x, y, z);

        Target.GetComponent<LerpTo>().targetRot = new Vector3(roll, pitch, yaw);
    }
}
