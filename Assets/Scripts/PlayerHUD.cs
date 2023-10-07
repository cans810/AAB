using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public TMP_Text nameField;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI spText;
    public GameObject armorText;
    public Image healthBar;
    public Image staminaBar;
    public Image armorBar;
    public GameObject armorBarOutline;
    private Player player;

    public GameObject popUpPrefab;
    private bool hasBeenInstantiated = false;
    private GameObject instantiatedPopUpObject;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        nameField.text = player.GetComponent<EntityAttributes>().entityName;

        healthBar.fillAmount = player.GetComponent<EntityAttributes>().HP / player.GetComponent<EntityAttributes>().maxHP;
        staminaBar.fillAmount = player.GetComponent<EntityAttributes>().SP / player.GetComponent<EntityAttributes>().maxSP;

        if (player.GetComponent<EntityAttributes>().maxArmorPoint == 0){
            armorBar.fillAmount = 0;
            armorBarOutline.SetActive(false);
            armorText.SetActive(false);
        }
        else{
            armorBarOutline.SetActive(true);
            armorText.SetActive(true);
            armorBar.fillAmount = player.GetComponent<EntityAttributes>().armorPoint / player.GetComponent<EntityAttributes>().maxArmorPoint;
            armorText.GetComponent<TextMeshProUGUI>().text = player.GetComponent<EntityAttributes>().armorPoint.ToString();
        }

        hpText.text = player.GetComponent<EntityAttributes>().HP.ToString();
        spText.text = player.GetComponent<EntityAttributes>().SP.ToString();

        // if entity gets hit, display pop-up
        if (!hasBeenInstantiated && player != null && player.GetComponent<ActionsManager>().gotHit)
        {
            float sideValue = 0;
            if (player.GetComponent<ActionsManager>().side.Equals("left")) sideValue = -1.5f;
            else sideValue = 1.5f;

            Vector3 position = new Vector3(player.GetComponent<Rigidbody2D>().position.x + sideValue, -1, player.transform.position.z);
            Quaternion rotation = Quaternion.identity;
            instantiatedPopUpObject = Instantiate(popUpPrefab, position, rotation);

            instantiatedPopUpObject.GetComponent<Canvas>().worldCamera = Camera.main;
            instantiatedPopUpObject.GetComponent<RectTransform>().anchoredPosition = position;

            Transform childTextPopUp = instantiatedPopUpObject.transform.Find("Text");
            childTextPopUp.gameObject.GetComponent<TextMeshProUGUI>().text = player.GetComponent<ActionsManager>().amountGotHit.ToString();

            Transform childImagePopUp = instantiatedPopUpObject.transform.Find("Image");
            childImagePopUp.gameObject.GetComponent<SpriteRenderer>().sprite = instantiatedPopUpObject.GetComponent<SpriteLibrary>().GetSprite("PopUp","meatHitNormal");

            //instantiatedPopUpObject.transform.SetParent(gameObject.transform);

            hasBeenInstantiated = true;
        }
        if(!hasBeenInstantiated && player != null && player.GetComponent<ActionsManager>().blockingMelee){
            float sideValue = 0;
            if (player.GetComponent<ActionsManager>().side.Equals("left")) sideValue = -1.5f;
            else sideValue = 1.5f;

            Vector3 position = new Vector3(player.GetComponent<Rigidbody2D>().position.x + sideValue, -1, player.transform.position.z);
            Quaternion rotation = Quaternion.identity;
            instantiatedPopUpObject = Instantiate(popUpPrefab, position, rotation);

            instantiatedPopUpObject.GetComponent<Canvas>().worldCamera = Camera.main;
            instantiatedPopUpObject.GetComponent<RectTransform>().anchoredPosition = position;

            Transform childTextPopUp = instantiatedPopUpObject.transform.Find("Text");
            childTextPopUp.gameObject.GetComponent<TextMeshProUGUI>().text = "BLOCK";

            Transform childImagePopUp = instantiatedPopUpObject.transform.Find("Image");
            childImagePopUp.gameObject.GetComponent<SpriteRenderer>().sprite = instantiatedPopUpObject.GetComponent<SpriteLibrary>().GetSprite("PopUp","blockHitNormal");

            hasBeenInstantiated = true;
        }
        if (!player.GetComponent<ActionsManager>().dying && !player.GetComponent<ActionsManager>().surrendering){
            if (!instantiatedPopUpObject){
                hasBeenInstantiated = false;
            }
        }
    }
}
