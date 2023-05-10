using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    public Button button;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
