using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBullet : MonoBehaviour
{

    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "GunTarget")
        {
            Destroy(target.gameObject);
        }
    }
}
