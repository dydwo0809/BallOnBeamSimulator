using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicGraph : MonoBehaviour
{
    public GameObject DynamicP;
    public GameObject DynamicI;
    public GameObject DynamicD;

    public float LengthP;
    public float LengthI;
    public float LengthD;

    private float LengthAdjustment = 200;

    public GameObject PIDButton;

    servo servo;

    // Start is called before the first frame update
    void Start()
    {
        servo = PIDButton.GetComponent<servo>();
    }

    // Update is called once per frame
    void Update()
    {
        LengthP = servo.pterm / LengthAdjustment;
        LengthI = servo.iterm / LengthAdjustment;
        LengthD = servo.dterm / LengthAdjustment;

        DynamicP.transform.localScale = new Vector3(Mathf.Abs(LengthP), 0.25f, 10.0f);
        DynamicI.transform.localScale = new Vector3(Mathf.Abs(LengthI), 0.25f, 10.0f);
        DynamicD.transform.localScale = new Vector3(Mathf.Abs(LengthD), 0.25f, 10.0f);

        DynamicP.transform.localPosition = new Vector3(LengthP / 2, 0.25f, 0f);
        DynamicI.transform.localPosition = new Vector3(LengthI / 2, 0f, 0f);
        DynamicD.transform.localPosition = new Vector3(LengthD / 2, -0.25f, 0f);

    }
}
