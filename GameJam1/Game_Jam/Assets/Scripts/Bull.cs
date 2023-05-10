using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;
    private bool attack = true;
    private bool canMove = true;
    public Animator animator;
    private Rigidbody2D rb2d;
    private bool charging;
    public int dmg;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
    }
    void Update()
    {
        if (Vector2.Distance(gameObject.transform.position, target.position) < 13)
        {
            if (Vector2.Distance(gameObject.transform.position, target.position) < 11 && attack)
            {

                StartCoroutine(atck());
            }
            if (Vector2.Distance(transform.position, target.position) > minimumDistance)
            {
                if (canMove)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    animator.SetBool("Walk", true);
                }
            }
            else
            {
                if (canMove)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
                    animator.SetBool("Walk", true);
                }
            }
        }


    }
    IEnumerator atck()
    {
        animator.SetBool("Walk", false);
        attack = false;
        canMove = false;
        charging = true;
        animator.SetBool("Charge", true);
        yield return new WaitForSeconds(1.5f);
        Vector3 dir = target.transform.position - transform.position;
        dir = dir.normalized;
        rb2d.AddForce(dir * 70, ForceMode2D.Impulse);
        animator.SetBool("Charge", false);
        yield return new WaitForSeconds(.2f);
        charging = false;
        yield return new WaitForSeconds(.8f);  
        animator.SetBool("StopCharging", true);
        canMove = true;
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("StopCharging", false);
        yield return new WaitForSeconds(5f);
        attack = true;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==7)
        {
            if (charging)
            {
                Debug.Log(collision.GetComponent<Player>()+"   "+dmg);
                collision.GetComponent<Player>().damageHealth(dmg);
                Vector3 dir = target.transform.position - transform.position;
                dir = dir.normalized;
                collision.GetComponent<Rigidbody2D>().AddForce(dir*40, ForceMode2D.Impulse);
                Debug.Log("grr");
            }
        }
    }
}
