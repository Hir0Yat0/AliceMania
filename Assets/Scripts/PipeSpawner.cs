    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 5;
    private float timer = 0;
    public float heightOffset = 10;
    public float spawnedPipeMoveSpeed = 23.54f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate){
            timer = timer + Time.deltaTime;
        }
        else {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe(){

        float highestHeight = transform.position.y + heightOffset;
        float lowestHeight = transform.position.y - heightOffset; 

        PipeMoveScript spawnedPipe = Instantiate(pipe,new Vector3(transform.position.x,Random.Range(lowestHeight,highestHeight),transform.position.z),transform.rotation).GetComponent<PipeMoveScript>();
        spawnedPipe.moveSpeed = spawnedPipeMoveSpeed;
    }
}
