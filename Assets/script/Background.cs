using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Material bgMaterial;
    private float scrollSpeed = 0.02f;

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.right;
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
