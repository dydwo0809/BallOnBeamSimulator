using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMove : MonoBehaviour
{
    public GameObject servoPillar;

    private Vector3 correct = new Vector3(-3, 1, 0);

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(servoPillar.transform.position + correct);
    }
}
