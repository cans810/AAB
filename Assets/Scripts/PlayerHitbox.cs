using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
        // Handle the collision with the enemy
            player.GetComponent<ActionsManager>().canAttack_Melee = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Reset the canAttack_Light flag when the hitbox is no longer colliding with an enemy
            player.GetComponent<ActionsManager>().canAttack_Melee = false;
        }
    }
}
