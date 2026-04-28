using UnityEngine;
using UnityEngine.InputSystem;

public class Bala : MonoBehaviour
{
    GameObject Personaje;
    public GameObject disparo;

    bool direccionPersonaje;

    public float velocidadBala = 0.5f;

    float heNacido;
    public float tiempoHastaDestruccion = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Personaje = GameObject.Find("Personaje");
        direccionPersonaje = Personaje.GetComponent<MovPersonaje>().direccionBalaDerecha;
        heNacido = Time.time; //4.0//10.0/...
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 0.5f);
        if (direccionPersonaje)
        {
            transform.Rotate(0, 0, 0.5f);
            disparo.transform.Translate(velocidadBala * Time.deltaTime, 0, 0);
        }
        else
        {
            disparo.transform.Translate(-1 * velocidadBala * Time.deltaTime, 0, 0);
            transform.Rotate(0, 0, -0.5f);
        }

        //Destruccion por tiempo

        if (Time.time >= heNacido + tiempoHastaDestruccion)
        {
            Destroy(disparo);
        }
    }
}
