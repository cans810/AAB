using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TournamentSystem : MonoBehaviour
{
    public GameObject InBattleRelatedStuff;
    // Update is called once per frame

    GameObject player;
    GameObject enemy;

    public bool beatenCurrentBoss;

    public GameObject goToTownButton;
    public GameObject nextBattleButton;

    public void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        beatenCurrentBoss = false;
        goToTownButton.SetActive(false);
        nextBattleButton.SetActive(false);
    }

    public void Update(){

        if (!PlayerLevelManager.leveledUP){
            if (BattleSystem.state == BattleState.IN_AFTER_BATTLE_WAITING && enemy.GetComponent<Enemy>().isABoss && enemy.GetComponent<EntityAttributes>().HP <= 0 && player.GetComponent<ActionsManager>().endBattle){
                beatenCurrentBoss = true;
                player.GetComponent<Player>().inTournament = false;
                goToTownButton.SetActive(true);
            }

            else if (BattleSystem.state == BattleState.IN_AFTER_BATTLE_WAITING && player.GetComponent<Player>().inTournament && !enemy.GetComponent<Enemy>().isABoss && enemy.GetComponent<EntityAttributes>().HP <= 0 && player.GetComponent<ActionsManager>().endBattle){
                nextBattleButton.SetActive(true);
            }
        }
        else if (PlayerLevelManager.leveledUP){
            if (BattleSystem.state == BattleState.IN_AFTER_BATTLE_WAITING && enemy.GetComponent<Enemy>().isABoss && enemy.GetComponent<EntityAttributes>().HP <= 0 && player.GetComponent<ActionsManager>().endBattle){
                beatenCurrentBoss = true;
                player.GetComponent<Player>().inTournament = false;
            }
            else if (BattleSystem.state == BattleState.IN_AFTER_BATTLE_WAITING && player.GetComponent<Player>().inTournament && !enemy.GetComponent<Enemy>().isABoss && enemy.GetComponent<EntityAttributes>().HP <= 0 && player.GetComponent<ActionsManager>().endBattle){
                
            }
        }

    }

    public void goToTown(){
        GameObject sceneLoader = GameObject.Find("SceneLoader");
        sceneLoader.GetComponent<SceneLoader>().FadeToLevel("TownScene");

        player.GetComponent<Player>().inTournament = false;
    }
    
    // public void nextBattle(){
    //     if (Player.Instance.gameObject.GetComponent<EntityAttributes>().HP > 0){
    //         TournamentManager.Instance.enemysToBeat -= 1;

    //         if (TournamentManager.Instance.enemysToBeat <= -1){
    //             SceneManager.LoadSceneAsync("TownScene");
    //         }
    //         else{
    //             if(EnemyGeneratorController.Instance != null){
    //                 Destroy(EnemyGeneratorController.Instance);
    //             }
    //             GameObject sceneLoader = GameObject.Find("SceneLoader");
    //             sceneLoader.GetComponent<SceneLoader>().FadeToLevel("TournamentShowcaseScene");
    //         }
    //     }
    //     else{
    //         Player.Instance.resetAfterBattle();
    //         TournamentManager.Instance.enemysToBeat -= 1;
    //         if(EnemyGeneratorController.Instance != null){
    //             Destroy(EnemyGeneratorController.Instance);
    //         }
    //         GameObject sceneLoader = GameObject.Find("SceneLoader");
    //         sceneLoader.GetComponent<SceneLoader>().FadeToLevel("TournamentShowcaseScene");
    //     }
    // }

    public void continueTournament(){
        TournamentManager.Instance.enemysToBeat -= 1;
        if(EnemyGeneratorController.Instance != null){
             Destroy(EnemyGeneratorController.Instance);
        }
        GameObject sceneLoader = GameObject.Find("SceneLoader");
        sceneLoader.GetComponent<SceneLoader>().FadeToLevel("TournamentShowcaseScene");
    }

}
