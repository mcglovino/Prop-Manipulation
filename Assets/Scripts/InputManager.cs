using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gets the inputs from keypresses, and input fields
/// Sends instructions to translate, rotate and scale the object accordingly
/// </summary>

public class InputManager : MonoBehaviour {

    //Declare variables
    public GameObject Target;
    public float x, y, z, roll, pitch, yaw, scalex, scaley, scalez;
    public int TRS;
    public static bool scale = false;

    //Input for rotation changed from degrees ro radians
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
    //Input for Position
    public void posX(string input)
    {
        x = float.Parse(input);
    }
    public void posY(string input)
    {
        y = -float.Parse(input);
    }
    public void posZ(string input)
    {
        z = float.Parse(input);
    }
    //Input for Scale
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
    //Checkbox for whetehr scale is tuned on or not
    public void Scale(bool input)
    {
        scale = input;
    }

    //When the Go button is pressed, move the object to the target location, rotation and scale
    public void go()
    {
        //targetpos xyz switched after different models added and things went wierd due to thier axis
        Target.GetComponent<LerpTo>().targetPos = new Vector3(-y,z,x);
        Target.GetComponent<LerpTo>().targetRot = new Vector3(pitch, yaw, roll);
        //Scale only changed if the tickbox has been activated
        if(scale == true)
            Target.GetComponent<LerpTo>().targetScale = new Vector3(scalex, scaley, scalez);
    }

    void Update()
    {
        //Changing between Rotate(J), Translate(K), and scale(L)
        if (Input.GetKeyDown(KeyCode.J))
            TRS = 0;
        if (Input.GetKeyDown(KeyCode.K))
            TRS = 1;
        if (Input.GetKeyDown(KeyCode.L))
            TRS = 2;
        //Change rotation according to key input
        if (TRS == 0)
        {
            //Pitch
            if (Input.GetKey(KeyCode.W))
                Target.GetComponent<LerpTo>().targetRot = VectorMaths.Add(Target.GetComponent<LerpTo>().targetRot, new Vector3(0.05f, 0, 0));
            if (Input.GetKey(KeyCode.S))
                Target.GetComponent<LerpTo>().targetRot = VectorMaths.Sub(Target.GetComponent<LerpTo>().targetRot, new Vector3(0.05f, 0, 0));
            //Yaw
            if (Input.GetKey(KeyCode.A))
                Target.GetComponent<LerpTo>().targetRot = VectorMaths.Sub(Target.GetComponent<LerpTo>().targetRot, new Vector3(0, 0.05f, 0));
            if (Input.GetKey(KeyCode.D))
                Target.GetComponent<LerpTo>().targetRot = VectorMaths.Add(Target.GetComponent<LerpTo>().targetRot, new Vector3(0, 0.05f, 0));
            //Roll
            if (Input.GetKey(KeyCode.E))
                Target.GetComponent<LerpTo>().targetRot = VectorMaths.Add(Target.GetComponent<LerpTo>().targetRot, new Vector3(0, 0, 0.05f));
            if (Input.GetKey(KeyCode.R))
                Target.GetComponent<LerpTo>().targetRot = VectorMaths.Sub(Target.GetComponent<LerpTo>().targetRot, new Vector3(0, 0, 0.05f));
        }
        //Change Translation according to input
        else if (TRS == 1)
        {
            //Y axis
            if (Input.GetKey(KeyCode.W))
                Target.GetComponent<LerpTo>().targetPos = VectorMaths.Add(Target.GetComponent<LerpTo>().targetPos, new Vector3(0.1f, 0, 0));
            if (Input.GetKey(KeyCode.S))
                Target.GetComponent<LerpTo>().targetPos = VectorMaths.Sub(Target.GetComponent<LerpTo>().targetPos, new Vector3(0.1f, 0, 0));
            //X axis
            if (Input.GetKey(KeyCode.A))
                Target.GetComponent<LerpTo>().targetPos = VectorMaths.Add(Target.GetComponent<LerpTo>().targetPos, new Vector3(0, 0, 0.1f));
            if (Input.GetKey(KeyCode.D))
                Target.GetComponent<LerpTo>().targetPos = VectorMaths.Sub(Target.GetComponent<LerpTo>().targetPos, new Vector3(0, 0, 0.1f));
            //Z Axis
            if (Input.GetKey(KeyCode.E))
                Target.GetComponent<LerpTo>().targetPos = VectorMaths.Add(Target.GetComponent<LerpTo>().targetPos, new Vector3(0, 0.1f, 0));
            if (Input.GetKey(KeyCode.R))
                Target.GetComponent<LerpTo>().targetPos = VectorMaths.Sub(Target.GetComponent<LerpTo>().targetPos, new Vector3(0, 0.1f, 0));
        }
        //Change scale according to input, only if scale tickbox is checked
        else if (TRS == 2 && scale == true)
        {
            //Y axis
            if (Input.GetKey(KeyCode.W))
                Target.GetComponent<LerpTo>().targetScale = VectorMaths.Add(Target.GetComponent<LerpTo>().targetScale, new Vector3(0, 0.05f, 0));
            if (Input.GetKey(KeyCode.S))
                Target.GetComponent<LerpTo>().targetScale = VectorMaths.Sub(Target.GetComponent<LerpTo>().targetScale, new Vector3(0, 0.05f, 0));
            //X Axis
            if (Input.GetKey(KeyCode.A))
                Target.GetComponent<LerpTo>().targetScale = VectorMaths.Sub(Target.GetComponent<LerpTo>().targetScale, new Vector3(0.05f, 0, 0));
            if (Input.GetKey(KeyCode.D))
                Target.GetComponent<LerpTo>().targetScale = VectorMaths.Add(new Vector3(0.05f, 0, 0), Target.GetComponent<LerpTo>().targetScale);
            //Z axis
            if (Input.GetKey(KeyCode.E))
                Target.GetComponent<LerpTo>().targetScale = VectorMaths.Sub(Target.GetComponent<LerpTo>().targetScale, new Vector3(0, 0, 0.05f));
            if (Input.GetKey(KeyCode.R))
                Target.GetComponent<LerpTo>().targetScale = VectorMaths.Add(new Vector3(0, 0, 0.05f), Target.GetComponent<LerpTo>().targetScale);
        }
    }
}
