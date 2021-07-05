using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SReadNote : MonoBehaviour
{
    [SerializeField] 
    private GameObject _note;
    private SSelect _select;
    private bool _is_active;

    private Material _note_material;

    void Start()
    {
        _select = GetComponent<SSelect>();
        _note.SetActive(false);
        _is_active = false;
        _note_material = GetComponent<Renderer>().material;
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
            }

        } else
        {
            _note_material.DisableKeyword("_EMISSION");
            Deactivate();
        }
    }

    void Activate()
    {
        _note.SetActive(true);
        _is_active = true;
    }

    void Deactivate()
    {
        _note.SetActive(false);
        _is_active = false;
    }
}
