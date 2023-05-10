using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followAI : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;

    private void Awake()
    {
        target= GameObject.Find("Player").transform;
    }
    void Update()
    {
        if (Vector2.Distance(gameObject.transform.position, target.position) <13)
        {
            if (Vector2.Distance(transform.position, target.position) > minimumDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
        
        
    }
}
