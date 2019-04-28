using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public float Distance(Transform target1, Transform target2)
    {
        float dist;
        dist = Mathf.Sqrt((target1.position.x - target2.position.x) * (target1.position.x - target2.position.x)
            + (target1.position.y - target2.position.y) * (target1.position.y - target2.position.y));

        return dist;
    }
}
