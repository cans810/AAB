 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class SkinChanger : MonoBehaviour
{
    private List<string> races = new List<string>();
    private int racesNum = 0;
    public GameObject entityObject;
    public string entityRace;
    public SpriteLibraryAsset[] skins;
    private int raceNumSprite = 0;

    List<Color> skinColors;
    Color CreamColor;
    Color LightBrownColor;
    Color BrownColor;
    Color DarkBrownColorButton;
    Color BlackColorButton;
    Color WhiteBlueColorButton;
    Color VeryLightGreyButton;
    Color LightGreyButton;
    Color GreyColorButton;
    Color YellowColorButton;
    Color LightBlueColorButton;
    Color DarkBlueColorButton;
    Color CyanColorButton;
    Color GreenColorButton;
    Color RedColorButton;
    Color PurpleColorButton;

    void Start(){
        fillRaces();
        fillSkinColors();
        entityRace = "Human";

         randomAppereanceInitial();
    }

    public void randomAppereanceInitial(){
        int randomRace = UnityEngine.Random.Range(0,skins.Length);

        ChangeRace(skins[randomRace],races[randomRace]);
        ChangeSkinColor(generateRandomSkinColor());
    }

    public Color generateRandomSkinColor(){
        int randomSkinColor = UnityEngine.Random.Range(0,skinColors.Count);

        return skinColors[randomSkinColor];
    }

    public void setEntityRaceNext(){
        racesNum += 1;
        raceNumSprite += 1;
        ChangeRace(skins[raceNumSprite],races[racesNum]);
    }
    public void setEntityRacePrev(){
        racesNum -= 1;
        raceNumSprite -= 1;
        ChangeRace(skins[raceNumSprite],races[racesNum]);
    }

    public void ChangeRace(SpriteLibraryAsset race,string raceName){
        entityRace = raceName;
        entityObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = race;
    }

    public SpriteLibraryAsset getCurrentRace(){
        return  entityObject.GetComponent<SpriteLibrary>().spriteLibraryAsset;
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

    private void ChangeSkinColor(Color skinColor){
        // Find a child GameObject by name
        Transform head = entityObject.transform.Find("head");
        Transform torso = entityObject.transform.Find("torso");

        Transform rightArm = entityObject.transform.Find("right_arm");
        Transform rightForearm = entityObject.transform.Find("right_forearm");

        Transform leftArm = entityObject.transform.Find("left_arm");
        Transform leftForearm = entityObject.transform.Find("left_forearm");

        Transform rightLeg = entityObject.transform.Find("right_leg");
        Transform rightCalf = entityObject.transform.Find("right_calf");

        Transform leftLeg = entityObject.transform.Find("left_leg");
        Transform leftCalf = entityObject.transform.Find("left_calf");

        
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

    private void fillSkinColors(){
        skinColors = new List<Color>();
        CreamColor = new Color(252/255f,186/255f,152/255f,1);
        LightBrownColor = new Color(154/255f,86/255f,57/255f,1);
        BrownColor = new Color(91/255f,50/255f,31/255f,1);
        DarkBrownColorButton = new Color(60/255f,32/255f,20/255f,1);
        BlackColorButton = new Color(36/255f,36/255f,36/255f,1);
        WhiteBlueColorButton = new Color(213/255f,253/255f,255/255f,1);
        VeryLightGreyButton = new Color(231/255f,231/255f,231/255f,1);
        LightGreyButton = new Color(183/255f,183/255f,183/255f,1);
        GreyColorButton = new Color(130/255f,130/255f,130/255f,1);
        YellowColorButton = new Color(255/255f,208/255f,114/255f,1);
        LightBlueColorButton = new Color(106/255f,167/255f,202/255f,1);
        DarkBlueColorButton = new Color(28/255f,60/255f,103/255f,1);
        CyanColorButton = new Color(76/255f,204/255f,174/255f,1);
        GreenColorButton = new Color(73/255f,115/255f,70/255f,1);
        RedColorButton = new Color(154/255f,30/255f,27/255f,1);
        PurpleColorButton = new Color(119/255f,37/255f,130/255f,1);

        skinColors.Add(CreamColor);
        skinColors.Add(LightBrownColor);
        skinColors.Add(BrownColor);
        skinColors.Add(DarkBrownColorButton);
        skinColors.Add(BlackColorButton);
        skinColors.Add(WhiteBlueColorButton);
        skinColors.Add(VeryLightGreyButton);
        skinColors.Add(LightGreyButton);
        skinColors.Add(GreyColorButton);
        skinColors.Add(YellowColorButton);
        skinColors.Add(LightBlueColorButton);
        skinColors.Add(DarkBlueColorButton);
        skinColors.Add(CyanColorButton);
        skinColors.Add(GreenColorButton);
        skinColors.Add(RedColorButton);
        skinColors.Add(PurpleColorButton);
    }
}
