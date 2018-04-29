using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public GameObject Target;
    public float x, y, z, roll, pitch, yaw, scalex, scaley, scalez;
    public int TRS;
    public static bool scale = false;

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

    public void scaleX(string input)
    {
        scalex = float.Parse(input);
    }
    public void scaleY(string input)
    {
        scaley = float.Parse(input);
    }
    public void scaleZ(string input)
    {
        scalez = float.Parse(input);
    }

    public void Scale(bool input)
    {
        scale = input;
    }

    public void go()
    {
        Target.GetComponent<LerpTo>().targetPos = new Vector3(x,y,z);

        Target.GetComponent<LerpTo>().targetRot = new Vector3(pitch, yaw, roll);

        Target.GetComponent<LerpTo>().targetScale = new Vector3(scalex, scaley, scalez);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            TRS = 0;
        if (Input.GetKeyDown(KeyCode.K))
            TRS = 1;
        if (Input.GetKeyDown(KeyCode.L))
            TRS = 2;

        if (TRS == 0)
        {
            if (Input.GetKey(KeyCode.W))
                Target.GetComponent<LerpTo>().targetRot -= new Vector3(0, 0, 0.05f);
            if (Input.GetKey(KeyCode.S))
                Target.GetComponent<LerpTo>().targetRot += new Vector3(0, 0, 0.05f);
            if (Input.GetKey(KeyCode.A))
                Target.GetComponent<LerpTo>().targetRot -= new Vector3(0, 0.05f, 0);
            if (Input.GetKey(KeyCode.D))
                Target.GetComponent<LerpTo>().targetRot += new Vector3(0, 0.05f, 0);
            if (Input.GetKey(KeyCode.E))
                Target.GetComponent<LerpTo>().targetRot -= new Vector3(0.05f, 0, 0);
            if (Input.GetKey(KeyCode.R))
                Target.GetComponent<LerpTo>().targetRot += new Vector3(0.05f, 0, 0);
        }
        else if (TRS == 1)
        {
            if (Input.GetKey(KeyCode.W))
                Target.GetComponent<LerpTo>().targetPos += new Vector3(0, 0.1f, 0);
            if (Input.GetKey(KeyCode.S))
                Target.GetComponent<LerpTo>().targetPos -= new Vector3(0, 0.1f, 0);
            if (Input.GetKey(KeyCode.A))
                Target.GetComponent<LerpTo>().targetPos += new Vector3(0.1f, 0, 0);
            if (Input.GetKey(KeyCode.D))
                Target.GetComponent<LerpTo>().targetPos -= new Vector3(0.1f, 0, 0);
            if (Input.GetKey(KeyCode.E))
                Target.GetComponent<LerpTo>().targetPos += new Vector3(0, 0, 0.1f);
            if (Input.GetKey(KeyCode.R))
                Target.GetComponent<LerpTo>().targetPos -= new Vector3(0, 0, 0.1f);
        }

        else if (TRS == 2 && scale == true)
        {
            if (Input.GetKey(KeyCode.W))
                Target.GetComponent<LerpTo>().targetScale += new Vector3(0, 0.05f, 0);
            if (Input.GetKey(KeyCode.S))
                Target.GetComponent<LerpTo>().targetScale -= new Vector3(0, 0.05f, 0);
            if (Input.GetKey(KeyCode.A))
                Target.GetComponent<LerpTo>().targetScale -= new Vector3(0.05f, 0, 0);
            if (Input.GetKey(KeyCode.D))
                Target.GetComponent<LerpTo>().targetScale += new Vector3(0.05f, 0, 0);
            if (Input.GetKey(KeyCode.E))
                Target.GetComponent<LerpTo>().targetScale -= new Vector3(0, 0, 0.05f);
            if (Input.GetKey(KeyCode.R))
                Target.GetComponent<LerpTo>().targetScale += new Vector3(0, 0, 0.05f);
        }
    }
}
