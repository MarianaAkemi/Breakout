using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BolaScript : MonoBehaviour
{
    public float velocidademax;
    Rigidbody2D rb;
    public GameObject NuvensPrefab;
    public GameObject Surpresa;
    public GameObject Perdeu;

    public Text vidasText;
    int vidas;

    public AudioSource pop;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pop = GetComponent<AudioSource>();
        vidas = 6;  
    }

    void Update()
    {
        vidasText.text = vidas.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Baixo")
        {
            if(vidas == 1)
            {
                FimdeJogo();
            }
            else
            {
                PlacarScript.pontos = 0;
                vidas--;
                transform.position = new Vector2(0.0f, 0.0f);
                rb.velocity = new Vector2(0.0f, 0.0f);
                Destroy(NuvensPrefab);
                Instantiate(NuvensPrefab);
            }
        }
        if(rb.velocity.magnitude > velocidademax)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, velocidademax);
        }

        if (PlacarScript.pontos >= 21)
        {
            Destroy(gameObject);
            Instantiate(Surpresa);
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Nuvem")
        {
            pop.Play();
            Destroy(collision.gameObject);
            PlacarScript.pontos++;
        }
    }

    void FimdeJogo()
    {
        print("Fim de Jogo");
        Perdeu.SetActive(true);
        Destroy(gameObject);
    }
}
