using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public VariableJoystick variableJoystick;
    public Transform playerObjesi;
    public Transform kameraObjesi;
    public float speed;

    void Update()
    {
        //this will make the camera look "inwards" towards Pivot
        transform.position = playerObjesi.transform.position + new Vector3(0, 2.5f, -7);


        kameraObjesi.transform.RotateAround(playerObjesi.transform.position,
                                            kameraObjesi.transform.up,
                                            variableJoystick.Horizontal * speed);

        kameraObjesi.transform.RotateAround(playerObjesi.transform.position,
                                        kameraObjesi.transform.right,
                                        variableJoystick.Vertical * speed);

    }
}
