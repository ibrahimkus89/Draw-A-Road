using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    public WheelJoint2D FrontTire;
    public WheelJoint2D RearTire;
    private JointMotor2D MotorFront;
    private JointMotor2D MotorRear;

    [SerializeField] private float Speed;
    [SerializeField] private float Torque;

   

   
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            MotorFront.motorSpeed = Speed * -1;
            MotorFront.maxMotorTorque = Torque;
            FrontTire.motor = MotorFront;

            MotorRear.motorSpeed = Speed * -1;
            MotorRear.maxMotorTorque = Torque;
            RearTire.motor = MotorRear;
        }
        else
        {
            RearTire.useMotor =false;
            FrontTire.useMotor = false;

        }
    }
}
