using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedAtPoint : MonoBehaviour
{
    public GameObject bleed_1Prefab;

    public void createBleed_1Effect_Death_1()
    {
        Vector3 playerPosition = transform.position;

        if (gameObject.tag.Equals("Player")){
            if (gameObject.GetComponent<ActionsManager>().side.Equals("left"))
            {
                GameObject bleedObject = Instantiate(bleed_1Prefab);
                bleedObject.transform.localScale = gameObject.transform.localScale * 3;
                bleedObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                bleedObject.transform.position = new Vector3(playerPosition.x + bleedObject.transform.localScale.x*22/10f, playerPosition.y+0.2f, playerPosition.z);
                
            }
            else if (gameObject.GetComponent<ActionsManager>().side.Equals("right"))
            {
                GameObject bleedObject = Instantiate(bleed_1Prefab);
                bleedObject.transform.localScale = gameObject.transform.localScale * 3;
                bleedObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                bleedObject.transform.position = new Vector3(playerPosition.x - bleedObject.transform.localScale.x*22/10f, playerPosition.y+0.2f, playerPosition.z);
               
            }
        }
        else if (gameObject.tag.Equals("Enemy")){
            if (gameObject.GetComponent<EnemyActionsManager>().side.Equals("left"))
            {
                GameObject bleedObject = Instantiate(bleed_1Prefab);
                bleedObject.transform.localScale = gameObject.transform.localScale * 3;
                bleedObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                bleedObject.transform.position = new Vector3(playerPosition.x + bleedObject.transform.localScale.x*22/10f, playerPosition.y+0.2f, playerPosition.z);
                
            }
            else if (gameObject.GetComponent<EnemyActionsManager>().side.Equals("right"))
            {
                GameObject bleedObject = Instantiate(bleed_1Prefab);
                bleedObject.transform.localScale = gameObject.transform.localScale * 3;
                bleedObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                bleedObject.transform.position = new Vector3(playerPosition.x - bleedObject.transform.localScale.x*22/10f, playerPosition.y+0.2f, playerPosition.z);
               
            }
        }

    
    }

    public void createBleed_1Effect_Death2()
    {
        Vector3 playerPosition = transform.position;

        if (gameObject.tag.Equals("Player")){
            if (gameObject.GetComponent<ActionsManager>().side.Equals("left"))
            {
                GameObject bleedObject = Instantiate(bleed_1Prefab);
                bleedObject.transform.localScale = gameObject.transform.localScale * 3;
                bleedObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                bleedObject.transform.position = new Vector3(playerPosition.x - bleedObject.transform.localScale.x*15/10f, playerPosition.y+0.2f, playerPosition.z);
                
            }
            else if (gameObject.GetComponent<ActionsManager>().side.Equals("right"))
            {
                GameObject bleedObject = Instantiate(bleed_1Prefab);
                bleedObject.transform.localScale = gameObject.transform.localScale * 3;
                bleedObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                bleedObject.transform.position = new Vector3(playerPosition.x + bleedObject.transform.localScale.x*15/10f, playerPosition.y+0.2f, playerPosition.z);
                
            }
        }
        else if (gameObject.tag.Equals("Enemy")){
            if (gameObject.GetComponent<EnemyActionsManager>().side.Equals("left"))
            {
                GameObject bleedObject = Instantiate(bleed_1Prefab);
                bleedObject.transform.localScale = gameObject.transform.localScale * 3;
                bleedObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                bleedObject.transform.position = new Vector3(playerPosition.x - bleedObject.transform.localScale.x*15/10f, playerPosition.y+0.2f, playerPosition.z);
                
            }
            else if (gameObject.GetComponent<EnemyActionsManager>().side.Equals("right"))
            {
                GameObject bleedObject = Instantiate(bleed_1Prefab);
                bleedObject.transform.localScale = gameObject.transform.localScale * 3;
                bleedObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                bleedObject.transform.position = new Vector3(playerPosition.x + bleedObject.transform.localScale.x*15/10f, playerPosition.y+0.2f, playerPosition.z);
            
            }
        }
    }
}
