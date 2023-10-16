using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameIntroObjectsCont : MonoBehaviour
{
    public GameObject inspiredBy;
    public GameObject agameby;
    public GameObject gameIntro;

    public void setMainMenuOn(){
        GameObject sceneLoader = GameObject.Find("SceneLoader");
        sceneLoader.GetComponent<SceneLoader>().FadeToLevel("MainMenu");
    }

    public void setInspiredByOff(){
        inspiredBy.SetActive(false);
    }

    public void setAgamebyOn(){
        agameby.SetActive(true);
    }

    public void setAgamebyOff(){
        agameby.SetActive(false);
    }
}
