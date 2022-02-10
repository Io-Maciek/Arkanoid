using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CeglaDestroy : MonoBehaviour
{
    private GameObject plansza;

    Image zdjecie;

    public uint zycia = 1;


    public GameObject[] Efekty;
    public bool CzyZawszeWyleciEfekt = false;

    private void Awake()
    {
        zdjecie = GetComponent<Image>();
        
        Pokoloruj();
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            --zycia;
            Pokoloruj();
            if(zycia == 0)
            {



                Destroy(gameObject);
                transform.parent.parent.GetComponent<Spawner>().CHECK_WIN(collision.gameObject);
            }
        }
    }

    private void Pokoloruj()
    {
        Color kolor = zdjecie.color;
        switch (zycia)
        {
            case 3:
                kolor=Color.red;
                break;
            case 2:
                kolor = Color.green;
                break;
            case 1:
                kolor = Color.yellow;
                break;
        }
        zdjecie.color = kolor;
    }
}
