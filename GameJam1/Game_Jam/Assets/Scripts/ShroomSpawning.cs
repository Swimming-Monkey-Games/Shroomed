using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomSpawning : MonoBehaviour
{
    public Transform[] allChildren;
    public List<Transform> positionsChangable;
    public List<Transform> positions;
    public List<GameObject> shroom;
    public bool playerEntered;
    public GameObject player;
    public int spawnCount;
    public GameObject parent;
    private GameObject parentSpawned;
    public bool spawnIniciated=false;
    public bool one;
    // Start is called before the first frame update
    void Start()
    {
        // Transform[] allChildren = GetComponentsInChildren<Transform>();
        // Debug.Log(allChildren[40]);
        allChildren = GetComponentsInChildren<Transform>();
        Spawn();
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
        yield return new WaitForSeconds(4f);
        if (one)
        {
            if (playerEntered && player.transform.position.y < 8.5)
            {
                Destroy(parentSpawned);
                allChildren = GetComponentsInChildren<Transform>();
                Spawn();
            }
        }
        else
        {
            if (playerEntered && player.transform.position.y > -28)
            {
                Destroy(parentSpawned);
                allChildren = GetComponentsInChildren<Transform>();
                Spawn();
            }
        }
        
        playerEntered = false;
        spawnIniciated = false;
    }
    private void Spawn()
    {
       // positionsChangable.Clear();
      //  for (int i = 0; i < positions.Count; i++)
      //  {
     //      positionsChangable.Add(positions[i]);
      //  }
        parentSpawned = Instantiate(parent, gameObject.transform.position, gameObject.transform.rotation);
        for (int i = 0; i < spawnCount; i++)
        {
            int shroomPos = Random.Range(1, allChildren.Length);
           
            int shroomType = Random.Range(0, shroom.Count);
            GameObject shr  = Instantiate(shroom[shroomType], allChildren[shroomPos].position, gameObject.transform.rotation);
            shr.transform.parent = parentSpawned.transform;
           // positionsChangable.RemoveAt(shroomPos);
        }
    }
}
