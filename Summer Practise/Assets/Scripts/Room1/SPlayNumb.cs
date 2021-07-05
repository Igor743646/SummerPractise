using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayNumb : MonoBehaviour
{
    public Transform panel;
    public Transform numbers;
    public GameObject lamp;

    private SSelect _select;
    private bool _active;
    private Color _origin_color;
    private bool _finish;

    private SNumber _1;
    private SNumber _2;
    private SNumber _3;
    private SNumber _4;
    private SNumber _5;
    private SNumber _6;
    private SNumber _7;
    private SNumber _8;
    // Start is called before the first frame update
    void Start()
    {
        _select = GetComponent<SSelect>();
        _1 = numbers.Find("1").GetComponent<SNumber>();
        _2 = numbers.Find("2").GetComponent<SNumber>();
        _3 = numbers.Find("3").GetComponent<SNumber>();
        _4 = numbers.Find("4").GetComponent<SNumber>();
        _5 = numbers.Find("5").GetComponent<SNumber>();
        _6 = numbers.Find("6").GetComponent<SNumber>();
        _7 = numbers.Find("7").GetComponent<SNumber>();
        _8 = numbers.Find("8").GetComponent<SNumber>();
        _origin_color = panel.GetComponent<Renderer>().material.color;
        _active = false;
        _finish = false;
        if (lamp.GetComponent<Light>().enabled)
            lamp.GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_select.true_select)
        {
            if (!_active) panel.GetComponent<Renderer>().material.color = Color.green;
            if (Input.GetKeyDown(KeyCode.E))
                _active = !_active;
        } else
        {
            panel.GetComponent<Renderer>().material.color = _origin_color;
        }

        if (_active)
            panel.GetComponent<Renderer>().material.color = Color.magenta;
        else if (!_select)
            panel.GetComponent<Renderer>().material.color = _origin_color;
    }

    private void LateUpdate()
    {
        if (_active)
        {
            Activation();
            Check();
        }
        else
        {
            Deactivation();
        }
    }

    void Activation()
    {
        _1.act = true; _2.act = true; _3.act = true;
        _4.act = true; _5.act = true; _6.act = true;
        _7.act = true; _8.act = true;
    }

    void Deactivation()
    {
        _1.act = false; _2.act = false; _3.act = false;
        _4.act = false; _5.act = false; _6.act = false;
        _7.act = false; _8.act = false;
    }

    void Check()
    {
        if (_1.transform.position == _1.true_position &&
            _2.transform.position == _2.true_position &&
            _3.transform.position == _3.true_position &&
            _4.transform.position == _4.true_position &&
            _5.transform.position == _5.true_position &&
            _6.transform.position == _6.true_position &&
            _7.transform.position == _7.true_position &&
            _8.transform.position == _8.true_position)
        {
            _1.ok = true; _2.ok = true; _3.ok = true;
            _4.ok = true; _5.ok = true; _6.ok = true;
            _7.ok = true; _8.ok = true;

            if (!_finish)
                lamp.GetComponent<Light>().enabled = true;
            _finish = true;
        }

    }


}
