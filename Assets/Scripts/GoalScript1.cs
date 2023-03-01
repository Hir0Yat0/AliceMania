using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript1 : MonoBehaviour
{
    GameSessionScript gameSession;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = GameObject.Find("GameSession").GetComponent<GameSessionScript>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        // gameSession.increaseScore(1);
        gameSession.onWin();
        Destroy(gameObject,0.1f);
    }
    // private void OnCollisionEnter2D(Collision2D other) {
    //     // gameSession.increaseScore(1);
    //     gameSession.onWin();
    //     Destroy(gameObject,0.1f);
    // }
}
