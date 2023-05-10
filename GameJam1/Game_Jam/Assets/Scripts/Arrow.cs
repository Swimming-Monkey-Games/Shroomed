using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
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
        transform.Translate(new Vector3(1,1,0) * speed * Time.deltaTime);
        Destroy(gameObject,3);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==10)
        {
            Debug.Log(transform.right);
            if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(((transform.right*0.5f)+(transform.up)*0.5f) * 37, ForceMode2D.Impulse);
            }
            collision.gameObject.GetComponent<Damagable>().Damage(dmg);
            if (collision.gameObject.GetComponent<Enemy>()!=null)
            {
                collision.gameObject.GetComponent<Enemy>().goRed(collision.gameObject);
            }
           
            Debug.Log(dmg);
            Destroy(gameObject);
        }
    }
   
}
