using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCodeConfirm : MonoBehaviour
{
    [SerializeField]
    private string _confirmed_text;
    [SerializeField]
    private GameObject _object_to_action;
    private SOpenDoor _action;
    private Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
        _action = _object_to_action.GetComponent<SOpenDoor>();
    }

    void Update()
    {
        if (_text.text == _confirmed_text)
        {
            _action.speed_open = 0.05f;
            _text.text = "";
        }
        else if (_text.text.Length >= 4)
        {
            _text.text = "";
        }
    }
}
