using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayerMoving : MonoBehaviour
{

    public float player_speed = 0.04f;
    private Rigidbody _player_rigidbody;
    private Transform _camera_transform;

    void Start()
    {
        _player_rigidbody = GetComponent<Rigidbody>();
        _camera_transform = Camera.main.transform;
    }

    private Vector3 ProjectionOnXZ(Vector3 vector)
    {
        vector.y = 0f;
        return vector;
    }

    private Vector3 DirectionVector() {
        Vector3 dirvec = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W)) dirvec += _camera_transform.forward.normalized;
        if (Input.GetKey(KeyCode.S)) dirvec += -_camera_transform.forward.normalized;
        if (Input.GetKey(KeyCode.D)) dirvec += _camera_transform.right.normalized;
        if (Input.GetKey(KeyCode.A)) dirvec += -_camera_transform.right.normalized;

        return dirvec;
    }

    void FixedUpdate()
    {
        _player_rigidbody.velocity = ProjectionOnXZ(DirectionVector()) * player_speed;
    }
}