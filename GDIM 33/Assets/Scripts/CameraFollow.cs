using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -10);
    [SerializeField] private float pixelsPerUnit = 512f;

    private void LateUpdate()
    {
        float x = Mathf.Round((target.position.x + offset.x) * pixelsPerUnit) / pixelsPerUnit;
        float y = Mathf.Round((target.position.y + offset.y) * pixelsPerUnit) / pixelsPerUnit;

        transform.position = new Vector3(x, y, offset.z);
    }
}