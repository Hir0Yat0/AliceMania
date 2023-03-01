using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIScript1 : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public DifficutySettingScript1 difficultySetting;

    // Start is called before the first frame update
    void Start()
    {
        difficultySetting = GameObject.Find("DifficultySetting").GetComponent<DifficutySettingScript1>();

        var root = GetComponent<UIDocument>().rootVisualElement;
        startButton = root.Q<Button>("Normal");
        exitButton = root.Q<Button>("Hard");

        startButton.clicked += StartButtonPressed;
        exitButton.clicked += ExitButtonPressed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartButtonPressed(){
        difficultySetting.DifficultyMultiplier = 1;
        SceneManager.LoadScene("Scene_Level_1_1");
    }

    void ExitButtonPressed(){
        // SceneManager.LoadScene("moonscene");
        difficultySetting.DifficultyMultiplier = 2;
        SceneManager.LoadScene("Scene_Level_1_1");
        // Application.Quit();
    }
}
