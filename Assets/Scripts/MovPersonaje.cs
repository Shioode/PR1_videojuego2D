using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovPersonaje : MonoBehaviour
{
    public float velocidad = 0.04f;

    public float impulsoSalto = 1;

    bool puedoSaltar = false;

    public GameObject barril;

    GameObject respawn;

    public bool direccionBalaDerecha = true;

    public string direccionPersonaje = "quieto";

    bool estoyAzul = false;

    Rigidbody2D rb;

    Animator controlAnimacion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controlAnimacion = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        barril = GameObject.Find("barril");
        respawn = GameObject.Find("Respawn");
        transform.position = respawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // controlAnimacion.SetBool("activaCamina",true);

        // this.transform.position = new Vector3(this.transform.position.x + 0.1f, this.transform.position.y,0);

        // PARA MOVERSE: EL DE ABAJO ES EL EQUIVALENTE DEL DE ARRIBA

        Vector2 moveInput = InputSystem.actions["Move"].ReadValue<Vector2>(); //=[-1,0]

        this.transform.Translate(moveInput.x * velocidad * Time.deltaTime, moveInput.y, 0);

        //FLIP//

        if (moveInput.x < 0)
        {
            direccionBalaDerecha = false;
            this.GetComponent<SpriteRenderer>().flipX = true;
            direccionPersonaje = "izq";
        }
        else if (moveInput.x > 0)
        {
            direccionBalaDerecha = true;
            this.GetComponent<SpriteRenderer>().flipX = false;
            direccionPersonaje = "dcha";
        }
        else
        {
            direccionPersonaje = "quieto";
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.7f);
        // Debug.DrawRay(transform.position,Vector2.down*0.7f, Color.red);

        //ANIMACION CAMINADO

        if (moveInput.x != 0)
        {
            controlAnimacion.SetBool("activaCamina", true);
        }
        else
        {
            controlAnimacion.SetBool("activaCamina", false);
        }

        if (hit.collider == true)
        {
            puedoSaltar = true;
            // this.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            puedoSaltar = false;
            // this.GetComponent<SpriteRenderer>().color = Color.red;
        }

        // SALTO //

        bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();

        if (salto == true && puedoSaltar)
        {
            Debug.Log("salto");
            rb.AddForce(transform.up * impulsoSalto, ForceMode2D.Impulse);
        }

        // MUERTE POR CAIDA

        if (transform.position.y <= -100)
        {
            Muerte();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "roca")
        {
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "roca")
        {
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    // void OnTriggerEnter2D(Collider2D otroObjeto)
    // {
    //     if (otroObjeto.gameObject.name == "coin")
    //     {
    //         otroObjeto.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    //     }
    // }

    // void OnTriggerExit2D(Collider2D otroObjeto)
    // {
    //     if (otroObjeto.gameObject.name == "coin")
    //     {
    //         otroObjeto.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    //     }
    // }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger con:" + col.gameObject.name);

        //MUERTE POR PINCHO

        if (col.gameObject.name == "dead")
        {
            Muerte();
        }
        //Checkpoint
        if (col.gameObject.name == "checkpoint")
        {
            respawn.transform.position = col.transform.position;
        }
    }

    public void Muerte()
    {
        GameManager.vidas -= 1;
        transform.position = respawn.transform.position;
        AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.muerte);
    }

    public void CambiaColor()
    {
        if (estoyAzul)
        {
            this.GetComponent<SpriteRenderer>().color = Color.blue;
            estoyAzul = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
            estoyAzul = true;
        }
    }
}
