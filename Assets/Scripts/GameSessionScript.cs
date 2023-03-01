using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSessionScript : MonoBehaviour
{
    // List<GameSessionScript> listofgamesession;
    GameSessionScript[] listofgamesession;
    int numofgamesession;
    public int player_lives = 3;
    public int scores = 0;
    bool isGameOver = false;
    public Text Lives;
    public Text Scores;
    NewPlayer1LogicsScript1 PlayerLogics;
    DifficutySettingScript1 difficultySetting;
    public int DifficultyLevel = 1;

    private void Awake() {

        PlayerLogics = GameObject.FindGameObjectWithTag("Player").GetComponent<NewPlayer1LogicsScript1>();
        difficultySetting = GameObject.Find("DifficultySetting").GetComponent<DifficutySettingScript1>();
        DifficultyLevel = difficultySetting.DifficultyMultiplier;
        listofgamesession = FindObjectsOfType<GameSessionScript>();
        numofgamesession = listofgamesession.Length;
        if(numofgamesession > 1){
            Destroy(gameObject);
        }
        else {
        PlayerLogics = GameObject.FindGameObjectWithTag("Player").GetComponent<NewPlayer1LogicsScript1>();
        difficultySetting = GameObject.Find("DifficultySetting").GetComponent<DifficutySettingScript1>();
        DifficultyLevel = difficultySetting.DifficultyMultiplier;
        DontDestroyOnLoad(gameObject);
        Lives.text = player_lives.ToString();
        Scores.text = (scores).ToString();

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        // difficultySetting = GameObject.Find("DifficultySetting").GetComponent<DifficutySettingScript1>();
        // DifficultyLevel = difficultySetting.DifficultyMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        onGameOver();
    }
    public void player_defeated(){
        player_lives = player_lives - 1;
        if (player_lives < 0){
            isGameOver = true;
            // Lives.text = player_lives.ToString();

            return;
        }    
        Lives.text = player_lives.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void onGameOver(){
        if (isGameOver){
            SceneManager.LoadScene("menuscene");
            Destroy(gameObject);
        }
    }
    public void increaseScore(int score){
        PlayerLogics = GameObject.FindGameObjectWithTag("Player").GetComponent<NewPlayer1LogicsScript1>();
        if (PlayerLogics == null){
            Debug.Log("aaaaaaa");
        }
        scores += score;
        // int scoreToAdd = scores + PlayerLogics.Score;
        Scores.text = (scores).ToString();
    }
    public void onWin(){
        // int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // int nextSceneIndex = currentSceneIndex + 1;
        // if (nextSceneIndex == SceneManager.sceneCount){
        //     nextSceneIndex = 0;
        // }
        // SceneManager.LoadScene(nextSceneIndex);
        PlayerLogics = GameObject.FindGameObjectWithTag("Player").GetComponent<NewPlayer1LogicsScript1>();
        scores += PlayerLogics.getScore();
        if (SceneManager.GetActiveScene().name == "Scene_Level_1_1"){
            SceneManager.LoadScene("Scene_Level_2_1");
        }
        else if (SceneManager.GetActiveScene().name == "Scene_Level_2_1"){
            SceneManager.LoadScene("Scene_Level_3_1");
            // SceneManager.LoadScene("menuscene");
            // Destroy(gameObject);
        }
        else if (SceneManager.GetActiveScene().name == "Scene_Level_3_1"){
            SceneManager.LoadScene("menuscene");
            Destroy(difficultySetting.gameObject);
            Destroy(gameObject);
        }
    }
}
    