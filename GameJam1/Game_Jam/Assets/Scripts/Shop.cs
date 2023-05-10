using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Shop : MonoBehaviour
{
    public Inv inventory;
    public Button[] addButtons;
    public Button[] subtractButtons;
    public TMP_Text[] sellTexts;
    public TMP_Text[] priceTags;
    public Image[] sellIcon;
    public GameObject[] sellSlots;
    public Button sellButton;
    public Button closeButton;
    public Player player;
    private int[] prices;
    private int[] sellAmounts;
    // Start is called before the first frame update
    void Awake()
    {
        sellAmounts = new int[7];
        prices = new int[15]
        {
            15,15,15,15,15,120,110,100,150,90,5,11,12,13,14
        };
        closeButton.onClick.AddListener(closeShop);
        sellButton.onClick.AddListener(sellSelectedItems);
        onOpenShop();
    }
    public void onOpenShop()
    {
        for(int i=0; i<7; i++)
        {
            sellSlots[i].gameObject.SetActive(true);
            addButtons[i].onClick.RemoveAllListeners();
            subtractButtons[i].onClick.RemoveAllListeners();
            priceTags[i].text = "";
            sellTexts[i].text = 0.ToString();
        }
        sellAmounts = new int[7];
        for (int i = inventory.itemSlots.Count; i < 7; i++)
        {
            sellSlots[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < inventory.itemSlots.Count; i++)
        {
            priceTags[i].text = prices[inventory.itemSlots[i].id].ToString();
            sellIcon[i].sprite = inventory.itemSprites[inventory.itemSlots[i].id];
            int test = i;
            addButtons[i].onClick.AddListener(delegate { addSellAmount(test); });
            subtractButtons[i].onClick.AddListener(delegate { subtractSellAmount(test); });
            Debug.Log("test petla" + i);
        }
    }
    void sellSelectedItems()
    {
        for(int i= sellAmounts.Length; i>0; i--)
        {
            for(int j=0; j<sellAmounts[i-1]; j++)
            {
                Debug.Log("SELL LOOP i=" + i + " j=" + j);
                player.addGold(prices[inventory.itemSlots[i - 1].id]);
                inventory.destroyItem(inventory.itemSlots[i-1].id);
            }
        }
        onOpenShop();
    }

    void addSellAmount(int slotId)
    {
        int test = slotId;
        Debug.Log(test + "slotId");
        Debug.Log(inventory.itemSlots[slotId].amount+" "+ sellAmounts[slotId]);
        if (inventory.itemSlots[slotId].amount > sellAmounts[slotId])
        {
            sellAmounts[slotId]++;
            sellTexts[slotId].text = sellAmounts[slotId].ToString();
        }
    }
    void subtractSellAmount(int slotId)
    {
        if (inventory.itemSlots[slotId].amount > 0 && sellAmounts[slotId]>0)
        {
            sellAmounts[slotId]--;
            sellTexts[slotId].text = sellAmounts[slotId].ToString();
        }
    }
    void closeShop()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
