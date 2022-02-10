using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Skrypty.Model
{
    public abstract class EffectModel : MonoBehaviour
    {
        public uint CzasTrwaniaEfektu;
        public bool CzyPozytywny;
        Rigidbody2D rb;

        private float speed = 150f;

        /// <summary>
        /// Metoda jaka wykonuje się po zebraniu obiektu przez platformę gracza
        /// </summary>
        public abstract void Effect(GameObject gracz);

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.down * speed*transform.parent.parent.GetComponent<RectTransform>().localScale.x;
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Effect(collision.gameObject);
                Destroy(gameObject);


                if (CzyPozytywny)
                {
                    transform.parent.GetComponent<Spawner>().Punkty += 10;
                }
                else
                {
                    transform.parent.GetComponent<Spawner>().Punkty -= 10;
                }
            }
        }


    }
}
