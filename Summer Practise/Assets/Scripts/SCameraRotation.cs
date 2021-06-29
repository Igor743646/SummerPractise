using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCameraRotation : MonoBehaviour
{
    public float camera_rotation_speed = 0.05f;
    public Transform target_transform;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float axisX = Input.GetAxis("Mouse X");
        float axisY = Input.GetAxis("Mouse Y");


        target_transform.Rotate(0, axisX * camera_rotation_speed, 0);
    }
}
