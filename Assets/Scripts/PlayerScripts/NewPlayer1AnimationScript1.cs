using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer1AnimationScript1 : MonoBehaviour
{
    Rigidbody2D Player_RGBD2D;
    Animator Player_Animator;
    GameObject textbubble1;
    GameObject textbubble1_exclamationmark1;
    GameObject textbubble1_dotdotdot1;
    GameObject textbubble1_heartheart;
    // Start is called before the first frame update
    void Start()
    {
        Player_RGBD2D = gameObject.GetComponent<Rigidbody2D>();
        Player_Animator = gameObject.GetComponent<Animator>();
        if (Player_Animator == null){
            Debug.Log("player_animator null");
        }
        textbubble1 = gameObject.transform.Find("speech-bubble-talk-bubble-chat-bubble-icon-transparent-free-png (1) Variant").gameObject;
        textbubble1_exclamationmark1 = textbubble1.transform.Find("pngtree-red-exclamation-mark-png-image_5412624. (1)png (Missing Prefab with guid_ ec324a8a4fd3c89459766bff3565e9cb)").gameObject;
        textbubble1_dotdotdot1 = textbubble1.transform.Find("dotdotdot").gameObject;
        textbubble1_heartheart = textbubble1.transform.Find("Two-Hearts-Emoji (1)").gameObject;
        Debug.Log(textbubble1.transform.childCount);
        // textbubble1 = gameObject.transform.Find("speech-bubble-talk-bubble-chat-bubble-icon-transparent-free-png (1) Variant").gameObject;
        // textbubble1_exclamationmark1 = textbubble1.transform.Find("pngtree-red-exclamation-mark-png-image_5412624. (1)png").gameObject;
        // textbubble1_dotdotdot1 = textbubble1.transform.Find("dotdotdot").gameObject;
    }
    private void Awake() {
        // textbubble1 = gameObject.transform.Find("speech-bubble-talk-bubble-chat-bubble-icon-transparent-free-png (1) Variant").gameObject;
        // textbubble1_exclamationmark1 = textbubble1.transform.Find("pngtree-red-exclamation-mark-png-image_5412624. (1)png").gameObject;
        // textbubble1_dotdotdot1 = textbubble1.transform.Find("dotdotdot").gameObject;
        // textbubble1_heartheart = textbubble1.transform.Find("Two-Hearts-Emoji (1)").gameObject;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     // FlipSprite();
    // }

    public void FlipSprite(Vector2 movementInput){
        if (Mathf.Abs(movementInput.x) > Mathf.Epsilon){
        gameObject.transform.localScale = new Vector2(Mathf.Sign(movementInput.x),gameObject.transform.localScale.y);
        }
    }
    
    public bool isRunning(Vector2 movementInput,float velocity){
        // return (Mathf.Abs(movementInput.x * velocity) > Mathf.Epsilon);
        return (Mathf.Abs(movementInput.x) > Mathf.Epsilon && Mathf.Abs(velocity) > Mathf.Epsilon);
    }

    public void setRunningAnimation(bool setAnimationState){
        Player_Animator.SetBool("isMoving",setAnimationState);        
    }

    public void setClimbingAnimation(bool setAnimationState){
        Player_Animator.SetBool("isClimbing",setAnimationState);
    }
    public void setFiringAnimation(){
        Player_Animator.SetTrigger("isShooting1");
    }

    public void setTextBubble1(bool textbubble){
        textbubble1.SetActive(textbubble);
    }
    public void setTextBubble1_ExclamationMark(bool exclamationmark){
        textbubble1_exclamationmark1.SetActive(exclamationmark);
    }
    public void setTextBubble1_DotDotDot(bool dotdotdot){
        textbubble1_dotdotdot1.SetActive(dotdotdot);
    }
    public void setTextBubble1_HeartHeart(bool heartheart){
        textbubble1_heartheart.SetActive(heartheart);
    }
}
