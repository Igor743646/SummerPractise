using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGun : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject new_bull = Instantiate(bullet, transform.position + new Vector3(0.5f, 0.1f, 0.0f), transform.rotation);
            new_bull.GetComponent<Rigidbody>().velocity = -new_bull.transform.right * 30.0f;
        }

    }
}
