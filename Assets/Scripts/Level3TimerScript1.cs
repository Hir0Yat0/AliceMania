using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3TimerScript1 : MonoBehaviour
{
    GameSessionScript gameSession;
    float TimeToWin = 90.0f;
    float currentTime =  0.0f;
    public Text Timer;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = GameObject.Find("GameSession").GetComponent<GameSessionScript>();        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= TimeToWin){
            gameSession.onWin();
        }
        Timer.text = currentTime.ToString() + " / " + TimeToWin.ToString();
    }
}
