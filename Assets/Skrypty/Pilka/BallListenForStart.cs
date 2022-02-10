using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallListenForStart : MonoBehaviour
{
    public AudioClip[] odbiciePlatforma;
    public AudioClip ceglaZniszczenie;
    new AudioSource audio;

    GameObject gracz;
    GameObject plansza;

    Rigidbody2D rb;

    private long comboMultiplyer = 1;

    

    public float speed=6f;

    //public float y;
    // Start is called before the first frame update
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = odbiciePlatforma[Random.Range(0, odbiciePlatforma.Length)];
        audio.pitch = Random.Range(0.85f, 1.16f);
        gracz = transform.parent.gameObject;
        plansza = gracz.transform.parent.gameObject;
        rb = GetComponent<Rigidbody2D>();      
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && transform.parent.gameObject == gracz)
        {
            float kierY = Random.Range(-1f,1f);
            Vector2 kierunek = new Vector2(kierY, 1* plansza.transform.parent.GetComponent<RectTransform>().localScale.x);
            transform.SetParent(plansza.transform);
            rb.velocity = kierunek * speed;
            audio.Play();

            gracz.GetComponent<GraczMovement>().ClearInstrukcje();
        }

        if(transform.parent.gameObject == gracz)
        {
            GetComponent<RectTransform>().position = new Vector3(gracz.GetComponent<RectTransform>().position.x, GetComponent<RectTransform>().position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == gracz)
        {
            audio.clip = odbiciePlatforma[Random.Range(0, odbiciePlatforma.Length)];
            audio.pitch = Random.Range(0.85f, 1.16f);
            audio.Play();

            //print($"{transform.position.x} - {collision.transform.position.x}\t=\t{(transform.position.x - collision.transform.position.x)}");
            float katVec = katUderzenia();
            Vector2 vec = new Vector2(katVec, 1 * plansza.transform.parent.GetComponent<RectTransform>().localScale.x);

            rb.velocity = vec *speed;
            comboMultiplyer = 1;
        }else if(collision.gameObject.tag == "Cegla")
        {
            CeglaDestroy c = collision.gameObject.GetComponent<CeglaDestroy>();
            if (c.zycia <= 1)
            {
                audio.clip = ceglaZniszczenie;
                audio.pitch = Random.Range(0.85f, 1.16f);
                audio.Play();
                int chance = c.CzyZawszeWyleciEfekt ? 10 : Random.Range(0, 11);

                // 40% ¿e coœ wyleci
                if (chance > 6)
                {
                    print("LECI");
                    chance = Random.Range(0, 11);
                    GameObject obj;
                    if (chance >= 3)
                    {
                        print("DOBRY");
                        obj = c.Efekty[Random.Range(0, 3)];
                    }
                    else
                    {
                        print("Z£Y");
                        obj = c.Efekty[Random.Range(3, 5)];
                    }
                    var ef = Instantiate(obj, plansza.transform);
                    ef.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                }
            }
                plansza.GetComponent<Spawner>().Punkty += 10 * comboMultiplyer;
                comboMultiplyer++;
            
        }
        else
        {
            comboMultiplyer = 1;
        }
    }


    /// <summary>
    /// Zwraca stronê i moc pozycji x gracza, w które oderzy³a pi³ka 
    /// <para>strona <c>(plus/minus)</c></para>
    /// <para><c>moc (odstek od 0.0 do 1.0)</c></para>
    /// </summary>
    float katUderzenia()=>(transform.position.x - gracz.transform.position.x) / gracz.GetComponent<GraczMovement>().graczSize;
    

}
