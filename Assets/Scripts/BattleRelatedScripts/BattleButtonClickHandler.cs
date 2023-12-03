using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleButtonClickHandler : MonoBehaviour
{
    Player player;
    public GameObject leapattackbutton;
    public GameObject lightattackbutton;
    public GameObject mediumattackbutton;
    public GameObject heavyattackbutton;
    public GameObject walkforwardbutton;
    public GameObject walkbackwardbutton;
    public GameObject changeSidesButton;

    public GameObject canvas;
    public GameObject spareorsacrifice;

    IEnumerator WaitForZoomIn()
    {
        // Wait until myBoolean becomes true
        while (!CameraZoom.zoomInEffectDone)
        {
            yield return null; // Wait for one frame
        }

        // Now myBoolean is true, so you can do something here, if it is already true, then this statement will execute
        canvas.GetComponent<RectTransform>().position = new Vector3(player.GetComponent<Rigidbody2D>().position.x-0.05f,-1.5f,player.transform.position.z);
        HandleButtons();
    }

    public void OnEnable(){
        player = Player.Instance;

        // nonsense pos so canvas wont be seen initially
        canvas.GetComponent<RectTransform>().position = new Vector3(player.GetComponent<Rigidbody2D>().position.x-0.05f,-1.5f,player.transform.position.z);

        StartCoroutine(WaitForZoomIn());
    }

    public void HandleButtons(){
        float distance = Math.Abs(player.GetComponent<Rigidbody2D>().transform.position.x - player.GetComponent<ActionsManager>().currentEnemyPos());

        //Debug.Log(distance);

        if (player.GetComponent<ActionsManager>().canAttack_Melee){
            leapattackbutton.SetActive(false);
            changeSidesButton.SetActive(true);

            if (player.GetComponent<ActionsManager>().side.Equals("left")){
                walkforwardbutton.SetActive(false);
                walkbackwardbutton.SetActive(true);
            }
            else if (player.GetComponent<ActionsManager>().side.Equals("right")){
                walkforwardbutton.SetActive(true);
                walkbackwardbutton.SetActive(false);
            }

            // display hit chance
            lightattackbutton.transform.Find("HitChance").GetComponent<TextMeshProUGUI>().text = "%" + (player.GetComponent<EntityAttributes>().hitChance_light * 100).ToString("F0");
            mediumattackbutton.transform.Find("HitChance").GetComponent<TextMeshProUGUI>().text = "%" + (player.GetComponent<EntityAttributes>().hitChance_medium*100).ToString("F0");
            heavyattackbutton.transform.Find("HitChance").GetComponent<TextMeshProUGUI>().text = "%" + (player.GetComponent<EntityAttributes>().hitChance_heavy*100).ToString("F0");
        }
        else{
            leapattackbutton.SetActive(true);

            walkforwardbutton.SetActive(true);
            walkbackwardbutton.SetActive(true);

            changeSidesButton.SetActive(false);

            // display hit chance
            leapattackbutton.transform.Find("HitChance").GetComponent<TextMeshProUGUI>().text = "%" + (player.GetComponent<EntityAttributes>().hitChance_leap*100).ToString("F0");
        }
    }

    void Update(){
        HandleButtons();
        if (BattleSystem.state == BattleState.PLAYERTURN){
            //flipAccordingToSide();
            canvas.GetComponent<RectTransform>().position = new Vector3(player.GetComponent<Rigidbody2D>().position.x-0.05f,-1.5f,player.transform.position.z);
            HandleButtons();
        }
    }

    public void flipAccordingToSide(){
        if (player.GetComponent<ActionsManager>().side.Equals("right")){
            Quaternion desiredRotation = Quaternion.Euler(0f, 180f, 0f);
            transform.rotation = desiredRotation;
        }
        else if (player.GetComponent<ActionsManager>().side.Equals("left")){
            Quaternion desiredRotation = Quaternion.Euler(0f, 0, 0f);
            transform.rotation = desiredRotation;
        }
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

    public void spare_enemy()
    {
        // Access the player GameObject from the Player Singleton

        if (player != null)
        {
            // Call a method or perform an action using the player GameObject
            player.GetComponent<ActionsManager>().spareEnemyAnim();
        }
        else
        {
            Debug.LogError("Player not found.");
        }
    }

    public void sacrifice_enemy()
    {
        // Access the player GameObject from the Player Singleton

        if (player != null)
        {
            // Call a method or perform an action using the player GameObject
            player.GetComponent<ActionsManager>().moveNextToEnemyToSacrifice();
        }
        else
        {
            Debug.LogError("Player not found.");
        }
    }
}
