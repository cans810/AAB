using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using UnityEngine.U2D.Animation;

public class CreateNewCharacter : MonoBehaviour
{

    // nickname input
    public TMP_InputField inputField;

    // UI Text game objects
    public GameObject totalPointsGameObject;
    public GameObject strengthPointGameObject;
    public GameObject staminaPointGameObject;
    public GameObject dexterityPointGameObject;
    public GameObject vitalityPointGameObject;
    public GameObject offensePointGameObject;
    public GameObject defencePointGameObject;
    public GameObject auraPointGameObject;
    public GameObject magicPointGameObject;

    // game variables
    public int totalPoints;

    // text components
    private TextMeshProUGUI textMeshPro_totalPoints_text;
    private TextMeshProUGUI textMeshPro_strengthPoint_text;
    private TextMeshProUGUI textMeshPro_staminaPoint_text;
    private TextMeshProUGUI textMeshPro_dexterityPoint_text;
    private TextMeshProUGUI textMeshPro_vitalityPoint_text;
    private TextMeshProUGUI textMeshPro_offensePoint_text;
    private TextMeshProUGUI textMeshPro_defencePoint_text;
    private TextMeshProUGUI textMeshPro_auraPoint_text;
    private TextMeshProUGUI textMeshPro_magicPoint_text;

    public GameObject SetAppereanceObject;
    public GameObject GiveStatsObject;
    public GameObject EnterNameObject;

    // player and player attributes
    public Player player;
    public static string entityName;
    public SkinChanger skinChanger;
    public static SpriteLibraryAsset race;
    public static string raceName;

    // Start is called before the first frame update
    void Start(){
        totalPoints = 5;
        player.GetComponent<EntityAttributes>().strength = 1;
        player.GetComponent<EntityAttributes>().stamina = 1;
        player.GetComponent<EntityAttributes>().dexterity = 1;
        player.GetComponent<EntityAttributes>().vitality = 1;
        player.GetComponent<EntityAttributes>().offense = 1;
        player.GetComponent<EntityAttributes>().defence = 1;
        player.GetComponent<EntityAttributes>().aura = 1;
        player.GetComponent<EntityAttributes>().magic = 1;

        player.GetComponent<EntityAttributes>().heightInCm = 170;

        raceName = skinChanger.entityRace;

        SetAppereanceObject.SetActive(true);
        GiveStatsObject.SetActive(false);
        EnterNameObject.SetActive(false);

        textMeshPro_totalPoints_text = totalPointsGameObject.GetComponent<TextMeshProUGUI>();

        textMeshPro_strengthPoint_text = strengthPointGameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro_staminaPoint_text = staminaPointGameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro_dexterityPoint_text = dexterityPointGameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro_vitalityPoint_text = vitalityPointGameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro_offensePoint_text = offensePointGameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro_defencePoint_text = defencePointGameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro_auraPoint_text = auraPointGameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro_magicPoint_text = magicPointGameObject.GetComponent<TextMeshProUGUI>();

        HitChance_light = player.GetComponent<EntityAttributes>().baseHitChance_light;
        HitChance_medium = player.GetComponent<EntityAttributes>().baseHitChance_medium;
        HitChance_heavy = player.GetComponent<EntityAttributes>().baseHitChance_heavy;
        HitChance_leap = player.GetComponent<EntityAttributes>().baseHitChance_leap;
    }

