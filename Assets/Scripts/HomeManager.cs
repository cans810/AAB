using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    public static bool justEnteredHome;

    Player player;

    Vector3 playerBasePos;

    public GameObject inventoryList;
    public GameObject equippedInventoryList;

    public GameObject inventoryButton;
    public GameObject equippedInventoryButton;

    public GameObject goBackButton;

    public GameObject equipButton;
    public GameObject unEquipButton;

    private void OnEnable(){
        inventoryList.SetActive(false);
        equippedInventoryList.SetActive(false);

        player = Player.Instance;
        playerBasePos = player.transform.position;
        player.GetComponent<Player>().transform.localScale = player.GetComponent<Player>().originalScale;
        player.GetComponent<Player>().transform.position = new Vector3(4.54f,-3.5f,0);
        player.GetComponent<Player>().transform.localScale = new Vector3(player.GetComponent<Player>().transform.localScale.x*1.5f, player.GetComponent<Player>().transform.localScale.y*1.5f, 
        player.GetComponent<Player>().transform.localScale.z*1.5f);

        // Freeze the Y-axis position
        player.rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public void showInventory(){
        inventoryList.SetActive(true);
        equippedInventoryList.SetActive(false);
        inventoryButton.SetActive(false);
        equippedInventoryButton.SetActive(false);
        goBackButton.SetActive(true);
    }

    public void showEquippedInventory(){
        inventoryList.SetActive(false);
        equippedInventoryList.SetActive(true);
        inventoryButton.SetActive(false);
        equippedInventoryButton.SetActive(false);
        goBackButton.SetActive(true);
    }

    public void goBack(){
        inventoryList.SetActive(false);
        equippedInventoryList.SetActive(false);
        inventoryButton.SetActive(true);
        equippedInventoryButton.SetActive(true);
        goBackButton.SetActive(false);
        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
    }

    private void OnDisable(){
        player.transform.position = playerBasePos;
        player.rb.constraints = RigidbodyConstraints2D.None;
    }
}
