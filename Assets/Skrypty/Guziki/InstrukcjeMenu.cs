using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrukcjeMenu : MonoBehaviour
{
    public GameObject Menu;

    public void ClickReturn()
    {
        Menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
