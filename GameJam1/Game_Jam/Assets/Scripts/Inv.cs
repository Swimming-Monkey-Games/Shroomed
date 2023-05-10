using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Pair<T1, T2>
{
    public T1 id { get; set; }
    public T2 amount { get; set; }
    public Pair(T1 x, T2 y)
    {
        id = x;
        amount = y;
    }
}

public class Inv : MonoBehaviour
{
    private int shroomType;
    public TMP_Text[] counters;
    public Image[] images;
    public Sprite[] itemSprites;
    public Image[] slotItems;
    public Button[] dropButtons;
    public GameObject[] prefabs;
    public Sprite transparent;
    public int maxSlots;
    public int[] items;
    public List<Pair<int,int>> itemSlots;
    private GameObject player;
    private GameObject bow;
    private GameObject bow2;
    private GameObject bow3;
    public GameObject sword;
    // Start is called before the first frame update
    void Start()
    {
        items = new int[15]; 
        itemSlots= new List<Pair<int, int>>{};
        for(int i=maxSlots; i<7; i++)
        slotItems[i].gameObject.SetActive(false);
        for(int i=0; i<maxSlots; i++)
        {
            images[i].sprite = transparent;
            counters[i].text = "";
        }
        player = GameObject.Find("Player");
        bow = GameObject.Find("bow");
        bow2 = GameObject.Find("bow2");
        bow3 = GameObject.Find("bow3");
        bow.SetActive(false);
        bow2.SetActive(false);
        bow3.SetActive(false);
        sword = GameObject.Find("Weapon");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool newItem(int itemId)
    {
    

     

        if (items[itemId] == 0)
        {
            if (checkIfFreeSlots(maxSlots))
            {
                items[itemId]++;
                itemSlots.Add(new Pair<int, int>(itemId, 1));
                for (int i = 0; i < itemSlots.Count; i++)
                {

                    if (itemSlots[i].id == itemId)
                    {
                        dropButtons[i].onClick.AddListener(delegate { dropItem(itemSlots[i].id); });
                        counters[i].text = itemSlots[i].amount.ToString();
                        images[i].sprite = itemSprites[itemSlots[i].id];
                        Debug.Log("Dodano itemek, nie bylo go wczesniej w eq");
                        return true;
                    }
                }
            }
            else
            {
                Debug.Log("Nie ma miejsca");
                return false;
            }
        }
        else if (items[itemId] > 0)
        {
            items[itemId]++;
            for (int i = 0; i < itemSlots.Count; i++)
            {
                if (itemSlots[i].id == itemId)
                {
                    itemSlots[i].amount++;
                    counters[i].text = itemSlots[i].amount.ToString();
                    images[i].sprite = itemSprites[itemSlots[i].id];
                    Debug.Log("Dodano itemek,  byl wczesniej w eq");
                    return true;
                }
            }
        }
        return false;
    }
    void dropItem(int itemId)
    {
        Debug.Log("function called"+items[itemId]);
        if (items[itemId] > 0)
        {
            Debug.Log("drop item" + itemId);
            Instantiate(prefabs[itemId],player.transform.position,player.transform.rotation);
            for(int i=0; i<itemSlots.Count; i++)
            {
                if (itemSlots[i].id == itemId)
                {
                    items[itemId]--;
                    itemSlots[i].amount--;
                    counters[i].text = itemSlots[i].amount.ToString();
                    if (itemSlots[i].amount == 0)
                    {
                        counters[i].text = "";
                        images[i].sprite = transparent;
                            for(int j=i; j<itemSlots.Count; j++)
                        {
                            if (j == itemSlots.Count - 1)
                            {
                                images[j].sprite = transparent;
                                counters[j].text = "";
                                dropButtons[j].onClick.RemoveAllListeners();
                            }
                            else
                            {
                                images[j].sprite = images[j + 1].sprite;
                                counters[j].text = counters[j + 1].text;
                                dropButtons[j].onClick.AddListener(delegate { dropItem(itemSlots[j+1].id); });
                      
                            }
                        }
                        itemSlots.RemoveAt(i);
                        
                        Debug.Log("Removed item slot!");
                    }
                    
                }
            }
        }
    }
    public void usePotion(int itemId)
    {
        switch (itemId)
        {
            case 5:
                bow.GetComponent<Bow>().dmg+=5;
                bow2.GetComponent<Bow>().dmg += 5;
                bow3.GetComponent<Bow>().dmg += 5;
                sword.GetComponent<Weapon>().dmg += 5;
                destroyItem(itemId);
                Debug.Log("potka wypita strength");
            break;
            case 6:
                player.GetComponent<Player>().changeHealth(4);
                destroyItem(itemId);
                Debug.Log("potka wypita hp");
                break;
            case 7:
                player.GetComponent<Player>().changeHealth(-1);
                destroyItem(itemId);

                break;
            case 8:
                player.GetComponent<Player>().startSpeed++;
                destroyItem(itemId);
                break;
        }
    }
    public void destroyItem(int itemId)
    {
        if (items[itemId] > 0)
        {
            Debug.Log("destroy item" + itemId);
            for (int i = 0; i < itemSlots.Count; i++)
            {
                if (itemSlots[i].id == itemId)
                {
                    items[itemId]--;
                    itemSlots[i].amount--;
                    counters[i].text = itemSlots[i].amount.ToString();
                    if (itemSlots[i].amount == 0)
                    {
                        counters[i].text = "";
                        images[i].sprite = transparent;
                        for (int j = i; j < itemSlots.Count; j++)
                        {
                            if (j == itemSlots.Count - 1)
                            {
                                images[j].sprite = transparent;
                                counters[j].text = "";
                                dropButtons[j].onClick.RemoveAllListeners();
                            }
                            else
                            {
                                images[j].sprite = images[j + 1].sprite;
                                counters[j].text = counters[j + 1].text;
                                dropButtons[j].onClick.AddListener(delegate { dropItem(itemSlots[j + 1].id); });

                            }
                        }
                        itemSlots.RemoveAt(i);

                        Debug.Log("Removed item slot!");
                    }

                }
            }
        }
    }
    private bool checkIfFreeSlots(int max) 
    {
        int x = 0;
        for(int i=0; i<items.Length; i++)
        {
            if (items[i] > 0) x++;
        }
        if (x >= max) return false;
        else return true;
    }
 
}
