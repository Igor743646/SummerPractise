using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPanelKey : MonoBehaviour
{
    public GameObject light3;
    public GameObject key;
    public Transform key_cube;

    private bool _get_key;
    private SSelect _select;
    private Color _origin_color;

    // Start is called before the first frame update
    void Start() { 
        _get_key = false;
        _origin_color = GetComponent<Renderer>().material.color;
        _select = GetComponent<SSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (light3.GetComponent<Light>().enabled)
        {
            if (_select.true_select)
            {
                GetComponent<Renderer>().material.color = Color.green;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<Renderer>().material.color = Color.magenta;
                    GetKey();
                }
            }
            else
            {
                GetComponent<Renderer>().material.color = _origin_color;
            }
        }
    }

    void GetKey()
    {
        if (!_get_key)
        {
            GameObject new_key = Instantiate(key, key_cube.position, key_cube.rotation);
            new_key.GetComponent<Rigidbody>().velocity = key_cube.right * 2.0f;
            _get_key = true;
        }
    }

}
