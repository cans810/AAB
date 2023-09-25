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

    // Start is called before the first frame update
    void Start()
    {
        player = Player.Instance;
        playerBasePos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable(){
        inventoryList.SetActive(false);
        equippedInventoryList.SetActive(false);

        player.transform.position = new Vector3(-4,-5,0);
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
    }

    private void OnDisable(){
        player.transform.position = playerBasePos;
    }
}
