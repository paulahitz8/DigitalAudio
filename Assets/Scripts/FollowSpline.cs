using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSpline : MonoBehaviour
{
    public Spline spline;
    public Transform followTransform;

    private Transform thisTransform;

    private void Start()
    {
        thisTransform = transform;
    }

    private void Update()
    {
        thisTransform.position = spline.WhereOnSpline(followTransform.position);
    }
}
