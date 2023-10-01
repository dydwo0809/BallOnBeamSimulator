using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dot : MonoBehaviour
{
    private RectTransform rectTransform;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void setPos(float x, float y)
    {
        rectTransform.anchoredPosition = new Vector2(x, y);
    }
    public void setHeight(float h)
    {
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, h);
    }

}
