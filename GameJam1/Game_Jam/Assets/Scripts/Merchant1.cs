using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant1 : MonoBehaviour, Interactable
{
    public Shop shop;
    public LayerMask interactable;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Interact(GameObject interacter)
    {
        shop.gameObject.SetActive(true);
        shop.onOpenShop();
        Debug.Log("elo");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
