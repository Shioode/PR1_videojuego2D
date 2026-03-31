using UnityEngine;
using UnityEngine.InputSystem;



public class MovPersonaje : MonoBehaviour
{

    public Vector3 inicioPersonaje= new Vector3(1,1,0);
    
    public float velocidad= 0.5f;

    public float impulsoSalto=1;


    Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()  
    {
        
        rb = GetComponent<Rigidbody2D>();
        barril.SetActive = false;
  
    }

    // Update is called once per frame
    void Update()
    {
        // this.transform.position = new Vector3(this.transform.position.x + 0.1f, this.transform.position.y,0);

        // PARA MOVERSE: EL DE ABAJO ES EL EQUIVALENTE DEL DE ARRIBA

        

        Vector2 moveInput = InputSystem.actions["Move"].ReadValue<Vector2>(); //=[-1,0]

        this.transform.Translate(moveInput.x*velocidad,moveInput.y,0);

        //moveInput.x = (-1:A).-------------------(1:D)

        if (moveInput.x < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        else 
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }


        // SALTO //

        bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();

        if(salto == true)
        {
            Debug.Log("salto");
            rb.AddForce(transform.up*impulsoSalto,ForceMode2D.Impulse);
            
            
        }



    }

}
