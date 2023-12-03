using Unity.VisualScripting;
using UnityEngine;

public class WeaponHitbox : MonoBehaviour
{
    public GameObject player;

    public GameObject soundManagerObject;

    public static bool hasHitAlready = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        // If OnTriggerStay2D is used for something else, you might want to check the condition here as well
        if (ShouldDealDamage() && !hasHitAlready)
        {
            if (collision.CompareTag("Enemy") && !player.GetComponent<ActionsManager>().doDamageEnemy && player.GetComponent<EntityEquipment>().RightHandEquipped)
            {
                // Handle the collision with the enemy
                player.GetComponent<ActionsManager>().canAttack_Melee = true;
                player.GetComponent<ActionsManager>().doDamageEnemy = true;
                Debug.Log("Hitting");

                // Set the flag to true to ensure the code inside runs only once
                hasHitAlready = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && player.GetComponent<EntityEquipment>().RightHandEquipped)
        {
            // Reset the canAttack_Melee flag and damageDealt when the hitbox is no longer colliding with an enemy
            player.GetComponent<ActionsManager>().canAttack_Melee = false;
            player.GetComponent<ActionsManager>().doDamageEnemy = false;
        }
    }

    private bool ShouldDealDamage()
    {
        // Add conditions for when the player should deal damage
        return player.GetComponent<ActionsManager>().attackingLight ||
               player.GetComponent<ActionsManager>().attackingMedium ||
               player.GetComponent<ActionsManager>().attackingHeavy ||
               player.GetComponent<ActionsManager>().attackingLeaping;
    }
}
