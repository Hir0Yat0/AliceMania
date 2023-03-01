using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleScript : MonoBehaviour
{
    public LogicManagerScript logicScript;

    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("LogicScripts").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.layer == 3){
        logicScript.scoreUpdate(1);
        }
    }
    // private void OnTriggerEnter2D(Collider2D other) {
        
    // }
}
