using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponShop : MonoBehaviour
{
    public GameObject axesButton;
    public GameObject axesList;

    public GameObject buttonPrefab;
    public Transform buttonContainer;

    public GameObject buyButton;
    public GameObject goBackButton;

    public GameObject selectedItemImage;
    public GameObject selectedItemInfo;

    Player player;
    public List<Item> playerInventory;

    Item currentSelectedItem;
    GameObject currentSelectedButton;

    void Awake(){
        
    }

    private void OnEnable(){
        axesList.SetActive(false);
        axesButton.SetActive(true);

        buyButton.SetActive(false);
        selectedItemImage.SetActive(false);
        selectedItemInfo.SetActive(false);
        goBackButton.SetActive(false);


        player = Player.Instance;
        playerInventory = player.GetComponent<EntityEquipment>().inventory;

        player.GetComponent<Player>().transform.localScale = player.GetComponent<Player>().originalScale;
        player.GetComponent<Player>().transform.position = new Vector3(2,-100f,0);
        player.GetComponent<Player>().transform.localScale = new Vector3(player.GetComponent<Player>().transform.localScale.x, player.GetComponent<Player>().transform.localScale.y, 
        player.GetComponent<Player>().transform.localScale.z);

        // Freeze the Y-axis position
        player.rb.constraints = RigidbodyConstraints2D.FreezePositionY;

        PopulateInventoryUI();
    }

    private void OnDisable(){
        player.rb.constraints = RigidbodyConstraints2D.None;

        axesList.SetActive(false);

        currentSelectedItem = null;

        buyButton.SetActive(false);
        selectedItemImage.SetActive(false);
        selectedItemInfo.SetActive(false);
        goBackButton.SetActive(false);

        Button[] buttons = buttonContainer.GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            Destroy(button.gameObject);
        }
    }

    public void PopulateInventoryUI()
    {
        foreach (Item item in AxeManager.Instance.axes)
        {
            // Instantiate the button prefab
            GameObject buttonObject = Instantiate(buttonPrefab, buttonContainer);
            
            // Access the TextMeshProUGUI component of the button's child
            //TextMeshProUGUI buttonText = buttonObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            // Set the text of the button using the item's name
            //buttonText.text = item.itemName;
            
            buttonObject.GetComponent<RectTransform>().localScale = new Vector2(item.texture.bounds.size.x/2,
            item.texture.bounds.size.y/4);

            buttonObject.GetComponent<Image>().sprite = item.texture;
            //axesContent.GetComponent<GridLayoutGroup>().cellSize

            //buttonContainer.GetComponent<GridLayoutGroup>().cellSize = new Vector2(item.texture.bounds.size.x*20, item.texture.bounds.size.y*20);
            
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

        selectedItemInfo.GetComponent<TextMeshProUGUI>().text = currentSelectedItem.itemName;

        selectedItemImage.GetComponent<Image>().sprite = currentSelectedItem.texture;
        ImageCommands.ResizeImageToSpriteSize(selectedItemImage.GetComponent<Image>());
        selectedItemImage.GetComponent<Image>().rectTransform.localScale = new Vector2(selectedItemImage.GetComponent<Image>().sprite.bounds.size.x/2,
        selectedItemImage.GetComponent<Image>().sprite.bounds.size.y/4);
        selectedItemImage.SetActive(true);
        selectedItemInfo.SetActive(true);
    }

    public void buyItem(){
        Destroy(currentSelectedButton);
        playerInventory.Add(currentSelectedItem);
        AxeManager.Instance.axes.Remove(currentSelectedItem);
        buyButton.SetActive(false);
        selectedItemImage.SetActive(false);
        selectedItemInfo.SetActive(false);
    }

    public void showAxes(){
        axesList.SetActive(true);
        axesButton.SetActive(false);
        goBackButton.SetActive(true);

        // rest weapons set off
        //helmetsList.SetActive(false);
        //helmetsButton.SetActive(false);
    }
        
    public void goBack(){
        selectedItemImage.SetActive(false);
        selectedItemInfo.SetActive(false);
        buyButton.SetActive(false);

        axesList.SetActive(false);
        axesButton.SetActive(true);

        goBackButton.SetActive(false);
    }
}

