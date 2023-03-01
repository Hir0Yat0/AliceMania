using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript1 : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapstrength;
    public LogicManagerScript logicScript;
    public bool isGameNotOver = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "aa";
        gameObject.name = "aa";
        // myRigidbody.velocity = Vector2.up*10;
        logicScript = GameObject.FindGameObjectWithTag("LogicScripts").GetComponent<LogicManagerScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.name = "aa";
        // myRigidbody.velocity = Vector2.up*10;
        // myRigidbody.velocity = Vector2.positiveInfinity;
        // if (Input.GetKey("space")){
        //     myRigidbody.velocity = Vector2.up * 10;
        // }
        if (Input.GetKeyDown(KeyCode.Space) && isGameNotOver){
            myRigidbody.velocity = Vector2.up * flapstrength;
        }    
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     logicScript.gameOver();
    //     // other.gameObject.;
    //     isGameNotOver = false;
    //     // Debug.Log(other.gameObject.name);
    // }

}
