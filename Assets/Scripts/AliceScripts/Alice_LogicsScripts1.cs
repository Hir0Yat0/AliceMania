using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Alice_LogicsScripts1 : MonoBehaviour
{
    [SerializeField] private int HP = 500;
    public int MaxHP = 500;
    private int ATK = 5;
    private int DEF = 2;
    public GameObject healthbar;
    public HealthBarScript1 healthBarScript;
    GameSessionScript gameSession;
    Alice_AnimationsScripts1 Alice_Animations;
    Alice_CombatScripts1 Alice_Combat;
    Alice_MovementsScripts1 Alice_Movements;

    // Start is called before the first frame update
    void Start()
    {
        healthbar = GameObject.Find("/GameSession/UI_1/Canvas/AliceHealthBar1");
        healthBarScript = GameObject.Find("/GameSession/UI_1/Canvas/AliceHealthBar1/AliceHealthBarInner1").GetComponent<HealthBarScript1>();
        gameSession = GameObject.Find("GameSession").GetComponent<GameSessionScript>();
        Alice_Animations = gameObject.GetComponent<Alice_AnimationsScripts1>();
        Alice_Combat = gameObject.GetComponent<Alice_CombatScripts1>();
        if (SceneManager.GetActiveScene().name == "Scene_Level_2_1"){
            Alice_Animations.Started = true;
            Alice_Combat.isAggro = true;
        }
        if (SceneManager.GetActiveScene().name == "Scene_Level_3_1"){
            Alice_Animations.Started = true;
            Alice_Combat.isAggro = true;
            Alice_Movements.Started = true;
            Alice_Combat.multiplier1 = 2;
        }

    }
    private void Awake() {
        // healthbar.SetActive(true);
    }
    private void OnEnable() {
        // healthbar.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0){
            gameObject.SetActive(false);
            healthbar.SetActive(false);
            gameSession.onWin();
        }   
    }
    private void OnDisable() {
        healthbar.SetActive(false);
    }

    public int getHP(){
        return HP;
    }

    public int getATK(){
        return ATK;
    }
    public int getDEF(){
        return DEF;
    }
    [ContextMenu("DecreaseHP")]
    void testtest1(){
        DecreaseHP(100);
    }
    [ContextMenu("bar fill test1")]
    void barfilltest1(){
        healthBarScript.updateHealthBar(HP,MaxHP);
    }
    public int DecreaseHP(int hp){
        HP = HP - hp;
        HP = Mathf.Max(HP,0);
        healthBarScript.updateHealthBar(HP,MaxHP);
        Debug.Log("Damge Dealt!");
        // Player_HP = Player_HP - hp;
        // Player_HP = Mathf.Max(Player_HP,0);
        // healthbar.updateHealthBar(Player_HP,Player_MaxHP);
        return HP;
    }
    public void setHealthbarActive(bool value){
        healthbar.SetActive(value);
    }
}
