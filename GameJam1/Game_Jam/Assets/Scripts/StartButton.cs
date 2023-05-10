using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update

    public Button button;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        SceneManager.LoadScene("Rizer", LoadSceneMode.Single);
        //SceneManager.UnloadScene("MainMenu");
        Debug.Log("starting game");
    }
}
