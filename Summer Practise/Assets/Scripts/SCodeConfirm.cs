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
    [SerializeField]
    private SEnterCodeCanvas _sEnterCodeCanvas_entering;
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
            _action.speed_open = 1.5f;
            _sEnterCodeCanvas_entering._entering = false;
            _text.text = _confirmed_text;
            _text.color = Color.green;
        }
        else if (_text.text.Length >= 4)
        {
            _text.text = "";
        }
    }
}
