using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossShowcase : MonoBehaviour
{
    /*public TextMeshProUGUI enemyName;
    public TextMeshProUGUI enemyInfo;
    public TextMeshProUGUI enemyHP;
    public TextMeshProUGUI enemyPowerValue;
    public TextMeshProUGUI enemy_textMeshPro_strengthPoint_text;
    public TextMeshProUGUI enemy_textMeshPro_staminaPoint_text;
    public TextMeshProUGUI enemy_textMeshPro_dexterityPoint_text;
    public TextMeshProUGUI enemy_textMeshPro_vitalityPoint_text;
    public TextMeshProUGUI enemy_textMeshPro_offensePoint_text;
    public TextMeshProUGUI enemy_textMeshPro_defencePoint_text;
    public TextMeshProUGUI enemy_textMeshPro_auraPoint_text;
    public TextMeshProUGUI enemy_textMeshPro_magicPoint_text;*/

    public TextMeshProUGUI enemyName;

    private GameObject enemy;
    public GameObject statsShowcase;
    public GameObject bossBackStoryText;

    public void Start(){
        GameObject player = GameObject.Find("Player");
        player.transform.position = new Vector3(-100,0,0);
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;

        enemy = EnemyGeneratorController.Instance;
        enemy.GetComponent<EnemyActionsManager>().side = "left";
        
        if (enemy.name.Equals("Romulus The Leatherman(Clone)")){
            enemy.GetComponent<Enemy>().animator.SetTrigger("RomulusTheLeathermanShowcase");
            bossBackStoryText.GetComponent<TextMeshProUGUI>().text = BossBackStoryManager.RomulusTheLeathermanBackStory;
        }
    
        if (enemy.name.Equals("Ferullus(Clone)")){ 
            enemy.GetComponent<Enemy>().animator.SetTrigger("FerullusShowcase");
            bossBackStoryText.GetComponent<TextMeshProUGUI>().text = BossBackStoryManager.FerullusBackStory;
        }

        if (enemy.name.Equals("Atticus Bloodthirst(Clone)")){ 
            enemy.GetComponent<Enemy>().animator.SetTrigger("FerullusShowcase");
            bossBackStoryText.GetComponent<TextMeshProUGUI>().text = BossBackStoryManager.AtticusBloodthirstBackStory;
        }

        
        

        enemy.GetComponent<EntityAttributes>().updatePowerValue();

        enemy.transform.position = new Vector3(0f,-2.76f,0);
        enemy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        enemy.transform.localScale = enemy.GetComponent<Enemy>().originalScale;

        enemyName.text = enemy.GetComponent<EntityAttributes>().entityName;


        /*enemyName.text = enemy.GetComponent<EntityAttributes>().entityName;
        enemyInfo.text = enemy.GetComponent<EntityAttributes>().heightInCm.ToString() + " cm";
        enemyHP.text = enemy.GetComponent<EntityAttributes>().maxHP.ToString();
        enemyPowerValue.text = enemy.GetComponent<EntityAttributes>().PowerValue.ToString();

        enemy_textMeshPro_strengthPoint_text.text = enemy.GetComponent<EntityAttributes>().strength.ToString();
        enemy_textMeshPro_staminaPoint_text.text = enemy.GetComponent<EntityAttributes>().stamina.ToString();
        enemy_textMeshPro_dexterityPoint_text.text = enemy.GetComponent<EntityAttributes>().dexterity.ToString();
        enemy_textMeshPro_vitalityPoint_text.text = enemy.GetComponent<EntityAttributes>().vitality.ToString();
        enemy_textMeshPro_offensePoint_text.text = enemy.GetComponent<EntityAttributes>().offense.ToString();
        enemy_textMeshPro_defencePoint_text.text = enemy.GetComponent<EntityAttributes>().defence.ToString();
        enemy_textMeshPro_auraPoint_text.text = enemy.GetComponent<EntityAttributes>().aura.ToString();
        enemy_textMeshPro_magicPoint_text.text = enemy.GetComponent<EntityAttributes>().magic.ToString();*/
    }

    public void OnDisable(){
        //GameObject player = GameObject.Find("Player");
        //player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        //enemy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

    public void continueToStatsShowcase(){
        statsShowcase.SetActive(true);
        gameObject.SetActive(false);
        enemy.GetComponent<EnemyActionsManager>().side = "right";
        enemy.GetComponent<OpacityController>().stopFadingOut();
        enemy.GetComponent<OpacityController>().SetOpacity(1);
        enemy.GetComponent<EnemyActionsManager>().endShowcaseAnimBool();
    }
}

