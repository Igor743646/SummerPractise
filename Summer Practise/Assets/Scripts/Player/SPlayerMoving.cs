using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayerMoving : MonoBehaviour
{
    public Transform target_rotation;

    public float player_speed = 0.7f;
    public float jump_size = 0.5f;
    public float max_jump_height = 2.0f;
    public float rotation_speed = 0.1f;

    private Rigidbody _player_rigidbody;

    void Start()
    {
        _player_rigidbody = GetComponent<Rigidbody>();

    }

    private Vector3 ProjectionOnXZ(Vector3 vector)
    {
        vector.y = 0f;
        return vector.normalized;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 move_vector = new Vector3(vertical, 0.0f, -horizontal).normalized;

        if (move_vector.magnitude > 0.1f)
        {
            _player_rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(ProjectionOnXZ(target_rotation.right)), rotation_speed));
        }
        _player_rigidbody.AddForce(((transform.right * -vertical) + (transform.forward * (horizontal))) * player_speed, ForceMode.VelocityChange);

        if (Input.GetKey(KeyCode.Space) && _player_rigidbody.position.y < max_jump_height)
        {
            _player_rigidbody.AddForce(Vector3.up * jump_size, ForceMode.VelocityChange);
        }
    }
}