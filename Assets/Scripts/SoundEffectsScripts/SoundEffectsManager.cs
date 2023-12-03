using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    public AudioSource source1;
    public AudioSource source2;
    public AudioClip earth_quake_sound;
    public AudioClip unknown_man_talking;

    public void playEarthQuakeSound(){
        source1.pitch = 0.93f;
        source1.clip = earth_quake_sound;
        source1.Play();
    }

    public void playUnKnownManTalkingSound(){
        source2.pitch = 0.22f;
        source2.clip = unknown_man_talking;
        source2.Play();
    }

    IEnumerator FadeOutSource1()
    {
        float startVolume = source1.volume;

        // Gradually decrease the volume over a duration of 2 seconds
        float t = 0;
        while (t < 0.7f)
        {
            t += Time.deltaTime;
            source1.volume = Mathf.Lerp(startVolume, 0f, t / 0.7f);
            yield return null;
        }

        // Ensure the volume is set to 0 when the coroutine is done
        source1.volume = 0f;
    }

    IEnumerator FadeOutSource2()
    {
        float startVolume = source2.volume;

        // Gradually decrease the volume over a duration of 2 seconds
        float t = 0;
        while (t < 0.7f)
        {
            t += Time.deltaTime;
            source2.volume = Mathf.Lerp(startVolume, 0f, t / 0.7f);
            yield return null;
        }

        // Ensure the volume is set to 0 when the coroutine is done
        source2.volume = 0f;
    }

}
