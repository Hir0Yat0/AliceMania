using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene2 : MonoBehaviour
{
    GameObject player;
    NewPlayer1MovementScript1 playermovement;
    NewPlayer1AnimationScript1 playeranimation;
    Rigidbody2D playerrgbd2d;
    GameObject Alice;
    Alice_CombatScripts1 Alice_Combat;
    Alice_MovementsScripts1 Alice_Movements;
    Alice_AnimationsScripts1 Alice_Animations;
    Alice_LogicsScripts1 Alice_Logics;
    GameObject SpaceShip;
    bool scenestart = false;
    int step = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Alice = GameObject.FindGameObjectWithTag("Alice1");
        playermovement = player.GetComponent<NewPlayer1MovementScript1>();
        playeranimation = player.GetComponent<NewPlayer1AnimationScript1>();
        playerrgbd2d = player.GetComponent<Rigidbody2D>();
        Alice_Combat = Alice.GetComponent<Alice_CombatScripts1>();
        Alice_Movements = Alice.GetComponent<Alice_MovementsScripts1>();
        Alice_Animations = Alice.GetComponent<Alice_AnimationsScripts1>();
        Alice_Logics = Alice.GetComponent<Alice_LogicsScripts1>();
        SpaceShip = GameObject.Find("SpaceShip");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (scenestart != false){
            return;
        }
        if (other.tag != "Player"){
            return;
        }
        scenestart = true;
        step = 1;
        // this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        // Alice.SetActive(true);
        Alice_Logics.setHealthbarActive(true);
        Alice_Movements.Started =true;
        Alice_Combat.isAggro = true;
        Alice_Animations.Started = true;
    }

    // void step1(){
    //     if (step != 1){
    //         return;
    //     }
    //     playermovement.setPlayer_Controllable(false);
    //     Alice_Combat.isAggro = false;
    //     Alice_Movements.Started = false;
    //     SpaceShip.transform.position = new Vector2(62.96f,26.55f);
    //     Alice_Animations.setTextBubble1(false);
    //     step++;        
    // }
    // void step2(){
    //     if (step != 2){
    //         return;
    //     }
    //     SpaceShip.transform.position = Vector2.MoveTowards(SpaceShip.transform.position,new Vector2(87.68f,18.1f),8f*Time.deltaTime);
    // }
}
