using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    public List<Sprite> arena_images;
    
    public SpriteRenderer arena_image;

    void OnEnable(){
        string arenaCurrent = GameObject.Find("GameManager").GetComponent<GameManager>().currentArena;
        
        for (int i = 0; i < arena_images.Count; i++)
        {
            if (arena_images[i].name.Equals(arenaCurrent)){
                arena_image.sprite = arena_images[i];
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
