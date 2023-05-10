using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform attackOrigin;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        } 
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, attackOrigin.position, attackOrigin.rotation);
        Destroy(bullet, 5f);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(attackOrigin.up * bulletForce, ForceMode2D.Impulse);
    }
}
