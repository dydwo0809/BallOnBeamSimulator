using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphButton : MonoBehaviour
{
    public GameObject Graph;

    int toggle = 1;

    public void click()
    {
        if (toggle == 1)
        {
            Graph.SetActive(false);
        }
        else
        {
            Graph.SetActive(true);
        }
        toggle = 1 - toggle;
    }
}
