using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Intro_scene : MonoBehaviour
{
    public musicHandeler mh;
    public LookAndMove playerMove;
    public TextMeshProUGUI[] lines;
    public Animator temp;
    public Image backLight;
    int current = 0;
    bool busy;

    public GameObject soundPrefab1;
    public GameObject soundPrefab2;

    private void Start()
    {
        temp.enabled = false;
        playerMove.cantMoveset();
        Display(current);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!busy)
            {
                current++;
            }

            if (current >= lines.Length)
            {
                playerMove.canMoveset();
                StartCoroutine(playerMove.startPowerOutage());
                temp.enabled = true;
                StartCoroutine(FadeToImage(0f, 1.0f, backLight));
                StartCoroutine(TheEnd());
                resetDisplay();
                
            }
            else
            {
                if (!busy)
                {
                    busy = true;
                    resetDisplay();
                    Display(current);
                    StartCoroutine(busy2());
                    if (current == 1)
                    {
                        SoundPlay1();
                        StartCoroutine(FadeToImage(0.76f, 1.0f, backLight));
                    }
                    else if (current == 2)
                    {
                        mh.firstMusicCall();
                    }
                    else if (current == 3)
                    {
                        SoundPlay2();
                    }
                }
            }
        }
    }

    IEnumerator TheEnd()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false); 
    }
    void SoundPlay1()
    {
        Instantiate(soundPrefab1);
    }
    void SoundPlay2()
    {
        Instantiate(soundPrefab2);
    }

    IEnumerator busy2()
    {
        yield return new WaitForSeconds(1);
        busy = false;
    }
    IEnumerator FadeTo(float aValue, float aTime, TextMeshProUGUI text)
    {
        float alpha = text.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            text.color = newColor;
            yield return null;
        }  
    }

    IEnumerator FadeToImage(float aValue, float aTime, Image text)
    {
        float alpha = text.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(alpha, aValue, t));
            text.color = newColor;
            yield return null;
        }
    }

    void Display(int current)
    {
        TextMeshProUGUI text = lines[current];
        text.gameObject.SetActive(true);
        text.alpha = 0;
        StartCoroutine(FadeTo(1.0f, 1.0f, text));
    }

    void resetDisplay()
    {
        TextMeshProUGUI text = lines[current - 1];
        text.gameObject.SetActive(true);
        StartCoroutine(FadeTo(0f, 0.55f, text));
    }
}
