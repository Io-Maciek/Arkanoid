using Assets.Skrypty.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    const string FILE = "wyniki.xml";

    public GameObject ball;
    GameObject gracz;
    public Text TextZycia;
    public Text TextPunkty;

    private GameObject Cegly;
    public int iloscCegiel { get; set; }

    public Animator a { get; set; }

    uint zycia = 3;
    public uint Zycia { get { return zycia; } set { TextZycia.text = $"Ilo�� pi�ek: {value}"; zycia = value; } }


    private long punkty;
    public long Punkty
    {
        get => punkty;
        set
        {
            TextPunkty.text = $"Punkty: {value}";
            punkty = value;
        }
    }


    void Awake()
    {
        Time.timeScale = 1;
        Cegly = transform.Find("Cegly").gameObject;
        iloscCegiel = Cegly.transform.childCount;

        a = TextZycia.gameObject.GetComponent<Animator>();
        gracz = transform.Find("Gracz").gameObject;
        //TextZycia.text = $"Ilo�� pi�ek: {zycia}";
        Spawn();
    }

    /// <summary>
    /// Event uruchamiany gdy jaka� ceg�a utraci wszystkie �ycia i zostanie zniszczona
    /// </summary>
    /// <param name="pilka"></param>
    public void CHECK_WIN(GameObject pilka)
    {
        --iloscCegiel;
        if (iloscCegiel == 0)
        {
            print("WYGRA�E��������");
            Destroy(pilka);
            //Punkty *= Zycia;
            KONIEC_GRY("POKONANO T� MAP�");
        }
    }

    public void KONIEC_GRY(string powodKo�ca)
    {
        Time.timeScale = 0;
        GameObject panel = transform.parent.Find("PanelZako�czenieGry").gameObject;
        transform.parent.Find("BtnDoMenu").gameObject.SetActive(false);

        panel.transform.Find("Powod").GetComponent<Text>().text = powodKo�ca;
        panel.transform.Find("PUNKTY").GetComponent<Text>().text = Zycia==0?Punkty.ToString():(Punkty*Zycia).ToString();

        panel.SetActive(true);

        //Gracz g = new Gracz("Io_" + (char)UnityEngine.Random.Range(50, 120), punkty);
        //Gracz[] gracze;

        //if (File.Exists(FILE))
        //{

        //    gracze = Serialization.Read<Gracz[]>(FILE);

        //    if (g.punkty > gracze[9].punkty)
        //    {
        //        print("CZYTAM Z PLIKU I WPISUJE NOWY: "+g.punkty);

        //        gracze[9] = g;
        //        Array.Sort(gracze);
        //        Array.Reverse(gracze);
        //        Serialization.Save(FILE, gracze);
        //    }
        //    else
        //    {
        //        print("CZYTAM Z PLIKU i nie zapisuje :(");
        //    }
        //}
        //else
        //{
        //    print("TWORZ� NOWY PLIK Z JEDNYM WYNIKIEM " + g.punkty);

        //    gracze = new Gracz[10];
        //    gracze[0] = g;

        //    for (int i = 1; i < gracze.Length; i++)
        //    {
        //        gracze[i] = new Gracz("---", 0);
        //    }

        //    Serialization.Save(FILE, gracze);
        //}

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            --Zycia;
            a.SetBool("Lost", true);
            if (Zycia > 0)
                Spawn();
            else
            {
                print("KONIEC GRY - BRAK �Y�");
                KONIEC_GRY("NIE MASZ WI�CEJ �Y�");
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<EffectModel>() != null)
        {
            Destroy(collision.gameObject);
        }
    }

    void Spawn()
    {
        var b = Instantiate(ball, gracz.transform);
        gracz.GetComponent<RectTransform>().localPosition = new Vector2(0, -215);
    }

}
