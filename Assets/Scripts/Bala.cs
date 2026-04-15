using UnityEngine;
using UnityEngine.InputSystem;



public class Bala : MonoBehaviour
{

    GameObject Personaje;
    public GameObject disparo;

    bool direccionPersonaje;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Personaje = GameObject.Find("Personaje");
        direccionPersonaje= Personaje.GetComponent<MovPersonaje>().direccionBalaDerecha;
    }

    // Update is called once per frame
    void Update()
    {
    
        transform.Rotate(0,0,0.5f);

        disparo.transform.Translate(0.01f,0,0);

    }
    
}
