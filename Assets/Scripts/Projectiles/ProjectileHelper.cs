using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileHelper : MonoBehaviour
{
    const float g = 9.8f;
    const float PI = Mathf.PI;

    /// <summary>
    /// Elevation Angle Required (Steep Trajectory)
    /// https://en.wikipedia.org/wiki/Projectile_motion
    /// </summary>
    /// <param name="distance"></param>
    /// <param name="velocity">shooting initial velocity</param>
    /// <param name="gravity"> The bigger, the faster trajectory</param>
    /// <returns></returns>
    public static float CalculateElevationAngle(float distance, ref float velocity)
    {
        float theta = float.NaN;

        float sin_2T = (-Physics.gravity.y * distance) / (velocity * velocity);
        if (sin_2T >= 1f)
        {
            velocity *= 1.1f;
            return CalculateElevationAngle(distance, ref velocity);
        }
        theta = 0.5f * Mathf.Asin(sin_2T) * Mathf.Rad2Deg;
        return theta;
    }

    public static float CalculateYawAngle(Vector3 v1, Vector3 v2)
    {
        return Vector3.Angle(v1, v2);
    }

    /// <summary>
    /// 포물선을 그리는 물체 발사 방향 계산 함수 
    /// </summary>
    /// <param name="currentTransform">발사 위치 기준 </param>
    /// <param name="targetPos">도착 지점 </param>
    /// <param name="v0">초기 발사 속도</param>
    /// <returns></returns>
    public static Vector3 ShootTowards(Transform currentTransform, Vector3 targetPos, float v0)
    {
        float distance = (targetPos - currentTransform.position).magnitude;
        Vector3 direction = (targetPos - currentTransform.position).normalized;
        float shootAngle = CalculateElevationAngle(distance, ref v0);

        Vector3 elevation = Quaternion.AngleAxis(shootAngle, currentTransform.right) * Vector3.up;
        float yaw = CalculateYawAngle(currentTransform.forward, direction);
        Vector3 velocity = Quaternion.AngleAxis(yaw, Vector3.up) * elevation * v0;

        return velocity;
    }
}
