﻿using System.Collections;
using UnityEngine;

public class myGizmo : MonoBehaviour
{
    public Color myColor = Color.yellow;
    public float Radius = 0.1f;

    void OnDrawGizmos()
    {
        Gizmos.color = myColor;
        Gizmos.DrawSphere(transform.position, Radius);
    }
}
