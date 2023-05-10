using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    public int maxHp;
    [SerializeField]
    private int hp;
    public float startSpeed;
    public float speed;
    public float dashSpeed;
    public LayerMask interactable;
    public Rigidbody2D rb;
    public Inv inv;
    private bool dashing;
    Vector2 movement;
    bool canWalk;
    public GameObject arm;
    public GameObject trail;
    private bool canDash=true;
    public GameObject knifeGraphic;
    public Animator animator;
    public GameObject graphics;

    public int gold;
    public int experience;
    public Image[] hearts;
    public Sprite[] heartSprites;
    public TMP_Text goldText;
    public Canvas UserInterface;
    public Image prefabImg;
    public Vector2 startPos;
    public GameObject heartHolder;
    private bool dead;
    private void Start()
    {
        startPos = gameObject.transform.position;
        speed = startSpeed;
        hp = maxHp;
        gold = 0;
        experience = 0;
        updateHearts();
        goldText.text = gold.ToString();
    }


    public void changeHealth(int amount)
    {
        hp += amount;
        if (hp > maxHp) hp = maxHp;
        else if (hp <= 0 && !dead)
        {
            StartCoroutine(die());
        }
        updateHearts();
    }
    public void damageHealth(int dmg)
    {
        hp -= dmg;
        
        if (hp <= 0&&!dead)
        {
            StartCoroutine(die());
        }
        else updateHearts();
    }

    
    private void updateHearts()
    {
        
        int totalHearts = maxHp / 2;
        if (maxHp % 2 == 1) totalHearts++;

        Debug.Log(totalHearts);
        for (int i = 0; i < hearts.Length; i++)
        {
            Destroy(hearts[i].gameObject);
        }
        hearts = new Image[totalHearts];
        for(int i=0; i<totalHearts; i++)
        {


            var heart = Instantiate(prefabImg, heartHolder.transform.position+new Vector3(i*110f, 0f, 0f), Quaternion.identity, heartHolder.transform);
            hearts[i] = heart;
        }
        int fullhearts = hp / 2;
        for (int i = 0; i < fullhearts; i++)
        {

            hearts[i].sprite = heartSprites[0];
        }
        for (int i = fullhearts; i < totalHearts; i++)
        {
            hearts[i].sprite = heartSprites[2];
        }
        //error tu
        Debug.Log(fullhearts+ "full hearts "+hearts.Length+"total hearts");
        if (hp % 2 == 1) hearts[fullhearts].sprite = heartSprites[1];

    }
    
    public void addGold(int amount)
    {
        gold += amount;
        goldText.text = gold.ToString();
    }
    public void addExperience(int amount)
    {
        experience += amount;
    }
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = mousePos - gameObject.transform.position;
        mouseDir.z = 0.0f;
        mouseDir = mouseDir.normalized;
        if (movement.x>0)
        {
            graphics.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(movement.x<0)
        {
            graphics.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (movement.x!=0||movement.y!=0)
        {
            animator.SetFloat("Speed",1);
        }
        else
        {
         
            animator.SetFloat("Speed", -1);
        }
        if (arm.transform.rotation.eulerAngles.z>90&& arm.transform.rotation.eulerAngles.z < 270)
        {
            knifeGraphic.transform.localScale =new Vector3(1f,-1f,1f);
        }
        else
        {
            knifeGraphic.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (Input.GetMouseButtonDown(0))
        {
            /*Do zrobienia
             * Tworzy pocisk, kt�ry leci tam gdzie myszka
             */
        }
        if (Input.GetKeyDown(KeyCode.C)&&canDash)
        {
            if ( movement.x != 0 || movement.y != 0)
            {
                rb.AddForce(movement * dashSpeed, ForceMode2D.Impulse);
                dashing = true;
                trail.SetActive(true);
                StartCoroutine(DashCooldown());
            }
            
        }
        if (movement.x != 0 && movement.y != 0)
        {
            speed = startSpeed * 0.7f;
        }
        else
        {
            speed = startSpeed;
        }
        if (!dashing)
        {

           // rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(movement * speed,ForceMode2D.Force);

            // rb.MovePosition(rb.position + movement * speed);
        }
        arm.transform.right = new Vector3(mousePos.x, mousePos.y, 0) - transform.position;
        knifeGraphic.transform.right = new Vector3(mousePos.x, mousePos.y, 0) - transform.position;
       
        Collider2D col = Physics2D.OverlapCircle(gameObject.transform.position, 1.5f, interactable);
        if (col != null)
        {
            GameObject colGameObject = col.gameObject;
            if (Input.GetKeyDown(KeyCode.E))
            {
                colGameObject.GetComponent<Interactable>().Interact(gameObject);
            }

            if (colGameObject.GetComponent<Shroom>()!=null)
            {
                colGameObject.GetComponent<Shroom>().highlight(true);
            }
            else if(colGameObject.GetComponent<Cauldron>()!=null)
            {
                colGameObject.GetComponent<Cauldron>().highlight(true);
            }
            

        }
       
        if (Input.GetKeyDown(KeyCode.Alpha3) && inv.itemSlots.Count>0)
        {
            if(inv.itemSlots[0].id>=5 && inv.itemSlots[0].id <= 8)
            {
               inv.usePotion(inv.itemSlots[0].id);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && inv.itemSlots.Count > 1)
        {
            if (inv.itemSlots[1].id >= 5 && inv.itemSlots[1].id <= 8)
            {
                inv.usePotion(inv.itemSlots[1].id);
            }
        }
         if (Input.GetKeyDown(KeyCode.Alpha5) && inv.itemSlots.Count > 2)
        {
            if (inv.itemSlots[2].id >= 5 && inv.itemSlots[2].id <= 8)
            {
                inv.usePotion(inv.itemSlots[2].id);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && inv.itemSlots.Count > 3)
        {
            if (inv.itemSlots[3].id >= 5 && inv.itemSlots[3].id <= 8)
            {
                inv.usePotion(inv.itemSlots[3].id);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha7) && inv.itemSlots.Count > 4)
        {
            if (inv.itemSlots[4].id >= 5 && inv.itemSlots[4].id <= 8)
            {
                inv.usePotion(inv.itemSlots[4].id);
                Debug.Log(inv.itemSlots[4].id);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha8) && inv.itemSlots.Count > 5)
        {
            if (inv.itemSlots[5].id >= 5 && inv.itemSlots[5].id <= 8)
            {
                inv.usePotion(inv.itemSlots[5].id);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha9) && inv.itemSlots.Count > 6)
        {
            if (inv.itemSlots[6].id >= 5 && inv.itemSlots[6].id <= 8)
            {
                inv.usePotion(inv.itemSlots[6].id);
            }
        }
       


    }
    IEnumerator die()
    {
        dead = true;
        animator.SetBool("Dead", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Dead", false);
        gameObject.transform.position = startPos;
        gold = 0;
        addGold(0);
        hp = maxHp;
        updateHearts();
        dead = false;
    }
    public bool go(int shroomType)
    {
        return inv.newItem(shroomType);
    }
    IEnumerator DashCooldown()
    {
        canDash = false;
        yield return new WaitForSeconds(.25f);
        dashing = false;
        yield return new WaitForSeconds(.25f);
        trail.SetActive(false);
        yield return new WaitForSeconds(1f);
        canDash = true;
    }
}

