using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScreenController : MonoBehaviour
{
    public void Awake(){
        gameObject.SetActive(false);
    }
    
    public void startBattle(){
        GameObject showcaseObject = GameObject.Find("Showcase");
        showcaseObject.SetActive(false);
        gameObject.SetActive(true);
    }
}
