using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeTarget : MonoBehaviour
{
    public GameObject targetA;
    public GameObject targetB;
    public GameObject targetC;
    public GameObject arrow;

    public TMP_InputField target_input;


    // Start is called before the first frame update
    void Start()
    {
        targetA.SetActive(false);
        targetB.SetActive(false);
        targetC.SetActive(false);
        arrow.SetActive(true);

    }

    public void SetTargetA()
    {
        targetA.SetActive(true);
        targetB.SetActive(false);
        targetC.SetActive(false);
        arrow.SetActive(false);

        PlayerPrefs.SetFloat("targetDist", 255f);
        target_input.text = "" + 255f;
    }

    public void SetTargetB()
    {
        targetA.SetActive(false);
        targetB.SetActive(true);
        targetC.SetActive(false);
        arrow.SetActive(false);

        PlayerPrefs.SetFloat("targetDist", 155f);
        target_input.text = "" + 155f;
    }

    public void SetTargetC()
    {
        targetA.SetActive(false);
        targetB.SetActive(false);
        targetC.SetActive(true);
        arrow.SetActive(false);

        PlayerPrefs.SetFloat("targetDist", 55f);
        target_input.text = "" + 55f;
    }
}
