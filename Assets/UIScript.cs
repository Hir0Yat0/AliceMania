using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        startButton = root.Q<Button>("startgamebutton");
        exitButton = root.Q<Button>("exitgamebutton");

        startButton.clicked += StartButtonPressed;
        exitButton.clicked += ExitButtonPressed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartButtonPressed(){
        SceneManager.LoadScene("menuscene1");
    }

    void ExitButtonPressed(){
        // SceneManager.LoadScene("moonscene");
        Application.Quit();
    }
}
