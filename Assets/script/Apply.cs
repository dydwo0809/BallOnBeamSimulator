using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Apply : MonoBehaviour
{
    public TMP_InputField textA;
    public TMP_InputField textB;

    public TMP_InputField P_input;
    public TMP_InputField I_input;
    public TMP_InputField D_input;
    public TMP_InputField target_input;

    public GameObject servoPiller;
    public GameObject LowArm;
    public GameObject upperArm;
    public GameObject beam;
    public GameObject joint;
    public GameObject hinge2;
    public GameObject target;

    public HingeJoint jointHinge;
    public HingeJoint THinge;

    public Rigidbody beamRigidbody;

    float A;
    float B;

    private float P;
    private float I;
    private float D;
    private float targetDist = 15;

    void Start()
    {
        A = PlayerPrefs.GetFloat("A");
        B = PlayerPrefs.GetFloat("B");

        P = PlayerPrefs.GetFloat("P");
        I = PlayerPrefs.GetFloat("I");
        D = PlayerPrefs.GetFloat("D");

        targetDist = PlayerPrefs.GetFloat("targetDist");


        textA.text = "" + A;
        textB.text = "" + B;
        P_input.text = "" + P;
        I_input.text = "" + I;
        D_input.text = "" + D;
        target_input.text = "" + targetDist;

        if (A == 0 && B == 0 && targetDist == 0)
        {
            A = 0.8f;
            B = 8f;
            targetDist = 20;
            P = 0;
            I = 0;
            D = 0;
        }
        joint.transform.parent = upperArm.transform;
        upperArm.transform.parent = LowArm.transform;
        LowArm.transform.parent = servoPiller.transform;
        hinge2.transform.parent = null;

        jointHinge.connectedBody = null;
        THinge.connectedBody = null;

        target.transform.parent = null;


        Vector3 tempBeam = new Vector3(-1.2f - A, beam.transform.position.y, beam.transform.position.z);
        beam.transform.position = tempBeam;

        Vector3 tempServoPiller = new Vector3(22.3f - B, servoPiller.transform.position.y, servoPiller.transform.position.z);
        servoPiller.transform.position = tempServoPiller;

        target.transform.position = new Vector3(targetDist - 10, 17.59f, -0.1f);

        target.transform.parent = beam.transform;

        hinge2.transform.parent = beam.transform;
        LowArm.transform.parent = null;
        upperArm.transform.parent = null;
        joint.transform.parent = beam.transform;

        jointHinge.connectedBody = beamRigidbody;
        THinge.connectedBody = beamRigidbody;
    }


    public void ReStart()
    {
        try
        {
            A = float.Parse(textA.text);
            if (A < 0)
            {
                A = 0f;
            }
            if (A > 2.6)
            {
                A = 2.6f;
            }
        }
        catch
        {
            A = PlayerPrefs.GetFloat("A");
        }
        try
        {
            B = float.Parse(textB.text);
            if (B < 7.2f + A)
            {
                B = (7.2f + A);
            }
            if (B > 35)
            {
                B = 35f;
            }
        }
        catch
        {
            B = PlayerPrefs.GetFloat("B");
        }

        try
        {
            P = float.Parse(P_input.text);
            if (P < 0)
            {
                P = 0;
            }
        }
        catch
        {
            P = PlayerPrefs.GetFloat("P");
        }
        try
        {
            I = float.Parse(I_input.text);
            if (I < 0)
            {
                I = 0;
            }
        }
        catch
        {
            I = PlayerPrefs.GetFloat("I");
        }
        try
        {
            D = float.Parse(D_input.text);
            if (D < 0)
            {
                D = 0;
            }
        }
        catch
        {
            D = PlayerPrefs.GetFloat("D");
        }
        try
        {
            targetDist = float.Parse(target_input.text);
            if (targetDist < 0)
            {
                targetDist = 0;
            }
        }
        catch
        {
            targetDist = PlayerPrefs.GetFloat("targetDist");
        }

        PlayerPrefs.SetFloat("A", A);
        PlayerPrefs.SetFloat("B", B);
        PlayerPrefs.SetFloat("P", P);
        PlayerPrefs.SetFloat("I", I);
        PlayerPrefs.SetFloat("D", D);
        PlayerPrefs.SetFloat("targetDist", targetDist);

        SceneManager.LoadScene("SampleScene");
    }
}
