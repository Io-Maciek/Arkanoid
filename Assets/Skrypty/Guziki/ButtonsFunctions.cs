using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctions : MonoBehaviour
{
    public GameObject MenuInstrukcje;

    public void ClickExit()
    {
        Application.Quit();
        //Debug.Break();
    }

    public void ClickInstrukcje()
    {
        MenuInstrukcje.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ClickStart()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
