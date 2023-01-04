using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowMaterial : MonoBehaviour
{
    private SkinnedMeshRenderer skinnedMesh;
    private Color color;
    private float hue;

    [SerializeField]
    private Transform meshParent;

    [SerializeField]
    private float speed = 0.1f;

    private void Awake()
    {
        skinnedMesh = meshParent.GetComponent<SkinnedMeshRenderer>();
    }

    private void Update()
    {
        hue += speed * Time.deltaTime;
        hue = Mathf.Repeat(hue, 1f);
        color = Color.HSVToRGB(hue, 1f, 1f);
        skinnedMesh.material.color = color;
    }
}