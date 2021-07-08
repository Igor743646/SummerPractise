using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPanelKey : MonoBehaviour
{
    public GameObject light3;
    public GameObject key;
    public Transform key_cube;
    public GameObject gun;
    public GameObject cap;

    private GameObject new_key;
    private bool _get_key;
    private SSelect _select;
    private Color _origin_color;
    private bool _ok;
    private Color _origin_color_key;
    private float _min_dist = 2.0f;

    // Start is called before the first frame update
    void Start() {
        _get_key = false;
        _origin_color = GetComponent<Renderer>().material.color;
        _select = GetComponent<SSelect>();
        _ok = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (light3.GetComponent<Light>().enabled)
        {
            if (_select.true_select)
            {
            GetComponent<Renderer>().material.color = Color.green;

            if (Input.GetKeyDown(KeyCode.E)) GetKey();
            }
            else
            {
                GetComponent<Renderer>().material.color = _origin_color;
            }
        }

        if (_get_key && _ok)
        {
            if (Vector3.Distance(new_key.transform.position, cap.transform.position) < _min_dist)
            {
                new_key.GetComponent<Renderer>().material.color = Color.green;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PutOn();
                    _ok = false;
                }
            } else
            {
                new_key.GetComponent<Renderer>().material.color = _origin_color_key;
            }
        }

    }

    void GetKey()
    {
        if (!_get_key)
        {
            float pos_z = key_cube.GetComponents<Collider>().Length;
            new_key = Instantiate(key, key_cube.position + new Vector3(0.0f, 0.0f, -pos_z), key_cube.rotation);
            new_key.GetComponent<Rigidbody>().velocity = key_cube.right * 4.0f;
            _origin_color_key = new_key.GetComponent<Renderer>().material.color;
            _get_key = true;
        }
    }

    void PutOn()
    {
        if (new_key.activeSelf) new_key.SetActive(false);
        if (cap.activeSelf) cap.SetActive(false);
        if (!gun.activeSelf) gun.SetActive(true);
        
    }

}
