using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile_Test : MonoBehaviour
{
    private Rigidbody rigid;

    public GameObject projectile;
    public Transform end;
    public float v0 = 10f;

    private const float g = 9.8f;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameObject obj = Instantiate(projectile, transform.position, Quaternion.identity);

            float distance = (end.position - transform.position).magnitude;
            Vector3 direction = (end.position - transform.position).normalized;

            float vi = v0;
            float shootAngle = CalculateShootAngle(distance, ref vi);
            Vector3 elevation = Quaternion.AngleAxis(shootAngle, transform.right) * transform.up;
            float yaw = Vector3.Angle(transform.forward, direction);
            Vector3 velocity = Quaternion.AngleAxis(yaw, transform.up) * elevation * vi;

            obj.GetComponent<Rigidbody>().AddForce(velocity, ForceMode.VelocityChange);
        }
    }

    private float CalculateDirectionAngle(Vector3 v1, Vector3 v2, Vector3 n)
    {
        float angle = Mathf.Atan2(Vector3.Dot(n, Vector3.Cross(v1, v2)),
            Vector3.Dot(v1, v2) * Mathf.Rad2Deg);

        return angle;
    }

    
    private float CalculateShootAngle(float distance, ref float velocity, float gravity = g)
    {
        float theta = float.NaN;

        float sin_2T  = (gravity * distance) / (velocity * velocity);
        if (sin_2T >= 1f)
        {
            velocity *= 1.1f;
            return CalculateShootAngle(distance, ref velocity);
        }
        theta = 0.5f * Mathf.Asin(sin_2T) * Mathf.Rad2Deg;
        return theta;
    }
}
