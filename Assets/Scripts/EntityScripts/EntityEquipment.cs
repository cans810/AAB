using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityEquipment : MonoBehaviour
{
    public List<Item> inventory;
    public List<Item> equippedItemsInventory;
    public Weapon RightHandEquipped;
    public Armor LeftHandEquipped;
    public Armor HelmetWorn;
    public Armor ChestplateWorn;
    public Armor ArmWorn;
    public Armor ForearmWorn;
    public Armor LegWorn;
    public Armor CalfWorn;
    public Armor FootWorn;

    void Awake(){
        equippedItemsInventory = new List<Item>();
        inventory = new List<Item>();

        if (RightHandEquipped != null){
            inventory.Add(RightHandEquipped);
        }

        equippedItemsInventory.Add(LeftHandEquipped);
        equippedItemsInventory.Add(HelmetWorn);
        equippedItemsInventory.Add(ChestplateWorn);
        equippedItemsInventory.Add(ArmWorn);
        equippedItemsInventory.Add(ForearmWorn);
        equippedItemsInventory.Add(LegWorn);
        equippedItemsInventory.Add(CalfWorn);
        equippedItemsInventory.Add(FootWorn);
    }
}
