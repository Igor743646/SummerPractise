using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOpenDoor : MonoBehaviour
{
    public Transform door_transform;
    public Vector3 door_transform_open;
    public Transform player_transform;
    public float interaction_radius = 0.1f;

    // PANEL ILLUMINATION WHEN OPERATING
    private Material _panel_material;

    // INTERACTION LOGIC
    private Vector3 _base_door_position;
    private bool _is_door_open;
    private bool _is_player_near;
    private bool _is_want_to_open_or_close;

    void Start()
    {
        _panel_material = GetComponent<Renderer>().material;

        _base_door_position = door_transform.position;
        _is_door_open = false;
        _is_player_near = false;
        _is_want_to_open_or_close = false;
    }

    void Update()
    {
        Vector3 distance = transform.position - player_transform.position;
        if (distance.magnitude <= interaction_radius)
        {
            _is_player_near = true;
            _panel_material.EnableKeyword("_EMISSION");

            if (Input.GetKeyDown("e"))
            {
                _is_want_to_open_or_close = true;
            }

        } else
        {
            _is_player_near = false;
            _panel_material.DisableKeyword("_EMISSION");
        }

    }

    void FixedUpdate()
    {
        if (_is_player_near && _is_want_to_open_or_close)
        {
            if (!_is_door_open)
            {
                door_transform.position = door_transform_open;
            } else
            {
                door_transform.position = _base_door_position;
            }

            _is_door_open = !_is_door_open;
            _is_want_to_open_or_close = false;
        }
    }
}
