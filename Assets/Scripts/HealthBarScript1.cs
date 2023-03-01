using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript1 : MonoBehaviour
{
    // NewPlayer1LogicsScript1 Player_Logics;
    public Image HealthBarImage; 
    // int HP;
    // int HP_Max;

    // Start is called before the first frame update
    void Start()
    {
        // Player_Logics = GameObject.FindGameObjectWithTag("Player").GetComponent<NewPlayer1LogicsScript1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateHealthBar(int HP, int HP_Max){
        HealthBarImage.fillAmount = Mathf.Clamp((float)HP/HP_Max,0.0f,1.0f);
        Debug.Log(HealthBarImage.fillAmount);
    }
}
