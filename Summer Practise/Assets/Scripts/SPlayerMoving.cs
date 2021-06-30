using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayerMoving : MonoBehaviour
{

    public float player_speed = 0.04f;
    private Transform _player_transform;
    private Transform _camera_transform;

    void Start()
    {
        _player_transform = transform;
        _camera_transform = Camera.main.transform;
    }

    private Vector3 ProjectionOnXZ(Vector3 vector)
    {
        vector.y = 0f;
        return vector;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 step = ProjectionOnXZ(_camera_transform.forward.normalized);
            _player_transform.position += player_speed * step;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 step = -ProjectionOnXZ(_camera_transform.forward.normalized);
            _player_transform.position += player_speed * step;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 step = ProjectionOnXZ(_camera_transform.right.normalized);
            _player_transform.position += player_speed * step;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 step = -ProjectionOnXZ(_camera_transform.right.normalized);
            _player_transform.position += player_speed * step;
        }
    }
}
