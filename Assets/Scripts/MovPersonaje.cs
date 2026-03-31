using UnityEngine;
using UnityEngine.InputSystem;



public class MovPersonaje : MonoBehaviour
{

    
    
    public float velocidad= 0.5f;

    public float impulsoSalto=1;

    bool puedoSaltar = false;

    public GameObject barril;


    Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()  
    {
        
        rb = GetComponent<Rigidbody2D>();
        barril = GameObject.Find("barril");
  
    }

    // Update is called once per frame
    void Update()
    {



        // this.transform.position = new Vector3(this.transform.position.x + 0.1f, this.transform.position.y,0);

        // PARA MOVERSE: EL DE ABAJO ES EL EQUIVALENTE DEL DE ARRIBA

        Vector2 moveInput = InputSystem.actions["Move"].ReadValue<Vector2>(); //=[-1,0]

        this.transform.Translate(moveInput.x*velocidad,moveInput.y,0);

        //moveInput.x = (-1:A).-------------------(1:D)
        //FLIP//

        if (moveInput.x < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        else 
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,0.7f);
        Debug.DrawRay(transform.position,Vector2.down*0.7f, Color.red);

         

        if(hit.collider == true)
        {
            puedoSaltar= true;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            
            
        }
        else
        {
            puedoSaltar=false;
            this.GetComponent<SpriteRenderer>().color = Color.red;
            
            
        }

        // SALTO //

        bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();

        if(salto == true && puedoSaltar)
        {
            Debug.Log("salto");
            rb.AddForce(transform.up*impulsoSalto,ForceMode2D.Impulse);
        }

    //Disparo

    bool disparo = InputSystem.actions["Attack"].WasPressedThisFrame();

        if (disparo)
        {
            Instantiate(barril, new Vector3(0,0,0), Quaternion.identity);
        }

    
    

    }

}
