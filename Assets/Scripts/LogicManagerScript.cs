using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicManagerScript : MonoBehaviour
{
    private int playerScore;
    public Text scoreIndicator;
    public GameObject gameOverScreen;

    [ContextMenu("Increase Score")]
    public void scoreUpdate(int scoreToAdd){
        playerScore = playerScore + scoreToAdd;
        scoreIndicator.text = playerScore.ToString();
        Debug.Log("Score +" + scoreToAdd +"!"); 
        if (playerScore >= 10){
            SceneManager.LoadScene("clearscene1");
        }
    }
    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver(){
        // gameOverScreen.SetActive(true);
        SceneManager.LoadScene("menuscene");
    }
   void print2(){
        Debug.Log("2");
    }
}
