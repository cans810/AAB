using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairColorSetter : MonoBehaviour
{

    public GameObject Instance;
    public Color HairColor;
    public Color FacialHairColor;

    public GameObject hairObject;
    public GameObject facialHairObject;

    public void Awake(){
        ChangeHairColors();
    }
    
    private void ChangeHairColors(){
        hairObject.GetComponent<SpriteRenderer>().color = HairColor;
        facialHairObject.GetComponent<SpriteRenderer>().color = FacialHairColor;
    }
}

