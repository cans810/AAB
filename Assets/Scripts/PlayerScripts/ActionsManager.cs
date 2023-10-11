using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
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
    public bool inAction;
    public bool played;
    public bool canAttack_Melee;
    public bool canAttack_Leaping;
    public string side;
    public bool currentAnimationUndone;
    public double KBPower;

    public AudioSource walkOnSand_soundEffect;
    public AudioSource[] gotHit_soundEffects;
    public AudioSource[] punch_soundEffects;
    public AudioSource[] punchMiss_soundEffects;

    public float amountGotHit;

    void Awake(){
        side = "left";

        movingLeft = false;
        movingRight = false;

        inAction = false;
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

    }

    public float currentEnemyPos(){
        GameObject enemy = GameObject.FindWithTag("Enemy");
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

        if (gameObject.GetComponent<EntityEquipment>().RightHandEquipped == null && canAttack_Melee){
            int randomPunchSoundEffect = UnityEngine.Random.Range(0, punch_soundEffects.Length);

            punch_soundEffects[randomPunchSoundEffect].Play();
        }
        else if(!canAttack_Melee){
            int randomPunchMissSoundEffect = UnityEngine.Random.Range(0, punchMiss_soundEffects.Length);

            punchMiss_soundEffects[randomPunchMissSoundEffect].Play();
        }

        idle = false;
        inAction = true;
        attackingLight = true;
        gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Player>().animator.SetBool("Idle",false);

        int randomAnimation = UnityEngine.Random.Range(1, 3); // The upper bound is exclusive, so use 3 to include 2

        if (randomAnimation == 1){
            gameObject.GetComponent<Player>().animator.SetTrigger("Light_Attack");
        }
        else if (randomAnimation == 2){
            gameObject.GetComponent<Player>().animator.SetTrigger("Light_Attack_2");
        }

    }

    public void attackMedium(){
        if (gameObject.GetComponent<EntityEquipment>().RightHandEquipped == null && canAttack_Melee){
            int randomPunchSoundEffect = UnityEngine.Random.Range(0, punch_soundEffects.Length);

            punch_soundEffects[randomPunchSoundEffect].Play();
        }
        else if(!canAttack_Melee){
            int randomPunchMissSoundEffect = UnityEngine.Random.Range(0, punchMiss_soundEffects.Length);

            punchMiss_soundEffects[randomPunchMissSoundEffect].Play();
        }

        idle = false;
        inAction = true;
        attackingMedium = true;
        gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Player>().animator.SetBool("Idle",false);

        int randomAnimation = UnityEngine.Random.Range(1, 3); // The upper bound is exclusive, so use 3 to include 2

        if (randomAnimation == 1){
            gameObject.GetComponent<Player>().animator.SetTrigger("Medium_Attack");
        }
        else if (randomAnimation == 2){
            gameObject.GetComponent<Player>().animator.SetTrigger("Medium_Attack_2");
        }

    }

    public void attackHeavy(){
        if (gameObject.GetComponent<EntityEquipment>().RightHandEquipped == null && canAttack_Melee){
            int randomPunchSoundEffect = UnityEngine.Random.Range(0, punch_soundEffects.Length);

            punch_soundEffects[randomPunchSoundEffect].Play();
        }
        else if(!canAttack_Melee){
            int randomPunchMissSoundEffect = UnityEngine.Random.Range(0, punchMiss_soundEffects.Length);

            punchMiss_soundEffects[randomPunchMissSoundEffect].Play();
        }

        idle = false;
        inAction = true;
        attackingHeavy = true;
        gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Player>().animator.SetBool("Idle",false);

        int randomAnimation = UnityEngine.Random.Range(1, 2); // The upper bound is exclusive, so use 3 to include 2

        if (randomAnimation == 1){
            gameObject.GetComponent<Player>().animator.SetTrigger("Heavy_Attack");
        }
        /*else if (randomAnimation == 2){
            //gameObject.GetComponent<Player>().animator.SetTrigger("Heavy_Attack_2");
        }*/

    }

    public void attackLeaping(){
        idle = false;
        if (!canLeapHitEnemy()){
            inAction = true;
            attackingLeaping = true;
            gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
            gameObject.GetComponent<Player>().animator.SetBool("Idle",false);
            gameObject.GetComponent<Player>().animator.SetTrigger("Leap_Attack");
        }
        else if (canLeapHitEnemy()){
            inAction = true;
            attackingLeaping = true;
            gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
            gameObject.GetComponent<Player>().animator.SetBool("Idle",false);
            gameObject.GetComponent<Player>().animator.SetTrigger("Leap_Attack_Hit");
        }

        adjustLeapAttackAnimations();
    }

    public void playAtLeapAttackMissEnd(){
        int randomPunchSoundEffect = UnityEngine.Random.Range(0, punchMiss_soundEffects.Length);

        punchMiss_soundEffects[randomPunchSoundEffect].Play();
    }

    public void playAtLeapAttackHitEnd(){
        if (gameObject.GetComponent<EntityEquipment>().RightHandEquipped == null){
            int randomPunchSoundEffect = UnityEngine.Random.Range(0, punch_soundEffects.Length);

            punch_soundEffects[randomPunchSoundEffect].Play();
        }
    }

    public void adjustMoveSpeed(){
        float animationDuration = 0.34f;

        float distance = Math.Abs(gameObject.GetComponent<EntityAttributes>().destinationX - gameObject.GetComponent<Rigidbody2D>().position.x);

        gameObject.GetComponent<EntityAttributes>().moveSpeed = distance / animationDuration;
    }

    public void adjustLeapAttackAnimations(){
        GameObject enemy = GameObject.FindWithTag("Enemy");

        float distance = 0;

        if (!canLeapHitEnemy()){
            if (side.Equals("left")){
                gameObject.GetComponent<EntityAttributes>().destinationX = gameObject.GetComponent<Rigidbody2D>().position.x + gameObject.GetComponent<EntityAttributes>().stepSize*3/4f;
            }
            else if (side.Equals("right")){
                gameObject.GetComponent<EntityAttributes>().destinationX = gameObject.GetComponent<Rigidbody2D>().position.x - gameObject.GetComponent<EntityAttributes>().stepSize*3/4f;
            }

            distance = Math.Abs(gameObject.GetComponent<EntityAttributes>().destinationX - gameObject.GetComponent<Rigidbody2D>().position.x);

        }
        else if (canLeapHitEnemy()){
            if (side.Equals("left")){
                gameObject.GetComponent<EntityAttributes>().destinationX = enemy.GetComponent<Rigidbody2D>().position.x - enemy.GetComponent<BoxCollider2D>().size.x*4/10;
            }
            else if (side.Equals("right")){
                gameObject.GetComponent<EntityAttributes>().destinationX = enemy.GetComponent<Rigidbody2D>().position.x + enemy.GetComponent<BoxCollider2D>().size.x*4/10;
            }

            distance = Math.Abs(gameObject.GetComponent<EntityAttributes>().destinationX - gameObject.GetComponent<Rigidbody2D>().position.x);
        }

        float moveSpeed = distance * 1.8f;
        
        // Apply the calculated moveSpeed
        gameObject.GetComponent<EntityAttributes>().moveSpeed = moveSpeed;
    } 

    public void surrender(){
        idle = false;
        surrendering = true;
        gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Player>().animator.SetBool("Idle",false);
        gameObject.GetComponent<Player>().animator.SetTrigger("Surrender");
        changeMouth("mouthFrown");
        changeEyes("eyesSerious");
    }

    public void death(){
        idle = false;
        dying = true;
        gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Player>().animator.SetBool("Idle",false);

        int randomAnimation = UnityEngine.Random.Range(1, 3); // The upper bound is exclusive, so use 3 to include 2

        if (randomAnimation == 1){
            gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
            gameObject.GetComponent<Player>().animator.SetBool("Idle",false);
            gameObject.GetComponent<Player>().animator.SetTrigger("Death_1");
            changeEyes("eyesHurt");
            changeMouth("mouthFrown");
        }
        else if (randomAnimation == 2){
            gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
            gameObject.GetComponent<Player>().animator.SetBool("Idle",false);
            gameObject.GetComponent<Player>().animator.SetTrigger("Death_2");
            changeEyes("eyesWide");
            changeMouth("mouthShoutPre");
        }
    }

    public void getSacrified(){
        idle = false;
        surrendering = false;
        dying = true;
        gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Player>().animator.SetBool("Idle",false);

        gameObject.GetComponent<Player>().animator.SetTrigger("GetSacrified_01");
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
        GameObject enemy = GameObject.FindWithTag("Enemy");

        if (side.Equals("left")){
            side = "right";
            enemy.GetComponent<EnemyActionsManager>().side = "left";
        }
        else if (side.Equals("right")){
            side = "left";
            enemy.GetComponent<EnemyActionsManager>().side = "right";
        }

        Vector3 playerPosition = gameObject.transform.position;
        Vector3 enemyPosition = enemy.transform.position;

        // Swap positions
        gameObject.transform.position = enemyPosition;
        enemy.transform.position = playerPosition;

        played = true;
        inAction = false;
    }

    public bool canLeapHitEnemy(){
        GameObject enemy = GameObject.FindWithTag("Enemy");
        
        if (side.Equals("left")){
            if (gameObject.GetComponent<Player>().hitbox.GetComponent<BoxCollider2D>().bounds.max.x + gameObject.GetComponent<EntityAttributes>().stepSize*3/4f >= 
            enemy.GetComponent<BoxCollider2D>().bounds.min.x){

            //Debug.Log("can hit " + (gameObject.GetComponent<Player>().hitbox.GetComponent<BoxCollider2D>().bounds.max.x + gameObject.GetComponent<EntityAttributes>().stepSize*3/4f) + " is bigger than " + 
            //enemy.GetComponent<BoxCollider2D>().bounds.min.x);

                return true;
            }
            else{
                return false;
            }
        }
        else if (side.Equals("right")){
            if (gameObject.GetComponent<Player>().hitbox.GetComponent<BoxCollider2D>().bounds.min.x - gameObject.GetComponent<EntityAttributes>().stepSize*3/4f <= 
            enemy.GetComponent<BoxCollider2D>().bounds.max.x){

                //Debug.Log("can hit " + (gameObject.GetComponent<Player>().hitbox.GetComponent<BoxCollider2D>().bounds.min.x - gameObject.GetComponent<EntityAttributes>().stepSize*3/4f) + " is smaller than " + 
                //enemy.GetComponent<BoxCollider2D>().bounds.max.x);

                return true;
            }
            else{
                return false;
            }
        }
        else{
            return false;
        }
    }

    public void intimidate(){
        gameObject.GetComponent<Player>().animator.SetBool("Idle",false);
        gameObject.GetComponent<Player>().animator.SetTrigger("Intimidate");
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
        walkOnSand_soundEffect.Play();

        gameObject.GetComponent<Player>().animator.SetBool("Idle",false);
        gameObject.GetComponent<Player>().animator.SetBool("Walking",true);
        changeEyes("eyesRight");
        gameObject.GetComponent<EntityAttributes>().destinationX = gameObject.GetComponent<Player>().rb.position.x + gameObject.GetComponent<EntityAttributes>().stepSize;
        inAction = true;
        movingRight = true;

        adjustMoveSpeed();
    }

    public void stopMovingRight(){
        played = true;
        inAction = false;
        movingRight = false;
        gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
        changeEyes("eyesNormal");
    }

    public void moveNextToEnemyToSacrifice(){
        GameObject enemy = GameObject.FindWithTag("Enemy");

        if (side.Equals("left")){
            walkOnSand_soundEffect.Play();

            gameObject.GetComponent<Player>().animator.SetBool("Idle",false);
            gameObject.GetComponent<Player>().animator.SetBool("Walking",true);
            changeEyes("eyesRight");
            gameObject.GetComponent<EntityAttributes>().destinationX = enemy.GetComponent<Enemy>().rb.position.x;
            inAction = true;
            movingRight = true;

            gameObject.GetComponent<EntityAttributes>().moveSpeed = 3.6f;
        }
        else if (side.Equals("right")){
            walkOnSand_soundEffect.Play();

            gameObject.GetComponent<Player>().animator.SetBool("Idle",false);
            gameObject.GetComponent<Player>().animator.SetBool("Walking",true);
            changeEyes("eyesLeft");
            gameObject.GetComponent<EntityAttributes>().destinationX = enemy.GetComponent<Enemy>().rb.position.x;
            inAction = true;
            movingLeft = true;

            gameObject.GetComponent<EntityAttributes>().moveSpeed = 3.6f;
        }

        movingNextToEnemyToSacrifice = true;
    }

    public void moveLeft(){
        walkOnSand_soundEffect.Play();

        gameObject.GetComponent<Player>().animator.SetBool("Idle",false);
        gameObject.GetComponent<Player>().animator.SetBool("Walking",true);
        changeEyes("eyesLeft");
        gameObject.GetComponent<EntityAttributes>().destinationX = gameObject.GetComponent<Player>().rb.position.x - gameObject.GetComponent<EntityAttributes>().stepSize;
        inAction = true;
        movingLeft = true;

        adjustMoveSpeed();
    }

    public void stopMovingLeft(){
       played = true;
       inAction = false;
       movingLeft = false;
       gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
       changeEyes("eyesNormal");
    }

    public void stopMovingToEnemyToSacrifice(){
        movingNextToEnemyToSacrifice = false;

        inAction = false;
        movingRight = false;
        movingLeft = false;
        gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
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

        if (canAttack_Melee){
            GameObject enemy = GameObject.FindWithTag("Enemy");
            calculateHitChance("melee_leap",GetComponent<EntityAttributes>().baseHitChance_leap);
            enemy.GetComponent<EnemyActionsManager>().getHit(GetComponent<EntityAttributes>().hitDamage,generateHitChance(calculateHitChance("melee_leap",GetComponent<EntityAttributes>().baseHitChance_leap)));
            Debug.Log("hit");
        }
    }

    public void DamageEnemy(){
        GameObject enemy = GameObject.FindWithTag("Enemy");

        if (canAttack_Melee){
            if (attackingLight){
                enemy.GetComponent<EnemyActionsManager>().getHit(GetComponent<EntityAttributes>().hitDamage,generateHitChance(calculateHitChance("melee_light",GetComponent<EntityAttributes>().baseHitChance_light)));
            }
            else if (attackingMedium){
                enemy.GetComponent<EnemyActionsManager>().getHit(GetComponent<EntityAttributes>().hitDamage*1.5f,generateHitChance(calculateHitChance("melee_medium",GetComponent<EntityAttributes>().baseHitChance_medium)));
            }
            else if (attackingHeavy){
                enemy.GetComponent<EnemyActionsManager>().getHit(GetComponent<EntityAttributes>().hitDamage*2f,generateHitChance(calculateHitChance("melee_heavy",GetComponent<EntityAttributes>().baseHitChance_heavy)));
            }
        }
    }

    public float calculateHitChance(string hitType, float baseHitChance){
        GameObject enemy = GameObject.FindWithTag("Enemy");

        if (hitType.Equals("melee_light")){

            float hitChanceCopy = CreateNewCharacter.HitChance_light;

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
            
            float hitChanceCopy = CreateNewCharacter.HitChance_medium;

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
            
            float hitChanceCopy = CreateNewCharacter.HitChance_heavy;

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
            
            float hitChanceCopy = CreateNewCharacter.HitChance_leap;

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
            return true;
        }
        else{
            return false;
        }
    }

    public void getHit(float damageValue,bool willBeHit){

        if (willBeHit){

            if (gameObject.GetComponent<EntityAttributes>().armorPoint > 0){
                float before = gameObject.GetComponent<EntityAttributes>().armorPoint;
                gameObject.GetComponent<EntityAttributes>().armorPoint -= (int)damageValue;

                if (gameObject.GetComponent<EntityAttributes>().armorPoint < 0) gameObject.GetComponent<EntityAttributes>().armorPoint = 0;

                amountGotHit = before-gameObject.GetComponent<EntityAttributes>().armorPoint;

                inAction = true;
                gotHit = true;

                int randomAnimation = UnityEngine.Random.Range(1, 3); // The upper bound is exclusive, so use 3 to include 2
                if (randomAnimation == 1){
                    gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
                    gameObject.GetComponent<Player>().animator.SetBool("Idle",false);
                    gameObject.GetComponent<Player>().animator.SetTrigger("Got_Hit_1");
                       changeEyes("eyesHurt");
                       changeMouth("mouthFrown");
                }
                else if (randomAnimation == 2){
                    gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
                    gameObject.GetComponent<Player>().animator.SetBool("Idle",false);
                    gameObject.GetComponent<Player>().animator.SetTrigger("Got_Hit_2");
                    changeEyes("eyesWide");
                    changeMouth("mouthShoutPre");
                }

                GameObject enemy = GameObject.FindWithTag("Enemy");
                Vector2 direction = (transform.position - enemy.transform.position).normalized;
                gameObject.GetComponent<Rigidbody2D>().AddForce(direction*(float)(enemy.GetComponent<EnemyActionsManager>().KBPower),ForceMode2D.Impulse);
            }

            else{
                int randomGotHitSoundEffect = UnityEngine.Random.Range(0, gotHit_soundEffects.Length);

                gotHit_soundEffects[randomGotHitSoundEffect].Play();

                float before = gameObject.GetComponent<EntityAttributes>().HP;
                gameObject.GetComponent<EntityAttributes>().HP -= damageValue;

                amountGotHit = before-gameObject.GetComponent<EntityAttributes>().HP;

                inAction = true;
                gotHit = true;

                if (gameObject.GetComponent<EntityAttributes>().HP <= 0){
                    surrender();
                }
                else{
                    int randomAnimation = UnityEngine.Random.Range(1, 3); // The upper bound is exclusive, so use 3 to include 2

                    if (randomAnimation == 1){
                        gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
                        gameObject.GetComponent<Player>().animator.SetBool("Idle",false);
                        gameObject.GetComponent<Player>().animator.SetTrigger("Got_Hit_1");
                        changeEyes("eyesHurt");
                        changeMouth("mouthFrown");
                    }
                    else if (randomAnimation == 2){
                        gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
                        gameObject.GetComponent<Player>().animator.SetBool("Idle",false);
                        gameObject.GetComponent<Player>().animator.SetTrigger("Got_Hit_2");
                        changeEyes("eyesWide");
                        changeMouth("mouthShoutPre");
                    }
                }

                GameObject enemy = GameObject.FindWithTag("Enemy");
                Vector2 direction = (transform.position - enemy.transform.position).normalized;
                gameObject.GetComponent<Rigidbody2D>().AddForce(direction*(float)(enemy.GetComponent<EnemyActionsManager>().KBPower),ForceMode2D.Impulse);
            }
        }
        else{
            inAction = true;
            blockingMelee = true;
            gameObject.GetComponent<Player>().animator.SetTrigger("Block_1");
        }
    }

    public void knockbackEntity(GameObject entityToKnockBack,GameObject entityReference){
        Vector2 direction = (transform.position - entityReference.transform.position).normalized;
        entityToKnockBack.GetComponent<Rigidbody2D>().AddForce(direction*(float)(1f),ForceMode2D.Impulse);
    }

    public void endGetHit(){
        gotHit = false;
        inAction = false;
        changeEyes("eyesNormal");
        changeMouth("mouthNormal");
    }

    public void endBlock(){
        inAction = false;
        blockingMelee = false;
        changeEyes("eyesNormal");
        changeMouth("mouthNormal");
    }
    
    public void spareEnemyAnim(){
        idle = false;
        inAction = true;
        
        gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Player>().animator.SetBool("Idle",false);

        sparing = true;
        gameObject.GetComponent<Player>().animator.SetTrigger("SpareEnemy_01");
    }

    public void spareEnemy(){
        GameObject enemy = GameObject.FindWithTag("Enemy");
        enemy.GetComponent<EnemyActionsManager>().getSpared();
    }

    public void getSpared(){
        idle = false;
        surrendering = true;
        gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Player>().animator.SetBool("Idle",false);
        gameObject.GetComponent<Player>().animator.SetTrigger("Surrender");
        changeEyes("eyesHurt");
        changeMouth("mouthFrown");
    }

    public void sacrificeEnemyAttackAnim(){
        idle = false;
        inAction = true;
        
        gameObject.GetComponent<Player>().animator.SetBool("Walking",false);
        gameObject.GetComponent<Player>().animator.SetBool("Idle",false);

        sacrificialAttack = true;
        gameObject.GetComponent<Player>().animator.SetTrigger("SacrificeEnemy_01");
    }

    public void sacrificeEnemy(){
        GameObject enemy = GameObject.FindWithTag("Enemy");
        enemy.GetComponent<EnemyActionsManager>().getSacrified();
    }

    public void endSacrificialAttack(){
        endBattle = true;
        inAction = false;
        sacrificialAttack = false;
    }

    public void endSparing(){
        endBattle = true;
        inAction = false;
        sparing = false;
    }

    public void changeEyes(string eyeState){
        gameObject.GetComponent<ExpressionManager>().eyes_state = eyeState;
    }

    public void changeMouth(string mouthState){
        gameObject.GetComponent<ExpressionManager>().mouth_state = mouthState;
    }

    public GameObject currentEnemyInBattle(){
        GameObject enemy = GameObject.FindWithTag("Enemy");
        return enemy;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ArenaWallLeft"))
        {
            // Handle collision with the ground (EdgeCollider2D)

            gameObject.GetComponent<Player>().SetEntityXPosition(transform.position.x + 0.1f);
            stopMovingLeft();
            
            Debug.Log("Entity has hit left wall.");
        }
        else if (collision.collider.CompareTag("ArenaWallRight"))
        {
            // Handle collision with the ground (EdgeCollider2D)

            gameObject.GetComponent<Player>().SetEntityXPosition(transform.position.x - 0.1f);
            stopMovingRight();

            Debug.Log("Entity has hit right wall.");
        }
        else if (collision.collider.CompareTag("Enemy"))
        {
            // Handle collision with the ground (EdgeCollider2D)
            if (movingLeft){
                stopMovingLeft();
            }
            else if(movingRight){
                stopMovingRight();
            }

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
