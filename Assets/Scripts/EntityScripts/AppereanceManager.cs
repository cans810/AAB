using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppereanceManager : MonoBehaviour
{

    public string race;

    public string hair;
    public string facial_hair;

    public GameObject hairObject;
    public GameObject facialHairObject;

    void Awake(){
        //race = "Human";

        //hair = "none";
        //facial_hair = "none";
    }

    void Update(){

        if (race.Equals("Beast") && hairObject.activeSelf && facialHairObject.activeSelf){
            hairObject.SetActive(false);
            facialHairObject.SetActive(false);
        }
        else if (!race.Equals("Beast") && !hairObject.activeSelf && !facialHairObject.activeSelf){
            hairObject.SetActive(true);
            facialHairObject.SetActive(true);
        }

        if (gameObject.GetComponent<EntityEquipment>().HelmetWorn != null){
            hairObject.SetActive(false);
        }
        else if (gameObject.GetComponent<EntityEquipment>().HelmetWorn != null && !race.Equals("Beast")){
            hairObject.SetActive(true);
        }

    }
    
}
