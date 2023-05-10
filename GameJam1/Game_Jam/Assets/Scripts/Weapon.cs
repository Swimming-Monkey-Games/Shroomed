using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public LayerMask enemy;
    public int dmg;
    public Animator animator;
    public bool canAttack=true;
    public GameObject attackPos;
    public GameObject arm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&&canAttack)
        {
            animator.SetBool("Attack", true);
            Collider2D[] col = Physics2D.OverlapBoxAll(attackPos.transform.position, new Vector2(1.8f, 2f), 0f, enemy);
            
            
            foreach (Collider2D c in col)
            {
                GameObject colGameObject = c.gameObject;
                colGameObject.GetComponent<Damagable>().Damage(dmg);
                StartCoroutine(red(colGameObject));
                StartCoroutine(Cooldown2(colGameObject));
                
            }
            StartCoroutine(Cooldown());
        }
    }
    IEnumerator red(GameObject obj)
    {
        yield return new WaitForSeconds(0.25f);
        obj.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        if (obj!=null)
        {
            obj.GetComponent<SpriteRenderer>().color = Color.white;
        }
        
    }
   
    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        
        Gizmos.DrawCube(attackPos.transform.position, new Vector2(1.8f, 2f));
    }
    IEnumerator Cooldown2(GameObject obj)
    {
        yield return new WaitForSeconds(.2f);
        if (obj.GetComponent<Rigidbody2D>()!=null)
        {
            obj.GetComponent<Rigidbody2D>().AddForce(transform.right * 37, ForceMode2D.Impulse);
        }
        
    }
        IEnumerator Cooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(.3f);
        animator.SetBool("Attack", false);
        canAttack = true;
    }
}
