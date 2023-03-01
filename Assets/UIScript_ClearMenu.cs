using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIScript_ClearMenu : MonoBehaviour
{
    // public Button startButton;
    // public Button exitButton;
    public Button backToMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        // startButton = root.Q<Button>("startgamebutton");
        // exitButton = root.Q<Button>("exitgamebutton");
        backToMenuButton = root.Q<Button>("backtomenubutton");

        // startButton.clicked += StartButtonPressed;
        // exitButton.clicked += ExitButtonPressed;
        backToMenuButton.clicked += BackToMenuButtonPressed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void StartButtonPressed(){
    //     SceneManager.LoadScene("platformerscenes1");
    // }

    // void ExitButtonPressed(){
    //     SceneManager.LoadScene("moonscene");
    // }

    void BackToMenuButtonPressed(){
        SceneManager.LoadScene("menuscene");
    }
}
