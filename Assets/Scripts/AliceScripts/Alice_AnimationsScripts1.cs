using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice_AnimationsScripts1 : MonoBehaviour
{
    GameObject player;
    public bool Started = false;
    GameObject textbubble1;
    GameObject textbubble1_exclamationmark1;
    GameObject textbubble1_dotdotdot1;
    GameObject textbubble1_heartheart;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        textbubble1 = gameObject.transform.Find("speech-bubble-talk-bubble-chat-bubble-icon-transparent-free-png (1) Variant").gameObject;
        textbubble1_exclamationmark1 = textbubble1.transform.Find("pngtree-red-exclamation-mark-png-image_5412624. (1)png (Missing Prefab with guid_ ec324a8a4fd3c89459766bff3565e9cb)").gameObject;
        textbubble1_dotdotdot1 = textbubble1.transform.Find("dotdotdot").gameObject;
        textbubble1_heartheart = textbubble1.transform.Find("Two-Hearts-Emoji (1)").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Started){
            return;
        }
        FlipSprite();
    }
    void FlipSprite(){
        gameObject.transform.localScale = new Vector2(Mathf.Sign((player.transform.position.x - gameObject.transform.position.x)),gameObject.transform.localScale.y);
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
