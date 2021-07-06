using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNumber : MonoBehaviour
{
    public Transform numbers;
    public LayerMask active;
    public Vector3 true_position;
    public bool act;
    public bool ok;

    private SSelect _select;
    private BoxCollider _box;
    private Color _origin_color;
    private float _min_distance;
    private Vector3 _move_x;
    private Vector3 _move_y;

    private Vector3 _1_position,  _2_position, _3_position;
    private Vector3 _4_position,  _5_position,  _6_position;
    private Vector3 _7_position,  _8_position;

    // Start is called before the first frame update
    void Start()
    {
        act = false; ok = false;
        _select = GetComponent<SSelect>();
        _box = GetComponent<BoxCollider>();

        true_position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        _1_position = numbers.Find("1").transform.position; _2_position = numbers.Find("2").transform.position;
        _3_position = numbers.Find("3").transform.position; _4_position = numbers.Find("4").transform.position;
        _5_position = numbers.Find("5").transform.position; _6_position = numbers.Find("6").transform.position;
        _7_position = numbers.Find("7").transform.position; _8_position = numbers.Find("8").transform.position;

        _origin_color = Color.HSVToRGB(22.0f, 77.0f, 32.0f);
        GetComponent<Renderer>().material.color = Color.white;
        _move_x = _1_position - _2_position;
        _move_y = _4_position - _7_position;
        _min_distance = transform.right.normalized.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ok && _select.true_select && act)
        {
            GetComponent<Renderer>().material.color = Color.green;
            Moving();

        }

        if (!ok && !_select.true_select && act)
        {
            GetComponent<Renderer>().material.color = _origin_color;
        }

        if (!act)
        {
            GetComponent<Renderer>().material.color = Color.white;
            
        }
        if (ok)
        {
            GetComponent<Renderer>().material.color = Color.magenta;
        }
    }

    void LateUpdate()
    {
        if (!act)
            StartPosition();

    }

    void Moving()
    {
        Ray ray_right = new Ray(transform.position, transform.right.normalized);
        Ray ray_left = new Ray(transform.position, -transform.right.normalized);
        Ray ray_up = new Ray(transform.position, transform.up.normalized);
        Ray ray_down = new Ray(transform.position, -transform.up.normalized);

        Debug.DrawRay(ray_right.origin, ray_right.direction, Color.red);
        Debug.DrawRay(ray_left.origin, ray_left.direction, Color.blue);
        Debug.DrawRay(ray_up.origin, ray_up.direction, Color.green);
        Debug.DrawRay(ray_down.origin, ray_down.direction, Color.yellow);

        if (Input.GetMouseButtonDown(0))
        {
            bool true_hit_right = Physics.Raycast(ray_right, _min_distance, active);
            bool true_hit_left = Physics.Raycast(ray_left, _min_distance, active);
            bool true_hit_up = Physics.Raycast(ray_up, _min_distance, active);
            bool true_hit_down = Physics.Raycast(ray_down, _min_distance, active);

            if (!true_hit_right) transform.position += _move_x;
            else if (!true_hit_left) transform.position -= _move_x;
            else if (!true_hit_up) transform.position += _move_y;
            else if (!true_hit_down) transform.position -= _move_y;
        }
    }
    void StartPosition()
    {
        numbers.Find("1").transform.position = _1_position;
        numbers.Find("2").transform.position = _2_position + _right;
        numbers.Find("3").transform.position = _3_position + _down;
        numbers.Find("4").transform.position = _4_position;
        numbers.Find("5").transform.position = _5_position + _up;
        numbers.Find("6").transform.position = _6_position + _down;
        numbers.Find("7").transform.position = _7_position;
        numbers.Find("8").transform.position = _8_position + _up;
    }
    private void Check()
    {
        if (transform.position == true_position)
        {
            GetComponent<Renderer>().material.color = Color.magenta;
        }
    }

    private Vector3 _right
    {
        get { return -_move_x; }
    }

    private Vector3 _left
    {
        get { return _move_x; }
    }

    private Vector3 _down
    {
        get { return -_move_y; }
    }

    private Vector3 _up
    {
        get { return _move_y; }
    }
}
