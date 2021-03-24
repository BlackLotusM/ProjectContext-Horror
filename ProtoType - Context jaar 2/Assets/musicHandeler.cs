using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicHandeler : MonoBehaviour
{
    public AudioSource musicSource;
    public bool isDone;
    public bool final;
    public AudioClip secondStageAudio;

    public IEnumerator Mix(AudioSource audioSource, float FadeTime)
    {
        final = true;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= 0.2f * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.clip = secondStageAudio;
        audioSource.Play();
        while (audioSource.volume < 1)
        {
            audioSource.volume += 0.2f * Time.deltaTime / FadeTime;
            yield return null;
        }
    }

    public IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = 0;
    }

    public IEnumerator FadeIn(AudioSource audioSource, float FadeTime, float steps)
    {
        audioSource.Play();
        while (audioSource.volume < 1)
        {
            audioSource.volume += steps * Time.deltaTime / FadeTime;
            yield return null;
        }
    }

    public void firstMusicCall()
    {
        IEnumerator fadeSound1 = FadeIn(musicSource, 0.5f, 0.1f);
        StartCoroutine(fadeSound1);
    }

    public void secondStage()
    {
        if (!final)
        {
            StartCoroutine(Mix(musicSource, 1f));
        }
    }
}
