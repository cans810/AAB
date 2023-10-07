using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityAttributes : MonoBehaviour
{
    public int level;
    public double xp;
    public float PowerValue;

    public int strength;
    public int stamina;
    public int dexterity;
    public int vitality;
    public int offense;
    public int defence;
    public int aura;
    public int magic;

    public string entityName;

    public double heightInCm = 170;
    public float baseHitDamage;
    public float hitDamage;
    public float baseHitChance_light;
    public float baseHitChance_medium;
    public float baseHitChance_heavy;
    public float baseHitChance_leap;

    public float hitChance_light;
    public float hitChance_medium;
    public float hitChance_heavy;
    public float hitChance_leap;

    public float destinationX;
    public float moveSpeed;
    public float energy;

    public float maxHP;
    public float HP;
    public float maxSP;
    public float SP;

    public int maxArmorPoint;
    public int armorPoint;
    public float baseStepSize;
    public float stepSize;

    void Awake(){
        xp = 0;
        level = 1;

        // strength defines hitDamage
        baseHitDamage = 12;
        hitDamage = baseHitDamage;
        baseHitChance_light = 90f/100f;
        baseHitChance_medium = 80f/100f;
        baseHitChance_heavy = 55f/100f;
        baseHitChance_leap = 50f/100f;

        // agility defines stepSize
        dexterity = 1;
        baseStepSize = 
        stepSize = 

        // vitality defines HP
        vitality = 1;
        maxHP = 25;
        HP = maxHP;

        // attack defines chances of attack action land
        // şimdilik atla
        offense = 1;

        // defence defines chances of blocking enemy attack
        // şimdilik atla
        defence = 1;

        // charisma reduces items prices that are in market,
        // şimdilik atla
        aura = 1;

        // stamina defines stamina point
        // şimdilik atla
        stamina = 1;
        maxSP = 25;
        SP = maxSP;

        // magicka defines magicDamage
        // şimdilik atla
        magic = 1;

        //alive = false;

        moveSpeed = 1f;
        stepSize = 1f;
    }

    public void updatePowerValue(){ 
        PowerValue = 0;

        PowerValue += strength;
        PowerValue += stamina;
        PowerValue += dexterity;
        PowerValue += offense;
        PowerValue += defence;
        PowerValue += vitality;
    }

    public void calculateMaxArmorPoint(){
        maxArmorPoint = 0;

        foreach (Armor armor in gameObject.GetComponent<EntityEquipment>().equippedItemsInventory.OfType<Armor>()){
            maxArmorPoint += armor.armorPoint;
        }
        armorPoint = maxArmorPoint;
    }

}
