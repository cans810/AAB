using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentProgressObjectManager : MonoBehaviour
{

    public GameObject ShowcasePillarPrefab;
    public GameObject BossShowcasePillarPrefab;

    public int initialX,initialY,initialZ;

    public void OnEnable(){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(2000,0,0);

        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy != null){
            enemy.transform.position = new Vector3(2000,0,0);
        }
    }

    private void Start()
    {
        initialX = 150;
        initialY = -263;
        initialZ = 0;
        
        StartCoroutine(SpawnShowcasePillars());
    }

    IEnumerator SpawnShowcasePillars()
    {
        for (int i = TournamentManager.Instance.totalEnemysToBeat; i > 0; i--)
        {
            GameObject ShowcasePillar = Instantiate(ShowcasePillarPrefab);
            ShowcasePillar.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            ShowcasePillar.GetComponent<RectTransform>().position = new Vector3(initialX - (150 * i), initialY, initialZ);
            ShowcasePillar.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>().transform, false);

            // Wait for 0.5 seconds before the next iteration
            yield return new WaitForSeconds(0.5f);

            if (i == 1){
                GameObject BossShowcasePillar = Instantiate(BossShowcasePillarPrefab);
                BossShowcasePillar.GetComponent<RectTransform>().localScale = new Vector3(1.3f, 1.3f, 1.3f);
                BossShowcasePillar.GetComponent<RectTransform>().position = new Vector3(initialX - (150 * (i-1)), initialY, initialZ);
                BossShowcasePillar.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>().transform, false);
            }
        }
    }

    public void continueTournament(){
        GameObject sceneLoader = GameObject.Find("SceneLoader");
        sceneLoader.GetComponent<SceneLoader>().FadeToLevel("ShowcaseEnemy");
    }
}
