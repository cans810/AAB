using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Weapon",menuName = "Weapon")]
public class Weapon : Item
{
    public bool equipped;
    public int meleeDamage;
    public Weapon(string itemName,Sprite texture,string category,int level,int price){
        this.itemName = itemName;
        this.texture = texture;
        this.category = category;
        this.level = level;
        this.price = price;
    }
}
