using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelUpScene : MonoBehaviour
{
    private Player player;
    // Start is called before the first frame update

    public GameObject totalPointsGameObject;
    public GameObject strengthPointGameObject;
    public GameObject staminaPointGameObject;
    public GameObject dexterityPointGameObject;
    public GameObject vitalityPointGameObject;
    public GameObject offensePointGameObject;
    public GameObject defencePointGameObject;
    public GameObject auraPointGameObject;
    public GameObject magicPointGameObject;

    private TextMeshProUGUI textMeshPro_totalPoints_text;
    private TextMeshProUGUI textMeshPro_strengthPoint_text;
    private TextMeshProUGUI textMeshPro_staminaPoint_text;
    private TextMeshProUGUI textMeshPro_dexterityPoint_text;
    private TextMeshProUGUI textMeshPro_vitalityPoint_text;
    private TextMeshProUGUI textMeshPro_offensePoint_text;
    private TextMeshProUGUI textMeshPro_defencePoint_text;
    private TextMeshProUGUI textMeshPro_auraPoint_text;
    private TextMeshProUGUI textMeshPro_magicPoint_text;

    public int totalPoints;

    void Start()
    {
        totalPoints = 2;

        player = Player.Instance;

        player.transform.position = new Vector3(2,-4.224179f,0);

        textMeshPro_totalPoints_text = totalPointsGameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro_strengthPoint_text = strengthPointGameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro_staminaPoint_text = staminaPointGameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro_dexterityPoint_text = dexterityPointGameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro_vitalityPoint_text = vitalityPointGameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro_offensePoint_text = offensePointGameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro_defencePoint_text = defencePointGameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro_auraPoint_text = auraPointGameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro_magicPoint_text = magicPointGameObject.GetComponent<TextMeshProUGUI>();

        if (EnemyGeneratorController.Instance != null){
            Destroy(EnemyGeneratorController.Instance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro_totalPoints_text.text = totalPoints.ToString();
        textMeshPro_strengthPoint_text.text = player.GetComponent<EntityAttributes>().strength.ToString();
        textMeshPro_staminaPoint_text.text = player.GetComponent<EntityAttributes>().stamina.ToString();
        textMeshPro_dexterityPoint_text.text = player.GetComponent<EntityAttributes>().dexterity.ToString();
        textMeshPro_vitalityPoint_text.text = player.GetComponent<EntityAttributes>().vitality.ToString();
        textMeshPro_offensePoint_text.text = player.GetComponent<EntityAttributes>().offense.ToString();
        textMeshPro_defencePoint_text.text = player.GetComponent<EntityAttributes>().defence.ToString();
        textMeshPro_auraPoint_text.text = player.GetComponent<EntityAttributes>().aura.ToString();
        textMeshPro_magicPoint_text.text = player.GetComponent<EntityAttributes>().magic.ToString();
        
        player.transform.localScale = player.showcaseScale;
    }

    public void increaseStrength(){
        totalPoints -= 1;
        player.GetComponent<EntityAttributes>().strength += 1;
        player.GetComponent<EntityAttributes>().hitDamage += 2;
        player.GetComponent<EntityAttributes>().heightInCm += 2f;

        // adjust player size here
        // Store the original position
        Vector3 originalPosition = player.transform.position;

         // Calculate the new scale uniformly
        float newScale =  player.showcaseScale.x * 1.01f;

        // Calculate the position adjustment based on the scale change
        Vector3 positionAdjustment = (newScale -  player.showcaseScale.x) * 0.59f *  player.transform.up;

        // Apply the new scale and adjust the position
        player.showcaseScale = new Vector3(newScale, newScale,  player.showcaseScale.z);

         // Calculate the new scale uniformly
        float newScaleReal =  player.originalScale.x * 1.01f;

        // Calculate the position adjustment based on the scale change
        Vector3 positionAdjustmentReal = (newScaleReal -  player.originalScale.x) * 0.59f *  player.transform.up;

        // Apply the new scale and adjust the position
        player.originalScale = new Vector3(newScaleReal, newScaleReal,  player.originalScale.z);

        player.transform.position = originalPosition - positionAdjustment;
        //player.transform.position = originalPosition - positionAdjustmentReal;
    }
    public void decreaseStrength(){
        totalPoints += 1;
        player.GetComponent<EntityAttributes>().strength -= 1;
        player.GetComponent<EntityAttributes>().hitDamage -= 2;
        player.GetComponent<EntityAttributes>().heightInCm -= 2f;

        // adjust player size here
        // Store the original position
        Vector3 originalPosition = player.transform.position;

         // Calculate the new scale uniformly
        float newScale =  player.showcaseScale.x / 1.01f;

        // Calculate the position adjustment based on the scale change
        Vector3 positionAdjustment = (newScale -  player.showcaseScale.x) * 0.59f *  player.transform.up;

        // Apply the new scale and adjust the position
        player.showcaseScale = new Vector3(newScale, newScale,  player.showcaseScale.z);

        // Calculate the new scale uniformly
        float newScaleReal =  player.originalScale.x / 1.01f;

        // Calculate the position adjustment based on the scale change
        Vector3 positionAdjustmentReal = (newScaleReal -  player.originalScale.x) * 0.59f *  player.transform.up;

        // Apply the new scale and adjust the position
        player.originalScale = new Vector3(newScaleReal, newScaleReal,  player.originalScale.z);

        player.transform.position = originalPosition - positionAdjustment;
    }

    public void increaseStamina(){
        totalPoints -= 1;
        player.GetComponent<EntityAttributes>().stamina += 1;
        player.GetComponent<EntityAttributes>().maxSP += 10;
    }
    public void decreaseStamina(){
        totalPoints += 1;
        player.GetComponent<EntityAttributes>().stamina -= 1;
        player.GetComponent<EntityAttributes>().maxSP -= 10;
    }

    public void increaseDexterity(){
        totalPoints -= 1;
        player.GetComponent<EntityAttributes>().dexterity += 1;
        player.GetComponent<EntityAttributes>().stepSize += 0.2f;
        player.GetComponent<EntityAttributes>().moveSpeed += 0.1f;
    }
    public void decreaseDexterity(){
        totalPoints += 1;
        player.GetComponent<EntityAttributes>().dexterity -= 1;
        player.GetComponent<EntityAttributes>().stepSize -= 0.2f;
        player.GetComponent<EntityAttributes>().moveSpeed -= 0.1f;
    }

    public void increaseVitality(){
        totalPoints -= 1;
        player.GetComponent<EntityAttributes>().vitality += 1;
        player.GetComponent<EntityAttributes>().maxHP += 10;
    }
    public void decreaseVitality(){
        totalPoints += 1;
        player.GetComponent<EntityAttributes>().vitality -= 1;
        player.GetComponent<EntityAttributes>().maxHP -= 10;
    }

    float HitChance_light;
     float HitChance_medium;
     float HitChance_heavy;
     float HitChance_leap;

    public void increaseOffense(){
        totalPoints -= 1;
        player.GetComponent<EntityAttributes>().offense += 1;

        player.GetComponent<EntityAttributes>().baseHitChance_light *= 1.0545f;
        CreateNewCharacter.HitChance_light *= 1.0545f;

        player.GetComponent<EntityAttributes>().baseHitChance_medium *= 1.0545f;
        CreateNewCharacter.HitChance_medium *= 1.0545f;

        player.GetComponent<EntityAttributes>().baseHitChance_heavy *= 1.0545f;
        CreateNewCharacter.HitChance_heavy *= 1.0545f;

        player.GetComponent<EntityAttributes>().baseHitChance_leap *= 1.0545f;
        CreateNewCharacter.HitChance_leap *= 1.0545f;

        if (player.GetComponent<EntityAttributes>().baseHitChance_light*100 > 90) player.GetComponent<EntityAttributes>().baseHitChance_light = 90f/100f;
        if (player.GetComponent<EntityAttributes>().baseHitChance_medium*100 > 90) player.GetComponent<EntityAttributes>().baseHitChance_medium = 90f/100f;
        if (player.GetComponent<EntityAttributes>().baseHitChance_heavy*100 > 90) player.GetComponent<EntityAttributes>().baseHitChance_heavy = 90f/100f;
        if (player.GetComponent<EntityAttributes>().baseHitChance_leap*100 > 90) player.GetComponent<EntityAttributes>().baseHitChance_leap = 90f/100f;
    }
    public void decreaseOffense(){
        totalPoints += 1;
        player.GetComponent<EntityAttributes>().offense -= 1;

        player.GetComponent<EntityAttributes>().baseHitChance_light /= 1.0545f;
        CreateNewCharacter.HitChance_light /= 1.0545f;

        player.GetComponent<EntityAttributes>().baseHitChance_medium /= 1.0545f;
        CreateNewCharacter.HitChance_medium /= 1.0545f;

        player.GetComponent<EntityAttributes>().baseHitChance_heavy /= 1.0545f;
        CreateNewCharacter.HitChance_heavy /= 1.0545f;

        player.GetComponent<EntityAttributes>().baseHitChance_leap /= 1.0545f;
        CreateNewCharacter.HitChance_leap /= 1.0545f;

        if (player.GetComponent<EntityAttributes>().baseHitChance_light*100 < 90) player.GetComponent<EntityAttributes>().baseHitChance_light = CreateNewCharacter.HitChance_light;
        if (player.GetComponent<EntityAttributes>().baseHitChance_medium*100 < 90) player.GetComponent<EntityAttributes>().baseHitChance_medium = CreateNewCharacter.HitChance_medium;
        if (player.GetComponent<EntityAttributes>().baseHitChance_heavy*100 < 90) player.GetComponent<EntityAttributes>().baseHitChance_heavy = CreateNewCharacter.HitChance_heavy;
        if (player.GetComponent<EntityAttributes>().baseHitChance_leap*100 < 90) player.GetComponent<EntityAttributes>().baseHitChance_leap = CreateNewCharacter.HitChance_leap;
        
        if (player.GetComponent<EntityAttributes>().baseHitChance_light*100 > 90) player.GetComponent<EntityAttributes>().baseHitChance_light = 90f/100f;
        if (player.GetComponent<EntityAttributes>().baseHitChance_medium*100 > 90) player.GetComponent<EntityAttributes>().baseHitChance_medium = 90f/100f;
        if (player.GetComponent<EntityAttributes>().baseHitChance_heavy*100 > 90) player.GetComponent<EntityAttributes>().baseHitChance_heavy = 90f/100f;
        if (player.GetComponent<EntityAttributes>().baseHitChance_leap*100 > 90) player.GetComponent<EntityAttributes>().baseHitChance_leap = 90f/100f;
    }

    public void increaseDefence(){
        totalPoints -= 1;
        player.GetComponent<EntityAttributes>().defence += 1;
    }
    public void decreaseDefence(){
        totalPoints += 1;
        player.GetComponent<EntityAttributes>().defence -= 1;
    }

    public void increaseAura(){
        totalPoints -= 1;
        player.GetComponent<EntityAttributes>().aura += 1;
    }
    public void decreaseAura(){
        totalPoints += 1;
        player.GetComponent<EntityAttributes>().aura -= 1;
    }

    public void increaseMagic(){
        totalPoints -= 1;
        player.GetComponent<EntityAttributes>().magic += 1;
    }
    public void decreaseMagic(){
        totalPoints += 1;
        player.GetComponent<EntityAttributes>().magic -= 1;
    }
    
    public void goToTown(){
        if (Player.Instance.inATournament){
            continueToTournament();
        }
        else{
            SceneManager.LoadSceneAsync("TownScene");
        }
    }

    public void continueToTournament(){
        TournamentManager.Instance.enemysToBeat -= 1;
        if(EnemyGeneratorController.Instance != null){
            Destroy(EnemyGeneratorController.Instance);
        }
        GameObject sceneLoader = GameObject.Find("SceneLoader");
        sceneLoader.GetComponent<SceneLoader>().FadeToLevel("TournamentShowcaseScene");
    }
}
