using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSelect : MonoBehaviour
{
    public bool true_select;

    public void Start()
    {
        true_select = false;
    }

    public void Select() {
        true_select = true;
    }

    public void Deselect()
    {
        true_select = false;
    }
}
