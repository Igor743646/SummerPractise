using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SEnterCodeCanvas : MonoBehaviour
{
    [SerializeField]
    private Text _panel;
    public void Enter1(string text)
    {
        _panel.text += text;
    }
}
