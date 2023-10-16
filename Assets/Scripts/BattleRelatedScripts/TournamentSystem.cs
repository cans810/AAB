using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TournamentSystem : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextBattle(){
        if (Player.Instance.gameObject.GetComponent<EntityAttributes>().HP > 0){
            TournamentManager.Instance.enemysToBeat -= 1;

            if (TournamentManager.Instance.enemysToBeat <= -1){
                SceneManager.LoadSceneAsync("TownScene");
            }
            else{
                if(EnemyGeneratorController.Instance != null){
                    Destroy(EnemyGeneratorController.Instance);
                }
                GameObject sceneLoader = GameObject.Find("SceneLoader");
                sceneLoader.GetComponent<SceneLoader>().FadeToLevel("ShowcaseEnemy");
            }
        }
        else{
            Player.Instance.resetAfterBattle();
            TournamentManager.Instance.enemysToBeat -= 1;
            if(EnemyGeneratorController.Instance != null){
                Destroy(EnemyGeneratorController.Instance);
            }
            GameObject sceneLoader = GameObject.Find("SceneLoader");
            sceneLoader.GetComponent<SceneLoader>().FadeToLevel("ShowcaseEnemy");
        }
    }
}
