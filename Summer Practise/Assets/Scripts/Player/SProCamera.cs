using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SProCamera : MonoBehaviour
{
    public Transform target;
    public float speedX = 300.0f;
    public float speedY = 400.0f;
    public float limitY = 90.0f;
    public float length_camera_react = 100.0f;
    public float length_player_react = 10.0f;
    public float min_obst_dist = 1.8f;
    public bool true_move;

    public LayerMask active;
    public LayerMask obstacles;
    public LayerMask no_player;

    private float _min_distance = 2.0f;
    private float _max_distance;
    private Vector3 _local_posotion;
    private float _current_y_rotation;
    public LayerMask _origin_mask;

    private GameObject _prev_select_obj;

    private Vector3 _position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    void Start()
    {
        true_move = true;
        _prev_select_obj = null;
        _local_posotion = target.InverseTransformPoint(_position);
        _max_distance = Vector3.Distance(_position, target.position);
        _origin_mask = GetComponent<Camera>().cullingMask;
    }

    private void Update()
    {
        CameraReact();
    }

    private void LateUpdate()
    {
        _position = target.TransformPoint(_local_posotion);
        CameraRot();
        if (true_move)
        {
            CameraObst();
            CameraMinObstDist();
        } 
        _local_posotion = target.InverseTransformPoint(_position);
    }

    void CameraRot()
    {
        float move_x = Input.GetAxis("Mouse X");
        float move_y = -Input.GetAxis("Mouse Y");

        if (move_y != 0)
        {
            float tmp = Mathf.Clamp(_current_y_rotation + move_y * speedY * Time.deltaTime, -limitY, limitY);
            if (tmp != _current_y_rotation)
            {
                float r = tmp - _current_y_rotation;
                transform.RotateAround(target.position, transform.right, r);
                _current_y_rotation = tmp;
            }
        }

        if (move_x != 0)
        {
            transform.RotateAround(target.position, transform.up, move_x * speedX * Time.deltaTime);
        }

        transform.LookAt(target);
    }

    void CameraObst()
    {
        float distance = Vector3.Distance(_position, target.position);
        RaycastHit hit;

        if (Physics.Raycast(target.position, transform.position - target.position, out hit, _max_distance - _min_distance, obstacles))
        {
            _position = hit.point;
        } else if (distance < _max_distance && !Physics.Raycast(_position, -transform.forward, 0.1f, obstacles))
        {
            _position -= transform.forward * 0.05f;
        }
    }

    void CameraMinObstDist()
    {
        if (Vector3.Distance(_position, target.position) < min_obst_dist)
        {
            GetComponent<Camera>().cullingMask = no_player;
        } else
        {
            GetComponent<Camera>().cullingMask = _origin_mask;
        }
    }

    void CameraReact()
    {
        Ray ray_forward = new Ray(transform.position, transform.forward.normalized);
        RaycastHit hit;

        if (Physics.Raycast(ray_forward, out hit, length_camera_react, active) && (XZ(target.position) - XZ(hit.point)).magnitude < length_player_react)
        {

            GameObject obj = hit.collider.gameObject;

            if (_prev_select_obj && _prev_select_obj != obj)
            {
                if (_prev_select_obj.GetComponent<SSelect>() && _prev_select_obj.GetComponent<SSelect>().true_select)
                {
                    _prev_select_obj.GetComponent<SSelect>().Deselect();
                    _prev_select_obj = null;
                }
            }

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