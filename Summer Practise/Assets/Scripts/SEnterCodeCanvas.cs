using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SEnterCodeCanvas : MonoBehaviour
{
    [SerializeField]
    private Text _panel;
    public bool _entering;

    public void Start()
    {
        _entering = true;
    }
    public void Enter1(string text)
    {
        if (_entering)
        {
            _panel.text += text;
        }
    }
}
