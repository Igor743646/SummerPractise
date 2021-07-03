using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SReadNote : MonoBehaviour
{

    private SSelect _select;
    // Start is called before the first frame update
    void Start()
    {
        _select = GetComponent<SSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_select.true_select)
        {
            Debug.Log("Active");
            Active();
        } else
        {
            Debug.Log("Disactive");
        }
    }

    void Active ()
    {

    }
}
