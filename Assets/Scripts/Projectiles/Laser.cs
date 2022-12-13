using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEngine.InputSystem;
#endif

public class Laser : MonoBehaviour
{
    private LineRenderer lineRend;
    private Transform target;

    private float fpsCounter = 0f;
    private int counter = 0;

    [SerializeField] private float laserWidth = 3.0f;
    [SerializeField] private Texture[] boltTextures;

    private void Awake()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.useWorldSpace = true;
        lineRend.startWidth = laserWidth;
        lineRend.enabled = false;
    }

    private void Update()
    {
        if(lineRend.enabled == true && target != null)
        {
            FollowTarget();
            fpsCounter += Time.deltaTime;
            if(fpsCounter >= 0.1f)
            {
                counter++;
                counter %= boltTextures.Length;
                lineRend.material.SetTexture("_MainTex", boltTextures[counter]);
                fpsCounter = 0f;
            }
        }
    }

    public void ShootLaser(IAttackable target)
    {
        lineRend.SetPosition(0, transform.position);
        this.target = target.Trans;
        lineRend.SetPosition(1, target.CurrentPos);
        lineRend.enabled = true;
    }

    public void TurnoffLaser()
    {
        target = null;
        lineRend.enabled = false;
    }

    private void FollowTarget()
    {
        lineRend.SetPosition(1, target.position);
    }

}
