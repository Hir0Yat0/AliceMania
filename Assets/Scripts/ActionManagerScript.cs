using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManagerScript : MonoBehaviour
{
    private void Awake() {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int DealDamage(GameObject dealer, int dmg, GameObject taker){
        // dmg dealt = dmg + (dealer buff/debuff) - (taker def + (taker buff/debuff))
        // return total dmg dealt
        int DamageDealt = 0;

        if (dealer.TryGetComponent<NewPlayer1LogicsScript1>(out NewPlayer1LogicsScript1 dealer_logics_player)){
            DamageDealt += dealer_logics_player.getPlayer_ATK() + dmg;
        }
        else if (dealer.TryGetComponent<Alice_LogicsScripts1>(out Alice_LogicsScripts1 dealer_logics_Alice)){
            DamageDealt += dealer_logics_Alice.getATK() + dmg;
        }

        if (taker.TryGetComponent<NewPlayer1LogicsScript1>(out NewPlayer1LogicsScript1 taker_logics_player)){
            DamageDealt -= taker_logics_player.getPlayer_DEF(); 
        }
        else if (taker.TryGetComponent<Alice_LogicsScripts1>(out Alice_LogicsScripts1 taker_logics_Alice)){
            DamageDealt -= taker_logics_Alice.getDEF();
        }

        return Mathf.Max(DamageDealt,0);
    }

    private int DecreaseHP(GameObject entity,int hp){
        // decrease hp of gameobject entity by specify hp
        // entity.hp -= hp

        return 0;
    }

    public int CounterAttack(GameObject caller, Projectiles1Script1 projectile){
        // deal 50% dmg to the owner of projectile that got counter

        return 0;
    }

    public int SpecialSkill(GameObject caller, int skillnumber, GameObject target=null){
        // call the [skillnumber] equipped special skill for players,
        // else call assigned special skill of other entities

        return 0;
    }


}
