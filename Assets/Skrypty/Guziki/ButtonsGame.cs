using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsGame : MonoBehaviour
{
    public GameObject guzikiPotwierdzenie;

    public void ButtonMenuBackOut()
    {
        if (GetComponentInChildren<Spawner>().Punkty > 0)
        {
            Time.timeScale = 0;
            transform.Find("BtnDoMenu").gameObject.GetComponent<Button>().interactable = false;
            guzikiPotwierdzenie.SetActive(true);
        }
        else
        {
            SceneManager.LoadSceneAsync(0);
        }
    }


    public void ButtonOK()
    {
        //Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }

    public void ButtonCancel()
    {
        Time.timeScale = 1;
        transform.Find("BtnDoMenu").gameObject.GetComponent<Button>().interactable = true;
        guzikiPotwierdzenie.SetActive(false);
    }
}
