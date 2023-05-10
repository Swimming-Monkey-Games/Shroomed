using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artillery : MonoBehaviour, Damagable
{
    public GameObject Player;
    public int maxHp;
    private int hp;
    public GameObject bullet;
    public GameObject marker;
    public bool knockbackable;
    public Animator animator;
    public GameObject sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Player = GameObject.Find("Player");
        
        
            StartCoroutine(Cooldown());
        
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            StartCoroutine(die());
        }
        
    }
    IEnumerator Cooldown()
    {
        if (Vector2.Distance(gameObject.transform.position, Player.transform.position) < 20)
        {
            yield return new WaitForSeconds(2.5f);
            animator.SetBool("Shoot", true);
            yield return new WaitForSeconds(.5f);
            Shoot();

            animator.SetBool("Shoot", false);
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(Cooldown());

        
    }
    IEnumerator FlyTime()
    {
        GameObject obj = Instantiate(marker, Player.transform.position, gameObject.transform.rotation,gameObject.transform);
        StartCoroutine(KillMarker(obj));
        Vector3 playerPos = Player.transform.position;
        yield return new WaitForSeconds(1.2f);
        Instantiate(bullet, playerPos, gameObject.transform.rotation);
    }
    IEnumerator KillMarker(GameObject marker)
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(marker);
    }
    void Shoot()
    {
        StartCoroutine(FlyTime());
    }
    public void Damage(int dmg)
    {
        StartCoroutine(red());
        hp -= dmg;
        Debug.Log("aaaa");
    }
    public IEnumerator red()
    {

        sprite.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.GetComponent<SpriteRenderer>().color = Color.white;
    }
    IEnumerator die()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
   
}
