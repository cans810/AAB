using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBattleCutsceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enterFirstBattle(){ 
        GameObject sceneLoader = GameObject.Find("SceneLoader");
        sceneLoader.GetComponent<SceneLoader>().FadeToLevel("ShowcaseEnemy");
    }
}
