using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cauldron : MonoBehaviour,Interactable
{
    private GameObject Player;
    private Sprite normal;
    public Sprite h;
    public LayerMask interactable;
    private List<int> mushrooms;
    public Animator animator;
    public GameObject[] potions;
    enum MixtureTypes
    {
        DamagePotion,
        HealthPotion,
        PoisonPotion,
        SpeedPotion
    }
    enum ShroomTypes
    {
        Purple,
        Red,
        Blue,
        Orange,
        Green
    } 
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        normal = gameObject.GetComponent<SpriteRenderer>().sprite;
        mushrooms = new List<int>();
    }

    // Update is called once per frame
    
    void Update()
    {
        Collider2D[] col = Physics2D.OverlapBoxAll(gameObject.transform.position, new Vector2(2f, 2f), 0f, interactable);
        foreach (Collider2D c in col)
        {
            GameObject colGameObject = c.gameObject;
            if (colGameObject.GetComponent<Shroom>() != null)
            {
                mushrooms.Add(colGameObject.GetComponent<Shroom>().shroomType);
                Destroy(colGameObject);
                Debug.Log("usunieto grzyba");
                StartCoroutine(splash());
            }


        }
    }
    IEnumerator splash()
    {
        animator.SetBool("Drop",true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Drop", false);
    }
    public void Interact(GameObject interacter)
    {
        Player p = interacter.GetComponent<Player>();
        Debug.Log("Mikstura");
        craftMixture();
    }
    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);

        Gizmos.DrawCube(gameObject.transform.position, new Vector2(2f, 2f));
    }
    public void highlight(bool high)
    {
        if (high)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = h;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = normal;
        }
    }
    public void craftMixture()
    {

        mixtureRecipe((int)MixtureTypes.DamagePotion, (int)ShroomTypes.Orange, 3, (int)ShroomTypes.Red, 2);
        mixtureRecipe((int)MixtureTypes.DamagePotion, (int)ShroomTypes.Orange, 5, (int)ShroomTypes.Orange, 5);
        mixtureRecipe((int)MixtureTypes.DamagePotion, (int)ShroomTypes.Orange, 3, (int)ShroomTypes.Purple, 2);
        mixtureRecipe((int)MixtureTypes.DamagePotion, (int)ShroomTypes.Orange, 2, (int)ShroomTypes.Green, 2);

        mixtureRecipe((int)MixtureTypes.HealthPotion, (int)ShroomTypes.Red, 2, (int)ShroomTypes.Purple, 2);
        mixtureRecipe((int)MixtureTypes.HealthPotion, (int)ShroomTypes.Red, 3, (int)ShroomTypes.Blue, 1);
        mixtureRecipe((int)MixtureTypes.HealthPotion, (int)ShroomTypes.Red, 3, (int)ShroomTypes.Orange, 1);
        mixtureRecipe((int)MixtureTypes.HealthPotion, (int)ShroomTypes.Red, 4, (int)ShroomTypes.Red, 4);

        mixtureRecipe((int)MixtureTypes.PoisonPotion, (int)ShroomTypes.Green, 3, (int)ShroomTypes.Red, 2);
        mixtureRecipe((int)MixtureTypes.PoisonPotion, (int)ShroomTypes.Green, 4, (int)ShroomTypes.Green, 4);
        mixtureRecipe((int)MixtureTypes.PoisonPotion, (int)ShroomTypes.Green, 2, (int)ShroomTypes.Purple, 2);
        mixtureRecipe((int)MixtureTypes.PoisonPotion, (int)ShroomTypes.Green, 3, (int)ShroomTypes.Blue, 1);

        mixtureRecipe((int)MixtureTypes.SpeedPotion, (int)ShroomTypes.Blue, 3, (int)ShroomTypes.Red, 2);
        mixtureRecipe((int)MixtureTypes.SpeedPotion, (int)ShroomTypes.Blue, 5, (int)ShroomTypes.Blue, 5);
        mixtureRecipe((int)MixtureTypes.SpeedPotion, (int)ShroomTypes.Blue, 3, (int)ShroomTypes.Purple, 1);
        mixtureRecipe((int)MixtureTypes.SpeedPotion, (int)ShroomTypes.Blue, 2, (int)ShroomTypes.Orange, 2);

        mushrooms.Clear();
    }
    int getShroomsAmount(int id)
    {
        int result = 0;
        for(int i=0; i<mushrooms.Count; i++)
        {
            if (mushrooms[i] == id) result++;
        }
        return result;
    }
    void mixtureRecipe(int mixtureId = 0, int shroom1=0, int count1=0, int shroom2=0, int count2=0) 
    {
        if (getShroomsAmount(shroom1)==count1 && getShroomsAmount(shroom2) == count2)
        {
            mushrooms.Clear();
            Debug.Log("elo elo");
            DropMixture(mixtureId);
        }
    }
    void DropMixture(int id)
    {
       Instantiate(potions[id],gameObject.transform.position+new Vector3(0,2,0),gameObject.transform.rotation);
    }
}
