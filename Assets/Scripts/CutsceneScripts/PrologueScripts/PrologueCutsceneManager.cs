using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrologueCutsceneManager : MonoBehaviour
{
    public GameObject xenarchusTextObject;
    public static string line2 = "in a deep moving current";
    public GameObject playerCopy;
    public GameObject skipButton; // Reference to the button you want to activate.
    public GameObject storyTextsObject;
    
    //
    public AudioSource blockSound_1;
    public AudioSource blockSound_2;
    public AudioSource greviousHitSound_1;
    public AudioSource punchSound_1;
    public AudioSource madmanShoutingSound;

    public GameObject self;

    public void Awake(){
        skipButton.SetActive(false);
        GameObject player = GameObject.Find("Player");
        player.transform.position = new Vector3(-1000,-3.5f,0);
        playerCopy.transform.localScale = new Vector3(49.92001f,49.92001f,49.92001f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            skipButton.SetActive(true);
        }
    }

    public void nextXenarchusLine(){
        xenarchusTextObject.GetComponent<TextMeshProUGUI>().text = line2;
    }

    public void guard1ArmDetach(){
        GameObject guard1 = GameObject.Find("Guard_1");
        guard1.GetComponent<DetachPart>().DetachArm();
    }

    public void enterFirstBattleCutscene(){ 
        GameObject cutsceneManager = GameObject.Find("CutscenesManager");
        cutsceneManager.GetComponent<CutsceneManager>().RunCutscene("firstbattle");
        CutsceneManager.Instance.PrologueCutSceneDone = true;
        self.SetActive(false);
    }

    public void playerEyesWide(){
        playerCopy.GetComponent<ExpressionManager>().eyes_state = "eyesWide";
    }
    public void playerEyesSerious(){
        playerCopy.GetComponent<ExpressionManager>().eyes_state = "eyesSerious";
    }

    public void playerEyesNormal(){
        playerCopy.GetComponent<ExpressionManager>().eyes_state = "eyesNormal";
    }

    public void playerMouthShouting(){
        playerCopy.GetComponent<ExpressionManager>().mouth_state = "mouthShouting";
    }
    public void startStory(){
        storyTextsObject.SetActive(true);
    }

    public void playBlockSound_1(){
        blockSound_1.Play();
    }
    public void playBlockSound_2(){
        blockSound_2.Play();
    }
    public void playGreviousHitSound_1(){
        greviousHitSound_1.Play();
    }
    public void playPunchSound_1(){
        punchSound_1.Play();
    }
    public void playMadmanShoutingSound(){
        madmanShoutingSound.Play();
    }

}
