using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice_CombatScripts1 : MonoBehaviour
{
    GameObject Alice;
    Alice_LogicsScripts1 Alice_Logic;
    [SerializeField] GameObject projectiles1;
    [SerializeField] GameObject projectiles2;
    GameObject player;
    float cooldown1 = 5.0f;
    float cooldown2 = 7.5f;
    float cooldown3 = 0.5f;
    float cooldown4 = 0.5f;
    // Action[] skillslots;
    // void[] skill;
    float waittime1 = 0;
    float waittime2 = 0;
    float waittime3 = 0;
    float waittime4 = 0;
    int shotsfired1 = 0;
    int shotsfired2 = 0;
    bool shotsfired_initialized1 = false;
    bool shotsfired_initialized2 = false;
    public bool isAggro = false;
    public int multiplier1 = 1;
    public int multiplier2 = 1;
    GameSessionScript gameSession;
    // [SerializeField] public AudioClip sfx1;
    // [SerializeField] public AudioClip sfx2;

    // Start is called before the first frame update
    void Start()
    {
        Alice = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        gameSession = GameObject.Find("GameSession").GetComponent<GameSessionScript>();
        multiplier2 = gameSession.DifficultyLevel;
        // multiplier1 = Alice_Logic.multiplier1;
        // waittime1 = 0;
        // waittime2 = 0;
        // cooldown1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Alice.transform.position,(player.transform.position - Alice.transform.position));
        if (!isAggro){
            return;
        }
        waittime1 += Time.deltaTime;
        waittime2 += Time.deltaTime;
        waittime3 += Time.deltaTime;
        waittime4 += Time.deltaTime;
        if (waittime1 >= cooldown1){
            if (!shotsfired_initialized1){
            shotsfired1 = Random.Range(3,6) * multiplier1 * multiplier2;
            shotsfired_initialized1 = true;

            }
            if (waittime3 >= cooldown3){
            ATK1();
            shotsfired1--;
            waittime3 = 0;
            }
            if (shotsfired1 == 0){
                waittime1 = 0;
                shotsfired_initialized1 = false;
            }
        }
        if (waittime2 >= cooldown2){
            
        if (waittime2 >= cooldown2){
            if (!shotsfired_initialized2){
            shotsfired2 = Random.Range(3,6) * multiplier1 * multiplier2;
            shotsfired_initialized2 = true;

            }
            if (waittime4 >= cooldown4){
            ATK2();
            shotsfired2--;
            waittime4 = 0;
            }
            if (shotsfired2 == 0){
                waittime2 = 0;
                shotsfired_initialized2 = false;
            }
        }
    }
    // void TP(){

    // }
    void ATK1(){
        GameObject projectile = Instantiate(projectiles1,gameObject.transform.position,gameObject.transform.rotation);
        Projectiles2Script1 projectile_script = projectile.GetComponent<Projectiles2Script1>();
        projectile_script.owner = this.gameObject;
        projectile_script.target = player.transform;
        // AudioSource.PlayClipAtPoint(sfx1,gameObject.transform.position);
    }
    void ATK2(){
        GameObject projectile = Instantiate(projectiles2,gameObject.transform.position,gameObject.transform.rotation);
        Projectiles2Script2 projectile_script = projectile.GetComponent<Projectiles2Script2>();
        projectile_script.owner = this.gameObject;
        projectile_script.target = player.transform;
        // AudioSource.PlayClipAtPoint(sfx2,gameObject.transform.position);
    }
    // void Skill1(){

    // }
    // void Skill2(){

    // }
}}
