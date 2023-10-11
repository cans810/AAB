using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArmorShop : MonoBehaviour
{
    public GameObject goBackButton;

    public GameObject helmetsButton;
    public GameObject helmetsList;

    public GameObject chestplatesButton;
    public GameObject chestplatesList;

    public GameObject armArmorsButton;
    public GameObject armArmorsList;

    public GameObject forearmArmorsButton;
    public GameObject forearmArmorsList;

    public GameObject legArmorsButton;
    public GameObject legArmorsList;

    public GameObject calfArmorsButton;
    public GameObject calfArmorsList;

    public GameObject footArmorsButton;
    public GameObject footArmorsList;


    public GameObject buttonPrefab;
    public Transform buttonContainerHelmets;
    public Transform buttonContainerChestplates;
    public Transform buttonContainerArmArmors;
    public Transform buttonContainerForearmArmors;
    public Transform buttonContainerLegArmors;
    public Transform buttonContainerCalfArmors;
    public Transform buttonContainerFootArmors;

    public GameObject buyButton;

    public GameObject selectedItemImage;

    Player player;
    public List<Item> playerInventory;

    Item currentSelectedItem;
    GameObject currentSelectedButton;

    void Awake(){
        
    }

    private void OnEnable(){
        helmetsList.SetActive(false);
        chestplatesList.SetActive(false);
        armArmorsList.SetActive(false);
        forearmArmorsList.SetActive(false);
        legArmorsList.SetActive(false);
        calfArmorsList.SetActive(false);
        footArmorsList.SetActive(false);

        buyButton.SetActive(false);
        selectedItemImage.SetActive(false);
        goBackButton.SetActive(false);

        helmetsButton.SetActive(true);
        chestplatesButton.SetActive(true);
        armArmorsButton.SetActive(true);
        forearmArmorsButton.SetActive(true);
        legArmorsButton.SetActive(true);
        calfArmorsButton.SetActive(true);
        footArmorsButton.SetActive(true);


        player = Player.Instance;
        playerInventory = player.GetComponent<EntityEquipment>().inventory;

        player.GetComponent<Player>().transform.localScale = player.GetComponent<Player>().originalScale;
        player.GetComponent<Player>().transform.position = new Vector3(2,-100f,0);
        player.GetComponent<Player>().transform.localScale = new Vector3(player.GetComponent<Player>().transform.localScale.x, player.GetComponent<Player>().transform.localScale.y, 
        player.GetComponent<Player>().transform.localScale.z);

        // Freeze the Y-axis position
        player.rb.constraints = RigidbodyConstraints2D.FreezePositionY;

        PopulateArmorsUI();
    }

    private void OnDisable(){
        player.rb.constraints = RigidbodyConstraints2D.None;

        currentSelectedItem = null;
        helmetsList.SetActive(false);
        chestplatesList.SetActive(false);
        armArmorsList.SetActive(false);
        footArmorsList.SetActive(false);
        legArmorsList.SetActive(false);
        calfArmorsList.SetActive(false);
        footArmorsList.SetActive(false);

        buyButton.SetActive(false);
        selectedItemImage.SetActive(false);
        goBackButton.SetActive(false);

        Button[] buttonsHelmets = buttonContainerHelmets.GetComponentsInChildren<Button>();
        foreach (Button button in buttonsHelmets)
        {
            Destroy(button.gameObject);
        }

        Button[] buttonsChestplates = buttonContainerChestplates.GetComponentsInChildren<Button>();
        foreach (Button button in buttonsChestplates)
        {
            Destroy(button.gameObject);
        }

        Button[] buttonsArmArmors = buttonContainerArmArmors.GetComponentsInChildren<Button>();
        foreach (Button button in buttonsArmArmors)
        {
            Destroy(button.gameObject);
        }

        Button[] buttonsForearmArmors = buttonContainerForearmArmors.GetComponentsInChildren<Button>();
        foreach (Button button in buttonsForearmArmors)
        {
            Destroy(button.gameObject);
        }

        Button[] buttonsLegArmors = buttonContainerLegArmors.GetComponentsInChildren<Button>();
        foreach (Button button in buttonsLegArmors)
        {
            Destroy(button.gameObject);
        }

        Button[] buttonsCalfArmors = buttonContainerCalfArmors.GetComponentsInChildren<Button>();
        foreach (Button button in buttonsCalfArmors)
        {
            Destroy(button.gameObject);
        }

        Button[] buttonsFootArmors = buttonContainerFootArmors.GetComponentsInChildren<Button>();
        foreach (Button button in buttonsFootArmors)
        {
            Destroy(button.gameObject);
        }
    }

    public void PopulateArmorsUI()
    {
        foreach (Armor item in HelmetManager.Instance.helmets)
        {
            // Instantiate the button prefab
            GameObject buttonObject = Instantiate(buttonPrefab, buttonContainerHelmets);
            
            // Access the TextMeshProUGUI component of the button's child
            TextMeshProUGUI buttonText = buttonObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            // Set the text of the button using the item's name
            buttonText.text = item.itemName + ", " + item.price + " gold, " + item.armorPoint + " armor";
            
            // Add functionality to the button, e.g., OnClick event
            buttonObject.GetComponent<Button>().onClick.AddListener(() => OnItemClick(item, buttonObject));
        }

        foreach (Armor item in ChestplateManager.Instance.chestplates)
        {
            // Instantiate the button prefab
            GameObject buttonObject = Instantiate(buttonPrefab, buttonContainerChestplates);
            
            // Access the TextMeshProUGUI component of the button's child
            TextMeshProUGUI buttonText = buttonObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            // Set the text of the button using the item's name
            buttonText.text = item.itemName + ", " + item.price + " gold, " + item.armorPoint + " armor";
            
            // Add functionality to the button, e.g., OnClick event
            buttonObject.GetComponent<Button>().onClick.AddListener(() => OnItemClick(item, buttonObject));
        }

        foreach (Armor item in ArmArmorManager.Instance.armArmors)
        {
            // Instantiate the button prefab
            GameObject buttonObject = Instantiate(buttonPrefab, buttonContainerArmArmors);
            
            // Access the TextMeshProUGUI component of the button's child
            TextMeshProUGUI buttonText = buttonObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            // Set the text of the button using the item's name
            buttonText.text = item.itemName + ", " + item.price + " gold, " + item.armorPoint + " armor";
            
            // Add functionality to the button, e.g., OnClick event
            buttonObject.GetComponent<Button>().onClick.AddListener(() => OnItemClick(item, buttonObject));
        }

        foreach (Armor item in ForearmArmorManager.Instance.foreArmArmors)
        {
            // Instantiate the button prefab
            GameObject buttonObject = Instantiate(buttonPrefab, buttonContainerForearmArmors);
            
            // Access the TextMeshProUGUI component of the button's child
            TextMeshProUGUI buttonText = buttonObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            // Set the text of the button using the item's name
            buttonText.text = item.itemName + ", " + item.price + " gold, " + item.armorPoint + " armor";
            
            // Add functionality to the button, e.g., OnClick event
            buttonObject.GetComponent<Button>().onClick.AddListener(() => OnItemClick(item, buttonObject));
        }

        foreach (Armor item in LegArmorManager.Instance.legArmors)
        {
            // Instantiate the button prefab
            GameObject buttonObject = Instantiate(buttonPrefab, buttonContainerLegArmors);
            
            // Access the TextMeshProUGUI component of the button's child
            TextMeshProUGUI buttonText = buttonObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            // Set the text of the button using the item's name
            buttonText.text = item.itemName + ", " + item.price + " gold, " + item.armorPoint + " armor";
            
            // Add functionality to the button, e.g., OnClick event
            buttonObject.GetComponent<Button>().onClick.AddListener(() => OnItemClick(item, buttonObject));
        }

        foreach (Armor item in CalfArmorManager.Instance.calfArmors)
        {
            // Instantiate the button prefab
            GameObject buttonObject = Instantiate(buttonPrefab, buttonContainerCalfArmors);
            
            // Access the TextMeshProUGUI component of the button's child
            TextMeshProUGUI buttonText = buttonObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            // Set the text of the button using the item's name
            buttonText.text = item.itemName + ", " + item.price + " gold, " + item.armorPoint + " armor";
            
            // Add functionality to the button, e.g., OnClick event
            buttonObject.GetComponent<Button>().onClick.AddListener(() => OnItemClick(item, buttonObject));
        }

        foreach (Armor item in FootArmorManager.Instance.footArmors)
        {
            // Instantiate the button prefab
            GameObject buttonObject = Instantiate(buttonPrefab, buttonContainerFootArmors);
            
            // Access the TextMeshProUGUI component of the button's child
            TextMeshProUGUI buttonText = buttonObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            // Set the text of the button using the item's name
            buttonText.text = item.itemName + ", " + item.price + " gold, " + item.armorPoint + " armor";
            
            // Add functionality to the button, e.g., OnClick event
            buttonObject.GetComponent<Button>().onClick.AddListener(() => OnItemClick(item, buttonObject));
        }
    }

    void OnItemClick(Item item, GameObject button)
    {
        // Implement the logic when an item button is clicked
        currentSelectedItem = item;
        currentSelectedButton = button;
        Debug.Log("Clicked item: " + currentSelectedItem.itemName);
        buyButton.SetActive(true);

        selectedItemImage.GetComponent<Image>().sprite = currentSelectedItem.texture;
        ImageCommands.ResizeImageToSpriteSize(selectedItemImage.GetComponent<Image>());
        selectedItemImage.SetActive(true);
    }

    public void buyItem(){
        Destroy(currentSelectedButton);
        playerInventory.Add(currentSelectedItem);

        if (currentSelectedItem.category.Contains("helmet")){
            HelmetManager.Instance.helmets.Remove(currentSelectedItem);
        }
        else if (currentSelectedItem.category.Contains("chestplate")){
            ChestplateManager.Instance.chestplates.Remove(currentSelectedItem);
        }
        else if (currentSelectedItem.category.Contains("arm_armor") && !currentSelectedItem.category.Contains("forearm_armor")){
            ArmArmorManager.Instance.armArmors.Remove(currentSelectedItem);
        }
        else if (currentSelectedItem.category.Contains("forearm_armor")){
            ForearmArmorManager.Instance.foreArmArmors.Remove(currentSelectedItem);
        }
        else if (currentSelectedItem.category.Contains("leg_armor")){
            LegArmorManager.Instance.legArmors.Remove(currentSelectedItem);
        }
        else if (currentSelectedItem.category.Contains("calf_armor")){
            CalfArmorManager.Instance.calfArmors.Remove(currentSelectedItem);
        }
        else if (currentSelectedItem.category.Contains("foot_armor")){
            FootArmorManager.Instance.footArmors.Remove(currentSelectedItem);
        }
        
        buyButton.SetActive(false);
        selectedItemImage.SetActive(false);
    }

    public void showHelmets(){
        helmetsList.SetActive(true);
        helmetsButton.SetActive(false);
        goBackButton.SetActive(true);

        chestplatesList.SetActive(false);
        armArmorsList.SetActive(false);
        footArmorsList.SetActive(false);
        legArmorsList.SetActive(false);
        calfArmorsList.SetActive(false);
        footArmorsList.SetActive(false);

        helmetsButton.SetActive(false);
        chestplatesButton.SetActive(false);
        armArmorsButton.SetActive(false);
        forearmArmorsButton.SetActive(false);
        legArmorsButton.SetActive(false);
        calfArmorsButton.SetActive(false);
        footArmorsButton.SetActive(false);
    }

    public void showChestplates(){
        chestplatesList.SetActive(true);
        chestplatesButton.SetActive(false);
        goBackButton.SetActive(true);

        helmetsList.SetActive(false);
        armArmorsList.SetActive(false);
        footArmorsList.SetActive(false);
        legArmorsList.SetActive(false);
        calfArmorsList.SetActive(false);
        footArmorsList.SetActive(false);

        helmetsButton.SetActive(false);
        chestplatesButton.SetActive(false);
        armArmorsButton.SetActive(false);
        forearmArmorsButton.SetActive(false);
        legArmorsButton.SetActive(false);
        calfArmorsButton.SetActive(false);
        footArmorsButton.SetActive(false);
    }

    public void showArmArmors(){
        armArmorsList.SetActive(true);
        armArmorsButton.SetActive(false);
        goBackButton.SetActive(true);

        helmetsList.SetActive(false);
        chestplatesList.SetActive(false);
        footArmorsList.SetActive(false);
        legArmorsList.SetActive(false);
        calfArmorsList.SetActive(false);
        footArmorsList.SetActive(false);

        helmetsButton.SetActive(false);
        chestplatesButton.SetActive(false);
        armArmorsButton.SetActive(false);
        forearmArmorsButton.SetActive(false);
        legArmorsButton.SetActive(false);
        calfArmorsButton.SetActive(false);
        footArmorsButton.SetActive(false);
    }

    public void showForearmArmors(){
        forearmArmorsList.SetActive(true);
        forearmArmorsButton.SetActive(false);
        goBackButton.SetActive(true);

        helmetsList.SetActive(false);
        chestplatesList.SetActive(false);
        armArmorsList.SetActive(false);
        legArmorsList.SetActive(false);
        calfArmorsList.SetActive(false);
        footArmorsList.SetActive(false);

        helmetsButton.SetActive(false);
        chestplatesButton.SetActive(false);
        armArmorsButton.SetActive(false);
        forearmArmorsButton.SetActive(false);
        legArmorsButton.SetActive(false);
        calfArmorsButton.SetActive(false);
        footArmorsButton.SetActive(false);
    }

    public void showLegArmors(){
        legArmorsList.SetActive(true);
        legArmorsButton.SetActive(false);
        goBackButton.SetActive(true);

        helmetsList.SetActive(false);
        chestplatesList.SetActive(false);
        armArmorsList.SetActive(false);
        footArmorsList.SetActive(false);
        calfArmorsList.SetActive(false);
        footArmorsList.SetActive(false);

        helmetsButton.SetActive(false);
        chestplatesButton.SetActive(false);
        armArmorsButton.SetActive(false);
        forearmArmorsButton.SetActive(false);
        legArmorsButton.SetActive(false);
        calfArmorsButton.SetActive(false);
        footArmorsButton.SetActive(false);
    }

    public void showCalfArmors(){
        calfArmorsList.SetActive(true);
        calfArmorsButton.SetActive(false);
        goBackButton.SetActive(true);

        helmetsList.SetActive(false);
        chestplatesList.SetActive(false);
        armArmorsList.SetActive(false);
        footArmorsList.SetActive(false);
        legArmorsList.SetActive(false);
        footArmorsList.SetActive(false);

        helmetsButton.SetActive(false);
        chestplatesButton.SetActive(false);
        armArmorsButton.SetActive(false);
        forearmArmorsButton.SetActive(false);
        legArmorsButton.SetActive(false);
        calfArmorsButton.SetActive(false);
        footArmorsButton.SetActive(false);
    }

    public void showFootArmors(){
        footArmorsList.SetActive(true);
        footArmorsButton.SetActive(false);
        goBackButton.SetActive(true);

        helmetsList.SetActive(false);
        chestplatesList.SetActive(false);
        armArmorsList.SetActive(false);
        forearmArmorsButton.SetActive(false);
        legArmorsList.SetActive(false);
        calfArmorsList.SetActive(false);

        helmetsButton.SetActive(false);
        chestplatesButton.SetActive(false);
        armArmorsButton.SetActive(false);
        forearmArmorsButton.SetActive(false);
        legArmorsButton.SetActive(false);
        calfArmorsButton.SetActive(false);
        footArmorsButton.SetActive(false);
    }

    public void goBack(){
        selectedItemImage.SetActive(false);
        buyButton.SetActive(false);

        helmetsList.SetActive(false);
        helmetsButton.SetActive(true);

        chestplatesList.SetActive(false);
        chestplatesButton.SetActive(true);

        armArmorsList.SetActive(false);
        armArmorsButton.SetActive(true);

        forearmArmorsList.SetActive(false);
        forearmArmorsButton.SetActive(true);

        legArmorsList.SetActive(false);
        legArmorsButton.SetActive(true);

        calfArmorsList.SetActive(false);
        calfArmorsButton.SetActive(true);

        footArmorsList.SetActive(false);
        footArmorsButton.SetActive(true);


        goBackButton.SetActive(false);
    }
}
