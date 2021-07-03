
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCapRotation : MonoBehaviour
{
    public float cap_speed = 2.0f;

    private Transform _player_transform;
    // Start is called before the first frame update
    void Start()
    {
        _player_transform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(_player_transform.position, transform.up, cap_speed);
    }
}