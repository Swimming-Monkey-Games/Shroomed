using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Image sword;
    public Image bow;
    public Sprite n;
    public Sprite h;
    public GameObject bowObj;
    public GameObject swordObj;
    public Weapon weapon;
    public Bow bowScript;
    public Bow bowScript2;
    public Bow bowScript3;
    public GameObject aim;
    public GameObject weaponObj;
    public Sprite sword2;
    public Sprite sword3;
    public Sprite bow2;
    public Sprite bow3;
    public Sprite sword1;
    public Sprite bow1;
    public Image swordIMG;
    public Image bowIMG;
    public Sprite currentSword;
    public Sprite currentBow;
    // Start is called before the first frame update
    void Start()
    {
        currentSword = sword1;
            currentBow = bow1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            one();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            two();
        }
    }
    public void one()
    {
        //aim.SetActive(false);
        swordIMG.sprite = currentSword;
        weaponObj.SetActive(true);
        weapon.canAttack = true;
        swordObj.SetActive(true);
        bowObj.SetActive(false);
        sword.sprite = h;
        bow.sprite = n;
        sword.transform.localScale = new Vector3(1.2f, 1.2f, 1);
        bow.transform.localScale = new Vector3(1f, 1f, 1);
    }
    public void two()
    {
        //aim.SetActive(true);
        bowIMG.sprite = currentBow;
        bowScript.canAttack = true;
        bowScript2.canAttack = true;
        bowScript3.canAttack = true;
        weaponObj.SetActive(false);
        swordObj.SetActive(false);
        bowObj.SetActive(true);
        sword.sprite = n;
        bow.sprite = h;
        sword.transform.localScale = new Vector3(1f, 1f, 1);
        bow.transform.localScale = new Vector3(1.2f, 1.2f, 1);
    }
}
