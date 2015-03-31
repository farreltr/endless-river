﻿using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour
{

    public Transform target;
    private Vector3 velocity = Vector3.zero;

    public float smoothTime = 0.15f;

    public bool verticalMaxEnabled = false;
    public float verticalMax = 0f;
    public bool verticalMinEnabled = false;
    public float verticalMin = 0f;

    public bool horizontalMaxEnabled = false;
    public float horizontalMax = 0f;
    public bool horizontalMinEnabled = false;
    public float horizontalMin = 0f;

    public bool heightMaxEnabled = false;
    public float heightMax = 0f;
    public bool heightMinEnabled = false;
    public float heightMin = 0f;

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 targetPosition = target.position;

            if (verticalMinEnabled && verticalMaxEnabled)
            {
                targetPosition.z = Mathf.Clamp(target.position.z, verticalMin, verticalMax);
            }
            else if (verticalMinEnabled)
            {
                targetPosition.z = Mathf.Clamp(target.position.z, verticalMin, target.position.z);
            }
            else if (verticalMaxEnabled)
            {
                targetPosition.z = Mathf.Clamp(target.position.z, target.position.z, verticalMax);
            }

            if (horizontalMinEnabled && horizontalMaxEnabled)
            {
                targetPosition.x = Mathf.Clamp(target.position.x, horizontalMin, horizontalMax);
            }
            else if (horizontalMinEnabled)
            {
                targetPosition.x = Mathf.Clamp(target.position.x, horizontalMin, target.position.x);
            }
            else if (horizontalMaxEnabled)
            {
                targetPosition.x = Mathf.Clamp(target.position.x, target.position.x, horizontalMax);
            }

            
            if (heightMinEnabled && heightMaxEnabled)
            {
                targetPosition.y = Mathf.Clamp(target.position.y, target.position.y + heightMin, heightMax);
            }
            else if (heightMinEnabled)
            {
                targetPosition.z = Mathf.Clamp(target.position.z, target.position.z, target.position.z + heightMin);
            }
            else if (heightMaxEnabled)
            {
                targetPosition.y = Mathf.Clamp(target.position.y, target.position.y, heightMax);
            }

           

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}