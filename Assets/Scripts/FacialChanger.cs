using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class FacialChanger : MonoBehaviour
{
    List<string> hairList;
    List<string> facialHairList;

    private int hairNum = 0;
    private int facialHairNum = 0;
    private GameObject entityObject;

    void Start(){
        entityObject = GameObject.FindWithTag("Player");
        
        hairList = new List<string>();
        fillHairs();

        facialHairList = new List<string>();
        fillFacialHairs();

        int randomHairInitial = UnityEngine.Random.Range(0,hairList.Count);
        ChangeHair(randomHairInitial);

        int randomFacialHairInitial = UnityEngine.Random.Range(0,facialHairList.Count);
        ChangeFacialHair(randomFacialHairInitial);
    }

    public void setEntityHairNext(){
        hairNum += 1;
        ChangeHair(hairNum);
    }
    public void setEntityHairPrev(){
        hairNum -= 1;
        ChangeHair(hairNum);
    }

    public void ChangeHair(int hairNum){
        entityObject.GetComponent<AppereanceManager>().hair = hairList[hairNum];
    }

    public void setEntityFacialHairNext(){
        facialHairNum += 1;
        ChangeFacialHair(facialHairNum);
    }
    public void setEntityFacialHairPrev(){
        facialHairNum -= 1;
        ChangeFacialHair(facialHairNum);
    }

    public void ChangeFacialHair(int facialHairNum){
        entityObject.GetComponent<AppereanceManager>().facial_hair = facialHairList[facialHairNum];
    }

    private void fillHairs(){
        hairList.Add("hair_01");
        hairList.Add("hair_02");
        hairList.Add("hair_03");
        hairList.Add("hair_04");
        hairList.Add("hair_05");
        hairList.Add("hair_06");
        hairList.Add("hair_07");
        hairList.Add("hair_08");
        hairList.Add("hair_09");
        hairList.Add("hair_10");
        hairList.Add("hair_11");
        hairList.Add("hair_12");
        hairList.Add("hair_13");
        hairList.Add("hair_14");
        hairList.Add("hair_15");
        hairList.Add("none");
    }
    private void fillFacialHairs(){
        facialHairList.Add("facialhair_01");
        facialHairList.Add("facialhair_02");
        facialHairList.Add("facialhair_03");
        facialHairList.Add("facialhair_04");
        facialHairList.Add("facialhair_05");
        facialHairList.Add("facialhair_06");
        facialHairList.Add("facialhair_07");
        facialHairList.Add("facialhair_08");
        facialHairList.Add("facialhair_09");
        facialHairList.Add("facialhair_10");
        facialHairList.Add("facialhair_11");
        facialHairList.Add("facialhair_12");
        facialHairList.Add("facialhair_13");
        facialHairList.Add("facialhair_14");
        facialHairList.Add("facialhair_15");
        facialHairList.Add("none");
    }
}

