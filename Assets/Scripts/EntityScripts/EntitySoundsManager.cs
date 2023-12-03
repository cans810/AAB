using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySoundsManager : MonoBehaviour
{
    public AudioSource shoutingSource;
    public AudioSource dyingShoutingSource;
    public AudioSource weaponsSource;
    public AudioSource groundSource;
    public AudioSource punchSource;
    public AudioClip walkingOnSandSoundEffect;
    public AudioClip[] weaponsHittingSoundEffects;
    public AudioClip[] hurtSoundEffects;
    public AudioClip[] punchSoundEffects;
    public AudioClip[] deathSoundEffects;

    public void playWeaponsHittingSoundEffects(int index)
    {
        weaponsSource.clip = weaponsHittingSoundEffects[index];
        weaponsSource.Play();
    }

    public void playHurtSoundEffects(int index)
    {
        shoutingSource.clip = hurtSoundEffects[index];
        shoutingSource.Play();
    }
    public void playDeathSoundEffects(int index)
    {
        dyingShoutingSource.clip = deathSoundEffects[index];
        dyingShoutingSource.Play();
    }

    public void playPunchSoundEffects(int index)
    {
        punchSource.clip = punchSoundEffects[index];
        punchSource.Play();
    }

    public void playWalkingOnSandSoundEffect()
    {
        groundSource.clip = walkingOnSandSoundEffect;
        groundSource.Play();
    }
}
