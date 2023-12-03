using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyCreator : MonoBehaviour
{
    private GameObject enemy;

    public GameObject ShowcaseEnemy;
    public GameObject BossShowcase;

    public GameObject TournamentManagerObject;

    void Awake(){
        GameObject player = GameObject.Find("Player");

        GameObject enemyGenerator = GameObject.Find("GladiatorGenerator");
        
        TournamentManagerObject = GameObject.Find("TournamentManager");
        TournamentManager tournamentManager = TournamentManagerObject.GetComponent<TournamentManager>();

        if (player.GetComponent<Player>().inTournament && tournamentManager.enemysToBeat != 0){
            enemyGenerator.GetComponent<EnemyGeneratorController>().generateRandomEnemy();
            EnemyGeneratorController.Instance.GetComponent<Enemy>().isABoss = false;
            EnemyGeneratorController.Instance.GetComponent<Enemy>().inTournament = true;
        }
        // UnluckyFolk
        if(player.GetComponent<EntityAttributes>().level == 1){
            enemyGenerator.GetComponent<EnemyGeneratorController>().generateUnluckyFolk();
        }
        // RomulusTheLeatherman
        else if(player.GetComponent<Player>().inTournament && tournamentManager.currentTournament.Equals("first") && !EnemyGeneratorController.SlainRomulusTheLeatherman && tournamentManager.enemysToBeat == 0){
            enemyGenerator.GetComponent<EnemyGeneratorController>().generateRomulusTheLeatherman();
            EnemyGeneratorController.Instance.GetComponent<Enemy>().isABoss = true;
        }
        // Ferullus
        else if(player.GetComponent<Player>().inTournament && tournamentManager.currentTournament.Equals("second") && !EnemyGeneratorController.SlainFerullus && tournamentManager.enemysToBeat == 0){
            enemyGenerator.GetComponent<EnemyGeneratorController>().generateFerullus();
            EnemyGeneratorController.Instance.GetComponent<Enemy>().isABoss = true;
        }
        // Atticus Bloodthirst
        else if(player.GetComponent<Player>().inTournament && tournamentManager.currentTournament.Equals("third") && !EnemyGeneratorController.SlainAtticusBloodthirst && tournamentManager.enemysToBeat == 0){
            enemyGenerator.GetComponent<EnemyGeneratorController>().generateAtticusBloodthirst();
            EnemyGeneratorController.Instance.GetComponent<Enemy>().isABoss = true;
        }
        // The Mammoth
        else if(player.GetComponent<Player>().inTournament && tournamentManager.currentTournament.Equals("fourth") && !EnemyGeneratorController.SlainTheMammoth && tournamentManager.enemysToBeat == 0){
            enemyGenerator.GetComponent<EnemyGeneratorController>().generateTheMammoth();
            EnemyGeneratorController.Instance.GetComponent<Enemy>().isABoss = true;
        }
        else if (!player.GetComponent<Player>().inTournament){
            enemyGenerator.GetComponent<EnemyGeneratorController>().generateRandomEnemy();
            EnemyGeneratorController.Instance.GetComponent<Enemy>().isABoss = false;
            EnemyGeneratorController.Instance.GetComponent<Enemy>().inTournament = false;
        }

        enemy = EnemyGeneratorController.Instance;

        enemy.GetComponent<EntityAttributes>().updatePowerValue();

        if (EnemyGeneratorController.Instance.GetComponent<Enemy>().isABoss == true){
            ShowcaseEnemy.SetActive(false);
            BossShowcase.SetActive(true);
        }
        else{
            ShowcaseEnemy.SetActive(true);
            BossShowcase.SetActive(false);
        }
    }

    public void OnDisable(){
        enemy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
}

