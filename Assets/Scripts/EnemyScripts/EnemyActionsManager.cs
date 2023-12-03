using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionsManager : MonoBehaviour
{
    public bool movingLeft, movingRight;
    public bool idle;
    public bool alive;
    public bool gotHit;
    public bool hittingLeftWall;
    public bool hittingRightWall;
    public bool attackingLight;
    public bool attackingMedium;
    public bool attackingHeavy;
    public bool attackingLeaping;
    public bool blockingMelee;
    public bool surrendering;
    public bool dying;
    public bool intimidating;
    public bool movingNextToEnemyToSacrifice;
    public bool sacrificialAttack;
    public bool sparing;
    public bool endBattle;
    public bool showcaseAnim;
    public bool inAction;
    public bool inReactionAction;
    public bool played;
    public bool canAttack_Melee;
    public bool doDamageEnemy;
    public string side;
    public bool currentAnimationUndone;
    public double KBPower;
    public float amountGotHit;

    public GameObject soundsManager;

    void Awake(){
        side = "right";

        movingLeft = false;
        movingRight = false;

        inAction = false;
        inReactionAction = false;
        played = false;

        canAttack_Melee = false;

        if (side.Equals("right")){
            flip("right");
        }
        else if (side.Equals("left")){
            flip("left");
        }

        KBPower = 1.1;
    }

    void Update(){
        //Debug.Log(canLeapHitEnemy());
    }

    public float currentEnemyPos(){
        GameObject enemy = GameObject.FindWithTag("Player");
        return enemy.GetComponent<Rigidbody2D>().position.x;
    }

    private IEnumerator WaitForSplitSeconds(float splitSeconds)
    {
        yield return new WaitForSeconds(splitSeconds);

        // Split seconds have passed, do something
        Debug.Log("Split seconds have passed");
        currentAnimationUndone = false;
    }

    public void attackLight(){
        // if (canAttack_Melee){
        //     int randomPunchSoundEffect = UnityEngine.Random.Range(0, soundsManager.GetComponent<EntitySoundsManager>().punch_soundEffects.Length);

        //     soundsManager.GetComponent<EntitySoundsManager>().punch_soundEffects[randomPunchSoundEffect].Play();
        // }
        // else if(!canAttack_Melee){
        //     int randomPunchMissSoundEffect = UnityEngine.Random.Range(0, soundsManager.GetComponent<EntitySoundsManager>().punchMiss_soundEffects.Length);

        //     soundsManager.GetComponent<EntitySoundsManager>().punchMiss_soundEffects[randomPunchMissSoundEffect].Play();
        // }

        idle = false;
        inAction = true;
        attackingLight = true;
        gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);

        int randomAnimation = UnityEngine.Random.Range(1, 3); // The upper bound is exclusive, so use 3 to include 2

        if (randomAnimation == 1){
            gameObject.GetComponent<Enemy>().animator.SetTrigger("Light_Attack");
        }
        else if (randomAnimation == 2){
            gameObject.GetComponent<Enemy>().animator.SetTrigger("Light_Attack_2");
        }

    }

    public void attackMedium(){
        // if (canAttack_Melee){
        //     int randomPunchSoundEffect = UnityEngine.Random.Range(0, soundsManager.GetComponent<EntitySoundsManager>().punch_soundEffects.Length);

        //     soundsManager.GetComponent<EntitySoundsManager>().punch_soundEffects[randomPunchSoundEffect].Play();
        // }
        // else if(!canAttack_Melee){
        //     int randomPunchMissSoundEffect = UnityEngine.Random.Range(0, soundsManager.GetComponent<EntitySoundsManager>().punchMiss_soundEffects.Length);

        //     soundsManager.GetComponent<EntitySoundsManager>().punchMiss_soundEffects[randomPunchMissSoundEffect].Play();
        // }

        idle = false;
        inAction = true;
        attackingMedium = true;
        gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);

        int randomAnimation = UnityEngine.Random.Range(1, 3); // The upper bound is exclusive, so use 3 to include 2

        if (randomAnimation == 1){
            gameObject.GetComponent<Enemy>().animator.SetTrigger("Medium_Attack");
        }
        else if (randomAnimation == 2){
            gameObject.GetComponent<Enemy>().animator.SetTrigger("Medium_Attack_2");
        }

    }

    public void attackHeavy(){
        // if (canAttack_Melee){
        //     int randomPunchSoundEffect = UnityEngine.Random.Range(0, soundsManager.GetComponent<EntitySoundsManager>().punch_soundEffects.Length);

        //     soundsManager.GetComponent<EntitySoundsManager>().punch_soundEffects[randomPunchSoundEffect].Play();
        // }
        // else if(!canAttack_Melee){
        //     int randomPunchMissSoundEffect = UnityEngine.Random.Range(0, soundsManager.GetComponent<EntitySoundsManager>().punchMiss_soundEffects.Length);

        //     soundsManager.GetComponent<EntitySoundsManager>().punchMiss_soundEffects[randomPunchMissSoundEffect].Play();
        // }

        idle = false;
        inAction = true;
        attackingHeavy = true;
        gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);

        int randomAnimation = UnityEngine.Random.Range(1, 2); // The upper bound is exclusive, so use 3 to include 2

        if (randomAnimation == 1){
            gameObject.GetComponent<Enemy>().animator.SetTrigger("Heavy_Attack");
        }
        /*else if (randomAnimation == 2){
            //gameObject.GetComponent<Player>().animator.SetTrigger("Heavy_Attack_2");
        }*/

    }

    public void attackLeaping(){
        idle = false;
        
        inAction = true;
        attackingLeaping = true;
        gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);
        gameObject.GetComponent<Enemy>().animator.SetTrigger("Leap_Attack_Hit");
        
        adjustLeapAttackAnimations();
    }

    // public void playAtLeapAttackMissEnd(){
    //     int randomPunchSoundEffect = UnityEngine.Random.Range(0, soundsManager.GetComponent<EntitySoundsManager>().punchMiss_soundEffects.Length);

    //     soundsManager.GetComponent<EntitySoundsManager>().punchMiss_soundEffects[randomPunchSoundEffect].Play();
    // }

    // public void playAtLeapAttackHitEnd(){
        
    //     int randomPunchSoundEffect = UnityEngine.Random.Range(0, soundsManager.GetComponent<EntitySoundsManager>().punch_soundEffects.Length);

    //     soundsManager.GetComponent<EntitySoundsManager>().punch_soundEffects[randomPunchSoundEffect].Play();
        
    // }

    public void adjustMoveSpeed(){
        float animationDuration = 0.34f;

        float distance = Math.Abs(gameObject.GetComponent<EntityAttributes>().destinationX - gameObject.GetComponent<Rigidbody2D>().position.x);

        gameObject.GetComponent<EntityAttributes>().moveSpeed = distance / animationDuration;
    }

    public void adjustLeapAttackAnimations(){
        GameObject enemy = GameObject.FindWithTag("Player");

        float distance = 0;

        if (side.Equals("left")){
            gameObject.GetComponent<EntityAttributes>().destinationX = gameObject.GetComponent<Rigidbody2D>().position.x + gameObject.GetComponent<EntityAttributes>().stepSize*3/4f;
        }
        else if (side.Equals("right")){
            gameObject.GetComponent<EntityAttributes>().destinationX = gameObject.GetComponent<Rigidbody2D>().position.x - gameObject.GetComponent<EntityAttributes>().stepSize*3/4f;
        }

        distance = Math.Abs(gameObject.GetComponent<EntityAttributes>().destinationX - gameObject.GetComponent<Rigidbody2D>().position.x);
        
        float moveSpeed = distance * 1.8f;
        
        // Apply the calculated moveSpeed
        gameObject.GetComponent<EntityAttributes>().moveSpeed = moveSpeed;
    } 

    public void surrender(){
        idle = false;
        surrendering = true;
        gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);
        gameObject.GetComponent<Enemy>().animator.SetTrigger("Surrender");

        int randomSound = UnityEngine.Random.Range(0,soundsManager.GetComponent<EntitySoundsManager>().deathSoundEffects.Length);
        soundsManager.GetComponent<EntitySoundsManager>().playDeathSoundEffects(randomSound);

        changeMouth("mouthFrown");
        changeEyes("eyesSerious");
    }

    public void death(){
        idle = false;
        dying = true;
        gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);

        int randomSound = UnityEngine.Random.Range(0,soundsManager.GetComponent<EntitySoundsManager>().deathSoundEffects.Length);
        soundsManager.GetComponent<EntitySoundsManager>().playDeathSoundEffects(randomSound);

        int randomAnimation = UnityEngine.Random.Range(1, 3); // The upper bound is exclusive, so use 3 to include 2

        if (randomAnimation == 1){
            gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
            gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);
            gameObject.GetComponent<Enemy>().animator.SetTrigger("Death_1");
            changeEyes("eyesHurt");
            changeMouth("mouthFrown");
        }
        else if (randomAnimation == 2){
            gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
            gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);
            gameObject.GetComponent<Enemy>().animator.SetTrigger("Death_2");
            changeEyes("eyesWide");
            changeMouth("mouthShoutPre");
        }
    }

    public void getSacrified(){
        idle = false;
        surrendering = false;
        dying = true;
        gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);

        gameObject.GetComponent<Enemy>().animator.SetTrigger("GetSacrified_01");
        changeEyes("eyesHurt");
        changeMouth("mouthFrown");
    }

    public void stopSurrender(){
        changeEyes("eyesNormal");
        changeMouth("mouthNormal");
        surrendering = false;
    }
    public void stopDeath(){
        changeEyes("eyesNormal");
        changeMouth("mouthNormal");
        dying = false;
        gameObject.GetComponent<DetachPart>().AttachHead_Death_1();
    }

    public void changeSides(){
        idle = false;
        GameObject enemy = GameObject.FindWithTag("Player");

        if (side.Equals("left")){
            side = "right";
            enemy.GetComponent<ActionsManager>().side = "left";
        }
        else if (side.Equals("right")){
            side = "left";
            enemy.GetComponent<ActionsManager>().side = "right";
        }

        Vector3 playerPosition = gameObject.transform.position;
        Vector3 enemyPosition = enemy.transform.position;

        // Swap positions
        gameObject.transform.position = enemyPosition;
        enemy.transform.position = playerPosition;

        played = true;
        inAction = false;
    }

    public void intimidate(){
        gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);
        gameObject.GetComponent<Enemy>().animator.SetTrigger("Intimidate");
        inAction = true;
        intimidating = true;
    }

    public void mouthShoutPre(){
        changeMouth("mouthShoutPre");
        changeEyes("eyesSerious");
    }

    public void mouthShout(){
        changeMouth("mouthShouting");
        changeEyes("eyesSerious");
    }

    public void EndIntimidating(){
        played = true;
        inAction = false;
        intimidating = false;
        changeMouth("mouthNormal");
        changeEyes("eyesNormal");
    }

    public void moveRight(){
        soundsManager.GetComponent<EntitySoundsManager>().playWalkingOnSandSoundEffect();

        gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);
        gameObject.GetComponent<Enemy>().animator.SetBool("Walking",true);
        changeEyes("eyesLeft");
        gameObject.GetComponent<EntityAttributes>().destinationX = gameObject.GetComponent<Enemy>().rb.position.x + gameObject.GetComponent<EntityAttributes>().stepSize;
        inAction = true;
        movingRight = true;

        adjustMoveSpeed();
    }

    public void stopMovingRight(){
        played = true;
        inAction = false;
        movingRight = false;
        gameObject.GetComponent<EntityAttributes>().destinationX = gameObject.GetComponent<Enemy>().rb.position.x;
        gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
        changeEyes("eyesNormal");
    }

    public void moveLeft(){
        soundsManager.GetComponent<EntitySoundsManager>().playWalkingOnSandSoundEffect();

        gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);
        gameObject.GetComponent<Enemy>().animator.SetBool("Walking",true);
        changeEyes("eyesRight");
        gameObject.GetComponent<EntityAttributes>().destinationX = gameObject.GetComponent<Enemy>().rb.position.x - gameObject.GetComponent<EntityAttributes>().stepSize;
        inAction = true;
        movingLeft = true;

        adjustMoveSpeed();
    }

    public void stopMovingLeft(){
       played = true;
       inAction = false;
       movingLeft = false;
       gameObject.GetComponent<EntityAttributes>().destinationX = gameObject.GetComponent<Enemy>().rb.position.x;
       gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
       changeEyes("eyesNormal");
    }

    public void EndLightAttack(){
        played = true;
        inAction = false;
        attackingLight = false;
    }

    public void EndMediumAttack(){
        played = true;
        inAction = false;
        attackingMedium = false;
    }

    public void EndHeavyAttack(){
        played = true;
        inAction = false;
        attackingHeavy = false;
    }

        public void EndLeapAttack(){
        played = true;
        inAction = false;
        attackingLeaping = false;
    }

    public void DamageEnemy(){
        GameObject enemy = GameObject.FindWithTag("Player");

        if (canAttack_Melee){
            if (attackingLight){
                enemy.GetComponent<ActionsManager>().getHit(GetComponent<EntityAttributes>().hitDamage,generateHitChance(calculateHitChance("melee_light",GetComponent<EntityAttributes>().baseHitChance_light)));
            }
            else if (attackingMedium){
                enemy.GetComponent<ActionsManager>().getHit(GetComponent<EntityAttributes>().hitDamage*1.5f,generateHitChance(calculateHitChance("melee_medium",GetComponent<EntityAttributes>().baseHitChance_medium)));
            }
            else if (attackingHeavy){
                enemy.GetComponent<ActionsManager>().getHit(GetComponent<EntityAttributes>().hitDamage*2f,generateHitChance(calculateHitChance("melee_heavy",GetComponent<EntityAttributes>().baseHitChance_heavy)));
            }
            else if (attackingLeaping){
                enemy.GetComponent<ActionsManager>().getHit(GetComponent<EntityAttributes>().hitDamage,generateHitChance(calculateHitChance("melee_leap",GetComponent<EntityAttributes>().baseHitChance_leap)));
            }
        }

        doDamageEnemy = false;
    }

    public float calculateHitChance(string hitType, float baseHitChance){
        GameObject enemy = GameObject.FindWithTag("Player");

        if (hitType.Equals("melee_light")){

            float hitChanceCopy = EnemyGeneratorController.HitChance_light;

            for (int i=1;i<enemy.GetComponent<EntityAttributes>().defence;i++){
                baseHitChance *= 0.9f;
                hitChanceCopy *= 0.9f;
            }

            if (hitChanceCopy*100 >= 90){
                baseHitChance = 90f/100f;
            }
            else{
                baseHitChance = hitChanceCopy;
            }
        }

        else if (hitType.Equals("melee_medium")){
            
            float hitChanceCopy = EnemyGeneratorController.HitChance_medium;

            for (int i=1;i<enemy.GetComponent<EntityAttributes>().defence;i++){
                baseHitChance *= 0.9f;
                hitChanceCopy *= 0.9f;
            }

            if (hitChanceCopy*100 >= 90){
                baseHitChance = 90f/100f;
            }
            else{
                baseHitChance = hitChanceCopy;
            }
        }

        else if (hitType.Equals("melee_heavy")){
            
            float hitChanceCopy = EnemyGeneratorController.HitChance_heavy;

            for (int i=1;i<enemy.GetComponent<EntityAttributes>().defence;i++){
                baseHitChance *= 0.9f;
                hitChanceCopy *= 0.9f;
            }

            if (hitChanceCopy*100 >= 90){
                baseHitChance = 90f/100f;
            }
            else{
                baseHitChance = hitChanceCopy;
            }
        }

        else if (hitType.Equals("melee_leap")){
            
            float hitChanceCopy = EnemyGeneratorController.HitChance_leap;

            for (int i=1;i<enemy.GetComponent<EntityAttributes>().defence;i++){
                baseHitChance *= 0.9f;
                hitChanceCopy *= 0.9f;
            }

            if (hitChanceCopy*100 >= 90){
                baseHitChance = 90f/100f;
            }
            else{
                baseHitChance = hitChanceCopy;
            }
        }

        return baseHitChance;
    }

    public bool generateHitChance(float hitChance){
        int randomChance = UnityEngine.Random.Range(0,101);
        Debug.Log("chance to hit enemy: " + randomChance);

        if (randomChance <= hitChance*100f){
            int randomSound = UnityEngine.Random.Range(0,soundsManager.GetComponent<EntitySoundsManager>().punchSoundEffects.Length);
            soundsManager.GetComponent<EntitySoundsManager>().playPunchSoundEffects(randomSound);
            return true;
        }
        else{
            return false;
        }
    }

    public void getHit(float damageValue,bool willBeHit){

        if (willBeHit){

            if (gameObject.GetComponent<EntityAttributes>().armorPoint > 0){
                idle = false;
                inReactionAction = true;
                gotHit = true;

                int randomSound = UnityEngine.Random.Range(0,soundsManager.GetComponent<EntitySoundsManager>().hurtSoundEffects.Length);
                soundsManager.GetComponent<EntitySoundsManager>().playHurtSoundEffects(randomSound);

                float before = gameObject.GetComponent<EntityAttributes>().armorPoint;
                gameObject.GetComponent<EntityAttributes>().armorPoint -= (int)damageValue;

                if (gameObject.GetComponent<EntityAttributes>().armorPoint < 0) gameObject.GetComponent<EntityAttributes>().armorPoint = 0;

                amountGotHit = before-gameObject.GetComponent<EntityAttributes>().armorPoint;

                int randomAnimation = UnityEngine.Random.Range(1, 3); // The upper bound is exclusive, so use 3 to include 2
                if (randomAnimation == 1){
                    gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
                    gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);
                    gameObject.GetComponent<Enemy>().animator.SetTrigger("Got_Hit_1");
                       changeEyes("eyesHurt");
                       changeMouth("mouthFrown");
                }
                else if (randomAnimation == 2){
                    gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
                    gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);
                    gameObject.GetComponent<Enemy>().animator.SetTrigger("Got_Hit_2");
                    changeEyes("eyesWide");
                    changeMouth("mouthShoutPre");
                }

                GameObject enemy = GameObject.FindWithTag("Player");
                Vector2 direction = (transform.position - enemy.transform.position).normalized;
                gameObject.GetComponent<Rigidbody2D>().AddForce(direction*(float)(enemy.GetComponent<ActionsManager>().KBPower),ForceMode2D.Impulse);
                
            }

            else{
                idle = false;
                inReactionAction = true;
                gotHit = true;

                float before = gameObject.GetComponent<EntityAttributes>().HP;
                gameObject.GetComponent<EntityAttributes>().HP -= damageValue;

                amountGotHit = before-gameObject.GetComponent<EntityAttributes>().HP;

                if (gameObject.GetComponent<EntityAttributes>().HP <= 0){
                    if (GetComponent<Enemy>().inTournament){
                        death();
                    }
                    else if (!GetComponent<Enemy>().inTournament){
                        surrender();
                    }
                }
                else{
                    int randomSound = UnityEngine.Random.Range(0,soundsManager.GetComponent<EntitySoundsManager>().hurtSoundEffects.Length);
                    soundsManager.GetComponent<EntitySoundsManager>().playHurtSoundEffects(randomSound);

                    int randomAnimation = UnityEngine.Random.Range(1, 3); // The upper bound is exclusive, so use 3 to include 2

                    if (randomAnimation == 1){
                        gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
                        gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);
                        gameObject.GetComponent<Enemy>().animator.SetTrigger("Got_Hit_1");
                        changeEyes("eyesHurt");
                       changeMouth("mouthFrown");
                   }
                    else if (randomAnimation == 2){
                        gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
                        gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);
                        gameObject.GetComponent<Enemy>().animator.SetTrigger("Got_Hit_2");
                        changeEyes("eyesWide");
                        changeMouth("mouthShoutPre");
                    }
                }

                GameObject enemy = GameObject.FindWithTag("Player");
                Vector2 direction = (transform.position - enemy.transform.position).normalized;
                gameObject.GetComponent<Rigidbody2D>().AddForce(direction*(float)(enemy.GetComponent<ActionsManager>().KBPower),ForceMode2D.Impulse);
            }
        }
        else{
            idle = false;
            inReactionAction = true;
            blockingMelee = true;

            if (gameObject.GetComponent<EntityEquipment>().IsWearingEnoughToMakeMetalsHittingSound()){
                int randomSound = UnityEngine.Random.Range(0,soundsManager.GetComponent<EntitySoundsManager>().weaponsHittingSoundEffects.Length);
                soundsManager.GetComponent<EntitySoundsManager>().playWeaponsHittingSoundEffects(randomSound);
            }

            gameObject.GetComponent<Enemy>().animator.SetTrigger("Block_1");
        }
    }

    public void knockbackEntity(GameObject entityToKnockBack,GameObject entityReference){
        Vector2 direction = (transform.position - entityReference.transform.position).normalized;
        entityToKnockBack.GetComponent<Rigidbody2D>().AddForce(direction*(float)(1f),ForceMode2D.Impulse);
    }

    public void endGetHit(){
        inReactionAction = false;
        gotHit = false;
        changeEyes("eyesNormal");
        changeMouth("mouthNormal");
        Debug.Log("ended get hit");
    }

    public void endBlock(){
        inReactionAction = false;
        blockingMelee = false;
        changeEyes("eyesNormal");
        changeMouth("mouthNormal");
    }

    public void changeEyes(string eyeState){
        gameObject.GetComponent<ExpressionManager>().eyes_state = eyeState;
    }

    public void changeMouth(string mouthState){
        gameObject.GetComponent<ExpressionManager>().mouth_state = mouthState;
    }

    public void startShowcaseAnimBool(){
        showcaseAnim = true;
    }
    public void endShowcaseAnimBool(){
        showcaseAnim = false;
    }

    public GameObject currentEnemyInBattle(){
        GameObject enemy = GameObject.FindWithTag("Player");
        return enemy;
    }

    public void spareEnemyAnim(){
        idle = false;
        inAction = true;
        
        gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);

        sparing = true;
        gameObject.GetComponent<Enemy>().animator.SetTrigger("SpareEnemy_01");
    }

    public void spareEnemy(){
        GameObject enemy = GameObject.FindWithTag("Player");
        enemy.GetComponent<ActionsManager>().getSpared();
    }

    public void getSpared(){
        idle = false;
        surrendering = true;
        gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);
        gameObject.GetComponent<Enemy>().animator.SetTrigger("Surrender");
        changeEyes("eyesHurt");
        changeMouth("mouthFrown");
    }

    public void endSparing(){
        endBattle = true;
        inAction = false;
        sparing = false;
    }

    public void sacrificeEnemyAttackAnim(){
        idle = false;
        inAction = true;
        
        gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);

        sacrificialAttack = true;
        gameObject.GetComponent<Enemy>().animator.SetTrigger("SacrificeEnemy_01");
    }

    public void sacrificeEnemy(){
        GameObject enemy = GameObject.FindWithTag("Player");
        enemy.GetComponent<ActionsManager>().getSacrified();
    }

    public void endSacrificialAttack(){
        endBattle = true;
        inAction = false;
        sacrificialAttack = false;
    }

    public void moveNextToEnemyToSacrifice(){
        GameObject enemy = GameObject.FindWithTag("Player");

        if (side.Equals("left")){
            soundsManager.GetComponent<EntitySoundsManager>().playWalkingOnSandSoundEffect();

            gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);
            gameObject.GetComponent<Enemy>().animator.SetBool("Walking",true);
            changeEyes("eyesLeft");
            gameObject.GetComponent<EntityAttributes>().destinationX = enemy.GetComponent<Player>().rb.position.x;
            inAction = true;
            movingRight = true;

            gameObject.GetComponent<EntityAttributes>().moveSpeed = 3.6f;
        }
        else if (side.Equals("right")){
            soundsManager.GetComponent<EntitySoundsManager>().playWalkingOnSandSoundEffect();

            gameObject.GetComponent<Enemy>().animator.SetBool("Idle",false);
            gameObject.GetComponent<Enemy>().animator.SetBool("Walking",true);
            changeEyes("eyesRight");
            gameObject.GetComponent<EntityAttributes>().destinationX = enemy.GetComponent<Player>().rb.position.x;
            inAction = true;
            movingLeft = true;

            gameObject.GetComponent<EntityAttributes>().moveSpeed = 3.6f;
        }

        movingNextToEnemyToSacrifice = true;
    }

    public void stopMovingToEnemyToSacrifice(){
        movingNextToEnemyToSacrifice = false;

        inAction = false;
        movingRight = false;
        movingLeft = false;
        gameObject.GetComponent<Enemy>().animator.SetBool("Walking",false);
        changeEyes("eyesNormal");
    }

    public IEnumerator WaitAndSacrifice(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
                        
        moveNextToEnemyToSacrifice();
    }

    public IEnumerator WaitAndSpare(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
                        
        spareEnemyAnim();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ArenaWallLeft"))
        {
            // Handle collision with the ground (EdgeCollider2D)
            gameObject.GetComponent<Enemy>().SetEntityXPosition(transform.position.x + 0.1f);
            stopMovingLeft();
            Debug.Log("Entity has hit left wall.");
        }
        else if (collision.collider.CompareTag("ArenaWallRight"))
        {
            // Handle collision with the ground (EdgeCollider2D)
            gameObject.GetComponent<Enemy>().SetEntityXPosition(transform.position.x - 0.1f);
            stopMovingRight();
            Debug.Log("Entity has hit right wall.");
        }
        else if (collision.collider.CompareTag("Player") && (!attackingLeaping && !Player.Instance.GetComponent<ActionsManager>().attackingLeaping))
        {
            // Handle collision with the ground (EdgeCollider2D)
            if (movingLeft){
                stopMovingLeft();
            }
            else if(movingRight){
                stopMovingRight();
            }
            
            stopMovingLeft();
            stopMovingRight();
            //knockbackEntity(gameObject,currentEnemyInBattle());
        }
    }

    public void flip(string side){
        if (side.Equals("right")){
            transform.Rotate(0f, 180f, 0f);
        }
        else if(side.Equals("left")){
            transform.Rotate(0f, 0f, 0f);
        }
    }

    private bool IsAnimationPlaying(string animationName)
    {
        return gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(animationName);
    }

}
