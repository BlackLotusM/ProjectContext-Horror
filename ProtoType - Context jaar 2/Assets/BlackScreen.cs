using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    public bool pres;
    public Image im;
    private void Update()
    {
        if (!pres)
        {
            
            if (Input.GetKeyDown(KeyCode.P))
            {
                pres = true;
            }
        }
        else
        {
            if(im.color.a < 255)
            {
                im.color = new Color(im.color.r, im.color.g, im.color.b, im.color.a + 0.002f);
            }
        }

        if (im.color.a >= 1f)
        {
            Debug.Log("ree");
            SceneManager.LoadScene("EndScene");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
