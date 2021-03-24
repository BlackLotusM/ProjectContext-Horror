using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class setVal : MonoBehaviour
{
    public string volType;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        if (!PlayerPrefs.HasKey(volType))
        {
            PlayerPrefs.SetFloat(volType, 1);
        }
        this.GetComponent<Slider>().value = PlayerPrefs.GetFloat(volType);
    }
}
