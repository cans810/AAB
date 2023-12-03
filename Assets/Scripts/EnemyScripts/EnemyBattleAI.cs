using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleAI : MonoBehaviour
{
    GameObject enemy;
    GameObject player;

    List<string> actions;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject;

        player = GameObject.FindWithTag("Player");

        actions = new List<string>();

        actions.Add("walkright");
        actions.Add("walkleft");
        actions.Add("attacklight");
        actions.Add("attackmedium");
        actions.Add("attackheavy");
        actions.Add("attackleap");
        actions.Add("intimidate");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnluckyFolkAction(){
        int randomAction = UnityEngine.Random.Range(0,7);

        string actionGenerated = actions[randomAction];

        if(actionGenerated.Equals("walkright")){
            if (enemy.GetComponent<EnemyActionsManager>().side == "left"){
                if (enemy.GetComponent<EnemyActionsManager>().canAttack_Melee){
                    UnluckyFolkAction();
                }

                else{
                    enemy.GetComponent<EnemyActionsManager>().moveRight();
                }
            }
            else if (enemy.GetComponent<EnemyActionsManager>().side == "right"){
                enemy.GetComponent<EnemyActionsManager>().moveRight();
            }
        }
        else if(actionGenerated.Equals("walkleft")){
            if (enemy.GetComponent<EnemyActionsManager>().side == "right"){
                if (enemy.GetComponent<EnemyActionsManager>().canAttack_Melee){
                    UnluckyFolkAction();
                }
                else{
                    enemy.GetComponent<EnemyActionsManager>().moveLeft();
                }
            }
            else if (enemy.GetComponent<EnemyActionsManager>().side == "left"){
                enemy.GetComponent<EnemyActionsManager>().moveLeft();
            }
        }
    }

    public void randomlyDoAnAction(){
        
        int randomAction = UnityEngine.Random.Range(0,7);

        string actionGenerated = actions[randomAction];

        if(actionGenerated.Equals("walkright")){
            if (enemy.GetComponent<EnemyActionsManager>().side == "left"){
                if (enemy.GetComponent<EnemyActionsManager>().canAttack_Melee){
                    randomlyDoAnAction();
                }

                else{
                    enemy.GetComponent<EnemyActionsManager>().moveRight();
                }
            }
            else if (enemy.GetComponent<EnemyActionsManager>().side == "right"){
                enemy.GetComponent<EnemyActionsManager>().moveRight();
            }
        }
        else if(actionGenerated.Equals("walkleft")){
            if (enemy.GetComponent<EnemyActionsManager>().side == "right"){
                if (enemy.GetComponent<EnemyActionsManager>().canAttack_Melee){
                    randomlyDoAnAction();
                }
                else{
                    enemy.GetComponent<EnemyActionsManager>().moveLeft();
                }
            }
            else if (enemy.GetComponent<EnemyActionsManager>().side == "left"){
                enemy.GetComponent<EnemyActionsManager>().moveLeft();
            }
        }
        else if(actionGenerated.Equals("attacklight")){
            enemy.GetComponent<EnemyActionsManager>().attackLight();
        }
        else if(actionGenerated.Equals("attackmedium")){
            enemy.GetComponent<EnemyActionsManager>().attackMedium();
        }
        else if(actionGenerated.Equals("attackheavy")){
            enemy.GetComponent<EnemyActionsManager>().attackHeavy();
        }
        else if(actionGenerated.Equals("attackleap")){
            if (enemy.GetComponent<EnemyActionsManager>().side == "left"){
                if (enemy.GetComponent<EnemyActionsManager>().canAttack_Melee){
                    randomlyDoAnAction();
                }

                else{
                    enemy.GetComponent<EnemyActionsManager>().attackLeaping();
                }
            }
            if (enemy.GetComponent<EnemyActionsManager>().side == "right"){
                if (enemy.GetComponent<EnemyActionsManager>().canAttack_Melee){
                    randomlyDoAnAction();
                }

                else{
                    enemy.GetComponent<EnemyActionsManager>().attackLeaping();
                }
            }
        }
        else if(actionGenerated.Equals("intimidate")){
            enemy.GetComponent<EnemyActionsManager>().intimidate();
        }
    }
}
