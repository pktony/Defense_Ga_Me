using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Torque_Test : MonoBehaviour
{
    Rigidbody rigid;
    Transform torquePoint;

    public float power = 5f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        torquePoint = transform.GetChild(0);
    }

    private void Update()
    {
        if(UnityEngine.InputSystem.Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rigid.AddForceAtPosition(Vector3.up * power, torquePoint.position, ForceMode.Impulse);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(torquePoint.position, torquePoint.up);
    }
}
