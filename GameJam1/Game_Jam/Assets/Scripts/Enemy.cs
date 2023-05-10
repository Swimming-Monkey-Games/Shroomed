using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Damagable
{
    public int maxHp;
    private int hp;
    public int gold;
    public int dmg;
    public int experience;
    public bool knockbackable;
    private GameObject Player;
    private bool attack = true;
    private Vector3 startScale;
    public bool ranged = false;
    // Start is called before the first frame update
    void Awake()
    {
        hp = maxHp;
        Player = GameObject.Find("Player");
        startScale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y>-23&& Player.transform.position.y<8.5&& Vector2.Distance(gameObject.transform.position, Player.transform.position) < 10)
        {
            Destroy(gameObject);
        }
        if (gameObject.transform.position.x>Player.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(-startScale.x,startScale.y,startScale.z);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(startScale.x, startScale.y, startScale.z);
        }
        if (hp <= 0)
        {

            
            StartCoroutine(die());
        }

        if (Vector2.Distance(Player.transform.position, transform.position) < 1.5 && attack&&!ranged)
        {

            StartCoroutine(bite());
            attack = false;
        }

    }
    public IEnumerator red(GameObject obj)
    {

        obj.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        obj.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void goRed(GameObject obj)
    {
        StartCoroutine(red(obj));
    }
    public void Damage(int dmg)
    {
        hp -= dmg;
       
        Debug.Log("aaaa");
    }
    
     IEnumerator bite()
    {
        yield return new WaitForSeconds(0.7f);
        if (Vector2.Distance(Player.transform.position, transform.position) < 1)
        {
            Player.GetComponent<Player>().damageHealth(dmg);
        }
        attack = true;
    }
    IEnumerator die()
    {
        yield return new WaitForSeconds(0.25f);
        Player.GetComponent<Player>().addGold(gold);
        Player.GetComponent<Player>().addExperience(experience);
        Destroy(gameObject);
    }
}
