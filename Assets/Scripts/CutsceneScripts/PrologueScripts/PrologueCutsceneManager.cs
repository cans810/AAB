using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrologueCutsceneManager : MonoBehaviour
{
    public GameObject xenarchusTextObject;
    public static string line2 = "in a deep moving current";

    public void Awake(){
        GameObject player = GameObject.Find("Player");
        player.transform.position = new Vector3(-1000,-3.5f,0);
    }

    public void nextXenarchusLine(){
        xenarchusTextObject.GetComponent<TextMeshProUGUI>().text = line2;
    }
}
