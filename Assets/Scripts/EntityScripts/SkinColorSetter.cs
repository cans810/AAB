using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinColorSetter : MonoBehaviour
{

    public GameObject Instance;
    public Color color;

    public void Awake(){
        ChangeSkinColor();
    }
    
    private void ChangeSkinColor(){
        // Find a child GameObject by name
        Transform head = Instance.transform.Find("head");
        Transform torso = Instance.transform.Find("torso");

        Transform rightArm = Instance.transform.Find("right_arm");
        Transform rightForearm = Instance.transform.Find("right_forearm");

        Transform leftArm = Instance.transform.Find("left_arm");
        Transform leftForearm = Instance.transform.Find("left_forearm");

        Transform rightLeg = Instance.transform.Find("right_leg");
        Transform rightCalf = Instance.transform.Find("right_calf");

        Transform leftLeg = Instance.transform.Find("left_leg");
        Transform leftCalf = Instance.transform.Find("left_calf");

        
        // Do something with the found child GameObject
        GameObject childObject_head = head.gameObject;
        childObject_head.GetComponent<SpriteRenderer>().color = color;

        GameObject childObject_torso = torso.gameObject;
        childObject_torso.GetComponent<SpriteRenderer>().color = color;

        GameObject childObject_rightArm = rightArm.gameObject;
        childObject_rightArm.GetComponent<SpriteRenderer>().color = color;

        GameObject childObject_rightForearm = rightForearm.gameObject;
        childObject_rightForearm.GetComponent<SpriteRenderer>().color = color;

        GameObject childObject_leftArm = leftArm.gameObject;
        childObject_leftArm.GetComponent<SpriteRenderer>().color = color;

        GameObject childObject_leftForearm = leftForearm.gameObject;
        childObject_leftForearm.GetComponent<SpriteRenderer>().color = color;

        GameObject childObject_rightLeg = rightLeg.gameObject;
        childObject_rightLeg.GetComponent<SpriteRenderer>().color = color;
        GameObject childObject_rightCalf = rightCalf.gameObject;
        childObject_rightCalf.GetComponent<SpriteRenderer>().color = color;

        GameObject childObject_leftLeg = leftLeg.gameObject;
        childObject_leftLeg.GetComponent<SpriteRenderer>().color = color;

        GameObject childObject_leftCalf = leftCalf.gameObject;
        childObject_leftCalf.GetComponent<SpriteRenderer>().color = color;
    }
}
