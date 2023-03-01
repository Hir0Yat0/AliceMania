using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayer1MovementScript1 : MonoBehaviour
{
    Rigidbody2D Player_RGBD2D;
    NewPlayer1LogicsScript1 Player_LogicsScripts1;
    // GameObject player;
    float Player_MovementSpeed = 7.5f;
    float Player_JumpStrength = 300f;
    float gravityDefault;
    Vector2 movementInput;
    CapsuleCollider2D Player_CapsuleCollider2D;
    BoxCollider2D Player_LEGS;
    float Player_MaxMovementSpeed = 7.5f;
    NewPlayer1AnimationScript1 Player1AnimationScript1;
    [SerializeField] Transform weapon;
    [SerializeField] GameObject projectiles;
    [SerializeField] private bool Player_Controllable = true;
    float Player_ClimbSpeed = 5f;
    int ATK_MP_Cost = 1;
    // [SerializeField] public AudioClip sfx1;
    

    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.FindWithTag("Player");
        // if (player == null){
        //     Debug.Log("aaaaa");
        // }
        Player_RGBD2D = gameObject.GetComponent<Rigidbody2D>();
        Player_LogicsScripts1 = gameObject.GetComponent<NewPlayer1LogicsScript1>();
        // Player_MovementSpeed = Player_LogicsScripts1.getPlayer_MovementSpeed();
        // Player_JumpStrength = Player_LogicsScripts1.getPlayer_JumpStrength();
        Player_CapsuleCollider2D = gameObject.GetComponent<CapsuleCollider2D>();
        Player_LEGS = gameObject.GetComponent<BoxCollider2D>();
        gravityDefault = Player_RGBD2D.gravityScale;
        Player1AnimationScript1 = gameObject.GetComponent<NewPlayer1AnimationScript1>();

    }

    // Update is called once per frame
    void Update()
    {
        // Player1AnimationScript1.FlipSprite(movementInput);
        if (!Player_Controllable){
            return;
        }
        Player1AnimationScript1.FlipSprite(movementInput);
        Player_Climb();
    }

    void FixedUpdate() 
    {
        Player_HorizontalMovement();
        if (!Player_Controllable){
            return;
        }
        Player_Climb();
    }
    void LateUpdate() 
    {
        // Player1AnimationScript1.setFiringAnimation(false);
        if (!Player_Controllable){
            return;
        }
    }

    void OnMove(InputValue input){
        movementInput = input.Get<Vector2>();
        Debug.Log(movementInput);
    }

    void OnJump(InputValue input){
        if (input.isPressed && Player_Controllable){
            Player_Jump();
            // Player1AnimationScript1.setJumpingAnimation();
        }
        Debug.Log("Jumping!");
    }

    void OnFire(InputValue input){
        if (input.isPressed && Player_Controllable){
        Player1AnimationScript1.setFiringAnimation();
        Player_ATK();
        }
        // Player1AnimationScript1.setFiringAnimation(false);
    }
    void Player_HorizontalMovement(){
        if (!Player_Controllable){
            return;
        }
        if (!(Player_RGBD2D.velocity.x > Player_MaxMovementSpeed)){
        Player_RGBD2D.AddForce(new Vector2(movementInput.x*Player_MovementSpeed,0));
        }
        Player1AnimationScript1.setRunningAnimation(Player1AnimationScript1.isRunning(movementInput,Player_RGBD2D.velocity.x));
        // Player1AnimationScript1.FlipSprite(movementInput);
    }
    void Player_Jump(){
        if (!Player_Controllable){
            return;
        }
        if(Player_LEGS.IsTouchingLayers(LayerMask.GetMask("platform1"))){
            Player_RGBD2D.AddForce(new Vector2(0,Player_JumpStrength));
            // (playerCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("platform1")));
        }

    }
    void Player_Climb(){
        if (!Player_Controllable){
            Player1AnimationScript1.setClimbingAnimation(false);
            return;
        }
        if (Player_CapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("ladders1"))){
            Player_RGBD2D.gravityScale = 0;
            Player_RGBD2D.velocity = new Vector2(Player_RGBD2D.velocity.x,movementInput.y*Player_ClimbSpeed);
            if (Mathf.Abs(movementInput.y*Player_RGBD2D.velocity.y) > Mathf.Epsilon){
            Player1AnimationScript1.setClimbingAnimation(true);
            }
        }
        else {
            Player_RGBD2D.gravityScale = gravityDefault;
            Player1AnimationScript1.setClimbingAnimation(false);
        }

    }
    void Player_ATK(){
        if (!Player_Controllable){
            return;
        }
        if (Player_LogicsScripts1.getPlayer_MP() < ATK_MP_Cost){
            return;
        }
        GameObject projectile = Instantiate(original:projectiles,weapon.position,transform.rotation);
        Projectiles1Script1 projectile_script = projectile.GetComponent<Projectiles1Script1>();
        projectile_script.owner = this.gameObject;
        Player_LogicsScripts1.DecreaseMP(ATK_MP_Cost);
        // AudioSource.PlayClipAtPoint(sfx1,gameObject.transform.position);
        Debug.Log("Fire!");
        
    }

    public void setPlayer_Controllable(bool controllable){
        Player_Controllable = controllable;
    }
    public bool getPlayer_Controllable(){
        return Player_Controllable;
    }

}
