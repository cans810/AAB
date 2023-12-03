using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public GameObject PrologueCutscene;
    public GameObject FirstBattleCutscene;

    public static CutsceneManager Instance { get; private set; }

    public bool PrologueCutSceneDone = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (PrologueCutSceneDone){
            PrologueCutscene.SetActive(false);
        }
        else{
            PrologueCutscene.SetActive(true);
        }
        FirstBattleCutscene.SetActive(false);
    }

    public void RunCutscene(string cutsceneName){

        if (cutsceneName.Equals("prologue")){
            PrologueCutscene.SetActive(true);
        }

        else if (cutsceneName.Equals("firstbattle")){
            FirstBattleCutscene.SetActive(true);
        }

    }
}
