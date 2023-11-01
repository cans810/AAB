using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class CopyEntityAppereance : MonoBehaviour
{

    public GameObject copyFromEntity;

    // Start is called before the first frame update
    void Start()
    {
        copyFromEntity = GameObject.Find("Player");

        ChangeSkinColor();
        ChangeRace();
        ChangeHairAndHairColor();
    }

    public void ChangeHairAndHairColor(){
        gameObject.GetComponent<AppereanceManager>().hair = copyFromEntity.GetComponent<AppereanceManager>().hair;
        gameObject.GetComponent<AppereanceManager>().facial_hair = copyFromEntity.GetComponent<AppereanceManager>().facial_hair;

        Transform copyHair = copyFromEntity.transform.Find("main_bone/torso_bone/head_bone/Hair/hair");
        GameObject copyHairObject = copyHair.gameObject;
        Color hairColor = copyHairObject.GetComponent<SpriteRenderer>().color;

        Transform Hair = gameObject.transform.Find("main_bone/torso_bone/head_bone/Hair/hair");
        GameObject HairObject = Hair.gameObject;
        HairObject.GetComponent<SpriteRenderer>().color = hairColor;

        Transform copyFacialHair = copyFromEntity.transform.Find("main_bone/torso_bone/head_bone/FacialHair/facial_hair");
        GameObject copyFacialHairObject = copyFacialHair.gameObject;
        Color facialHairColor = copyFacialHairObject.GetComponent<SpriteRenderer>().color;

        Transform FacialHair = gameObject.transform.Find("main_bone/torso_bone/head_bone/FacialHair/facial_hair");
        GameObject FacialHairObject = FacialHair.gameObject;
        FacialHairObject.GetComponent<SpriteRenderer>().color = facialHairColor;
    }

    public void ChangeRace(){
        gameObject.GetComponent<AppereanceManager>().race = copyFromEntity.GetComponent<AppereanceManager>().race;
        gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = copyFromEntity.GetComponent<SpriteLibrary>().spriteLibraryAsset;
    }

    private void ChangeSkinColor(){
        Transform copyHead = copyFromEntity.transform.Find("head");
        GameObject copyHeadObject = copyHead.gameObject;
        Color skinColor = copyHeadObject.GetComponent<SpriteRenderer>().color;


        // Find a child GameObject by name
        Transform head = gameObject.transform.Find("head");
        Transform torso = gameObject.transform.Find("torso");

        Transform rightArm = gameObject.transform.Find("right_arm");
        Transform rightForearm = gameObject.transform.Find("right_forearm");

        Transform leftArm = gameObject.transform.Find("left_arm");
        Transform leftForearm = gameObject.transform.Find("left_forearm");

        Transform rightLeg = gameObject.transform.Find("right_leg");
        Transform rightCalf = gameObject.transform.Find("right_calf");

        Transform leftLeg = gameObject.transform.Find("left_leg");
        Transform leftCalf = gameObject.transform.Find("left_calf");

        
        // Do something with the found child GameObject
        GameObject childObject_head = head.gameObject;
        childObject_head.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_torso = torso.gameObject;
        childObject_torso.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_rightArm = rightArm.gameObject;
        childObject_rightArm.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_rightForearm = rightForearm.gameObject;
        childObject_rightForearm.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_leftArm = leftArm.gameObject;
        childObject_leftArm.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_leftForearm = leftForearm.gameObject;
        childObject_leftForearm.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_rightLeg = rightLeg.gameObject;
        childObject_rightLeg.GetComponent<SpriteRenderer>().color = skinColor;
        GameObject childObject_rightCalf = rightCalf.gameObject;
        childObject_rightCalf.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_leftLeg = leftLeg.gameObject;
        childObject_leftLeg.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_leftCalf = leftCalf.gameObject;
        childObject_leftCalf.GetComponent<SpriteRenderer>().color = skinColor;
    }
}
