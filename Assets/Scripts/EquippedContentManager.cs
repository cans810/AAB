using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquippedContentManager : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform buttonContainer;

    public GameObject unEquipButton;

    public GameObject selectedItemImage;

    Player player;
    List<Item> playerInventory;

    Item currentSelectedItem;
    GameObject currentSelectedButton;
    List<Item> equippedItemsInventory;

    void Awake(){
        
    }

    private void OnEnable(){
        unEquipButton.SetActive(false);
        selectedItemImage.SetActive(false);

        player = Player.Instance;
        playerInventory = Player.Instance.GetComponent<EntityEquipment>().inventory;
        equippedItemsInventory =Player.Instance.GetComponent<EntityEquipment>().equippedItemsInventory;

        PopulateInventoryUI();
    }

    private void OnDisable(){
        currentSelectedItem = null;

        Button[] buttons = buttonContainer.GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            Destroy(button.gameObject);
        }
    }

    public void PopulateInventoryUI()
    {
        foreach (Item item in equippedItemsInventory)
        {
            if (item != null){
                // Instantiate the button prefab
                GameObject buttonObject = Instantiate(buttonPrefab, buttonContainer);
            
                // Access the TextMeshProUGUI component of the button's child
                TextMeshProUGUI buttonText = buttonObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

                // Set the text of the button using the item's name
                buttonText.text = item.itemName;
            
                // Add functionality to the button, e.g., OnClick event
                buttonObject.GetComponent<Button>().onClick.AddListener(() => OnItemClick(item, buttonObject));
            }
        }
    }

    void OnItemClick(Item item, GameObject button)
    {
        // Implement the logic when an item button is clicked
        currentSelectedItem = item;
        currentSelectedButton = button;
        Debug.Log("Clicked item: " + currentSelectedItem.itemName);
        unEquipButton.SetActive(true);
        
        selectedItemImage.GetComponent<Image>().sprite = currentSelectedItem.texture;
        ImageCommands.ResizeImageToSpriteSize(selectedItemImage.GetComponent<Image>());
        selectedItemImage.SetActive(true);
    }

    public void unequipItem(){
        if (currentSelectedItem is Weapon weapon)
        {
            weapon.equipped = false;
            player.GetComponent<EntityEquipment>().RightHandEquipped = null;
        }
        if (currentSelectedItem is Armor armor)
        {
            if (armor.category.Equals("helmet")){
                player.GetComponent<EntityEquipment>().HelmetWorn = null;
            }
            if (armor.category.Equals("chestplate")){
                player.GetComponent<EntityEquipment>().ChestplateWorn = null;
            }
            if (armor.category.Equals("arm_armor")){
                player.GetComponent<EntityEquipment>().ArmWorn = null;
            }
            if (armor.category.Equals("forearm_armor")){
                player.GetComponent<EntityEquipment>().ForearmWorn = null;
            }
            if (armor.category.Equals("leg_armor")){
                player.GetComponent<EntityEquipment>().LegWorn = null;
            }
            if (armor.category.Equals("calf_armor")){
                player.GetComponent<EntityEquipment>().CalfWorn = null;
            }
            if (armor.category.Equals("foot_armor")){
                player.GetComponent<EntityEquipment>().FootWorn = null;
            }

            armor.equipped = false;
        }


        equippedItemsInventory.Remove(currentSelectedItem);
        playerInventory.Add(currentSelectedItem);
        selectedItemImage.SetActive(false);
        Destroy(currentSelectedButton);
    }
}
