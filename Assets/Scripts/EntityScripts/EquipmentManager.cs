using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class EquipmentManager : MonoBehaviour
{
    public GameObject entity;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        if (entity != null){
            if (gameObject.name.Equals("righthand_equipment")){
                if (entity.GetComponent<EntityEquipment>().RightHandEquipped != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().RightHandEquipped.texture;
                    // Get the SpriteRenderer component
                    spriteRenderer = GetComponent<SpriteRenderer>();

                    if (spriteRenderer == null)
                    {
                        Debug.LogError("SpriteRenderer component not found on GameObject.");
                        return;
                    }

                    // Add the BoxCollider2D component if not already present
                    boxCollider = gameObject.GetComponent<BoxCollider2D>();
                    if (boxCollider == null)
                    {
                        boxCollider = gameObject.AddComponent<BoxCollider2D>();
                        boxCollider.isTrigger = true;
                    }

                    // Set the size of the BoxCollider2D to match the sprite size
                    SetColliderSizeAndPosition();
                }
                else if (entity.GetComponent<EntityEquipment>().RightHandEquipped == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                    
                    Destroy(gameObject.GetComponent<BoxCollider2D>());
                }
            }
            if (gameObject.name.Equals("helmet")){
                if (entity.GetComponent<EntityEquipment>().HelmetWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().HelmetWorn.texture;
                }
                else if (entity.GetComponent<EntityEquipment>().HelmetWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            }
            if (gameObject.name.Equals("chestplate")){
                if (entity.GetComponent<EntityEquipment>().ChestplateWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().ChestplateWorn.texture;
                }
                else if (entity.GetComponent<EntityEquipment>().ChestplateWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("rightarm_armor")){
                if (entity.GetComponent<EntityEquipment>().ArmWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().ArmWorn.texture;
                }
                else if (entity.GetComponent<EntityEquipment>().ArmWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("leftarm_armor")){
                if (entity.GetComponent<EntityEquipment>().ArmWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().ArmWorn.pair;
                }
                else if (entity.GetComponent<EntityEquipment>().ArmWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("rightforearm_armor")){
                if (entity.GetComponent<EntityEquipment>().ForearmWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().ForearmWorn.texture;
                }
                else if (entity.GetComponent<EntityEquipment>().ForearmWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("leftforearm_armor")){
                if (entity.GetComponent<EntityEquipment>().ForearmWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().ForearmWorn.pair;
                }
                else if (entity.GetComponent<EntityEquipment>().ForearmWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("pants")){
                if (entity.GetComponent<EntityEquipment>().LegWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().LegWorn.pairExtra;
                }
                else if (entity.GetComponent<EntityEquipment>().LegWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("rightleg_armor")){
                if (entity.GetComponent<EntityEquipment>().LegWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().LegWorn.texture;
                }
                else if (entity.GetComponent<EntityEquipment>().LegWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("leftleg_armor")){
                if (entity.GetComponent<EntityEquipment>().LegWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().LegWorn.pair;
                }
                else if (entity.GetComponent<EntityEquipment>().LegWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("rightcalf_armor")){
                if (entity.GetComponent<EntityEquipment>().CalfWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().CalfWorn.texture;
                }
                else if (entity.GetComponent<EntityEquipment>().CalfWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("leftcalf_armor")){
                if (entity.GetComponent<EntityEquipment>().CalfWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().CalfWorn.pair;
                }
                else if (entity.GetComponent<EntityEquipment>().CalfWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("rightfoot_armor")){
                if (entity.GetComponent<EntityEquipment>().FootWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().FootWorn.texture;
                }
                else if (entity.GetComponent<EntityEquipment>().FootWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("leftfoot_armor")){
                if (entity.GetComponent<EntityEquipment>().FootWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().FootWorn.pair;
                }
                else if (entity.GetComponent<EntityEquipment>().FootWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
         }
    }

    // Update is called once per frame
    void Update()
    {
         if (entity != null){
            if (gameObject.name.Equals("righthand_equipment")){
                if (entity.GetComponent<EntityEquipment>().RightHandEquipped != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().RightHandEquipped.texture;

                    // Get the SpriteRenderer component
                    spriteRenderer = GetComponent<SpriteRenderer>();

                    if (spriteRenderer == null)
                    {
                        Debug.LogError("SpriteRenderer component not found on GameObject.");
                        return;
                    }

                    // Add the BoxCollider2D component if not already present
                    boxCollider = gameObject.GetComponent<BoxCollider2D>();
                    if (boxCollider == null)
                    {
                        boxCollider = gameObject.AddComponent<BoxCollider2D>();
                        boxCollider.isTrigger = true;
                    }

                    // Set the size of the BoxCollider2D to match the sprite size
                    SetColliderSizeAndPosition();
                }
                else if (entity.GetComponent<EntityEquipment>().RightHandEquipped == null){
                    GetComponent<SpriteRenderer>().sprite = null;

                    Destroy(gameObject.GetComponent<BoxCollider2D>());
                }
            }
            if (gameObject.name.Equals("helmet")){
                if (entity.GetComponent<EntityEquipment>().HelmetWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().HelmetWorn.texture;
                }
                else if (entity.GetComponent<EntityEquipment>().HelmetWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            }
            if (gameObject.name.Equals("chestplate")){
                if (entity.GetComponent<EntityEquipment>().ChestplateWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().ChestplateWorn.texture;
                }
                else if (entity.GetComponent<EntityEquipment>().ChestplateWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("rightarm_armor")){
                if (entity.GetComponent<EntityEquipment>().ArmWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().ArmWorn.texture;
                }
                else if (entity.GetComponent<EntityEquipment>().ArmWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("leftarm_armor")){
                if (entity.GetComponent<EntityEquipment>().ArmWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().ArmWorn.pair;
                }
                else if (entity.GetComponent<EntityEquipment>().ArmWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("rightforearm_armor")){
                if (entity.GetComponent<EntityEquipment>().ForearmWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().ForearmWorn.texture;
                }
                else if (entity.GetComponent<EntityEquipment>().ForearmWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("leftforearm_armor")){
                if (entity.GetComponent<EntityEquipment>().ForearmWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().ForearmWorn.pair;
                }
                else if (entity.GetComponent<EntityEquipment>().ForearmWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("pants")){
                if (entity.GetComponent<EntityEquipment>().LegWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().LegWorn.pairExtra;
                }
                else if (entity.GetComponent<EntityEquipment>().LegWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            }
            if (gameObject.name.Equals("rightleg_armor")){
                if (entity.GetComponent<EntityEquipment>().LegWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().LegWorn.texture;
                }
                else if (entity.GetComponent<EntityEquipment>().LegWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("leftleg_armor")){
                if (entity.GetComponent<EntityEquipment>().LegWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().LegWorn.pair;
                }
                else if (entity.GetComponent<EntityEquipment>().LegWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("rightcalf_armor")){
                if (entity.GetComponent<EntityEquipment>().CalfWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().CalfWorn.texture;
                }
                else if (entity.GetComponent<EntityEquipment>().CalfWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("leftcalf_armor")){
                if (entity.GetComponent<EntityEquipment>().CalfWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().CalfWorn.pair;
                }
                else if (entity.GetComponent<EntityEquipment>().CalfWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("rightfoot_armor")){
                if (entity.GetComponent<EntityEquipment>().FootWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().FootWorn.texture;
                }
                else if (entity.GetComponent<EntityEquipment>().FootWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
            if (gameObject.name.Equals("leftfoot_armor")){
                if (entity.GetComponent<EntityEquipment>().FootWorn != null){
                    GetComponent<SpriteRenderer>().sprite = entity.GetComponent<EntityEquipment>().FootWorn.pair;
                }
                else if (entity.GetComponent<EntityEquipment>().FootWorn == null){
                    GetComponent<SpriteRenderer>().sprite = null;
                }
            } 
         }
    }
    void SetColliderSizeAndPosition()
    {
        // Get the size of the sprite from the SpriteRenderer
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        // Set the size of the BoxCollider2D
        boxCollider.size = spriteSize;

        // Get the position of the sprite from the SpriteRenderer
        Vector2 spritePosition = spriteRenderer.sprite.bounds.center;

        // Set the position of the BoxCollider2D
        boxCollider.offset = spritePosition;
    }
}
