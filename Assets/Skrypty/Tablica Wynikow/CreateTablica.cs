using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CreateTablica : MonoBehaviour
{
    const string FILE = "wyniki.xml";

    public GameObject wynik;

    public GameObject[] wyniki = new GameObject[10];

    const int DIFF = 25;

    private Gracz[] gracze;

    // Start is called before the first frame update
    void Start()
    {


        //wyniki[0] = transform.Find("Wynik").gameObject;

        if (File.Exists(FILE))
        {
            print("JEST TAKI PLIK W WYNIKACH");

            gracze = Serialization.Read<Gracz[]>(FILE);

            for (int i = 0; i < wyniki.Length; i++)
            {
                wyniki[i] = Instantiate(wynik, transform);
                wyniki[i].transform.Find("ID").GetComponent<Text>().text = $"{i + 1}.";
                wyniki[i].transform.Find("Nick").GetComponent<Text>().text = gracze[i].nick;
                wyniki[i].transform.Find("Punkty").GetComponent<Text>().text = gracze[i].punkty.ToString();
                Vector3 p = wyniki[i].GetComponent<RectTransform>().localPosition;
                wyniki[i].GetComponent<RectTransform>().localPosition = new Vector3(p.x, p.y - (i * DIFF) , 0);
            }
        }
        else
        {
            print("PLIKU NIE MA, WYŒWIETLAM DOMYŒLNIE");

            for (int i = 0; i < wyniki.Length; i++)
            {
                wyniki[i] = Instantiate(wynik, transform);
                wyniki[i].transform.Find("ID").GetComponent<Text>().text = $"{i + 1}.";
                Vector3 p = wyniki[i].GetComponent<RectTransform>().localPosition;
                wyniki[i].GetComponent<RectTransform>().localPosition = new Vector3(p.x, p.y - (i * DIFF), 0);
            }
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
