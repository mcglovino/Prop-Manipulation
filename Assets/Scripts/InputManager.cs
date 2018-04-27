using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public GameObject Target;

    public void rotRoll(string input)
    {
        //Target.GetComponent<TRS>().rotation.x = (float.Parse(input)/(180/Mathf.PI));
        Target.GetComponent<LerpTo>().targetRot.x = float.Parse(input) / (180 / Mathf.PI);
        //Target.GetComponent<TRS>().rotation.x = Mathf.Lerp(transform.eulerAngles.x, float.Parse(input) / (180 / Mathf.PI), 0.25f);
    }
    public void rotPitch(string input)
    {
        //Target.GetComponent<TRS>().rotation.y = (float.Parse(input) / (180 / Mathf.PI));
        Target.GetComponent<LerpTo>().targetRot.y = float.Parse(input) / (180 / Mathf.PI);
        //Target.GetComponent<TRS>().rotation.y = Mathf.Lerp(transform.eulerAngles.y, float.Parse(input) / (180 / Mathf.PI), 0.25f);
    }
    public void rotYaw(string input)
    {
        //Target.GetComponent<TRS>().rotation.z = (float.Parse(input) / (180 / Mathf.PI));
        Target.GetComponent<LerpTo>().targetRot.z = float.Parse(input) / (180 / Mathf.PI);
        //Target.GetComponent<TRS>().rotation.z = Mathf.Lerp(transform.eulerAngles.z, float.Parse(input) / (180 / Mathf.PI), 0.25f);
    }

    public void posX(string input)
    {
        Target.GetComponent<LerpTo>().targetPos.x = float.Parse(input);
    }
    public void posY(string input)
    {
        Target.GetComponent<LerpTo>().targetPos.y = float.Parse(input);
    }
    public void posZ(string input)
    {
        Target.GetComponent<LerpTo>().targetPos.z = float.Parse(input);
    }
}
