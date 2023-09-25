using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowcaseEnemy : MonoBehaviour
{
    public TextMeshProUGUI enemyName;
    public TextMeshProUGUI enemyInfo;
    public TextMeshProUGUI enemyHP;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerInfo;
    public TextMeshProUGUI playerHP;

    private GameObject enemy;

    public TextMeshProUGUI enemy_textMeshPro_strengthPoint_text;
    public TextMeshProUGUI enemy_textMeshPro_staminaPoint_text;
    public TextMeshProUGUI enemy_textMeshPro_dexterityPoint_text;
    public TextMeshProUGUI enemy_textMeshPro_vitalityPoint_text;
    public TextMeshProUGUI enemy_textMeshPro_offensePoint_text;
    public TextMeshProUGUI enemy_textMeshPro_defencePoint_text;
    public TextMeshProUGUI enemy_textMeshPro_auraPoint_text;
    public TextMeshProUGUI enemy_textMeshPro_magicPoint_text;

    public TextMeshProUGUI player_textMeshPro_strengthPoint_text;
    public TextMeshProUGUI player_textMeshPro_staminaPoint_text;
    public TextMeshProUGUI player_textMeshPro_dexterityPoint_text;
    public TextMeshProUGUI player_textMeshPro_vitalityPoint_text;
    public TextMeshProUGUI player_textMeshPro_offensePoint_text;
    public TextMeshProUGUI player_textMeshPro_defencePoint_text;
    public TextMeshProUGUI player_textMeshPro_auraPoint_text;
    public TextMeshProUGUI player_textMeshPro_magicPoint_text;

    public List<Sprite> arena_images;
    
    public GameObject arena_image;

    void Awake(){
        string arenaCurrent = GameObject.Find("GameManager").GetComponent<GameManager>().currentArena;
        
        for (int i = 0; i < arena_images.Count; i++)
        {
            if (arena_images[i].name.Equals(arenaCurrent)){
                arena_image.GetComponent<Image>().sprite = arena_images[i];
                break;
            }
        }

        GameObject player = GameObject.Find("Player");

        GameObject randomEnemyGenerated = GameObject.Find("GladiatorGenerator");
        randomEnemyGenerated.GetComponent<RandomEnemyGenerator>().generateRandomEnemy();

        enemy = RandomEnemyGenerator.Instance;

        enemy.transform.position = new Vector3(3.58f,-1.77915f,0);
        enemy.transform.localScale = enemy.GetComponent<Enemy>().originalScale;
        enemyName.text = enemy.GetComponent<EntityAttributes>().entityName;
        enemyInfo.text = enemy.GetComponent<EntityAttributes>().heightInCm.ToString() + " cm";
        enemyHP.text = enemy.GetComponent<EntityAttributes>().maxHP.ToString();

        player.transform.position = new Vector3(-3.24f,-1.77915f,0);
        player.transform.localScale = player.GetComponent<Player>().originalScale;
        playerName.text = player.GetComponent<EntityAttributes>().entityName;
        playerInfo.text = player.GetComponent<EntityAttributes>().heightInCm.ToString() + " cm";
        playerHP.text = player.GetComponent<EntityAttributes>().maxHP.ToString();

        enemy_textMeshPro_strengthPoint_text.text = enemy.GetComponent<EntityAttributes>().strength.ToString();
        enemy_textMeshPro_staminaPoint_text.text = enemy.GetComponent<EntityAttributes>().stamina.ToString();
        enemy_textMeshPro_dexterityPoint_text.text = enemy.GetComponent<EntityAttributes>().dexterity.ToString();
        enemy_textMeshPro_vitalityPoint_text.text = enemy.GetComponent<EntityAttributes>().vitality.ToString();
        enemy_textMeshPro_offensePoint_text.text = enemy.GetComponent<EntityAttributes>().offense.ToString();
        enemy_textMeshPro_defencePoint_text.text = enemy.GetComponent<EntityAttributes>().defence.ToString();
        enemy_textMeshPro_auraPoint_text.text = enemy.GetComponent<EntityAttributes>().aura.ToString();
        enemy_textMeshPro_magicPoint_text.text = enemy.GetComponent<EntityAttributes>().magic.ToString();

        player_textMeshPro_strengthPoint_text.text = player.GetComponent<EntityAttributes>().strength.ToString();
        player_textMeshPro_staminaPoint_text.text = player.GetComponent<EntityAttributes>().stamina.ToString();
        player_textMeshPro_dexterityPoint_text.text = player.GetComponent<EntityAttributes>().dexterity.ToString();
        player_textMeshPro_vitalityPoint_text.text = player.GetComponent<EntityAttributes>().vitality.ToString();
        player_textMeshPro_offensePoint_text.text = player.GetComponent<EntityAttributes>().offense.ToString();
        player_textMeshPro_defencePoint_text.text = player.GetComponent<EntityAttributes>().defence.ToString();
        player_textMeshPro_auraPoint_text.text = player.GetComponent<EntityAttributes>().aura.ToString();
        player_textMeshPro_magicPoint_text.text = player.GetComponent<EntityAttributes>().magic.ToString();
    }

    public void enterFirstBattle(){
        GameObject BattleScreen = GameObject.Find("In-Battle Objects");
        BattleScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
