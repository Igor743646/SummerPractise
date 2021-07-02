using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SProCamera : MonoBehaviour
{
    public Transform target;
    public float speedX = 360.0f;
    public float speedY = 240.0f;
    public float limitY = 40.0f;

    public float min_distanse = 1.0f;
    public LayerMask obstacles;
    public LayerMask noPlayer;

    private float _max_distance;
    private Vector3 _local_posotion;
    private float _current_y_rotation;

    private Vector3 _position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _local_posotion = target.InverseTransformPoint(_position);
        _max_distance = Vector3.Distance(_position, target.position);
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _position = target.TransformPoint(_local_posotion);
        CameraRotation();
        _local_posotion = target.InverseTransformPoint(_position);
    }

    void CameraRotation()
    {
        float move_x = Input.GetAxis("Mouse X");
        float move_y = -Input.GetAxis("Mouse Y");

        if (move_y != 0)
        {
            float tmp = Mathf.Clamp(_current_y_rotation + move_y * speedY, -10.0f, limitY);
            if (tmp != _current_y_rotation)
            {
                float r = tmp - _current_y_rotation;
                transform.RotateAround(target.position, transform.right, r);
                _current_y_rotation = tmp;
            }
        }
        if (move_x != 0)
        {
            transform.RotateAround(target.position, transform.up, move_x * speedX);
        }
        transform.LookAt(target);
    }

}
