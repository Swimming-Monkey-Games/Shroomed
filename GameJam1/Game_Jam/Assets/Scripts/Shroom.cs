using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shroom : MonoBehaviour,Interactable
{
    private GameObject Player;
    [SerializeField]
    public int shroomType;
    private Sprite normal;
    public Sprite h;
    // Start is called before the first frame update
    void Start()
    {
        normal = gameObject.GetComponent<SpriteRenderer>().sprite;
        Player = GameObject.Find("Player");  
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.transform.position,gameObject.transform.position)>1.51f)
        {
            highlight(false);
        }
    }
    public void Interact(GameObject interacter)
    {
        Player p =  interacter.GetComponent<Player>();
        Debug.Log("TEST");
        if(p.go(shroomType)) Destroy(gameObject);
    }
    public void highlight(bool high)
    {
        if (high)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = h;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = normal;
        }
    }
}
