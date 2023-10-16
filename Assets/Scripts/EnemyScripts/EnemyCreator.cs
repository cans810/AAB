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

        if (player.GetComponent<Player>().inATournament && tournamentManager.enemysToBeat != 0){
            enemyGenerator.GetComponent<EnemyGeneratorController>().generateRandomEnemy();
            EnemyGeneratorController.Instance.GetComponent<Enemy>().isABoss = false;
        }
        // RomulusTheLeatherman
        else if(player.GetComponent<Player>().inATournament && tournamentManager.currentTournament.Equals("first") && !EnemyGeneratorController.SlainRomulusTheLeatherman && tournamentManager.enemysToBeat == 0){
            enemyGenerator.GetComponent<EnemyGeneratorController>().generateRomulusTheLeatherman();
            EnemyGeneratorController.Instance.GetComponent<Enemy>().isABoss = true;
        }
        // Ferullus
        else if(player.GetComponent<Player>().inATournament && tournamentManager.currentTournament.Equals("second") && !EnemyGeneratorController.SlainFerullus && tournamentManager.enemysToBeat == 0){
            enemyGenerator.GetComponent<EnemyGeneratorController>().generateFerullus();
            EnemyGeneratorController.Instance.GetComponent<Enemy>().isABoss = true;
        }
        else if (!player.GetComponent<Player>().inATournament){
            enemyGenerator.GetComponent<EnemyGeneratorController>().generateRandomEnemy();
            EnemyGeneratorController.Instance.GetComponent<Enemy>().isABoss = false;
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

