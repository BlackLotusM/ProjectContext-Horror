using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{
    public AudioMixer mixer;
    public GameObject[] allWindows; 
    public void open(GameObject windowToOpen)
    {
        for(int i = 0; i < allWindows.Length; i++)
        {
            allWindows[i].SetActive(false);
        }

        windowToOpen.SetActive(true);
    }

    public void start(string s)
    {
        SceneManager.LoadScene(s);
        for (int i = 0; i < allWindows.Length; i++)
        {
            allWindows[i].SetActive(false);
        }
    }

    public void quit()
    {
        for (int i = 0; i < allWindows.Length; i++)
        {
            allWindows[i].SetActive(false);
        }
        Application.Quit();
    }

    public void changeMain(float sliderValue)
    {
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
        mixer.SetFloat("MasterVolume", Mathf.Log10 (sliderValue) * 20);
    }

    public void changeSFX(float sliderValue)
    {
        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
        mixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void changeMusic(float sliderValue)
    {
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void changeQuality(int level)
    {
        QualitySettings.SetQualityLevel(level);
    }

    public void resume(GameObject th)
    {
        for (int i = 0; i < allWindows.Length; i++)
        {
            allWindows[i].SetActive(false);
        }
        th.SetActive(false);
    }

}
