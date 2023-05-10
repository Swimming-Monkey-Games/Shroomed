using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedFollow : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;
    private bool attack=true;
    public Animator animator;
    public GameObject ball;
    public GameObject shootPos;


    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }
    void Update()
    {
        if (Vector2.Distance(gameObject.transform.position, target.position) < 13)
        {
            if (Vector2.Distance(gameObject.transform.position, target.position) < 11&&attack)
            {
                animator.SetBool("Shoot",true);
                StartCoroutine(atck()) ;
            }
            if (Vector2.Distance(transform.position, target.position) > minimumDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                animator.SetBool("Walk", true);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
                animator.SetBool("Walk", true);
            }
        }


    }
    IEnumerator atck()
    {
        attack = false;
        

        
        yield return new WaitForSeconds(0.5f);
        shootPos.transform.right = new Vector3(target.position.x, target.position.y, 0) - transform.position;
        Instantiate(ball, shootPos.transform.position, shootPos.transform.rotation);
        animator.SetBool("Shoot", false);
        yield return new WaitForSeconds(4f);
        attack = true;
    }

}
