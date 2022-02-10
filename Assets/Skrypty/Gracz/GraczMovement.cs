using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GraczMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    bool[] poznano = new bool[2];
    public GameObject[] instrukcje;


    public float graczSize
    {
        get => GetComponent<RectTransform>().sizeDelta.x;
        set
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(value, 25);
            GetComponent<BoxCollider2D>().size = new Vector2(value, 23);
        }
    }

    public float defaultGraczSize = 80;



    // Start is called before the first frame update
    void Start()
    {
        graczSize = defaultGraczSize;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 m = Vector2.left * Time.deltaTime * speed * transform.parent.parent.GetComponent<RectTransform>().localScale.x;
            rb.AddForce(m, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 m = Vector2.right * Time.deltaTime * speed*transform.parent.parent.GetComponent<RectTransform>().localScale.x;
            rb.AddForce(m, ForceMode2D.Impulse);
        }

        if (poznano[1] == false && poznano[0] == false && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            poznano[0] = true;
            Invoke("ShowWSADinstrukcja", 0.5f);
            //instrukcje[2].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))//&&graczSize*1.5f<400)
        {
            graczSize *= 1.15f;
        }

/*        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }*/
    }
    void resetBoost()
    {
        speed /= 2;
    }

    void resetBoostN()
    {
        speed /= 0.75f;
    }

    void resetSize()
    {
        graczSize /= 1.5f;
    }

    void resetSizeN()
    {
        graczSize /= 0.75f;
    }

    void ShowWSADinstrukcja()
    {
        if (poznano[1] == false)
            instrukcje[2].SetActive(true);
    }


    public void ClearInstrukcje()
    {
        if (poznano[1] == false)
        {
            poznano[1] = true;
            foreach (var x in instrukcje)
            {
                x.SetActive(false);
            }
        }
    }
}
