using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene1 : MonoBehaviour
{
    NewPlayer1MovementScript1 playermovement;
    NewPlayer1AnimationScript1 playeranimation;
    Rigidbody2D playerrgbd2d;
    GameObject player;
    [SerializeField] Vector2 pointA;
    [SerializeField] Vector2 pointB;
    [SerializeField] Vector2 pointC;
    [SerializeField] int step = 0;
    float waittime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null){
            Debug.Log("aaaaa");
        }
        // playermovement = FindObjectOfType<NewPlayer1MovementScript1>();
        playermovement = player.GetComponent<NewPlayer1MovementScript1>();
        playeranimation = FindObjectOfType<NewPlayer1AnimationScript1>();
        playerrgbd2d =  GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        pointA = transform.position;
        pointB = new Vector2(playermovement.gameObject.transform.position.x+4,playermovement.gameObject.transform.position.y+4);
        pointC = new Vector2(Mathf.Abs(pointA.x-pointB.x)+pointB.x,pointA.y);
        step = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector2.MoveTowards(transform.position,pointB,5*Time.deltaTime);
        step1();
        step2();
        step2_1();
        step3();
        step4();
        step5();
    }

    private void FixedUpdate() {
        step3_1();    
    }
    

    void step1(){
        if (step != 1){
            return;
        }
        if (Mathf.Abs(transform.position.x - pointB.x) <= Mathf.Epsilon && Mathf.Abs(transform.position.y - pointB.y) < Mathf.Epsilon){
            step++;
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position,pointB,5*Time.deltaTime);
        playermovement.setPlayer_Controllable(false);
    }

    void step2(){
        if (step != 2){
            return;
        }
        // if (waittime >= 3.7){
        //     // step++;
        //     // waittime = 0;
        //     return;
        // }
        waittime += Time.deltaTime;
    }

    void step2_1(){
        if (step != 2){
            return;
        }
        if (waittime >= 3.9){
            playeranimation.setTextBubble1(false);
            step++;
            waittime = 0;
            return;
        }
        if (waittime >= 3.5){
            playeranimation.setTextBubble1_ExclamationMark(true);
            playeranimation.setTextBubble1_DotDotDot(false);
            playerrgbd2d.AddForce(Vector2.up * 3);
            return;
        }
        if (waittime >= 1.2){
            playeranimation.setTextBubble1(true);
            playeranimation.setTextBubble1_DotDotDot(true);
            playeranimation.setTextBubble1_ExclamationMark(false);
            playeranimation.setTextBubble1_HeartHeart(false);
            return;
        }

    }

    void step3(){
        if (step != 3){
            return;
        }
        if (Mathf.Abs(transform.position.x - pointC.x) < Mathf.Epsilon && Mathf.Abs(transform.position.y - pointC.y) < Mathf.Epsilon){
            step++;
            playeranimation.setRunningAnimation(false);
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position,pointC,5*Time.deltaTime);
        playeranimation.setRunningAnimation(true);
        // playerrgbd2d.AddForce(new Vector2(7.5f,0f));
        
    }
    void step3_1(){
        if (step != 3){
            return;
        }
        playerrgbd2d.AddForce(new Vector2(6.3f,0f));
    }

    void step4(){
        if (step != 4){
            return;
        }
        if (waittime >= 2){
            step++;
            waittime = 0;
            return;
        }
        waittime += Time.deltaTime;
    }

    void step5(){
        if (step!=5){
            return;
        }
        playermovement.setPlayer_Controllable(true);
        step++;
        return;
    }
}
