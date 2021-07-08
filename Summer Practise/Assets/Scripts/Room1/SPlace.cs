using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlace : MonoBehaviour
{
    public Camera cam;
    public Transform player;
    public GameObject panel_numb;

    private float _min_distanse = 0.5f;
    private float _origin_dist;
    private bool _act;

    private void Start()
    {
        _origin_dist = cam.GetComponent<SProCamera>().length_player_react;
        _act = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < _min_distanse && panel_numb.GetComponent<SPlayNumb>().active && _act)
        {
            cam.GetComponent<SProCamera>().true_move = false;
            cam.GetComponent<SProCamera>().length_player_react = 50;
            cam.GetComponent<Camera>().cullingMask = cam.GetComponent<SProCamera>().no_player;
        } else if (_act)
        {
            cam.GetComponent<Camera>().cullingMask = cam.GetComponent<SProCamera>()._origin_mask;
            cam.GetComponent<SProCamera>().length_player_react = _origin_dist;
            cam.GetComponent<SProCamera>().true_move = true;
        }

        if (panel_numb.GetComponent<SPlayNumb>().finish && _act)
        {
            cam.GetComponent<Camera>().cullingMask = cam.GetComponent<SProCamera>()._origin_mask;
            cam.GetComponent<SProCamera>().length_player_react = _origin_dist;
            cam.GetComponent<SProCamera>().true_move = true;
            _act = false;
        }
    }
}
