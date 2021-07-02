using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STargetForCamera : MonoBehaviour
{
    public Transform player;

    private Vector3 _local_posotion;
    // Start is called before the first frame update
    void Start()
    {
        _local_posotion = player.InverseTransformPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.TransformPoint(_local_posotion);
        _local_posotion = player.InverseTransformPoint(transform.position);
    }
}
