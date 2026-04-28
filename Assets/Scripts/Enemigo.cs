using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Enemigo : MonoBehaviour
{
    GameObject Personaje;

    //ESTADO DE ENEMIGO: patrulla, deteccion, perseccucion
    string estado = "patrulla";

    public float distanciaPatrulla = 2f;

    public float velocidadPatrulla = 0.03f;

    Vector3 posicionLimitIzq;

    Vector3 posicionLimitDcha;

    Vector3 posicionInicial;

    bool dirPatrullaDcha = true;

    //ATAQUE

    public float velocidadAtaque = 0.1f;
    public float distanciaAtaque = 4.0f;

    public float distanciaEvitar = 6;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Personaje = GameObject.FindWithTag("Player");
        posicionInicial = transform.position;
        posicionLimitIzq = new Vector3(
            posicionInicial.x - distanciaPatrulla,
            posicionInicial.y,
            posicionInicial.z
        );
        posicionLimitDcha = new Vector3(
            posicionInicial.x + distanciaPatrulla,
            posicionInicial.y,
            posicionInicial.z
        );
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Estado:" + estado);

        float distancia = Vector3.Distance(transform.position, Personaje.transform.position);

        // Debug.DrawRay(transform.position, Personaje.transform.position, Color.red);

        //DETECCION
        if (distancia <= distanciaAtaque)
        {
            estado = "ataque";
        }

        //VUELVE A PATRULLAR

        if (distancia >= distanciaEvitar)
        {
            estado = "patrulla";
        }

        if (estado == "patrulla")
        {
            //si limite derecha
            if (transform.position.x >= posicionLimitDcha.x)
            {
                dirPatrullaDcha = false;
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
            if (transform.position.x <= posicionLimitIzq.x)
            {
                dirPatrullaDcha = true;
                this.GetComponent<SpriteRenderer>().flipX = true;
            }

            //si limite derecha(x)
            if (dirPatrullaDcha == true)
            {
                transform.Translate(velocidadPatrulla, 0, 0);
            }
            else
            {
                transform.Translate(velocidadPatrulla * -1, 0, 0);
            }
        }
        //ATAQUE
        if (estado == "ataque")
        {
            // Debug.Log(Personaje.transform.position);
            // Debug.Log("velocidadAtaque:" + velocidadAtaque);
            transform.position = Vector3.MoveTowards(
                transform.position,
                Personaje.transform.position,
                velocidadAtaque
            );

            if (AudioManager.Instance.GetComponent<AudioSource>().isPlaying == true) { }
            else
            {
                AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.fantasma);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("MUERTE");

            Personaje.GetComponent<MovPersonaje>().Muerte();
        }
        if (col.gameObject.name == "Bala")
        {
            Destroy(this.gameObject, 0.5f);
            Destroy(col.gameObject, 0.5f);
        }
    }
}
