using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Test : MonoBehaviour
{
    LineRenderer lineRend;

    int counter = 0;
    float timer = 0f;

    public Texture[] textures;

    private void Awake()
    {
        lineRend = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1.5f)
        {
            counter++;
            counter %= textures.Length;
            lineRend.material.SetTexture("_MainTex", textures[counter]);
            Debug.Log(textures[counter]);
            timer = 0f;
        }
    }
}
