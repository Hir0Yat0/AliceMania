using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficutySettingScript1 : MonoBehaviour
{
    GameSessionScript[] listofgamesession;
    int numofgamesession;
    public int DifficultyMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake() {
        // PlayerLogics = GameObject.FindGameObjectWithTag("Player").GetComponent<NewPlayer1LogicsScript1>();
        listofgamesession = FindObjectsOfType<GameSessionScript>();
        numofgamesession = listofgamesession.Length;
        if(numofgamesession > 1){
            Destroy(gameObject);
        }
        else {
        // PlayerLogics = GameObject.FindGameObjectWithTag("Player").GetComponent<NewPlayer1LogicsScript1>();
        DontDestroyOnLoad(gameObject);
        // Lives.text = player_lives.ToString();
        // Scores.text = (scores).ToString();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
