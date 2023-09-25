using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleButtonClickHandler : MonoBehaviour
{
    Player player;
    public GameObject leapattackbutton;
    public GameObject lightattackbutton;
    public GameObject mediumattackbutton;
    public GameObject heavyattackbutton;
    public GameObject walkforwardbutton;
    public GameObject changeSidesButton;

    public GameObject canvas;

    IEnumerator WaitForZoomIn()
    {
        // Wait until myBoolean becomes true
        while (!CameraZoom.zoomInEffectDone)
        {
            yield return null; // Wait for one frame
        }

        // Now myBoolean is true, so you can do something here, if it is already true, then this statement will execute
        canvas.GetComponent<RectTransform>().anchoredPosition = new Vector3(player.GetComponent<Rigidbody2D>().position.x+(0.21f),-0.08457112f,player.transform.position.z);
        HandleAttackButtons();
    }

    public void OnEnable(){
        player = Player.Instance;

        // nonsense pos so canvas wont be seen initially
        canvas.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1000,-1000,-1);

        StartCoroutine(WaitForZoomIn());
    }

    public void HandleAttackButtons(){
        float distance = Math.Abs(player.GetComponent<Rigidbody2D>().transform.position.x - player.GetComponent<ActionsManager>().currentEnemyPos());

        //Debug.Log(distance);

        if (player.GetComponent<ActionsManager>().canAttack_Melee){
            leapattackbutton.SetActive(false);
            lightattackbutton.SetActive(true);
            mediumattackbutton.SetActive(true);
            heavyattackbutton.SetActive(true);
            walkforwardbutton.SetActive(false);
            changeSidesButton.SetActive(true);

            // display hit chance
            lightattackbutton.transform.Find("HitChance").GetComponent<TextMeshProUGUI>().text = "%" + (player.GetComponent<EntityAttributes>().hitChance_light*100).ToString();
            mediumattackbutton.transform.Find("HitChance").GetComponent<TextMeshProUGUI>().text = "%" + (player.GetComponent<EntityAttributes>().hitChance_medium*100).ToString();
            heavyattackbutton.transform.Find("HitChance").GetComponent<TextMeshProUGUI>().text = "%" + (player.GetComponent<EntityAttributes>().hitChance_heavy*100).ToString();
        }
        else{
            leapattackbutton.SetActive(true);
            lightattackbutton.SetActive(false);
            mediumattackbutton.SetActive(false);
            heavyattackbutton.SetActive(false);
            walkforwardbutton.SetActive(true);
            changeSidesButton.SetActive(false);

            // display hit chance
            leapattackbutton.transform.Find("HitChance").GetComponent<TextMeshProUGUI>().text = "%" + (player.GetComponent<EntityAttributes>().hitChance_leap*100).ToString();
        }
    }

    void Update(){

    }

    public void light_attack()
    {
        // Access the player GameObject from the Player Singleton

        if (player != null)
        {
            // Call a method or perform an action using the player GameObject
            player.GetComponent<ActionsManager>().attackLight();
        }
        else
        {
            Debug.LogError("Player not found.");
        }
    }

    public void medium_attack()
    {
        // Access the player GameObject from the Player Singleton

        if (player != null)
        {
            // Call a method or perform an action using the player GameObject
            player.GetComponent<ActionsManager>().attackMedium();
        }
        else
        {
            Debug.LogError("Player not found.");
        }
    }

    public void heavy_attack()
    {
        // Access the player GameObject from the Player Singleton

        if (player != null)
        {
            // Call a method or perform an action using the player GameObject
            player.GetComponent<ActionsManager>().attackHeavy();
        }
        else
        {
            Debug.LogError("Player not found.");
        }
    }

    public void leap_attack()
    {
        // Access the player GameObject from the Player Singleton

        if (player != null)
        {
            // Call a method or perform an action using the player GameObject
            player.GetComponent<ActionsManager>().attackLeaping();
        }
        else
        {
            Debug.LogError("Player not found.");
        }
    }
    
    public void move_right()
    {
        // Access the player GameObject from the Player Singleton

        if (player != null)
        {
            // Call a method or perform an action using the player GameObject
            player.GetComponent<ActionsManager>().moveRight();
        }
        else
        {
            Debug.LogError("Player not found.");
        }
    }
    public void move_left()
    {
        // Access the player GameObject from the Player Singleton

        if (player != null)
        {
            // Call a method or perform an action using the player GameObject
            player.GetComponent<ActionsManager>().moveLeft();
        }
        else
        {
            Debug.LogError("Player not found.");
        }
    }

    public void change_sides(){
        // Access the player GameObject from the Player Singleton

        if (player != null)
        {
            // Call a method or perform an action using the player GameObject
            player.GetComponent<ActionsManager>().changeSides();
        }
        else
        {
            Debug.LogError("Player not found.");
        }
    }

    public void intimidate(){
        // Access the player GameObject from the Player Singleton

        if (player != null)
        {
            // Call a method or perform an action using the player GameObject
            player.GetComponent<ActionsManager>().intimidate();
        }
        else
        {
            Debug.LogError("Player not found.");
        }
    }
}
