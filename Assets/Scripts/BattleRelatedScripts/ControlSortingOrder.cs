using UnityEngine;

public class ControlSortingOrder : MonoBehaviour
{
    private GameObject player;
    private Renderer[] childRenderersPlayer;
    private GameObject enemy;
    private Renderer[] childRenderersEnemy;

    bool switchPlayerTurn;
    bool switchEnemyTurn;
    
    private void OnEnable(){
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        switchPlayerTurn = true;
        switchEnemyTurn = false;
    }

    private void Update(){

        if (switchPlayerTurn){
            if (BattleSystem.state == BattleState.PLAYERTURN){
                // Get all the child Renderers (including limbs).
                childRenderersPlayer = player.GetComponentsInChildren<Renderer>();

                foreach (var renderer in childRenderersPlayer)
                {
                    // Get the current sorting order and add 1 to it.
                    int currentSortingOrder = renderer.sortingOrder;
                    renderer.sortingOrder = currentSortingOrder + 1;
                }

                // Get all the child Renderers (including limbs).
                childRenderersEnemy = enemy.GetComponentsInChildren<Renderer>();

                foreach (var renderer in childRenderersEnemy)
                {
                    // Get the current sorting order and add 1 to it.
                    int currentSortingOrder = renderer.sortingOrder;
                    renderer.sortingOrder = currentSortingOrder - 1;
                }

                switchPlayerTurn = false;
                switchEnemyTurn = true;
            }
        }

        if (switchEnemyTurn){
            if (BattleSystem.state == BattleState.ENEMYTURN){
                // Get all the child Renderers (including limbs).
                childRenderersEnemy = enemy.GetComponentsInChildren<Renderer>();

                foreach (var renderer in childRenderersEnemy)
                {
                    // Get the current sorting order and add 1 to it.
                    int currentSortingOrder = renderer.sortingOrder;
                    renderer.sortingOrder = currentSortingOrder + 1;
                }

                // Get all the child Renderers (including limbs).
                childRenderersPlayer = player.GetComponentsInChildren<Renderer>();

                foreach (var renderer in childRenderersPlayer)
                {
                    // Get the current sorting order and add 1 to it.
                    int currentSortingOrder = renderer.sortingOrder;
                    renderer.sortingOrder = currentSortingOrder - 1;
                }

                switchEnemyTurn = false;
                switchPlayerTurn = true;
            }
        }
    
    }
}
