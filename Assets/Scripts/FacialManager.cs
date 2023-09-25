using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class FacialManager : MonoBehaviour
{
    public GameObject entity;
    public SpriteLibraryAsset textures;

    // Start is called before the first frame update
    void Start()
    {
        if (entity != null){
            if (gameObject.name.Equals("eyes")){
                if (entity.GetComponent<AppereanceManager>().race.Equals("Human")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("eyes",entity.GetComponent<ExpressionManager>().eyes_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Cyclops")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("eyes_cyclops",entity.GetComponent<ExpressionManager>().eyes_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Skeleton")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("eyes_skeleton",entity.GetComponent<ExpressionManager>().eyes_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Elf")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("eyes",entity.GetComponent<ExpressionManager>().eyes_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Orc")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("eyes_orc",entity.GetComponent<ExpressionManager>().eyes_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Tiefling")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("eyes_tiefling",entity.GetComponent<ExpressionManager>().eyes_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Beast")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("eyes_beast",entity.GetComponent<ExpressionManager>().eyes_state);
                }
            }
            if (gameObject.name.Equals("mouth")){
                if (entity.GetComponent<AppereanceManager>().race.Equals("Human")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("mouth",entity.GetComponent<ExpressionManager>().mouth_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Cyclops")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("mouth",entity.GetComponent<ExpressionManager>().mouth_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Skeleton")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("mouth_skeleton",entity.GetComponent<ExpressionManager>().mouth_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Elf")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("mouth",entity.GetComponent<ExpressionManager>().mouth_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Orc")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("mouths_orc",entity.GetComponent<ExpressionManager>().mouth_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Tiefling")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("mouths_tiefling",entity.GetComponent<ExpressionManager>().mouth_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Beast")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("mouths_beast",entity.GetComponent<ExpressionManager>().mouth_state);
                }
            }
            if (gameObject.name.Equals("hair")){
                GetComponent<SpriteRenderer>().sprite = textures.GetSprite("hair",entity.GetComponent<AppereanceManager>().hair);
            }
            if (gameObject.name.Equals("facial_hair")){
                GetComponent<SpriteRenderer>().sprite = textures.GetSprite("facial_hair",entity.GetComponent<AppereanceManager>().facial_hair);
            }
         }
    }

    // Update is called once per frame
    void Update()
    {
         if (entity != null){
            if (gameObject.name.Equals("eyes")){
                if (entity.GetComponent<AppereanceManager>().race.Equals("Human")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("eyes",entity.GetComponent<ExpressionManager>().eyes_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Cyclops")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("eyes_cyclops",entity.GetComponent<ExpressionManager>().eyes_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Skeleton")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("eyes_skeleton",entity.GetComponent<ExpressionManager>().eyes_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Elf")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("eyes",entity.GetComponent<ExpressionManager>().eyes_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Orc")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("eyes_orc",entity.GetComponent<ExpressionManager>().eyes_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Tiefling")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("eyes_tiefling",entity.GetComponent<ExpressionManager>().eyes_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Beast")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("eyes_beast",entity.GetComponent<ExpressionManager>().eyes_state);
                }
            }
            if (gameObject.name.Equals("mouth")){
                if (entity.GetComponent<AppereanceManager>().race.Equals("Human")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("mouth",entity.GetComponent<ExpressionManager>().mouth_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Cyclops")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("mouth",entity.GetComponent<ExpressionManager>().mouth_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Skeleton")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("mouth_skeleton",entity.GetComponent<ExpressionManager>().mouth_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Elf")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("mouth",entity.GetComponent<ExpressionManager>().mouth_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Orc")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("mouths_orc",entity.GetComponent<ExpressionManager>().mouth_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Tiefling")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("mouths_tiefling",entity.GetComponent<ExpressionManager>().mouth_state);
                }
                else if (entity.GetComponent<AppereanceManager>().race.Equals("Beast")){
                    GetComponent<SpriteRenderer>().sprite = textures.GetSprite("mouths_beast",entity.GetComponent<ExpressionManager>().mouth_state);
                }
            }
            if (gameObject.name.Equals("hair")){
                GetComponent<SpriteRenderer>().sprite = textures.GetSprite("hair",entity.GetComponent<AppereanceManager>().hair);
            }
            if (gameObject.name.Equals("facial_hair")){
                GetComponent<SpriteRenderer>().sprite = textures.GetSprite("facial_hair",entity.GetComponent<AppereanceManager>().facial_hair);
            }
         }
    }
}
