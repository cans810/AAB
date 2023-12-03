using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    public static BattleState state;
    // GAME OBJECTS
    public GameObject playerActionsHUD;
    private Player player;
    private GameObject enemy;
    
    public GameObject playerLevelManagerGameObject;

    public GameObject goToTownButton;
    public GameObject goToLevelUpSceneButton;

    public GameObject spareOrSacrifice;

    public GameObject playerHUD;
    public GameObject enemyHUD;

    public bool waitingInBetweenTurns;

    // Define a boolean flag to track if the turn has changed
    bool hasTurnChanged = false;
    bool executedSacrificeOrSpare = false;

    void OnEnable(){
        player = Player.Instance;
        player.transform.position = new Vector3(-1,-3.5f,0);

        enemy = EnemyGeneratorController.Instance;
        playerLevelManagerGameObject = GameObject.Find("PlayerLevelManager");

        goToTownButton.SetActive(false);
        goToLevelUpSceneButton.SetActive(false);
        spareOrSacrifice.SetActive(false);
        playerHUD.SetActive(true);
        enemyHUD.SetActive(true);

        state = BattleState.START;

        SetupBattle();
    }

    // Update is called once per frame
    void Update()
    {

        if (enemy != null){

            if (state != BattleState.IN_AFTER_BATTLE_WAITING){
                if (player.GetComponent<EntityAttributes>().HP <= 0 && enemy.GetComponent<EntityAttributes>().HP > 0){
                    state = BattleState.LOST;

                    if (player.GetComponent<ActionsManager>().surrendering 
                    && (!enemy.GetComponent<EnemyActionsManager>().movingNextToEnemyToSacrifice && !enemy.GetComponent<EnemyActionsManager>().sacrificialAttack) && !executedSacrificeOrSpare){

                        executedSacrificeOrSpare = true;

                        // 50 50 sacrifice or spare player for now
                        int SacrificeOrSpare = UnityEngine.Random.Range(0,2);
                        if (SacrificeOrSpare == 0) StartCoroutine(enemy.GetComponent<EnemyActionsManager>().WaitAndSacrifice(0.5f));
                        else StartCoroutine(enemy.GetComponent<EnemyActionsManager>().WaitAndSpare(0.5f));
                    }

                }
                else if (player.GetComponent<EntityAttributes>().HP > 0 && enemy.GetComponent<EntityAttributes>().HP <= 0){
                    state = BattleState.WON;
                    editTournamentInfoNApplySlayedBoss();

                    if (!player.GetComponent<ActionsManager>().endBattle){
                        spareOrSacrifice.SetActive(true);
                        //Debug.Log("sa");
                    }
                }
            }

            if (player.GetComponent<ActionsManager>().endBattle || enemy.GetComponent<EnemyActionsManager>().endBattle){
                playerLevelManagerGameObject.SetActive(true);
                spareOrSacrifice.SetActive(false);
                playerHUD.SetActive(false);
                enemyHUD.SetActive(false);
            }

            if (state == BattleState.IN_AFTER_BATTLE_WAITING && PlayerLevelManager.leveledUP == false && !spareOrSacrifice.activeSelf && !SceneManager.GetActiveScene().name.Equals("TournamentScene")){
                goToTownButton.SetActive(true);
            }
            else if (state == BattleState.IN_AFTER_BATTLE_WAITING && PlayerLevelManager.leveledUP == true && !spareOrSacrifice.activeSelf){
                goToLevelUpSceneButton.SetActive(true);
            }


            // player actions hud manager
            if (enemy.GetComponent<EnemyActionsManager>().inAction || player.GetComponent<ActionsManager>().inAction){
                playerActionsHUD.SetActive(false);
            }
            else{
                if (state == BattleState.ENEMYTURN || enemy.GetComponent<EnemyActionsManager>().inAction || player.GetComponent<ActionsManager>().inAction){
                    playerActionsHUD.SetActive(false);

                }
                else if (state == BattleState.PLAYERTURN && (!enemy.GetComponent<EnemyActionsManager>().inAction || !player.GetComponent<ActionsManager>().inAction)){
                    playerActionsHUD.SetActive(true);

                }
            }

            if (state == BattleState.ENEMYTURN)
            {
                // Check if the turn has changed and execute the statement once
                if (hasTurnChanged)
                {
                    enemy.GetComponent<EntityAttributes>().hitChance_light = enemy.GetComponent<EnemyActionsManager>().calculateHitChance("melee_light",enemy.GetComponent<EntityAttributes>().baseHitChance_light);
                    enemy.GetComponent<EntityAttributes>().hitChance_medium = enemy.GetComponent<EnemyActionsManager>().calculateHitChance("melee_medium",enemy.GetComponent<EntityAttributes>().baseHitChance_medium);
                    enemy.GetComponent<EntityAttributes>().hitChance_heavy = enemy.GetComponent<EnemyActionsManager>().calculateHitChance("melee_heavy",enemy.GetComponent<EntityAttributes>().baseHitChance_heavy);
                    enemy.GetComponent<EntityAttributes>().hitChance_leap = enemy.GetComponent<EnemyActionsManager>().calculateHitChance("melee_leap",enemy.GetComponent<EntityAttributes>().baseHitChance_leap);
                    Debug.Log("enemy turn");
                    EnemyHitbox.hasHitAlready = false;
                    EnemyWeaponHitbox.hasHitAlready = false;
                    // Execute the statement that should occur only once
                    hasTurnChanged = false;
                }

                // !player.GetComponent<ActionsManager>().inAction vurduğumuz zaman enemy nin anında yanıt vermesi için önemli olabilir
                if (!enemy.GetComponent<EnemyActionsManager>().inAction && !enemy.GetComponent<EnemyActionsManager>().inReactionAction 
                && !enemy.GetComponent<EnemyActionsManager>().played && !player.GetComponent<ActionsManager>().inAction) 
                {
                    if (enemy.GetComponent<EntityAttributes>().entityName.Equals("Unlucky Folk")){
                        enemy.GetComponent<EnemyBattleAI>().UnluckyFolkAction();
                    }
                    else{
                        enemy.GetComponent<EnemyBattleAI>().randomlyDoAnAction();
                    }
                }

                // !enemy.GetComponent<EnemyActionsManager>().inAction çok önemli
                if (enemy.GetComponent<EnemyActionsManager>().played && (!enemy.GetComponent<EnemyActionsManager>().inAction || !enemy.GetComponent<EnemyActionsManager>().inReactionAction))
                {
                    if (!waitingInBetweenTurns)
                    {
                        waitingInBetweenTurns = true;
                        //StartCoroutine(WaitAndTransition(0f, BattleState.PLAYERTURN));
            
                        StartCoroutine(WaitAndChangeTurn(0.1f));

                        enemy.GetComponent<EnemyActionsManager>().inAction = false;
                        enemy.GetComponent<EnemyActionsManager>().inReactionAction = false;
                        enemy.GetComponent<EnemyActionsManager>().played = false;
                        state = BattleState.PLAYERTURN;
                    }
                }
            }
            else if (state == BattleState.PLAYERTURN)
            {
                // Check if the turn has changed and execute the statement once
                if (!hasTurnChanged)
                {
                    player.GetComponent<EntityAttributes>().hitChance_light = player.GetComponent<ActionsManager>().calculateHitChance("melee_light",player.GetComponent<EntityAttributes>().baseHitChance_light);
                    player.GetComponent<EntityAttributes>().hitChance_medium = player.GetComponent<ActionsManager>().calculateHitChance("melee_medium",player.GetComponent<EntityAttributes>().baseHitChance_medium);
                    player.GetComponent<EntityAttributes>().hitChance_heavy = player.GetComponent<ActionsManager>().calculateHitChance("melee_heavy",player.GetComponent<EntityAttributes>().baseHitChance_heavy);
                    player.GetComponent<EntityAttributes>().hitChance_leap = player.GetComponent<ActionsManager>().calculateHitChance("melee_leap",player.GetComponent<EntityAttributes>().baseHitChance_leap);
                    Debug.Log("player turn");
                    PlayerHitbox.hasHitAlready = false;
                    WeaponHitbox.hasHitAlready = false;
                    // Execute the statement that should occur only once
                    hasTurnChanged = true;
                }

                else if (player.GetComponent<ActionsManager>().played)
                {
                    if (!waitingInBetweenTurns)
                    {
                        waitingInBetweenTurns = true;
                        //StartCoroutine(WaitAndTransition(0f, BattleState.ENEMYTURN));
                        
                        StartCoroutine(WaitAndChangeTurn(0.1f));

                        player.GetComponent<ActionsManager>().inAction = false;
                        player.GetComponent<ActionsManager>().inReactionAction = false;
                        player.GetComponent<ActionsManager>().played = false;
                        state = BattleState.ENEMYTURN;
                    }
                }
            }

            //hasTurnChanged = false;
            
            // Reset the turn change flag when necessary (e.g., at the start of a new round)
            if (state == BattleState.START)
            {
                hasTurnChanged = false;
            }

        }
    }

    public void entitySideCalculator(){
        float playerX = player.transform.position.x;
        float enemyX = enemy.transform.position.x;

        if (playerX >= enemyX){
            player.GetComponent<ActionsManager>().side = "right";
            enemy.GetComponent<EnemyActionsManager>().side = "left";
        }
        else if (playerX < enemyX){
            player.GetComponent<ActionsManager>().side = "left";
            enemy.GetComponent<EnemyActionsManager>().side = "right";
        }
    }

    public void editTournamentInfoNApplySlayedBoss(){

        if (enemy.name.Equals("Romulus The Leatherman(Clone)")){
            //player.GetComponent<Player>().inTournament = false;
            TournamentManager.Instance.currentTournament = TournamentManager.Instance.tournaments[1];
            TournamentManager.Instance.canEnterCurrentTournament = false;
            EnemyGeneratorController.SlainRomulusTheLeatherman = true;
        }
        else if (enemy.name.Equals("Ferullus(Clone)")){
            //player.GetComponent<Player>().inTournament = false;
            TournamentManager.Instance.currentTournament = TournamentManager.Instance.tournaments[2];
            TournamentManager.Instance.canEnterCurrentTournament = false;
            EnemyGeneratorController.SlainFerullus = true;
        }
        else if (enemy.name.Equals("Atticus Bloodthirst(Clone)")){
            //player.GetComponent<Player>().inTournament = false;
            TournamentManager.Instance.currentTournament = TournamentManager.Instance.tournaments[3];
            TournamentManager.Instance.canEnterCurrentTournament = false;
            EnemyGeneratorController.SlainAtticusBloodthirst = true;
        }
        else if (enemy.name.Equals("The Mammoth(Clone)")){
            //player.GetComponent<Player>().inTournament = false;
            TournamentManager.Instance.currentTournament = TournamentManager.Instance.tournaments[4];
            TournamentManager.Instance.canEnterCurrentTournament = false;
            EnemyGeneratorController.SlainTheMammoth = true;
        }
    }

    private IEnumerator WaitAndTransition(float waitTime, BattleState nextState)
    {
        yield return new WaitForSeconds(waitTime);

        state = nextState;
        waitingInBetweenTurns = false;
    }

    private IEnumerator WaitAndChangeTurn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        waitingInBetweenTurns = false;
    }

    public void goToTown(){
        SceneManager.LoadSceneAsync("TownScene");
        player.resetAfterBattle();
    }

    public void goToLevelUpScene(){
        SceneManager.LoadSceneAsync("LevelUpScene");
        player.resetAfterBattle();
    }

    void SetupBattle(){
        player.resetBeforeBattle();
        if (enemy != null){
            enemy.GetComponent<Enemy>().resetBeforeBattle();
        }
        state = BattleState.PLAYERTURN;
    }
}

public enum BattleState{
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST,
    IN_AFTER_BATTLE_WAITING
}