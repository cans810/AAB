using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyCreator : MonoBehaviour
{
    private GameObject enemy;
    public bool isEnemyABoss;

    public GameObject ShowcaseEnemy;
    public GameObject BossShowcase;

    void Awake(){
        GameObject player = GameObject.Find("Player");

        GameObject enemyGenerator = GameObject.Find("GladiatorGenerator");

        if(player.GetComponent<EntityAttributes>().level == 2 && !EnemyGeneratorController.SlainRomulusTheLeatherman){
            isEnemyABoss = true;
            enemyGenerator.GetComponent<EnemyGeneratorController>().generateRomulusTheLeatherman();
        }
        else if(player.GetComponent<EntityAttributes>().level == 3 && !EnemyGeneratorController.SlainFerullus){
            isEnemyABoss = true;
            enemyGenerator.GetComponent<EnemyGeneratorController>().generateFerullus();
        }
        else{
            isEnemyABoss = false;
            enemyGenerator.GetComponent<EnemyGeneratorController>().generateRandomEnemy();
        }

        enemy = EnemyGeneratorController.Instance;

        enemy.GetComponent<EntityAttributes>().updatePowerValue();

        if (isEnemyABoss){
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

