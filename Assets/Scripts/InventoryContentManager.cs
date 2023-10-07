using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryContentManager : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform buttonContainer;

    public GameObject equipButton;

    public GameObject selectedItemImage;

    Player player;
    List<Item> playerInventory;

    Item currentSelectedItem;
    GameObject currentSelectedButton;
    List<Item> equippedItemsInventory;
    
    private void OnEnable(){
        equipButton.SetActive(false);
        selectedItemImage.SetActive(false);

        player = Player.Instance;
        playerInventory = Player.Instance.GetComponent<EntityEquipment>().inventory;
        equippedItemsInventory = Player.Instance.GetComponent<EntityEquipment>().equippedItemsInventory;

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
        foreach (Item item in playerInventory)
        {
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

    void OnItemClick(Item item, GameObject button)
    {
        // Implement the logic when an item button is clicked
        currentSelectedItem = item;
        currentSelectedButton = button;
        Debug.Log("Clicked item: " + currentSelectedItem.itemName);
        equipButton.SetActive(true);
        
        selectedItemImage.GetComponent<Image>().sprite = currentSelectedItem.texture;
        ImageCommands.ResizeImageToSpriteSize(selectedItemImage.GetComponent<Image>());
        selectedItemImage.SetActive(true);
    }

    public void equipItem(){
        if (currentSelectedItem is Weapon weapon)
        {
            // The item at the specified index is a Weapon, so you can access its properties
            if (player.GetComponent<EntityEquipment>().RightHandEquipped != null){
                player.GetComponent<EntityEquipment>().RightHandEquipped.equipped = false;
                equippedItemsInventory.Remove(player.GetComponent<EntityEquipment>().RightHandEquipped);
            }
            weapon.equipped = true;
            player.GetComponent<EntityEquipment>().RightHandEquipped = weapon;

            playerInventory.Remove(weapon);
            equippedItemsInventory.Add(weapon);
            selectedItemImage.SetActive(false);
            Destroy(currentSelectedButton);
        }

        if (currentSelectedItem is Armor armor)
        {
            if (armor.category.Equals("helmet")){
                if (player.GetComponent<EntityEquipment>().HelmetWorn != null){
                    playerInventory.Add(player.GetComponent<EntityEquipment>().HelmetWorn);
                    player.GetComponent<EntityEquipment>().HelmetWorn.isWorn = false;
                    equippedItemsInventory.Remove(player.GetComponent<EntityEquipment>().HelmetWorn);
                }
                
                player.GetComponent<EntityEquipment>().HelmetWorn = armor;
            }
            if (armor.category.Equals("chestplate")){
                if (player.GetComponent<EntityEquipment>().ChestplateWorn != null){
                    playerInventory.Add(player.GetComponent<EntityEquipment>().ChestplateWorn);
                    player.GetComponent<EntityEquipment>().ChestplateWorn.isWorn = false;
                    equippedItemsInventory.Remove(player.GetComponent<EntityEquipment>().ChestplateWorn);
                }

                player.GetComponent<EntityEquipment>().ChestplateWorn = armor;
            }
            if (armor.category.Equals("arm_armor")){
                if (player.GetComponent<EntityEquipment>().ArmWorn != null){
                    playerInventory.Add(player.GetComponent<EntityEquipment>().ArmWorn);
                    player.GetComponent<EntityEquipment>().ArmWorn.isWorn = false;
                    equippedItemsInventory.Remove(player.GetComponent<EntityEquipment>().ArmWorn);
                }
                player.GetComponent<EntityEquipment>().ArmWorn = armor;
            }
            if (armor.category.Equals("forearm_armor")){
                if (player.GetComponent<EntityEquipment>().ForearmWorn != null){
                    playerInventory.Add(player.GetComponent<EntityEquipment>().ForearmWorn);
                    player.GetComponent<EntityEquipment>().ForearmWorn.isWorn = false;
                    equippedItemsInventory.Remove(player.GetComponent<EntityEquipment>().ForearmWorn);
                }

                player.GetComponent<EntityEquipment>().ForearmWorn = armor;
            }
            if (armor.category.Equals("leg_armor")){
                if (player.GetComponent<EntityEquipment>().LegWorn != null){
                    playerInventory.Add(player.GetComponent<EntityEquipment>().LegWorn);
                    player.GetComponent<EntityEquipment>().LegWorn.isWorn = false;
                    equippedItemsInventory.Remove(player.GetComponent<EntityEquipment>().LegWorn);
                }

                player.GetComponent<EntityEquipment>().LegWorn = armor;
            }
            if (armor.category.Equals("calf_armor")){
                if (player.GetComponent<EntityEquipment>().CalfWorn != null){
                    playerInventory.Add(player.GetComponent<EntityEquipment>().CalfWorn);
                    player.GetComponent<EntityEquipment>().CalfWorn.isWorn = false;
                    equippedItemsInventory.Remove(player.GetComponent<EntityEquipment>().CalfWorn);
                }

                player.GetComponent<EntityEquipment>().CalfWorn = armor;
            }
            if (armor.category.Equals("foot_armor")){
                if (player.GetComponent<EntityEquipment>().FootWorn != null){
                    playerInventory.Add(player.GetComponent<EntityEquipment>().FootWorn);
                    player.GetComponent<EntityEquipment>().FootWorn.isWorn = false;
                    equippedItemsInventory.Remove(player.GetComponent<EntityEquipment>().FootWorn);
                }

                player.GetComponent<EntityEquipment>().FootWorn = armor;
            }

            armor.equipped = true;
            playerInventory.Remove(armor);
            equippedItemsInventory.Add(armor);
            selectedItemImage.SetActive(false);
            equipButton.SetActive(false);
            Destroy(currentSelectedButton);

            currentSelectedItem = null;

            Button[] buttons = buttonContainer.GetComponentsInChildren<Button>();
            foreach (Button button in buttons)
            {
                Destroy(button.gameObject);
            }

            PopulateInventoryUI();
        }
    }
}
