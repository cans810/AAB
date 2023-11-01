using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class EnemyGeneratorController : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public static GameObject Instance;
    public Color randomSkinColorGenerated;
    public SpriteLibraryAsset[] skins;
    private List<string> races = new List<string>();

    public List<GameObject> BossesList;

    public static bool SlainRomulusTheLeatherman;
    public static bool SlainFerullus;
    public static bool SlainAtticusBloodthirst;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        fillRaces();
    }
    
    private void Start()
    {
        fillRaces();
    }

    public void generateRandomEnemy(){
        // to remove the existing enemy completely
        if(Instance != null){
            Destroy(Instance);
        }

        Instance = Instantiate(prefabToSpawn);

        if (Instance.GetComponent<Enemy>() != null)
        {
            // Customize the attributes of the spawned enemy
            Instance.GetComponent<EntityAttributes>().entityName = "nbr";

            // APPEREANCE (skin color, race)
            int randomRaceGeneratedIndex = generateRandomRace();
            Instance.GetComponent<SpriteLibrary>().spriteLibraryAsset = skins[randomRaceGeneratedIndex];
            Instance.GetComponent<AppereanceManager>().race = races[randomRaceGeneratedIndex];
            ChangeSkinColor(generateRandomSkinColor());

            // STATS
            HitChance_light = Instance.GetComponent<EntityAttributes>().baseHitChance_light;
            HitChance_medium = Instance.GetComponent<EntityAttributes>().baseHitChance_medium;
            HitChance_heavy = Instance.GetComponent<EntityAttributes>().baseHitChance_heavy;
            HitChance_leap = Instance.GetComponent<EntityAttributes>().baseHitChance_leap;

            STATS_generateRandomStrength();
            STATS_generateRandomVitality();
            STATS_generateRandomStamina();
            STATS_generateRandomDexterity();
            STATS_generateRandomOffense();
            STATS_generateRandomDefence();
        }
        else
        {
            Debug.LogError("Enemy component not found on the prefab instance.");
        }

        DontDestroyOnLoad(Instance);
    }

    public void generateRomulusTheLeatherman(){
        generateBoss(BossesList[0]);

        // APPEREANCE (skin color, race)
        ChangeSkinColor(generateSpecificSkinColor(50,30,60));

        // STATS
        HitChance_light = Instance.GetComponent<EntityAttributes>().baseHitChance_light;
        HitChance_medium = Instance.GetComponent<EntityAttributes>().baseHitChance_medium;
        HitChance_heavy = Instance.GetComponent<EntityAttributes>().baseHitChance_heavy;
        HitChance_leap = Instance.GetComponent<EntityAttributes>().baseHitChance_leap;

        STATS_generateSpecificStrength(5);
        STATS_generateSpecificVitality(7);
        STATS_generateSpecificStamina(6);
        STATS_generateSpecificDexterity(3);
        STATS_generateSpecificOffense(3);
        STATS_generateSpecificDefence(5);
    }

    public void generateFerullus(){
        generateBoss(BossesList[1]);

        // APPEREANCE (skin color, race)
        ChangeSkinColor(generateSpecificSkinColor(252,186,152));

        // STATS
        HitChance_light = Instance.GetComponent<EntityAttributes>().baseHitChance_light;
        HitChance_medium = Instance.GetComponent<EntityAttributes>().baseHitChance_medium;
        HitChance_heavy = Instance.GetComponent<EntityAttributes>().baseHitChance_heavy;
        HitChance_leap = Instance.GetComponent<EntityAttributes>().baseHitChance_leap;

        STATS_generateSpecificStrength(20);
        STATS_generateSpecificVitality(7);
        STATS_generateSpecificStamina(2);
        STATS_generateSpecificDexterity(2);
        STATS_generateSpecificOffense(9);
        STATS_generateSpecificDefence(6);
    }
    public void generateAtticusBloodthirst(){
        generateBoss(BossesList[2]);

        // APPEREANCE (skin color, race)
        ChangeSkinColor(generateSpecificSkinColor(110,140,108));

        // STATS
        HitChance_light = Instance.GetComponent<EntityAttributes>().baseHitChance_light;
        HitChance_medium = Instance.GetComponent<EntityAttributes>().baseHitChance_medium;
        HitChance_heavy = Instance.GetComponent<EntityAttributes>().baseHitChance_heavy;
        HitChance_leap = Instance.GetComponent<EntityAttributes>().baseHitChance_leap;

        STATS_generateSpecificStrength(22);
        STATS_generateSpecificVitality(12);
        STATS_generateSpecificStamina(8);
        STATS_generateSpecificDexterity(3);
        STATS_generateSpecificOffense(13);
        STATS_generateSpecificDefence(4);
    }

    public void generateBoss(GameObject bossPrefab){
        // to remove the existing enemy completely
        if(Instance != null){
            Destroy(Instance);
        }

        Instance = Instantiate(bossPrefab);

        DontDestroyOnLoad(Instance);
    }

    public Color generateRandomSkinColor(){
        int randomRed = UnityEngine.Random.Range(0, 255);
        int randomGreen = UnityEngine.Random.Range(0, 255);
        int randomBlue = UnityEngine.Random.Range(0, 255);

        randomSkinColorGenerated = new Color(randomRed/ 255f,randomGreen/ 255f,randomBlue/ 255f);

        return randomSkinColorGenerated;
    }

    public int generateRandomRace(){
        int randomRace = UnityEngine.Random.Range(0, skins.Length);
        return randomRace;
    }

    public void STATS_generateRandomStrength(){
        int randomStrengthValue = UnityEngine.Random.Range(1,100);

        Instance.GetComponent<EntityAttributes>().strength = randomStrengthValue;

        for (int i=1;i<randomStrengthValue;i++){

            Instance.GetComponent<EntityAttributes>().heightInCm += 2f;
            Instance.GetComponent<EntityAttributes>().hitDamage += 2;

            // adjust player size here
            // Store the original position
            Vector3 originalPosition = Instance.transform.position;

            // Calculate the new scale uniformly
            float newScale =  Instance.GetComponent<Enemy>().showcaseScale.x * 1.01f;

            // Calculate the position adjustment based on the scale change
            Vector3 positionAdjustment = (newScale -  Instance.GetComponent<Enemy>().showcaseScale.x) * 0.59f *  Instance.transform.up;

            // Apply the new scale and adjust the position
            Instance.GetComponent<Enemy>().showcaseScale = new Vector3(newScale, newScale,  Instance.GetComponent<Enemy>().showcaseScale.z);

            // Calculate the new scale uniformly
            float newScaleReal =  Instance.GetComponent<Enemy>().originalScale.x * 1.01f;

            // Calculate the position adjustment based on the scale change
            Vector3 positionAdjustmentReal = (newScaleReal -  Instance.GetComponent<Enemy>().originalScale.x) * 0.59f *  Instance.transform.up;

            // Apply the new scale and adjust the position
            Instance.GetComponent<Enemy>().originalScale = new Vector3(newScaleReal, newScaleReal,  Instance.GetComponent<Enemy>().originalScale.z);

            Instance.transform.position = originalPosition - positionAdjustment;
            //player.transform.position = originalPosition - positionAdjustmentReal;
        }
    }

    public void STATS_generateRandomVitality(){
        int randomVitalityValue = UnityEngine.Random.Range(1,10);

        Instance.GetComponent<EntityAttributes>().vitality = randomVitalityValue;

        for (int i=1;i<randomVitalityValue;i++){
            Instance.GetComponent<EntityAttributes>().maxHP += 10;
        }
    }

    public void STATS_generateRandomStamina(){
        int randomStaminaValue = UnityEngine.Random.Range(1,10);

        Instance.GetComponent<EntityAttributes>().stamina = randomStaminaValue;

        for (int i=1;i<randomStaminaValue;i++){
            Instance.GetComponent<EntityAttributes>().maxSP += 10;
        }
    }

    public void STATS_generateRandomDexterity(){
        int randomDexterityValue = UnityEngine.Random.Range(1,10);

        Instance.GetComponent<EntityAttributes>().dexterity = randomDexterityValue;

        for (int i=1;i<randomDexterityValue;i++){
            Instance.GetComponent<EntityAttributes>().stepSize += 0.2f;
            Instance.GetComponent<EntityAttributes>().moveSpeed += 0.1f;
        }
    }

    public static float HitChance_light;
    public static float HitChance_medium;
    public static float HitChance_heavy;
    public static float HitChance_leap;

    public void STATS_generateRandomOffense(){
        int randomOffenseValue = UnityEngine.Random.Range(1,10);

        Instance.GetComponent<EntityAttributes>().offense = randomOffenseValue;

        for (int i=1;i<randomOffenseValue;i++){
            Instance.GetComponent<EntityAttributes>().baseHitChance_light *= 1.0545f;
            HitChance_light *= 1.0545f;

            Instance.GetComponent<EntityAttributes>().baseHitChance_medium *= 1.0545f;
            HitChance_medium *= 1.0545f;

            Instance.GetComponent<EntityAttributes>().baseHitChance_heavy *= 1.0545f;
            HitChance_heavy *= 1.0545f;

            Instance.GetComponent<EntityAttributes>().baseHitChance_leap *= 1.0545f;
            HitChance_leap *= 1.0545f;

            if (Instance.GetComponent<EntityAttributes>().baseHitChance_light*100 > 90) Instance.GetComponent<EntityAttributes>().baseHitChance_light = 90f/100f;
            if (Instance.GetComponent<EntityAttributes>().baseHitChance_medium*100 > 90) Instance.GetComponent<EntityAttributes>().baseHitChance_medium = 90f/100f;
            if (Instance.GetComponent<EntityAttributes>().baseHitChance_heavy*100 > 90) Instance.GetComponent<EntityAttributes>().baseHitChance_heavy = 90f/100f;
            if (Instance.GetComponent<EntityAttributes>().baseHitChance_leap*100 > 90) Instance.GetComponent<EntityAttributes>().baseHitChance_leap = 90f/100f;
        }
    }

    public void STATS_generateRandomDefence(){
        int randomDefenceValue = UnityEngine.Random.Range(1,10);

        Instance.GetComponent<EntityAttributes>().defence = randomDefenceValue;
    }

    public Color generateSpecificSkinColor(int red,int green,int blue){

        randomSkinColorGenerated = new Color(red/ 255f,green/ 255f,blue/ 255f);

        return randomSkinColorGenerated;
    }

    public void STATS_generateSpecificStrength(int strength){

        Instance.GetComponent<EntityAttributes>().strength = strength;

        for (int i=1;i<strength;i++){

            Instance.GetComponent<EntityAttributes>().heightInCm += 2f;
            Instance.GetComponent<EntityAttributes>().hitDamage += 2;

            // adjust player size here
            // Store the original position
            Vector3 originalPosition = Instance.transform.position;

            // Calculate the new scale uniformly
            float newScale =  Instance.GetComponent<Enemy>().showcaseScale.x * 1.01f;

            // Calculate the position adjustment based on the scale change
            Vector3 positionAdjustment = (newScale -  Instance.GetComponent<Enemy>().showcaseScale.x) * 0.59f *  Instance.transform.up;

            // Apply the new scale and adjust the position
            Instance.GetComponent<Enemy>().showcaseScale = new Vector3(newScale, newScale,  Instance.GetComponent<Enemy>().showcaseScale.z);

            // Calculate the new scale uniformly
            float newScaleReal =  Instance.GetComponent<Enemy>().originalScale.x * 1.01f;

            // Calculate the position adjustment based on the scale change
            Vector3 positionAdjustmentReal = (newScaleReal -  Instance.GetComponent<Enemy>().originalScale.x) * 0.59f *  Instance.transform.up;

            // Apply the new scale and adjust the position
            Instance.GetComponent<Enemy>().originalScale = new Vector3(newScaleReal, newScaleReal,  Instance.GetComponent<Enemy>().originalScale.z);

            Instance.transform.position = originalPosition - positionAdjustment;
            //player.transform.position = originalPosition - positionAdjustmentReal;
        }
    }

    public void STATS_generateSpecificVitality(int vitality){
        Instance.GetComponent<EntityAttributes>().vitality = vitality;

        for (int i=1;i<vitality;i++){
            Instance.GetComponent<EntityAttributes>().maxHP += 10;
        }
    }

    public void STATS_generateSpecificStamina(int stamina){
        Instance.GetComponent<EntityAttributes>().stamina = stamina;

        for (int i=1;i<stamina;i++){
            Instance.GetComponent<EntityAttributes>().maxSP += 10;
        }
    }

    public void STATS_generateSpecificDexterity(int dexterity){
        Instance.GetComponent<EntityAttributes>().dexterity = dexterity;

        for (int i=1;i<dexterity;i++){
            Instance.GetComponent<EntityAttributes>().stepSize += 0.2f;
            Instance.GetComponent<EntityAttributes>().moveSpeed += 0.1f;
        }
    }

    public void STATS_generateSpecificOffense(int offense){
        int randomOffenseValue = UnityEngine.Random.Range(1,10);

        Instance.GetComponent<EntityAttributes>().offense = offense;

        for (int i=1;i<offense;i++){
            Instance.GetComponent<EntityAttributes>().baseHitChance_light *= 1.0545f;
            HitChance_light *= 1.0545f;

            Instance.GetComponent<EntityAttributes>().baseHitChance_medium *= 1.0545f;
            HitChance_medium *= 1.0545f;

            Instance.GetComponent<EntityAttributes>().baseHitChance_heavy *= 1.0545f;
            HitChance_heavy *= 1.0545f;

            Instance.GetComponent<EntityAttributes>().baseHitChance_leap *= 1.0545f;
            HitChance_leap *= 1.0545f;

            if (Instance.GetComponent<EntityAttributes>().baseHitChance_light*100 > 90) Instance.GetComponent<EntityAttributes>().baseHitChance_light = 90f/100f;
            if (Instance.GetComponent<EntityAttributes>().baseHitChance_medium*100 > 90) Instance.GetComponent<EntityAttributes>().baseHitChance_medium = 90f/100f;
            if (Instance.GetComponent<EntityAttributes>().baseHitChance_heavy*100 > 90) Instance.GetComponent<EntityAttributes>().baseHitChance_heavy = 90f/100f;
            if (Instance.GetComponent<EntityAttributes>().baseHitChance_leap*100 > 90) Instance.GetComponent<EntityAttributes>().baseHitChance_leap = 90f/100f;
        }
    }

    public void STATS_generateSpecificDefence(int defence){

        Instance.GetComponent<EntityAttributes>().defence = defence;
    }

    private void ChangeSkinColor(Color skinColor){
        // Find a child GameObject by name
        Transform head = Instance.transform.Find("head");
        Transform torso = Instance.transform.Find("torso");

        Transform rightArm = Instance.transform.Find("right_arm");
        Transform rightForearm = Instance.transform.Find("right_forearm");

        Transform leftArm = Instance.transform.Find("left_arm");
        Transform leftForearm = Instance.transform.Find("left_forearm");

        Transform rightLeg = Instance.transform.Find("right_leg");
        Transform rightCalf = Instance.transform.Find("right_calf");

        Transform leftLeg = Instance.transform.Find("left_leg");
        Transform leftCalf = Instance.transform.Find("left_calf");

        
        // Do something with the found child GameObject
        GameObject childObject_head = head.gameObject;
        childObject_head.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_torso = torso.gameObject;
        childObject_torso.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_rightArm = rightArm.gameObject;
        childObject_rightArm.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_rightForearm = rightForearm.gameObject;
        childObject_rightForearm.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_leftArm = leftArm.gameObject;
        childObject_leftArm.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_leftForearm = leftForearm.gameObject;
        childObject_leftForearm.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_rightLeg = rightLeg.gameObject;
        childObject_rightLeg.GetComponent<SpriteRenderer>().color = skinColor;
        GameObject childObject_rightCalf = rightCalf.gameObject;
        childObject_rightCalf.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_leftLeg = leftLeg.gameObject;
        childObject_leftLeg.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_leftCalf = leftCalf.gameObject;
        childObject_leftCalf.GetComponent<SpriteRenderer>().color = skinColor;
    }

    private void fillRaces(){
        races.Add("Human");
        races.Add("Cyclops");
        races.Add("Skeleton");
        races.Add("Elf");
        races.Add("Orc");
        races.Add("Tiefling");
        races.Add("Beast");
    }
}
