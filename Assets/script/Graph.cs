using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Graph : MonoBehaviour
{
    int graphSize = 800;

    private float[] targetDist;
    private float[] currentDist;

    public GameObject ball;
    public GameObject sensor;

    public Dot dotPrefab;
    public Dot targetDotPrefab;

    private Dot[] dots;
    private Dot[] targetDots;


    // Start is called before the first frame update
    void Start()
    {
        targetDist = new float[graphSize];
        currentDist = new float[graphSize];

        dots = new Dot[graphSize];
        targetDots = new Dot[graphSize];

        for (int i = 0; i < graphSize; i++)
        {
            targetDist[i] = 155f;
            currentDist[i] = 0f;
            Dot dot = Instantiate(dotPrefab);
            Dot targetDot = Instantiate(targetDotPrefab);

            dot.transform.SetParent(transform);
            targetDot.transform.SetParent(transform);

            dots[i] = dot;
            targetDots[i] = targetDot;
        }
    }

    float correctY(float y)
    {
        if (y < 0)
        {
            y = 0;
        }
        if (y > 320)
        {
            y = 320;
        }
        float correct = (y * 449 / 320)- 455;

        return correct;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 1; i < graphSize; i++)
        {
            targetDist[i - 1] = targetDist[i];
            currentDist[i - 1] = currentDist[i];
        }
        targetDist[graphSize - 1] = PlayerPrefs.GetFloat("targetDist");
        float temp = Vector3.Distance(ball.transform.position, sensor.transform.position) - 8.15f;
        temp *= 10;
        currentDist[graphSize - 1] = temp;

        for (int i = 0; i < graphSize; i++)
        {
            float x = i + 181;
            float y = correctY(currentDist[i]);
            float targetY = correctY(targetDist[i]);

            dots[i].setPos(x, y);
            targetDots[i].setPos(x, targetY);
            targetDots[i].setHeight(5);
            if (i > 0)
            {
                if (targetDist[i] != targetDist[i - 1])
                {
                    temp = correctY(targetDist[i]) - correctY(targetDist[i - 1]);
                    targetDots[i].setHeight(Mathf.Abs(temp));
                    targetDots[i].setPos(x, targetY - (temp / 2));
                }
            }
        }

    }
}
