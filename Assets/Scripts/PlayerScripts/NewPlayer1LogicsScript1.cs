using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer1LogicsScript1 : MonoBehaviour
{
    [SerializeField] private int Player_HP = 15;
    [SerializeField] private int Player_MP = 10;
    private int Player_ATK = 3;
    private int Player_DEF = 3;
    public int Player_MaxHP = 10;
    public int Player_MaxMP = 10;
    [SerializeField] private float Player_DefaultMovementSpeed = 10f;
    [SerializeField] private float Player_DefaultJumpStrength = 10f;
    GameObject GameSession;
    GameSessionScript GameSession_Script; 
    private int MP_RegenRate = 2; // mp regen rate per seconds
    private int HP_RegenRate = 1; // hp regen rate per seconds
    float waittime1 = 0;
    float waittime2 = 0;
    public HealthBarScript1 healthbar; 
    public HealthBarScript1 mpbar;
    [SerializeField] public int Score = 0;


    // Start is called before the first frame update
    void Start()
    {
        GameSession = GameObject.Find("GameSession");
        GameSession_Script = GameSession.GetComponent<GameSessionScript>();
        healthbar = GameObject.Find("/GameSession/UI_1/Canvas/HealthBar1/HealthBarInner1").GetComponent<HealthBarScript1>();
        mpbar = GameObject.Find("/GameSession/UI_1/Canvas/MPBar1/MPBarInner1").GetComponent<HealthBarScript1>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Player_HP <= 0){
            GameSession_Script.player_defeated();
        }
        waittime1 += Time.deltaTime;
        waittime2 += Time.deltaTime;
        if (waittime1 >= 1.0f && Player_MP < Player_MaxMP){
            Player_MP += MP_RegenRate;
            Player_MP = Mathf.Min(Player_MP,Player_MaxMP);
            mpbar.updateHealthBar(Player_MP,Player_MaxMP);
            waittime1 = 0;
        }   
        if (waittime2 >= 1.5f && Player_HP < Player_MaxHP){
            Player_HP += HP_RegenRate;
            Player_HP = Mathf.Min(Player_HP,Player_MaxHP);
            healthbar.updateHealthBar(Player_HP,Player_MaxHP);
            waittime2 = 0;
        }
    }
    public float getPlayer_DefaultMovementSpeed(){
        return Player_DefaultMovementSpeed;
    }
    public float getPlayer_DefaultJumpStrength(){
        return Player_DefaultJumpStrength;
    }
    public int getPlayer_HP(){
        return Player_HP;
    }
    public int getPlayer_MP(){
        return Player_MP;
    }
    public int getPlayer_ATK(){
        return Player_ATK;
    }
    public int getPlayer_DEF(){
        return Player_DEF;
    }
    public int DecreaseHP(int hp){
        Player_HP = Player_HP - hp;
        Player_HP = Mathf.Max(Player_HP,0);
        healthbar.updateHealthBar(Player_HP,Player_MaxHP);
        return Player_HP;
    }
    public int DecreaseMP(int mp){
        Player_MP = Player_MP - mp;
        Player_MP = Mathf.Max(Player_MP,0);
        mpbar.updateHealthBar(Player_MP,Player_MaxMP);
        return Player_MP;
    }
    // private void OnDestroy() {
    //     GameSession_Script.player_defeated();
    // }
    public int AddScore(int score){
        Score += score;
        return Score;
    }
    public int getScore(){
        return Score;
    }
}
