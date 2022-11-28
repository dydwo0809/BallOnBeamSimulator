using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMove : MonoBehaviour
{
    public Rigidbody ballRigidbody;
    public GameObject beam;

    private float beamDegree;
    private float speed;

    void Start()
    {
        speed = ballRigidbody.mass * 18;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            beamDegree = beam.transform.eulerAngles.z;
            beamDegree = beamDegree * Mathf.PI / 180;

            ballRigidbody.AddForce(new Vector3(-Mathf.Cos(beamDegree), -Mathf.Sin(beamDegree), 0f) * speed);
            
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            beamDegree = beam.transform.eulerAngles.z;
            beamDegree = beamDegree * Mathf.PI / 180;

            ballRigidbody.AddForce(new Vector3(Mathf.Cos(beamDegree), Mathf.Sin(beamDegree), 0f) * speed);
        }
    }
}
