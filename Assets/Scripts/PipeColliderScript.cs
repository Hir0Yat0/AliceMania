using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeColliderScript : MonoBehaviour
{
    BirdScript1 playerBird;
    // Start is called before the first frame update
    void Start()
    {
        playerBird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript1>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other) {
        playerBird.logicScript.gameOver();
        // other.gameObject.;
        playerBird.isGameNotOver = false;
        // Debug.Log(other.gameObject.name);
    }
}
