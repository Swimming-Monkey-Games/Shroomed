using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestEnemyGenerator : MonoBehaviour
{
    public Transform[] allChildren;
    public GameObject parent;
    private GameObject parentSpawned;
    public List<GameObject> enemies;
    public bool playerEntered;
    public GameObject player;
    public int spawnCount;
    public bool spawnIniciated = false;
    public bool one;
   // private List<int> uniqueCheck;    // Start is called before the first frame update
    void Start()
    {
        allChildren = GetComponentsInChildren<Transform>();
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        if (one)
        {
            if (player.transform.position.y > 8.5 && !playerEntered)
            {
                playerEntered = true;
            }
            if (playerEntered && player.transform.position.y < 8.5 && !spawnIniciated)
            {
                StartCoroutine(coolDown());
            }
        }
        else
        {
            if (player.transform.position.y < -28 && !playerEntered)
            {
                playerEntered = true;
            }
            if (playerEntered && player.transform.position.y > -28 && !spawnIniciated)
            {
                StartCoroutine(coolDown());
            }
        }
    }
    IEnumerator coolDown()
    {

        spawnIniciated = true;
        yield return new WaitForSeconds(5f);
        if (one)
        {
            if (playerEntered && player.transform.position.y < 8.5)
            {
                Destroy(parentSpawned);
                Generate();
            }
        }
        else
        {
            if (playerEntered && player.transform.position.y > -28)
            {
                Destroy(parentSpawned);
                Generate();
            }
        }

        playerEntered = false;
        spawnIniciated = false;
    }
    void Generate()
    {
        parentSpawned = Instantiate(parent, gameObject.transform.position, gameObject.transform.rotation);
        for (int i = 1; i < spawnCount; i++)
        {
            int spawnPos = Random.Range(1, allChildren.Length);
           // if (uniqueCheck.Contains(spawnPos)==false)
          //  {
                int shroomType = Random.Range(0, enemies.Count);
                GameObject enemy = Instantiate(enemies[shroomType], allChildren[spawnPos].position, gameObject.transform.rotation);
                //do zrobienia zeby nie mozna bylo 2 na to samo miejsce
                enemy.transform.parent = parentSpawned.transform;
            //    uniqueCheck.Add(spawnPos);
         //   }
            
        }
       // uniqueCheck.Clear();
    }
}
