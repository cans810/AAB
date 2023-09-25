using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Weapon",menuName = "Weapon")]
public class Weapon : Item
{
    public string category;

    public bool equipped;
    public Weapon(string itemName,Sprite texture,string category,int level){
        this.itemName = itemName;
        this.texture = texture;
        this.category = category;
        this.level = level;
    }
}
