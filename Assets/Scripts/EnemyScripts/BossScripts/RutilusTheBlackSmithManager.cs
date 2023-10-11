using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RutilusTheBlackSmithManager : MonoBehaviour
{
    public bool enteringScreenAnim;

    public void startEnteringScreen(){
        enteringScreenAnim = true;
    }

    public void stopEnteringScreen(){
        enteringScreenAnim = false;
    }

    public void Update(){

        if (enteringScreenAnim == false){
            GetComponent<Animator>().SetTrigger("Idle");
            enteringScreenAnim = true;
        }

    }
}
