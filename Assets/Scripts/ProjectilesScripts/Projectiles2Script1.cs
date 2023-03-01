using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles2Script1 : MonoBehaviour
{
    public GameObject owner;
    Rigidbody2D rgbd2d;
    CapsuleCollider2D capsulecollider;
    float speed = 5.0f;
    public Transform target;
    ActionManagerScript action;
    Vector2 direction;
    int dmg = 5;

    // Start is called before the first frame update
    void Start()
    {
        rgbd2d = this.gameObject.GetComponent<Rigidbody2D>();
        capsulecollider = this.gameObject.GetComponent<CapsuleCollider2D>();
        action = GameObject.Find("/GameSession/ActionManager").GetComponent<ActionManagerScript>();
        direction = (target.position - owner.transform.position).normalized;
        Destroy(gameObject,30.0f);
    }
    private void FixedUpdate() {
        // rgbd2d.velocity = (target.position - owner.transform.position).normalized * speed;
        rgbd2d.velocity = direction * speed;

    }

    // Update is called once per frame
    void Update()
    {
        // rgbd2d.velocity = (target.position - owner.transform.position) * speed;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            target.gameObject.GetComponent<NewPlayer1LogicsScript1>().DecreaseHP(action.DealDamage(owner.gameObject,dmg,target.gameObject));
            Destroy(gameObject);
        }
        Destroy(gameObject,0.5f);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject,0.5f);
    }

}
