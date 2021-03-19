using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelected : MonoBehaviour
{
    public GameObject thisButton;

   void deselectButton()
    {
        if(thisButton.activeInHierarchy)
        {
            thisButton.SetActive(false);
            Debug.Log("I'm unselecting!");
        }
    }
}
