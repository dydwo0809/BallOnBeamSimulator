using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class servo : MonoBehaviour
{
    public HingeJoint servoHinge;
    public float speed;
    private int PID = 0;
    public float P;
    public float I;
    public float D;

    private float pterm = 0;
    private float dterm = 0;
    private float iterm = 0;

    private float currentDegree;

    private float targetDist;
    private float currentDist;
    private float prevDist;

    private float error_curr;
    private float control;

    public GameObject lowArm;
    public GameObject ball;
    public GameObject sensor;

    public TMP_InputField P_input;
    public TMP_InputField I_input;
    public TMP_InputField D_input;
    public TMP_InputField target_input;

    private void Start()
    {
        JointLimits limits = servoHinge.limits;
        limits.min = -90;
        limits.bounciness = 0;
        limits.bounceMinVelocity = 0;
        limits.max = 90;
        servoHinge.limits = limits;

        P = PlayerPrefs.GetFloat("P");
        I = PlayerPrefs.GetFloat("I");
        D = PlayerPrefs.GetFloat("D");

        targetDist = PlayerPrefs.GetFloat("targetDist");
    }

    private void FixedUpdate()
    {
        Debug.Log(PID);
        if (PID == 1) 
        {
            currentDist = Vector3.Distance(ball.transform.position, sensor.transform.position) - 2.15f;
            error_curr = targetDist - currentDist;


            pterm = error_curr * P;
            dterm = (prevDist - currentDist) * D;
            iterm += error_curr * I;

            control = pterm + dterm + iterm;

            Write(control);

            prevDist = currentDist;
        }
        else
        {
            JointMotor motor = servoHinge.motor;
            motor.targetVelocity = 0;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                motor.targetVelocity = -speed;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                motor.targetVelocity = speed;
            }
            servoHinge.motor = motor;
        }
    }
    

    private void Write(float degree)
    {
        if (degree > 90)
        {
            degree = 90;
        }
        if (degree < -90)
        {
            degree = -90;
        }

        JointMotor motor = servoHinge.motor;
        JointLimits limits = servoHinge.limits;
        currentDegree = lowArm.transform.eulerAngles.z;
        if (currentDegree > 180)
        {
            currentDegree -= 360;
        }

        if (currentDegree > degree)
        {
            limits.min = degree;
            limits.max = 90;
            servoHinge.limits = limits;
            motor.targetVelocity = -speed;
        }
        else
        {
            limits.max = degree;
            limits.min = -90;
            servoHinge.limits = limits;
            motor.targetVelocity = speed;
        }
        servoHinge.motor = motor;
        
    }

    public void togglePID()
    {
        PID = 1 - PID;

        if (PID == 0)
        {
            JointLimits limits = servoHinge.limits;
            limits.min = -90;
            limits.max = 90;
            servoHinge.limits = limits;
        }
    }
}
