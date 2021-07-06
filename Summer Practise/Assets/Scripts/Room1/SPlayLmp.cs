using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayLmp : MonoBehaviour
{
    public Transform lmp;
    public Transform light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject first_lamp;
    public GameObject second_lamp;

    private SSelect _select;
    private Color _origin_color;
    private bool _end;
    // Start is called before the first frame update
    void Start()
    {
        _end = false;
        _select = GetComponent<SSelect>();
        _origin_color = GetComponent<Renderer>().material.color;

        if (first_lamp.GetComponent<Light>().enabled)
            first_lamp.GetComponent<Light>().enabled = false;

        if (second_lamp.GetComponent<Light>().enabled)
            second_lamp.GetComponent<Light>().enabled = false;

        if (light3.GetComponent<Light>().enabled)
            light3.GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (light2.GetComponent<Light>().enabled)
        {
            if (_select.true_select)
            {
                GetComponent<Renderer>().material.color = Color.grey;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<Renderer>().material.color = Color.blue;
                    if (first_lamp.GetComponent<Light>().enabled)
                        first_lamp.GetComponent<Light>().enabled = false;
                    else first_lamp.GetComponent<Light>().enabled = true;

                    if (second_lamp.GetComponent<Light>().enabled)
                        second_lamp.GetComponent<Light>().enabled = false;
                    else second_lamp.GetComponent<Light>().enabled = true;
                }

            }
            else
            {
                GetComponent<Renderer>().material.color = _origin_color;
            }
            
        }
    }
    void LateUpdate()
    {
        Check();
        if (light2.GetComponent<Light>().enabled) Check();
    }

    void Check()
    {
        bool ok = true;
        foreach (Transform l in lmp.GetComponentInChildren<Transform>())
        {
            if (!l.GetComponent<Light>().enabled)
                ok = false;
        }
        if (ok && !_end)
        {
            if (light2.GetComponent<Light>().enabled)
                light2.GetComponent<Light>().enabled = false;

            if (!light3.GetComponent<Light>().enabled)
                light3.GetComponent<Light>().enabled = true;

            light1.RotateAround(light1.position, light1.right, 175.0f);
            light1.GetComponent<Light>().intensity = light1.GetComponent<Light>().intensity / 1.4f;
            _end = true;
        }
        

    }

}
