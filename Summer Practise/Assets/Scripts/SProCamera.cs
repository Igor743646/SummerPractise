using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SProCamera : MonoBehaviour
{
    public Transform target;
    public float speedX = 15.0f;
    public float speedY = 15.0f;
    public float limitY = 10.0f;
    public float length_camera_react = 100.0f;
    public float length_player_react = 1.0f;

    public LayerMask active;
    public LayerMask obstacles;
    public LayerMask roof;
    public LayerMask ground;

    private float _min_distance = 1.0f;
    private float _max_distance;
    private Vector3 _local_posotion;
    private float _current_y_rotation;
    private GameObject _prev_select_obj;

    private Vector3 _position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _prev_select_obj = null;


        _local_posotion = target.InverseTransformPoint(_position);
        _max_distance = Vector3.Distance(_position, target.position);

    }

    private void Update()
    {
        CameraReact();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _position = target.TransformPoint(_local_posotion);
        CameraRotation();
        _local_posotion = target.InverseTransformPoint(_position);
    }

    void CameraRotation()
    {
        float move_x = Input.GetAxis("Mouse X");
        float move_y = -Input.GetAxis("Mouse Y");


        RaycastHit hit;
        Ray ray_right = new Ray(transform.position, transform.right.normalized);
        Ray ray_left = new Ray(transform.position, -transform.right.normalized);
        Ray ray_up = new Ray(transform.position, transform.up.normalized);
        Ray ray_down = new Ray(transform.position, -transform.up.normalized);

        bool true_hit_right = Physics.Raycast(ray_right, _min_distance, obstacles);
        bool true_hit_left = Physics.Raycast(ray_left, _min_distance, obstacles);
        bool true_hit_up = Physics.Raycast(ray_up, _min_distance, roof);
        bool true_hit_down = Physics.Raycast(ray_down, _min_distance * 1.5f, ground);

        float distance = Vector3.Distance(_position, target.position);


        if (Physics.Raycast(target.position, transform.position - target.position, out hit, _max_distance - _min_distance, obstacles))
        {
            _position = hit.point;

            if (hit.distance < _min_distance)
            {
                true_hit_right = true;
                true_hit_left = true;
            }

        }
        else if (distance < _max_distance && !Physics.Raycast(_position, -transform.forward, 0.1f, obstacles))
        {
            _position -= transform.forward * 0.05f;
        }

        if (move_y != 0)
        {
            if ((move_y < 0 && !true_hit_down) || (move_y > 0 && !true_hit_up))
            {
                float tmp = Mathf.Clamp(_current_y_rotation + move_y * speedY, -10.0f, limitY);
                if (tmp != _current_y_rotation)
                {
                    float r = tmp - _current_y_rotation;
                    transform.RotateAround(target.position, transform.right, r);
                    _current_y_rotation = tmp;
                }
            }
        }
        if (move_x != 0)
        {
            if ((move_x < 0 && !true_hit_right) || (move_x > 0 && !true_hit_left))
            {
                transform.RotateAround(target.position, transform.up, move_x * speedX);
            }

        }
        transform.LookAt(target);

    }


    void CameraReact()
    {
        Ray ray_forward = new Ray(transform.position, transform.forward.normalized);
        RaycastHit hit;

        if (Physics.Raycast(ray_forward, out hit, length_camera_react, active) && (XZ(target.position) - XZ(hit.point)).magnitude < length_player_react)
        {

            GameObject obj = hit.collider.gameObject;

            if (obj.GetComponent<SSelect>())
            {
                _prev_select_obj = obj;
                obj.GetComponent<SSelect>().Select();
            }
        }
        else if (_prev_select_obj && _prev_select_obj.GetComponent<SSelect>() && _prev_select_obj.GetComponent<SSelect>().true_select)
        {
            _prev_select_obj.GetComponent<SSelect>().Deselect();
            _prev_select_obj = null;
        }

    }

    Vector3 XZ(Vector3 vector)
    {
        vector.y = 0;
        return vector;
    }
}