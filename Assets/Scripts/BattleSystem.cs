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
    private PlayerLevelManager playerLevelManager;

    public GameObject goToTownButton;
    public GameObject goToLevelUpSceneButton;

    public bool waitingInBetweenTurns;

    // Define a boolean flag to track if the turn has changed
    bool hasTurnChanged = false;

    void OnEnable(){
        player = Player.Instance;
        player.transform.position = new Vector3(-1,-3.5f,0);

        enemy = RandomEnemyGenerator.Instance;
        playerLevelManagerGameObject = GameObject.Find("PlayerLevelManager");

        goToTownButton.SetActive(false);
        goToLevelUpSceneButton.SetActive(false);

        state = BattleState.START;

        SetupBattle();
    }

    public void Start(){
        SetupBattle();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null){

            if (state != BattleState.IN_AFTER_BATTLE_WAITING){
                if (player.GetComponent<EntityAttributes>().HP <= 0 && enemy.GetComponent<EntityAttributes>().HP > 0){
                    state = BattleState.LOST;
                    playerLevelManagerGameObject.SetActive(true);
                    //SceneManager.LoadSceneAsync("TownScene");
                }
                else if (player.GetComponent<EntityAttributes>().HP > 0 && enemy.GetComponent<EntityAttributes>().HP <= 0){
                    state = BattleState.WON;
                    playerLevelManagerGameObject.SetActive(true);
                    //SceneManager.LoadSceneAsync("TownScene");
                }
            }
            else if (state == BattleState.IN_AFTER_BATTLE_WAITING && PlayerLevelManager.leveledUP == false){
                goToTownButton.SetActive(true);
            }
            else if (state == BattleState.IN_AFTER_BATTLE_WAITING && PlayerLevelManager.leveledUP == true){
                goToLevelUpSceneButton.SetActive(true);
            }


            // player actions hud manager
            if (enemy.GetComponent<EnemyActionsManager>().inAction || player.GetComponent<ActionsManager>().inAction){
                playerActionsHUD.SetActive(false);
            }
            else{
                if (state == BattleState.ENEMYTURN){
                    playerActionsHUD.SetActive(false);

                }
                else if (state == BattleState.PLAYERTURN){
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
                    // Execute the statement that should occur only once
                    hasTurnChanged = false;
                }

                if (!enemy.GetComponent<EnemyActionsManager>().inAction && !enemy.GetComponent<EnemyActionsManager>().played)
                {
                    enemy.GetComponent<EnemyActionsManager>().attackLight();
                }

                if (enemy.GetComponent<EnemyActionsManager>().played)
                {
                    if (!waitingInBetweenTurns)
                    {
                        waitingInBetweenTurns = true;
                        StartCoroutine(WaitAndTransition(0.02f, BattleState.PLAYERTURN));
                        enemy.GetComponent<EnemyActionsManager>().inAction = false;
                        enemy.GetComponent<EnemyActionsManager>().played = false;
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
                    // Execute the statement that should occur only once
                    hasTurnChanged = true;
                }

                if (player.GetComponent<ActionsManager>().played)
                {
                    if (!waitingInBetweenTurns)
                    {
                        waitingInBetweenTurns = true;
                        StartCoroutine(WaitAndTransition(0.02f, BattleState.ENEMYTURN));
                        player.GetComponent<ActionsManager>().inAction = false;
                        player.GetComponent<ActionsManager>().played = false;
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

    private IEnumerator WaitAndTransition(float waitTime, BattleState nextState)
    {
        yield return new WaitForSeconds(waitTime);

        state = nextState;
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
        enemy.GetComponent<Enemy>().resetBeforeBattle();
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