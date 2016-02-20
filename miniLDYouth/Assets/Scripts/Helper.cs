using System;
using UnityEngine;

public static class Helper
{
    public static Quaternion getDirectionToTarget(Vector3 target, Vector3 ownPosition)
    {
        Vector3 dir = target - ownPosition;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
