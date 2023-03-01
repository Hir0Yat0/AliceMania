using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.InputSystem;

public class NewPlayersMovementScript : MonoBehaviour
{
    [SerializeField] public Vector2 movementInput;
    public Rigidbody2D playerRgbd2d;
    public float movementSpeed = 10f;
    public float jumpStrenght = 25f;
    public Animator playerAnimator;
    private bool isRunning = false;
    public CapsuleCollider2D playerCapsuleCollider2D;
    public float climbSpeed = 5.0f;
    private string[] playerStatusList = {"isIdle","isRunning","isClimbing","isJumping"};
    public string playerStatus;
    private float gravityDefault;

    // Start is called before the first frame update
    void Start()
    {
        playerRgbd2d = gameObject.GetComponent<Rigidbody2D>();
        playerAnimator = gameObject.GetComponent<Animator>();
        playerCapsuleCollider2D = gameObject.GetComponent<CapsuleCollider2D>();
        playerStatus = playerStatusList[0];
        gravityDefault = playerRgbd2d.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        // player_Run1(movementInput,movementSpeed);
        // player_Run11();
        updateMovement();
        updateSprite();
    }

    void OnMove(InputValue input){

        movementInput = input.Get<Vector2>();
        Debug.Log(movementInput);
        // player_Run(movementInput,movementSpeed);
    }
    void OnJump(InputValue input){
        if (input.isPressed){
            // playerRgbd2d.velocity = new Vector2 (playerRgbd2d.velocity.x,playerRgbd2d.velocity.y + jumpStrenght);
            if (player_check_isOnGround()){
            playerRgbd2d.velocity += new Vector2 (0f,jumpStrenght);
            }

        }; 
    }

    void player_Run1(Vector2 direction, float speed){

        Vector2 runsvelocity = new Vector2 (direction.x * speed, playerRgbd2d.velocity.y);
        playerRgbd2d.velocity = runsvelocity;

    }
    void player_Run11(){
        playerRgbd2d.velocity = new Vector2 (movementInput.x*movementSpeed,playerRgbd2d.velocity.y);
    }
    void player_Run(Vector2 direction, float speed){
        Vector2 runsvelocity = new Vector2 (direction.x * speed, playerRgbd2d.velocity.y);
        playerRgbd2d.AddForce(runsvelocity);
    }
    void updateMovement(){
        // for running movements
        player_Run1(movementInput,movementSpeed);
        isRunning = player_isRunning();
        // if (player_isRunning()){
        //     playerStatus = playerStatusList[1];
        // }
        // updateSprite();

        // for climbing movement
        player_Climb1(movementInput,climbSpeed);
    }
    void updateSprite(){
        if (/*playerStatus == "isRunning"*/isRunning){
            FlipSprite();
            player_setRunAnimation_True();
        }
        else {
            player_setRunAnimation_False();
        }

        player_setClimbingAnimation();
    }
    bool player_isRunning(){
        if (Mathf.Abs(movementInput.x*movementSpeed) > Mathf.Epsilon){
            return true;
        }
        return false;
    }
    void FlipSprite(){
        if (/*playerStatus == "isRunning"*/isRunning){
            transform.localScale = new Vector2 (Mathf.Sign(movementInput.x),transform.localScale.y);
        }

    }
    void player_Climb1(Vector2 movementInput,float climbSpeed){
        if (playerCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("ladders1"))){
            playerRgbd2d.gravityScale = 0f;
            Vector2 climbVelocity = new Vector2 (playerRgbd2d.velocity.x,movementInput.y*climbSpeed);
            playerRgbd2d.velocity = climbVelocity;
            // playerAnimator.SetBool("isClimbing",Mathf.Abs(playerRgbd2d.velocity.y*movementInput.y) > Mathf.Epsilon)
        }
        else {
            playerRgbd2d.gravityScale = gravityDefault;
        }
    }
    void player_setClimbingAnimation(){
        playerAnimator.SetBool("isClimbing",Mathf.Abs(playerRgbd2d.velocity.y*movementInput.y) > Mathf.Epsilon);
    }
    void player_setRunAnimation_True(){
        playerAnimator.SetBool("isMoving",true);
    }
    void player_setRunAnimation_False(){
        playerAnimator.SetBool("isMoving",false);
    }
    bool player_check_isOnGround(){
        return (playerCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("platform1")));
    }

    // }
}
