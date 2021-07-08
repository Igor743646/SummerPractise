using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOpenDoor : MonoBehaviour
{
    public float speed_open = 1.0f;
    public bool is_open;
    public Transform panel;
    public Transform door;

    //private BoxCollider _box_door;
    private Quaternion _close_rotation;
    private Quaternion _open_rotation;

    private SSelect _select;

    private Color _panal_color;

    //Start is called before the first frame update
    void Start()
    {
        _select = GetComponent<SSelect>();
        _panal_color = panel.GetComponent<Renderer>().material.color;

        _close_rotation = door.rotation;
        _open_rotation = Quaternion.LookRotation(-door.transform.right);
        is_open = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (_select.true_select)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                is_open = !is_open;
            }
            else
            {
                if (is_open) panel.GetComponent<Renderer>().material.color = Color.green;
                if (!is_open) panel.GetComponent<Renderer>().material.color = Color.magenta;
            }

        }
        else
        {
            panel.GetComponent<Renderer>().material.color = _panal_color;
        }

    }

    private void LateUpdate()
    {
        Rotate();
    }

    void Rotate()
    {
        if (door.rotation != _open_rotation && is_open)
            door.rotation = Quaternion.RotateTowards(door.rotation, _open_rotation, speed_open);

        if (door.rotation != _close_rotation && !is_open)
            door.rotation = Quaternion.RotateTowards(door.rotation, _close_rotation, speed_open);
    }


}