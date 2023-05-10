using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{


    //public GameObject hitEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
       // Destroy(effect, 5f);
        Destroy(gameObject);
    }

}
