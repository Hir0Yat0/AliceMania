using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice_MovementsScripts1 : MonoBehaviour
{
    Transform[] TP_points;
    [SerializeField] float cooldown1;
    float cooldown2 = 7f;
    // float cooldown3;
    GameObject Alice;
    GameObject TP_Points;
    Rigidbody2D Alice_RGBD2D;
    Alice_AnimationsScripts1 Alice_Animations;
    int TP_points_counts;
    // int * cooldown;
    public bool Started = false; 


    // Start is called before the first frame update
    void Start()
    {
        Alice = this.gameObject;
        Alice_RGBD2D = Alice.GetComponent<Rigidbody2D>();
        Alice_Animations = Alice.GetComponent<Alice_AnimationsScripts1>();
        // TP_Points = Alice.transform.GetChild(0).gameObject;
        TP_Points = GameObject.FindWithTag("TP_Points1");
        if (TP_Points == null){
            Debug.Log("abcdef");
        }
        TP_points_counts = TP_Points.transform.childCount;
        TP_points = new Transform[TP_points_counts];
        for (int i = 0; i < TP_points_counts;i++){
        TP_points[i] = TP_Points.transform.GetChild(i);
        }
        cooldown1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Started){
            return;
        }
        if (cooldown1 >= cooldown2){
            cooldown1 = 0;
            TP();
        }
        cooldown1 += Time.deltaTime; 
    }

    void TP(){
        Alice.transform.position = TP_points[Random.Range(0,TP_points_counts)].transform.position;
        Debug.Log("Warp!");
    }
    // void ATK1(){

    // }
    // void ATK2(){

    // }
    // void Skill1(){

    // }
    // void Skill2(){

    // }
}
