using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript1 : MonoBehaviour
{
    GameObject playerToTrack;


    // Start is called before the first frame update
    void Start()
    {

        playerToTrack = GameObject.FindGameObjectWithTag("Player"); 

    }

    // Update is called once per frame
    void Update()
    {
        if (!(isOnCam_player(playerToTrack))){
            moveCam(playerToTrack);
        }
    }
    bool isOnCam_player(GameObject player){

        if ((player.transform.position.x < 1)){
            
        }

        return false;
    }
    
    void moveCam(GameObject player){

    }

    
}
