using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool IsPause = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsPause == false)
            {
                Time.timeScale = 0;
                IsPause = true;
                return;
            }
            else
            {
                Time.timeScale = 1;
                IsPause = false;
                return;
            }
        }
    }
}
