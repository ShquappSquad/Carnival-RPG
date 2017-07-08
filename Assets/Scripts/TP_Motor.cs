using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TP_Motor : MonoBehaviour
{
    public static TP_Motor Instance;
    public float MoveSpeed = 10f;
    public Vector3 MoveVector { get; set; }


	void Awake ()
    {
        Instance = this;	
	}
	
	public void UpdateMotor ()
    {
        SnapAlignCharacterWithCamera();
        ProcessMotion();
    }

    void ProcessMotion()
    {
        //Transform MoveVector to World Space
        MoveVector = transform.TransformDirection(MoveVector);

        //Normalize MoveVector is Magnitude > 1
        if (MoveVector.magnitude > 1)
            MoveVector = Vector3.Normalize(MoveVector);

        //Multiply MoveVector by MoveSpeed
        MoveVector *= MoveSpeed;

        //Multiply MoveVector by DeltaTime
        MoveVector *= Time.deltaTime;

        //Move Character imn World Space
        TP_Controller.CharacterController.Move(MoveVector);
    }

    void SnapAlignCharacterWithCamera()
    {
        if (MoveVector.x != 0 || MoveVector.z != 0)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x,
                Camera.main.transform.eulerAngles.y,
                transform.eulerAngles.z);
        }
    }
}
