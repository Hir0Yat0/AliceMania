using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBoxScript1 : MonoBehaviour
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
        if (other.tag == "Player"){
            // Destroy(other.gameObject);
            gameSession.player_defeated();
        }
    }
}
