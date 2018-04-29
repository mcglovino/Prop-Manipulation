using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public GameObject Target;
    public float x, y, z, roll, pitch, yaw;
    bool transRot = false;

    public void rotRoll(string input)
    {
        roll = Maths.DegToRad(float.Parse(input));
    }
    public void rotPitch(string input)
    {
        pitch = Maths.DegToRad(float.Parse(input));
    }
    public void rotYaw(string input)
    {
        yaw = Maths.DegToRad(float.Parse(input));
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            transRot = !transRot;

        if (transRot)
        {
            if (Input.GetKey(KeyCode.W))
                Target.GetComponent<LerpTo>().targetRot -= new Vector3(0, 0.05f, 0);
            if (Input.GetKey(KeyCode.S))
                Target.GetComponent<LerpTo>().targetRot += new Vector3(0, 0.05f, 0);
            if (Input.GetKey(KeyCode.A))
                Target.GetComponent<LerpTo>().targetRot -= new Vector3(0, 0, 0.05f);
            if (Input.GetKey(KeyCode.D))
                Target.GetComponent<LerpTo>().targetRot += new Vector3(0, 0, 0.05f);
            if (Input.GetKey(KeyCode.E))
                Target.GetComponent<LerpTo>().targetRot -= new Vector3(0.05f, 0, 0);
            if (Input.GetKey(KeyCode.R))
                Target.GetComponent<LerpTo>().targetRot += new Vector3(0.05f, 0, 0);
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
                Target.GetComponent<LerpTo>().targetPos += new Vector3(0, 0.1f, 0);
            if (Input.GetKey(KeyCode.S))
                Target.GetComponent<LerpTo>().targetPos -= new Vector3(0, 0.1f, 0);
            if (Input.GetKey(KeyCode.A))
                Target.GetComponent<LerpTo>().targetPos -= new Vector3(0.1f, 0, 0);
            if (Input.GetKey(KeyCode.D))
                Target.GetComponent<LerpTo>().targetPos += new Vector3(0.1f, 0, 0);
            if (Input.GetKey(KeyCode.E))
                Target.GetComponent<LerpTo>().targetPos += new Vector3(0, 0, 0.1f);
            if (Input.GetKey(KeyCode.R))
                Target.GetComponent<LerpTo>().targetPos -= new Vector3(0, 0, 0.1f);
        }
    }
}
