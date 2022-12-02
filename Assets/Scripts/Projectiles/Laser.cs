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

    [SerializeField] private float laserWidth = 3.0f;

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
