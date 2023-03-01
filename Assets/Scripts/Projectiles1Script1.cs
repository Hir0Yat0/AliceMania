using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles1Script1 : MonoBehaviour
{
    [SerializeField] float speedHorizontal = 10f;
    [SerializeField] Rigidbody2D rgbd2d;
    [SerializeField] public GameObject owner;
    // private float projectile_maxlifetime = 5;
    // private float projectile_lifetime = 0;
    [SerializeField] CapsuleCollider2D projectile_capsulecollider2d;
    [SerializeField] CircleCollider2D projectile_circlecollider2d;
    float hitanimationtime = 0;
    ActionManagerScript action;
    int dmg = 5;


    // Start is called before the first frame update
    void Start()
    {
        // projectile_lifetime = 0;
        rgbd2d = GetComponent<Rigidbody2D>();
        // owner.transform.localScale = new Vector2(owner.transform.localScale.x*2,owner.transform.localScale.y*2);
        // public Vector2 owner.transform.localScale = new Vector2(owner.transform.localScale);
        projectile_capsulecollider2d = GetComponent<CapsuleCollider2D>();
        projectile_circlecollider2d = GetComponent<CircleCollider2D>();
        // rgbd2d.bodyType
        transform.localScale *= new Vector2(Mathf.Sign(owner.transform.localScale.x),Mathf.Sign(owner.transform.localScale.y));
        speedHorizontal *= Mathf.Sign(transform.localScale.x);
        // Player1AnimationScript1.FlipSprite(movementInput);
        action = GameObject.Find("/GameSession/ActionManager").GetComponent<ActionManagerScript>();
        Destroy(this.gameObject,5); 
        // Debug.Log("Projectile!");
        // Destroy(this.gameObject);
    }
    private void Awake() {
        // rgbd2d = GetComponent<Rigidbody2D>();
        // projectile_capsulecollider2d = GetComponent<CapsuleCollider2D>();
        // projectile_circlecollider2d = GetComponent<CircleCollider2D>();
        // transform.localScale *= new Vector2(Mathf.Sign(owner.transform.localScale.x),Mathf.Sign(owner.transform.localScale.y));
        // speedHorizontal *= Mathf.Sign(transform.localScale.x);
        // Destroy(this.gameObject,5); 
    }

    // Update is called once per frame
    void Update()
    {
        // if (projectile_lifetime >= projectile_maxlifetime){
            // Destroy(this.gameObject);
        // }
        // Destroy(this.gameObject,5);
        // rgbd2d.velocity = new Vector2(speed,rgbd2d.velocity.y);
        // projectile_lifetime += Time.deltaTime;

    }
    void FixedUpdate() {
        rgbd2d.velocity = new Vector2(speedHorizontal,rgbd2d.velocity.y);    
    }

    private void OnBecameInvisible() {
        Destroy(this.gameObject,0.1f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy1"){

        }
        else if (other.tag == "Bosses1"){

        }
        else if (other.tag == "Alice1"){
            other.gameObject.GetComponent<Alice_LogicsScripts1>().DecreaseHP(action.DealDamage(owner,dmg,other.gameObject));
        }
        // else if (other.tag == "Platforms1"){
        //     // play animation and destroy
        //     Debug.Log("Projectile Hit A Platform!");
        //     Destroy(this.gameObject);
        // else if (){

        // }
        // }
        Debug.Log("Projectile Hit A Platform! 1");
        Destroy(this.gameObject,hitanimationtime);
        
    }
    // private void Awake() {
        
    // }
    private void OnCollisionEnter2D(Collision2D other) {
        // other.GetHashCode();
        Debug.Log("Projectile Hit A Platform! 2");
        Destroy(this.gameObject,hitanimationtime);
    }
}
