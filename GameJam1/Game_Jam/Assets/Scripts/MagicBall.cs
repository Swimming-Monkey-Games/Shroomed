using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    public float speed;
    public int dmg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        Destroy(gameObject, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {

            collision.GetComponent<Player>().damageHealth(dmg);
            Destroy(gameObject);
        }
    }
}
