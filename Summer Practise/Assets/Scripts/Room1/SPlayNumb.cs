using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayNumb : MonoBehaviour
{
    public Transform panel;
    public Transform numbers;
    public GameObject lamp;
    public bool active;
    public bool finish;

    private SSelect _select;
    private Color _origin_color;

    private SNumber _1, _2, _3;
    private SNumber _4, _5, _6;
    private SNumber _7, _8;

    // Start is called before the first frame update
    void Start()
    {
        _select = GetComponent<SSelect>();
        _1 = Pos("1"); _2 = Pos("2"); _3 = Pos("3");
        _4 = Pos("4"); _5 = Pos("5"); _6 = Pos("6");
        _7 = Pos("7"); _8 = Pos("8");

        _origin_color = panel.GetComponent<Renderer>().material.color;
        active = false;
        finish = false;
        if (lamp.GetComponent<Light>().enabled)
            lamp.GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_select.true_select)
        {
            if (!active) panel.GetComponent<Renderer>().material.color = Color.green;
            if (Input.GetKeyDown(KeyCode.E))
                active = !active;
        } else
        {
            panel.GetComponent<Renderer>().material.color = _origin_color;
        }

        if (active)
            panel.GetComponent<Renderer>().material.color = Color.magenta;
        else if (!_select)
            panel.GetComponent<Renderer>().material.color = _origin_color;
        
    }

    private void LateUpdate()
    {
        if (active)
        {
            Activation();
            Check();
        }
        else
        {
            Deactivation();
        }
    }

    private void Activation()
    {
        _1.act = true; _2.act = true; _3.act = true;
        _4.act = true; _5.act = true; _6.act = true;
        _7.act = true; _8.act = true;
    }

    private void Deactivation()
    {
        _1.act = false; _2.act = false; _3.act = false;
        _4.act = false; _5.act = false; _6.act = false;
        _7.act = false; _8.act = false;
    }

   private void Check()
    {
        if (InTruePosition(_1) && InTruePosition(_2) &&
            InTruePosition(_3) && InTruePosition(_4) &&
            InTruePosition(_5) && InTruePosition(_6) &&
            InTruePosition(_7) && InTruePosition(_8))
        {
            _1.ok = true; _2.ok = true; _3.ok = true;
            _4.ok = true; _5.ok = true; _6.ok = true;
            _7.ok = true; _8.ok = true;

            if (!finish)
                lamp.GetComponent<Light>().enabled = true;
            finish = true;
        }

    }

    private SNumber Pos(string num)
    {
        return numbers.Find(num).GetComponent<SNumber>();
    }

    private bool InTruePosition(SNumber num)
    {
        return num.transform.position == num.true_position;
    }



}
