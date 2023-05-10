using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public Animator animatorSword1;
    public Animator animatorSword2;
    public Animator animatorSword3;
    public GameObject sword1;
    public GameObject sword2;
    public GameObject sword3;
    public GameObject bow1;
    public GameObject bow2;
    public GameObject bow3;
    public Weapon weapon;
    //  public Bow bow;
    public UiManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        
    }
    public void upgradeSword(int swordLvl)
    {
        switch (swordLvl)
        {
            case 1:
                weapon.animator = animatorSword1;
                uiManager.swordObj = sword1;
                
                sword1.SetActive(true);
                sword2.SetActive(false);
                sword3.SetActive(false);
                Debug.Log("1");
                break;
            case 2:
                weapon.animator = animatorSword2;
                uiManager.swordObj = sword2;
                uiManager.currentSword = uiManager.sword2;
                sword2.SetActive(true);
                sword1.SetActive(false);
                sword3.SetActive(false);
                Debug.Log("2");
                break;
            case 3:
                weapon.animator = animatorSword3;
                uiManager.swordObj = sword3;
                uiManager.currentSword = uiManager.sword3;
                sword3.SetActive(true);
                sword2.SetActive(false);
                sword1.SetActive(false);
                break;
        }

        uiManager.one();
    }
    public void upgradeBow(int bowLvl)
    {
        switch (bowLvl)
        {
            case 1:
                // bow.animator = animatorBow1;
                uiManager.bowObj = bow1;
                bow2.SetActive(false);
                bow3.SetActive(false);
                Debug.Log("1");
                break;
            case 2:
                // bow.animator = animatorBow2;
                uiManager.bowObj = bow2;
                uiManager.currentBow = uiManager.bow2;
                bow1.SetActive(false);
                bow3.SetActive(false);
                Debug.Log("2");
                break;
            case 3:
                //  bow.animator = animatorBow3;
                uiManager.bowObj = bow3;
                uiManager.currentBow = uiManager.bow3;
                bow2.SetActive(false);
                bow1.SetActive(false);
                break;
        }
        uiManager.two();
    }
}
