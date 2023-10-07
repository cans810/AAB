using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class EnemyHUD : MonoBehaviour
{
    public TMP_Text nameField;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI spText;
    public GameObject armorText;

    public Image healthBar;
    public Image staminaBar;
    public Image armorBar;
    public GameObject armorBarOutline;

    private GameObject enemy;

    public GameObject popUpPrefab;

    private bool hasBeenInstantiated = false;
    private GameObject instantiatedPopUpObject;

    // Start is called before the first frame update
    void Start()
    {
        enemy = EnemyGeneratorController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null){
            nameField.text = enemy.GetComponent<EntityAttributes>().entityName;

            healthBar.fillAmount = enemy.GetComponent<EntityAttributes>().HP / enemy.GetComponent<EntityAttributes>().maxHP;
            staminaBar.fillAmount = enemy.GetComponent<EntityAttributes>().SP / enemy.GetComponent<EntityAttributes>().maxSP;

            if (enemy.GetComponent<EntityAttributes>().maxArmorPoint == 0){
                armorBar.fillAmount = 0;
                armorBarOutline.SetActive(false);
                armorText.SetActive(false);
            }
            else{
                armorBarOutline.SetActive(true);
                armorText.SetActive(true);
                armorBar.fillAmount = enemy.GetComponent<EntityAttributes>().armorPoint / enemy.GetComponent<EntityAttributes>().maxArmorPoint;
                armorText.GetComponent<TextMeshProUGUI>().text = enemy.GetComponent<EntityAttributes>().armorPoint.ToString();
            }
        }

        hpText.text = enemy.GetComponent<EntityAttributes>().HP.ToString();
        spText.text = enemy.GetComponent<EntityAttributes>().SP.ToString();

        // if entity gets hit, display pop-up
        if (!hasBeenInstantiated && enemy != null && enemy.GetComponent<EnemyActionsManager>().gotHit)
        {
            float sideValue = 0;
            if (enemy.GetComponent<EnemyActionsManager>().side.Equals("left")) sideValue = -1.5f;
            else sideValue = 1.5f;

            Vector3 position = new Vector3(enemy.GetComponent<Rigidbody2D>().position.x + sideValue, -1, enemy.transform.position.z);
            Quaternion rotation = Quaternion.identity;
            instantiatedPopUpObject = Instantiate(popUpPrefab, position, rotation);

            instantiatedPopUpObject.GetComponent<Canvas>().worldCamera = Camera.main;
            instantiatedPopUpObject.GetComponent<RectTransform>().anchoredPosition = position;

            Transform childTextPopUp = instantiatedPopUpObject.transform.Find("Text");
            childTextPopUp.gameObject.GetComponent<TextMeshProUGUI>().text = enemy.GetComponent<EnemyActionsManager>().amountGotHit.ToString();
            
            Transform childImagePopUp = instantiatedPopUpObject.transform.Find("Image");
            childImagePopUp.gameObject.GetComponent<SpriteRenderer>().sprite = instantiatedPopUpObject.GetComponent<SpriteLibrary>().GetSprite("PopUp","meatHitNormal");

            //instantiatedPopUpObject.transform.SetParent(gameObject.transform);

            hasBeenInstantiated = true;
        }
        if(!hasBeenInstantiated && enemy != null && enemy.GetComponent<EnemyActionsManager>().blockingMelee){
            float sideValue = 0;
            if (enemy.GetComponent<EnemyActionsManager>().side.Equals("left")) sideValue = -1.5f;
            else sideValue = 1.5f;

            Vector3 position = new Vector3(enemy.GetComponent<Rigidbody2D>().position.x + sideValue, -1, enemy.transform.position.z);
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
        if (!enemy.GetComponent<EnemyActionsManager>().dying && !enemy.GetComponent<EnemyActionsManager>().surrendering){
            if (!instantiatedPopUpObject){
                hasBeenInstantiated = false;
            }
        }
    }
}
