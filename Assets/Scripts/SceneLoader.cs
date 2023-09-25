using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;

    private string levelName;

    // Update is called once per frame
    void Update()
    {
    }

    public void FadeToLevel(string levelName){
        this.levelName = levelName;
        animator.SetTrigger("Fade_Out");
    }

    public void OnFadeComplete(){
        SceneManager.LoadScene(levelName);
    }
}
