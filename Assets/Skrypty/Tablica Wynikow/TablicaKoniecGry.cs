using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TablicaKoniecGry : MonoBehaviour
{
    public Text Powod { get; set; }
    public Text Punkty { get; set; }

    const string FILE = "wyniki.xml";

    private void Start()
    {
        Powod = transform.Find("Powod").GetComponent<Text>();
        Punkty= transform.Find("PUNKTY").GetComponent<Text>();
    }

    public void BtnAnuluj()
    {
        SceneManager.LoadSceneAsync(0);
    }


    public void BtnZapisz()
    {
        string nick = transform.Find("NICK").GetComponent<InputField>().text;
        Gracz g = new Gracz(nick, int.Parse(Punkty.text));
        Gracz[] gracze;

        if (File.Exists(FILE))
        {

            gracze = Serialization.Read<Gracz[]>(FILE);

            if (g.punkty > gracze[9].punkty)
            {
                print("CZYTAM Z PLIKU I WPISUJE NOWY: " + g.punkty);

                gracze[9] = g;
                Array.Sort(gracze);
                Array.Reverse(gracze);
                Serialization.Save(FILE, gracze);
            }
            else
            {
                print("CZYTAM Z PLIKU i nie zapisuje :(");
            }
        }
        else
        {
            print("TWORZÊ NOWY PLIK Z JEDNYM WYNIKIEM " + g.punkty);

            gracze = new Gracz[10];
            gracze[0] = g;

            for (int i = 1; i < gracze.Length; i++)
            {
                gracze[i] = new Gracz("---", 0);
            }

            Serialization.Save(FILE, gracze);
        }

        SceneManager.LoadSceneAsync(0);
    }
}
