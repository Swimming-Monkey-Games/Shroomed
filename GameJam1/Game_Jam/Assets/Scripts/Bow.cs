using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public int dmg;
    public Animator animator;
    public bool canAttack = true;
    public GameObject attackPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            StartCoroutine(Cooldown());
            animator.SetBool("Shoot", true);
        }
    }
    IEnumerator Cooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(.5f);
        GameObject arrow2=Instantiate(arrow, attackPos.transform.position, gameObject.transform.rotation);
        arrow2.GetComponent<Arrow>().dmg=dmg;
          animator.SetBool("Shoot", false);
        canAttack = true;
    }
}
