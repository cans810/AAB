using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D.Animation;

public class Player : Entity
{
    public Animator animator;
    public Rigidbody2D rb;
    public GameObject hitbox;

    public Vector3 originalScale = new Vector3(0.33f,0.33f,0.33f);
    public Vector3 showcaseScale = new Vector3(0.33f,0.33f,0.33f);

    public static Player Instance { get; private set; }

    public int goldBalance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            // Set the Player instance if it doesn't exist yet
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy the duplicate Player instance
            Destroy(gameObject);
            return;
        }

        // Call the initialization method here or any other setup specific to the Player GameObject
        InitPlayer();
    }

    void InitPlayer(){
        rb = GetComponent<Rigidbody2D>();

        // adjust player size here
        // transform localscale and position
        Vector3 originalPosition = transform.position;

         // Calculate the new scale uniformly
        float newScale =  transform.localScale.x * math.pow(1.01f,gameObject.GetComponent<EntityAttributes>().strength);

        // Calculate the position adjustment based on the scale change
        Vector3 positionAdjustment = (newScale - transform.localScale.x) * 0.59f *  transform.up;

        // Apply the new scale and adjust the position
        transform.localScale = new Vector3(newScale, newScale,  transform.localScale.z);
        transform.position = originalPosition - positionAdjustment;

        //transform.localScale = transform.localScale/1.450000045000004500000450000045f;
        transform.position = new Vector3(0.5f,-4.119578f,0);

        goldBalance = 1500;
    }

    public void resetBeforeBattle(){
        gameObject.GetComponent<ActionsManager>().side = "left";
        transform.position = new Vector3(-1,-4.119578f,0);
        transform.localScale = originalScale;
        gameObject.GetComponent<EntityAttributes>().HP = gameObject.GetComponent<EntityAttributes>().maxHP;
        gameObject.GetComponent<EntityAttributes>().SP = gameObject.GetComponent<EntityAttributes>().maxSP;

        gameObject.GetComponent<ActionsManager>().inAction = false;
        gameObject.GetComponent<ActionsManager>().played = false;
        gameObject.GetComponent<ActionsManager>().canAttack_Melee = false;

        gameObject.GetComponent<EntityAttributes>().calculateMaxArmorPoint();
        gameObject.GetComponent<EntityAttributes>().updatePowerValue();
        //Debug.Log("resetted");
    }

    public void resetAfterBattle(){
        gameObject.GetComponent<ActionsManager>().side = "left";
        gameObject.GetComponent<Player>().animator.SetBool("Idle",true);
        gameObject.GetComponent<EntityAttributes>().HP = gameObject.GetComponent<EntityAttributes>().maxHP;
        gameObject.GetComponent<EntityAttributes>().SP = gameObject.GetComponent<EntityAttributes>().maxSP;

        gameObject.GetComponent<ActionsManager>().inAction = false;
        gameObject.GetComponent<ActionsManager>().played = false;
        gameObject.GetComponent<ActionsManager>().canAttack_Melee = false;
        gameObject.GetComponent<ActionsManager>().movingLeft = false;
        gameObject.GetComponent<ActionsManager>().movingRight = false;
        gameObject.GetComponent<ActionsManager>().idle = true;
        gameObject.GetComponent<ActionsManager>().gotHit = false;
        gameObject.GetComponent<ActionsManager>().blockingMelee = false;
        gameObject.GetComponent<ActionsManager>().hittingLeftWall = false;
        gameObject.GetComponent<ActionsManager>().hittingRightWall = false;
        gameObject.GetComponent<ActionsManager>().attackingLight = false;
        gameObject.GetComponent<ActionsManager>().attackingMedium = false;
        gameObject.GetComponent<ActionsManager>().attackingHeavy = false;
        gameObject.GetComponent<ActionsManager>().attackingLeaping = false;
        gameObject.GetComponent<ActionsManager>().surrendering = false;
        gameObject.GetComponent<ActionsManager>().dying = false;
        gameObject.GetComponent<ActionsManager>().intimidating = false;
        gameObject.GetComponent<ActionsManager>().inAction = false;
        gameObject.GetComponent<ActionsManager>().played = false;
        gameObject.GetComponent<ActionsManager>().canAttack_Melee = false;
        gameObject.GetComponent<ActionsManager>().canAttack_Leaping = false;
        gameObject.GetComponent<ActionsManager>().stopSurrender();
        gameObject.GetComponent<ActionsManager>().stopDeath();
    }

    public void buy(Item item){
        gameObject.GetComponent<EntityEquipment>().inventory.Add(item);
    }

    // Update is called once per frame
    void Update(){
        //Debug.Log(maxArmorPoint);

        //Debug.Log(Player.Instance.transform.localPosition.x + ", " + Player.Instance.transform.localPosition.y);

        flipAccordingToSide();

        //Debug.Log(gameObject.GetComponent<ActionsManager>().side);


        if (gameObject.GetComponent<ActionsManager>().movingRight){
            if (rb.position.x <= gameObject.GetComponent<EntityAttributes>().destinationX){

                float movementAmount = gameObject.GetComponent<EntityAttributes>().moveSpeed * Time.deltaTime;
                Vector3 movement = new Vector3(movementAmount, 0f, 0f);

                // Move the player
                transform.position += movement;
                animator.SetBool("Idle",false);
                animator.SetBool("Walking",true);
            }
            else{
                gameObject.GetComponent<ActionsManager>().stopMovingRight();
            }
        }
        else if (gameObject.GetComponent<ActionsManager>().movingLeft){
            if (rb.position.x >= gameObject.GetComponent<EntityAttributes>().destinationX){
                
                float movementAmount = gameObject.GetComponent<EntityAttributes>().moveSpeed * Time.deltaTime;
                Vector3 movement = new Vector3(movementAmount, 0f, 0f);

                // Move the player
                transform.position -= movement;
                animator.SetBool("Idle",false);
                animator.SetBool("Walking",true);
            }
            else{
                gameObject.GetComponent<ActionsManager>().stopMovingLeft();
            }
        }

        else if (gameObject.GetComponent<ActionsManager>().attackingLight){
            animator.SetBool("Idle",false);
        }

        else if (gameObject.GetComponent<ActionsManager>().attackingMedium){
            animator.SetBool("Idle",false);
        }

        else if (gameObject.GetComponent<ActionsManager>().attackingHeavy){
            animator.SetBool("Idle",false);
        }

        else if(gameObject.GetComponent<ActionsManager>().surrendering){
            animator.SetBool("Idle",false);
        }

        else if(gameObject.GetComponent<ActionsManager>().dying){
            animator.SetBool("Idle",false);
        }
        
        else if(gameObject.GetComponent<ActionsManager>().intimidating){
            animator.SetBool("Idle",false);
        }

        else if(gameObject.GetComponent<ActionsManager>().blockingMelee){
            animator.SetBool("Idle",false);
        }

        else if (gameObject.GetComponent<ActionsManager>().attackingLeaping){
            
            if (gameObject.GetComponent<ActionsManager>().side.Equals("left")){

                if (gameObject.GetComponent<Rigidbody2D>().position.x <= gameObject.GetComponent<EntityAttributes>().destinationX){

                    float movementAmount = gameObject.GetComponent<EntityAttributes>().moveSpeed * Time.deltaTime;
                    Vector3 movement = new Vector3(movementAmount, 0f, 0f);

                    // Move the player
                    transform.position += movement;
                }

            }
            else if (gameObject.GetComponent<ActionsManager>().side.Equals("right")){

                if (gameObject.GetComponent<Rigidbody2D>().position.x >= gameObject.GetComponent<EntityAttributes>().destinationX){
                    float movementAmount = gameObject.GetComponent<EntityAttributes>().moveSpeed * Time.deltaTime;
                    Vector3 movement = new Vector3(movementAmount, 0f, 0f);

                    // Move the player
                    transform.position -= movement;
                }

            }
        }

        else if (gameObject.GetComponent<ActionsManager>().gotHit){
            animator.SetBool("Idle",false);
        }

        // if idle
        else{
            animator.SetBool("Walking",false);
            animator.SetBool("Idle",true);
        }
    }

    public void flipAccordingToSide(){
        if (gameObject.GetComponent<ActionsManager>().side.Equals("right")){
            Quaternion desiredRotation = Quaternion.Euler(0f, 180f, 0f);
            transform.rotation = desiredRotation;
        }
        else if (gameObject.GetComponent<ActionsManager>().side.Equals("left")){
            Quaternion desiredRotation = Quaternion.Euler(0f, 0, 0f);
            transform.rotation = desiredRotation;
        }
    }

    private bool IsAnimationPlaying(string animationName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(animationName);
    }

    public void SetEntityXPosition(float newX)
    {
        Vector3 newPosition = transform.position;
        newPosition.x = newX;
        transform.position = newPosition;
    }
}