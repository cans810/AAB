using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("hello from enemyhitbox");
        if (collision.CompareTag("Player"))
        {
        // Handle the collision with the enemy
            enemy.GetComponent<EnemyActionsManager>().canAttack_Melee = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Reset the canAttack_Light flag when the hitbox is no longer colliding with an enemy
            enemy.GetComponent<EnemyActionsManager>().canAttack_Melee = false;
        }
    }
}
