using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CuteSlimePlayerScript1 : MonoBehaviour
{
    public Rigidbody2D slimeRigidbody;
    public float speedHorizontal = 10f;
    private float movementHorizontal;
    public float jumpStrenght = 250f;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        slimeRigidbody = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // for horizontal movement
        movementHorizontal = Input.GetAxis("Horizontal");
        moveHorizontal(movementHorizontal);

        // for jumping
        if(Input.GetKeyDown(KeyCode.Space)){
            // jump
            slimeRigidbody.AddForce(transform.up*jumpStrenght);
        }

        // check if gameisover or not

        if (isGameOver){
            SceneManager.LoadScene("menuscene");
            SceneManager.LoadScene("menuscene");
        }

    }

    void moveHorizontal(float movementHorizontal){
        movementHorizontal = movementHorizontal * speedHorizontal * Time.deltaTime;
        transform.Translate(movementHorizontal,0,0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "FallHole"){
            isGameOver = true;
        }
        if (other.name == "Star"){
            SceneManager.LoadScene("maingamescene1");
        }        
    }
}