    // Update is called once per frame
    void Update(){
         // text mesh pro
         textMeshPro_totalPoints_text.text = totalPoints.ToString();
         textMeshPro_strengthPoint_text.text = player.GetComponent<EntityAttributes>().strength.ToString();
         textMeshPro_staminaPoint_text.text = player.GetComponent<EntityAttributes>().stamina.ToString();
         textMeshPro_dexterityPoint_text.text = player.GetComponent<EntityAttributes>().dexterity.ToString();
         textMeshPro_vitalityPoint_text.text = player.GetComponent<EntityAttributes>().vitality.ToString();
         textMeshPro_offensePoint_text.text = player.GetComponent<EntityAttributes>().offense.ToString();
         textMeshPro_defencePoint_text.text = player.GetComponent<EntityAttributes>().defence.ToString();
         textMeshPro_auraPoint_text.text = player.GetComponent<EntityAttributes>().aura.ToString();
         textMeshPro_magicPoint_text.text = player.GetComponent<EntityAttributes>().magic.ToString();

         updatePlayerValues();

         player.transform.localScale = player.showcaseScale;

         //Debug.Log(player.GetComponent<AppereanceManager>().race);
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

     public static float HitChance_light;
     public static float HitChance_medium;
     public static float HitChance_heavy;
     public static float HitChance_leap;

    public void increaseOffense(){
        totalPoints -= 1;
        player.GetComponent<EntityAttributes>().offense += 1;

        player.GetComponent<EntityAttributes>().baseHitChance_light *= 1.0545f;
        HitChance_light *= 1.0545f;

        player.GetComponent<EntityAttributes>().baseHitChance_medium *= 1.0545f;
        HitChance_medium *= 1.0545f;

        player.GetComponent<EntityAttributes>().baseHitChance_heavy *= 1.0545f;
        HitChance_heavy *= 1.0545f;

        player.GetComponent<EntityAttributes>().baseHitChance_leap *= 1.0545f;
        HitChance_leap *= 1.0545f;

        if (player.GetComponent<EntityAttributes>().baseHitChance_light*100 > 90) player.GetComponent<EntityAttributes>().baseHitChance_light = 90f/100f;
        if (player.GetComponent<EntityAttributes>().baseHitChance_medium*100 > 90) player.GetComponent<EntityAttributes>().baseHitChance_medium = 90f/100f;
        if (player.GetComponent<EntityAttributes>().baseHitChance_heavy*100 > 90) player.GetComponent<EntityAttributes>().baseHitChance_heavy = 90f/100f;
        if (player.GetComponent<EntityAttributes>().baseHitChance_leap*100 > 90) player.GetComponent<EntityAttributes>().baseHitChance_leap = 90f/100f;
    }
    public void decreaseOffense(){
        totalPoints += 1;
        player.GetComponent<EntityAttributes>().offense -= 1;

        player.GetComponent<EntityAttributes>().baseHitChance_light /= 1.0545f;
        HitChance_light /= 1.0545f;

        player.GetComponent<EntityAttributes>().baseHitChance_medium /= 1.0545f;
        HitChance_medium /= 1.0545f;

        player.GetComponent<EntityAttributes>().baseHitChance_heavy /= 1.0545f;
        HitChance_heavy /= 1.0545f;

        player.GetComponent<EntityAttributes>().baseHitChance_leap /= 1.0545f;
        HitChance_leap /= 1.0545f;

        if (player.GetComponent<EntityAttributes>().baseHitChance_light*100 < 90) player.GetComponent<EntityAttributes>().baseHitChance_light = HitChance_light;
        if (player.GetComponent<EntityAttributes>().baseHitChance_medium*100 < 90) player.GetComponent<EntityAttributes>().baseHitChance_medium = HitChance_medium;
        if (player.GetComponent<EntityAttributes>().baseHitChance_heavy*100 < 90) player.GetComponent<EntityAttributes>().baseHitChance_heavy = HitChance_heavy;
        if (player.GetComponent<EntityAttributes>().baseHitChance_leap*100 < 90) player.GetComponent<EntityAttributes>().baseHitChance_leap = HitChance_leap;
        
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

    public void proceedToGiveStats(){
        SetAppereanceObject.SetActive(false);
        GiveStatsObject.SetActive(true);
    }

    public void proceedToEnterName(){
        GiveStatsObject.SetActive(false);
        EnterNameObject.SetActive(true);
    }

    public void updatePlayerValues(){
        player.GetComponent<SpriteLibrary>().spriteLibraryAsset = skinChanger.getCurrentRace();
        player.GetComponent<AppereanceManager>().race = skinChanger.entityRace;

        player.GetComponent<EntityAttributes>().entityName = inputField.text;
    }

    public void enterFirstBattle(){
        updatePlayerValues();
        GameObject backgroundMusicManager = GameObject.Find("Background Music");
        backgroundMusicManager.GetComponent<BackgroundMusicManager>().StartFadeOut();
        
        GameObject sceneLoader = GameObject.Find("SceneLoader");
        sceneLoader.GetComponent<SceneLoader>().FadeToLevel("ShowcaseEnemy");
    }
}
