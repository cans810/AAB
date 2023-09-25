using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySoundManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] gotHit_Sounds;
    public AudioClip walkingOn_Sand;

    public void Start(){
        foreach (AudioClip clip in gotHit_Sounds)
        {
            source.clip = clip; // Assign the clip to the AudioSource to preload it
        }
        source.clip = walkingOn_Sand;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play_gotHit_Random(){
        source.PlayOneShot(gotHit_Sounds[UnityEngine.Random.Range(0,gotHit_Sounds.Length)]);
    }

    public void play_walkingOn_Sand(){
        source.PlayOneShot(walkingOn_Sand);
    }
}
