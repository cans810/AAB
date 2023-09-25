using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Armor",menuName = "Armor")]
public class Armor : Item
{
    public string category;

    public bool equipped;

    public int armorPoint;

    public Sprite pair;
    public Armor(string itemName,Sprite texture,string category,int armorPoint,int level){
        this.itemName = itemName;
        this.texture = texture;
        this.category = category;
        this.armorPoint = armorPoint;
        this.level = level;
    }
}
