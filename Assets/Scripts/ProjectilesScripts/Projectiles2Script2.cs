using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles2Script2 : MonoBehaviour
{
    public GameObject owner;
    Rigidbody2D rgbd2d;
    CapsuleCollider2D capsulecollider;
    float speed1 = 4.0f;
    float speed2 = 2.0f;
    public Transform target;
    ActionManagerScript action;
    int dmg = 10;
    int phase = 0;
    float waittime = 0;
    float phase1_duration = 2.0f;
    Vector2 phase1_direction;
    Vector2 phase2_direction;
    // Alice_LogicsScripts1 Alice_Logics;

    // Start is called before the first frame update
    void Start()
    {
        rgbd2d = this.gameObject.GetComponent<Rigidbody2D>();
        capsulecollider = this.gameObject.GetComponent<CapsuleCollider2D>();
        action = GameObject.Find("/GameSession/ActionManager").GetComponent<ActionManagerScript>();
        Destroy(gameObject,30.0f);
        phase1_direction = new Vector2(Random.Range(-1.0f,1.0f),Random.Range(0.0f,1.0f));
        // phase2_direction = new Vector2(owner.transform);
        phase2_direction = (target.position-owner.transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        waittime += Time.deltaTime;
        if (phase == 0 && waittime >= phase1_duration){
            phase = 1;
            waittime = 0;
        }
        // phase1();
        // phase2();

    }
    private void FixedUpdate() {
        phase1();
        phase2();
    }

    void phase1(){
        if (phase != 0){
            return;
        }
        rgbd2d.velocity = phase1_direction * speed1;
        // gameObject.transform.LookAt(target); 
    }
    void phase2(){
        if (phase != 1){
            return;
        }
        rgbd2d.velocity = phase2_direction * speed2;
        // gameObject.transform.localScale = phase2_direction;
        // gameObject.transform.LookAt(target);
        // gameObject.transform.RotateAround(gameObject.transform.position,Vector2.up,0.2f*Time.deltaTime);        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            target.gameObject.GetComponent<NewPlayer1LogicsScript1>().DecreaseHP(action.DealDamage(owner.gameObject,dmg,target.gameObject));
            Destroy(gameObject,0.2f);
        }
        Destroy(gameObject,0.5f);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject,0.5f);
    }
}
