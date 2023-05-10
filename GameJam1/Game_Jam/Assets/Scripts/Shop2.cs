using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop2: MonoBehaviour
{
    public Button closeButton;
    public Button[] buyButtons;
    public Player player;
    public GameObject playerGO;
    public GameObject brickWall;
    void Awake()
    {
        buyButtons[0].onClick.AddListener(buySword1);
        buyButtons[1].onClick.AddListener(buySword2);
        buyButtons[2].onClick.AddListener(buyBow1);
        buyButtons[3].onClick.AddListener(buyBow2);
        buyButtons[4].onClick.AddListener(buyArea);
        closeButton.onClick.AddListener(closeWindow);
    }

    // Update is called once per frame
    void buySword1()
    {
        if (player.gold >= 400)
        {
            playerGO.GetComponent<UpgradeManager>().upgradeSword(2);
            buyButtons[0].gameObject.SetActive(false);
            player.addGold(-400);
            player.inv.sword.GetComponent<Weapon>().dmg += 10;
        }
    }
    void buySword2()
    {
        if (player.gold >= 700)
        {
            playerGO.GetComponent<UpgradeManager>().upgradeSword(3);
                player.inv.sword.GetComponent<Weapon>().dmg += 20;
            buyButtons[1].gameObject.SetActive(false);
            buyButtons[0].gameObject.SetActive(false);
            
            player.addGold(-700);
           
        }
    }
    void buyBow1()
    {
        if (player.gold >= 600){
            playerGO.GetComponent<UpgradeManager>().upgradeBow(2);
            buyButtons[2].gameObject.SetActive(false);
            player.addGold(-600);
        }
    }
    void buyBow2()
    {
        if (player.gold >= 800)
        {
            playerGO.GetComponent<UpgradeManager>().upgradeBow(3);
            buyButtons[3].gameObject.SetActive(false);
            buyButtons[2].gameObject.SetActive(false);
            player.addGold(-800);
        }
    }
    void buyArea()
    {
        if (player.gold >= 550)
        {
            Destroy(brickWall);
            buyButtons[4].gameObject.SetActive(false);
            player.addGold(-550);
        }
    }
    void closeWindow()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        
    }

}
