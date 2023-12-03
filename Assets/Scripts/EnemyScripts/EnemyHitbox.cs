using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public GameObject player;

    public GameObject soundManagerObject;

    public static bool hasHitAlready = false;


    private void OnTriggerStay2D(Collider2D collision)
    {
        // If OnTriggerStay2D is used for something else, you might want to check the condition here as well
        if (ShouldDealDamage() && !hasHitAlready)
        {
            if (collision.CompareTag("Player") && !player.GetComponent<EnemyActionsManager>().doDamageEnemy && !player.GetComponent<EntityEquipment>().RightHandEquipped)
            {
                // Handle the collision with the enemy
                player.GetComponent<EnemyActionsManager>().canAttack_Melee = true;
                player.GetComponent<EnemyActionsManager>().doDamageEnemy = true;
                Debug.Log("Hitting");

                // Set the flag to true to ensure the code inside runs only once
                hasHitAlready = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<EnemyActionsManager>().canAttack_Melee = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !player.GetComponent<EntityEquipment>().RightHandEquipped)
        {
            // Reset the canAttack_Melee flag and damageDealt when the hitbox is no longer colliding with an enemy
            player.GetComponent<EnemyActionsManager>().canAttack_Melee = false;
            player.GetComponent<EnemyActionsManager>().doDamageEnemy = false;
        }
    }

    private bool ShouldDealDamage()
    {
        // Add conditions for when the player should deal damage
        return player.GetComponent<EnemyActionsManager>().attackingLight ||
               player.GetComponent<EnemyActionsManager>().attackingMedium ||
               player.GetComponent<EnemyActionsManager>().attackingHeavy ||
               player.GetComponent<EnemyActionsManager>().attackingLeaping;
    }
}
