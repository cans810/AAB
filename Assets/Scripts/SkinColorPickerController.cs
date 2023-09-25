using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinColorPickerController : MonoBehaviour
{
    public Button baseCreamButton;
    public Button baseBrownButton;
    public Button LightBrownButton;
    public Button BrownButton;
    public Button DarkBrownButton;
    public Button BlackButton;
    public Button WhiteBlueButton;
    public Button VeryLightGreyButton;
    public Button LightGreyButton;
    public Button GreyButton;
    public Button YellowButton;
    public Button LightBlueButton;
    public Button DarkBlueButton;
    public Button CyanBlueButton;
    public Button GreenButton;
    public Button RedButton;
    public Button PurpleButton;

    Color selectedColor;

    public GameObject entity;

    private void Start()
    {
        baseCreamButton.onClick.AddListener(() => HandleButtonClick(baseCreamButton));
        baseBrownButton.onClick.AddListener(() => HandleButtonClick(baseBrownButton));
        LightBrownButton.onClick.AddListener(() => HandleButtonClick(LightBrownButton));
        BrownButton.onClick.AddListener(() => HandleButtonClick(BrownButton));
        DarkBrownButton.onClick.AddListener(() => HandleButtonClick(DarkBrownButton));
        BlackButton.onClick.AddListener(() => HandleButtonClick(BlackButton));
        WhiteBlueButton.onClick.AddListener(() => HandleButtonClick(WhiteBlueButton));

        VeryLightGreyButton.onClick.AddListener(() => HandleButtonClick(VeryLightGreyButton));
        LightGreyButton.onClick.AddListener(() => HandleButtonClick(LightGreyButton));
        GreyButton.onClick.AddListener(() => HandleButtonClick(GreyButton));

        YellowButton.onClick.AddListener(() => HandleButtonClick(YellowButton));
        LightBlueButton.onClick.AddListener(() => HandleButtonClick(LightBlueButton));
        DarkBlueButton.onClick.AddListener(() => HandleButtonClick(DarkBlueButton));
        CyanBlueButton.onClick.AddListener(() => HandleButtonClick(CyanBlueButton));
        GreenButton.onClick.AddListener(() => HandleButtonClick(GreenButton));
        RedButton.onClick.AddListener(() => HandleButtonClick(RedButton));
        PurpleButton.onClick.AddListener(() => HandleButtonClick(PurpleButton));
    }

    private void UpdateColor()
    {
        ChangeSkinColor();
    }

    private void HandleButtonClick(Button clickedButton)
    {
        Image buttonImage = clickedButton.GetComponent<Image>();

        if (buttonImage != null)
        {
            selectedColor = buttonImage.color;
            UpdateColor();
        }
        else
        {
            Debug.LogError("Image component not found on the button.");
        }
    }

    private void ChangeSkinColor(){
        // Find a child GameObject by name
        Transform head = entity.transform.Find("head");
        Transform torso = entity.transform.Find("torso");

        Transform rightArm = entity.transform.Find("right_arm");
        Transform rightForearm = entity.transform.Find("right_forearm");

        Transform leftArm = entity.transform.Find("left_arm");
        Transform leftForearm = entity.transform.Find("left_forearm");

        Transform rightLeg = entity.transform.Find("right_leg");
        Transform rightCalf = entity.transform.Find("right_calf");

        Transform leftLeg = entity.transform.Find("left_leg");
        Transform leftCalf = entity.transform.Find("left_calf");

        
        // Do something with the found child GameObject
        GameObject childObject_head = head.gameObject;
        childObject_head.GetComponent<SpriteRenderer>().color = selectedColor;

        GameObject childObject_torso = torso.gameObject;
        childObject_torso.GetComponent<SpriteRenderer>().color = selectedColor;

        GameObject childObject_rightArm = rightArm.gameObject;
        childObject_rightArm.GetComponent<SpriteRenderer>().color = selectedColor;

        GameObject childObject_rightForearm = rightForearm.gameObject;
        childObject_rightForearm.GetComponent<SpriteRenderer>().color = selectedColor;

        GameObject childObject_leftArm = leftArm.gameObject;
        childObject_leftArm.GetComponent<SpriteRenderer>().color = selectedColor;

        GameObject childObject_leftForearm = leftForearm.gameObject;
        childObject_leftForearm.GetComponent<SpriteRenderer>().color = selectedColor;

        GameObject childObject_rightLeg = rightLeg.gameObject;
        childObject_rightLeg.GetComponent<SpriteRenderer>().color = selectedColor;

        GameObject childObject_rightCalf = rightCalf.gameObject;
        childObject_rightCalf.GetComponent<SpriteRenderer>().color = selectedColor;

        GameObject childObject_leftLeg = leftLeg.gameObject;
        childObject_leftLeg.GetComponent<SpriteRenderer>().color = selectedColor;

        GameObject childObject_leftCalf = leftCalf.gameObject;
        childObject_leftCalf.GetComponent<SpriteRenderer>().color = selectedColor;
    }
}
