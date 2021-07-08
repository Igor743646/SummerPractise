using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEnemy : MonoBehaviour
{
    public Transform start_point;
    public float enemy_speed = 0.3f;
    private Vector3 move_vect;
    // Start is called before the first frame update
    void Start()
    {
        move_vect = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += move_vect * enemy_speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            if (move_vect == transform.forward)
                move_vect = -transform.forward;
            else
                move_vect = transform.forward;
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = start_point.position;
        }
    }
}
