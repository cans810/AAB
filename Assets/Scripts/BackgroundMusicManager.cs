using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public float fadeDuration = 2.0f; // Duration of the fade-out in seconds

    private float initialVolume;
    private bool fading = false;

    private static BackgroundMusicManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        initialVolume = backgroundMusic.volume;
    }

    public void StartFadeOut()
    {
        if (!fading)
        {
            fading = true;
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            float t = elapsedTime / fadeDuration;
            backgroundMusic.volume = Mathf.Lerp(initialVolume, 0, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        backgroundMusic.volume = 0;
        fading = false;
        backgroundMusic.Stop();
    }
}
