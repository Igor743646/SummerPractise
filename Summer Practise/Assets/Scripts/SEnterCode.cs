using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEnterCode : MonoBehaviour
{
    [SerializeField]
    private GameObject _note;
    private Camera _camera;
    private SSelect _select;
    private bool _is_active;
    private float[] _speedXandY;

    private Material _note_material;

    void Start()
    {
        _select = GetComponent<SSelect>();
        _note.SetActive(false);
        _is_active = false;
        _note_material = GetComponent<Renderer>().material;
        _camera = Camera.main;
        _speedXandY = new float[2] { _camera.GetComponent<SProCamera>().speedX, _camera.GetComponent<SProCamera>().speedY };
    }

    void Update()
    {
        if (_select.true_select)
        {
            _note_material.EnableKeyword("_EMISSION");

            if (Input.GetKeyDown(KeyCode.E) && !_is_active)
            {
                Activate();
            }

            if (Input.GetKeyDown(KeyCode.Q) && _is_active)
            {
                Deactivate();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

        }
        else
        {
            if (_is_active)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            _note_material.DisableKeyword("_EMISSION");
            Deactivate();
        }
    }

    void Activate()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        _camera.GetComponent<SProCamera>().speedX = 0f;
        _camera.GetComponent<SProCamera>().speedY = 0f;

        _note.SetActive(true);
        _is_active = true;
    }

    void Deactivate()
    {
        _camera.GetComponent<SProCamera>().speedX = _speedXandY[0];
        _camera.GetComponent<SProCamera>().speedY = _speedXandY[1];

        _note.SetActive(false);
        _is_active = false;
    }
}
