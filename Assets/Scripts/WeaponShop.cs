using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponShop : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform buttonContainer;

    public GameObject buyButton;

    public GameObject selectedItemImage;

    Player player;
    public List<Item> playerInventory;

    Item currentSelectedItem;
    GameObject currentSelectedButton;

    void Awake(){
        
    }

    private void OnEnable(){
        buyButton.SetActive(false);
        selectedItemImage.SetActive(false);


        player = Player.Instance;
        playerInventory = player.GetComponent<EntityEquipment>().inventory;

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
        foreach (Item item in SwordManager.Instance.swords)
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
        buyButton.SetActive(true);

        selectedItemImage.GetComponent<Image>().sprite = currentSelectedItem.texture;
        ImageCommands.ResizeImageToSpriteSize(selectedItemImage.GetComponent<Image>());
        selectedItemImage.SetActive(true);
    }

    public void buyItem(){
        Destroy(currentSelectedButton);
        playerInventory.Add(currentSelectedItem);
        SwordManager.Instance.swords.Remove(currentSelectedItem);
        buyButton.SetActive(false);
        selectedItemImage.SetActive(false);
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

