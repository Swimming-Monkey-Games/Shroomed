using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant2 : MonoBehaviour, Interactable
{
    // Start is called before the first frame update
    public Shop2 shop2;
    public LayerMask interactable;

    // Update is called once per frame

    public void Interact(GameObject interacter)
    {
        shop2.gameObject.SetActive(true);
        Debug.Log("elo");
    }
}
