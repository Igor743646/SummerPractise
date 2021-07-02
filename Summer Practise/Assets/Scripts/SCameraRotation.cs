using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCameraRotation : MonoBehaviour
{

    public float camera_rotation_speed = 0.05f;

    private Transform _target_transform;

    private float _rotateY = 0.0f;
    private float _rotateX = 0.0f;

    private Vector3 ProjectionOnZY(Vector3 vector)
    {
        vector.x = 0.0f;
        return vector;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _target_transform = transform.parent;
    }

    void Update()
    {
        float axisX = Input.GetAxis("Mouse X");
        float axisY = Input.GetAxis("Mouse Y");


        //GORIZONTAL ROTATION

        _rotateX = Mathf.Clamp(axisX * camera_rotation_speed, -90.0f, 90.0f);

        transform.RotateAround(_target_transform.position, _target_transform.up, _rotateX);


        //VERTICAL ROTATION

        _rotateY = -Mathf.Clamp(axisY * camera_rotation_speed, -30.0f, 30.0f);


        float angle = Vector3.Angle(transform.up, _target_transform.up);

        if ((angle + _rotateY > 0.0f) && (angle + _rotateY < 90.0f))
            transform.RotateAround(_target_transform.position, transform.right, _rotateY);



    }
}
