
using UnityEngine;

public class Aim : MonoBehaviour
{

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = new Vector2(mousePosition.x,mousePosition.y);
    }
}
