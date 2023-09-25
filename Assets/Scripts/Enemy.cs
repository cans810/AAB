using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D.Animation;

public class Enemy : Entity
{
    public Animator animator;
    public Rigidbody2D rb;
    public GameObject hitbox;

    public Vector3 originalScale = new Vector3(0.33f,0.33f,0.33f);
    public Vector3 showcaseScale = new Vector3(0.33f,0.33f,0.33f);

    public static Enemy Instance { get; private set; }
    
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
        InitEnemy();
    }

    void InitEnemy(){
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
    }

    public void resetBeforeBattle(){
        gameObject.GetComponent<EnemyActionsManager>().side = "right";
        transform.position = new Vector3(1,-4.119578f,0);
        transform.localScale = originalScale;
        gameObject.GetComponent<EntityAttributes>().HP = gameObject.GetComponent<EntityAttributes>().maxHP;
        gameObject.GetComponent<EntityAttributes>().SP = gameObject.GetComponent<EntityAttributes>().maxSP;

        gameObject.GetComponent<EnemyActionsManager>().inAction = false;
        gameObject.GetComponent<EnemyActionsManager>().played = true;
        gameObject.GetComponent<EnemyActionsManager>().canAttack_Melee = false;

        gameObject.GetComponent<EntityAttributes>().calculateMaxArmorPoint();
    }

    public void resetAfterBattle(){
        gameObject.GetComponent<EnemyActionsManager>().side = "right";
        gameObject.GetComponent<Player>().animator.SetBool("Idle",true);
        gameObject.GetComponent<EntityAttributes>().HP = gameObject.GetComponent<EntityAttributes>().maxHP;
        gameObject.GetComponent<EntityAttributes>().SP = gameObject.GetComponent<EntityAttributes>().maxSP;

        gameObject.GetComponent<EnemyActionsManager>().inAction = false;
        gameObject.GetComponent<EnemyActionsManager>().played = false;
        gameObject.GetComponent<EnemyActionsManager>().canAttack_Melee = false;
        gameObject.GetComponent<EnemyActionsManager>().movingLeft = false;
        gameObject.GetComponent<EnemyActionsManager>().movingRight = false;
        gameObject.GetComponent<EnemyActionsManager>().idle = true;
        gameObject.GetComponent<EnemyActionsManager>().gotHit = false;
        gameObject.GetComponent<EnemyActionsManager>().blockingMelee = false;
        gameObject.GetComponent<EnemyActionsManager>().hittingLeftWall = false;
        gameObject.GetComponent<EnemyActionsManager>().hittingRightWall = false;
        gameObject.GetComponent<EnemyActionsManager>().attackingLight = false;
        gameObject.GetComponent<EnemyActionsManager>().attackingMedium = false;
        gameObject.GetComponent<EnemyActionsManager>().attackingHeavy = false;
        gameObject.GetComponent<EnemyActionsManager>().attackingLeaping = false;
        gameObject.GetComponent<EnemyActionsManager>().surrendering = false;
        gameObject.GetComponent<EnemyActionsManager>().dying = false;
        gameObject.GetComponent<EnemyActionsManager>().intimidating = false;
        gameObject.GetComponent<EnemyActionsManager>().inAction = false;
        gameObject.GetComponent<EnemyActionsManager>().played = false;
        gameObject.GetComponent<EnemyActionsManager>().canAttack_Melee = false;
        gameObject.GetComponent<EnemyActionsManager>().canAttack_Leaping = false;
        gameObject.GetComponent<EnemyActionsManager>().stopSurrender();
        gameObject.GetComponent<EnemyActionsManager>().stopDeath();
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


        if (gameObject.GetComponent<EnemyActionsManager>().movingRight){
            if (rb.position.x <= gameObject.GetComponent<EntityAttributes>().destinationX){

                float movementAmount = gameObject.GetComponent<EntityAttributes>().moveSpeed * Time.deltaTime;
                Vector3 movement = new Vector3(movementAmount, 0f, 0f);

                // Move the player
                transform.position += movement;
                animator.SetBool("Idle",false);
                animator.SetBool("Walking",true);
            }
            else{
                gameObject.GetComponent<EnemyActionsManager>().stopMovingRight();
            }
        }
        else if (gameObject.GetComponent<EnemyActionsManager>().movingLeft){
            if (rb.position.x >= gameObject.GetComponent<EntityAttributes>().destinationX){
                
                float movementAmount = gameObject.GetComponent<EntityAttributes>().moveSpeed * Time.deltaTime;
                Vector3 movement = new Vector3(movementAmount, 0f, 0f);

                // Move the player
                transform.position -= movement;
                animator.SetBool("Idle",false);
                animator.SetBool("Walking",true);
            }
            else{
                gameObject.GetComponent<EnemyActionsManager>().stopMovingLeft();
            }
        }

        else if (gameObject.GetComponent<EnemyActionsManager>().attackingLight){
            animator.SetBool("Idle",false);
        }

        else if (gameObject.GetComponent<EnemyActionsManager>().attackingMedium){
            animator.SetBool("Idle",false);
        }

        else if (gameObject.GetComponent<EnemyActionsManager>().attackingHeavy){
            animator.SetBool("Idle",false);
        }

        else if(gameObject.GetComponent<EnemyActionsManager>().surrendering){
            animator.SetBool("Idle",false);
        }

        else if(gameObject.GetComponent<EnemyActionsManager>().dying){
            animator.SetBool("Idle",false);
        }
        
        else if(gameObject.GetComponent<EnemyActionsManager>().intimidating){
            animator.SetBool("Idle",false);
        }

        else if(gameObject.GetComponent<EnemyActionsManager>().blockingMelee){
            animator.SetBool("Idle",false);
        }

        else if (gameObject.GetComponent<EnemyActionsManager>().attackingLeaping){
            
            if (gameObject.GetComponent<EnemyActionsManager>().side.Equals("left")){

                if (gameObject.GetComponent<Rigidbody2D>().position.x <= gameObject.GetComponent<EntityAttributes>().destinationX){

                    float movementAmount = gameObject.GetComponent<EntityAttributes>().moveSpeed * Time.deltaTime;
                    Vector3 movement = new Vector3(movementAmount, 0f, 0f);

                    // Move the player
                    transform.position += movement;
                }

            }
            else if (gameObject.GetComponent<EnemyActionsManager>().side.Equals("right")){

                if (gameObject.GetComponent<Rigidbody2D>().position.x >= gameObject.GetComponent<EntityAttributes>().destinationX){
                    float movementAmount = gameObject.GetComponent<EntityAttributes>().moveSpeed * Time.deltaTime;
                    Vector3 movement = new Vector3(movementAmount, 0f, 0f);

                    // Move the player
                    transform.position -= movement;
                }

            }
        }

        else if (gameObject.GetComponent<EnemyActionsManager>().gotHit){
            animator.SetBool("Idle",false);
        }

        // if idle
        else{
            animator.SetBool("Walking",false);
            animator.SetBool("Idle",true);
        }
    }

    public void flipAccordingToSide(){
        if (gameObject.GetComponent<EnemyActionsManager>().side.Equals("right")){
            Quaternion desiredRotation = Quaternion.Euler(0f, 180f, 0f);
            transform.rotation = desiredRotation;
        }
        else if (gameObject.GetComponent<EnemyActionsManager>().side.Equals("left")){
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