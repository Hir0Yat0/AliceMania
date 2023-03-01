using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars1Script1 : MonoBehaviour
{
    // GameSessionScript gameSession;
    NewPlayer1LogicsScript1 player_logics;
    [SerializeField] public AudioClip sfx1;

    private void Awake() {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        // gameSession = GameObject.Find("GameSession").GetComponent<GameSessionScript>();
        player_logics = GameObject.FindGameObjectWithTag("Player").GetComponent<NewPlayer1LogicsScript1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        // gameSession.increaseScore(1);
        player_logics.AddScore(1);
        AudioSource.PlayClipAtPoint(sfx1,gameObject.transform.position);
        Destroy(gameObject,0.1f);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        // gameSession.increaseScore(1);
        player_logics.AddScore(1);
        AudioSource.PlayClipAtPoint(sfx1,gameObject.transform.position);
        Destroy(gameObject,0.1f);
    }
}
