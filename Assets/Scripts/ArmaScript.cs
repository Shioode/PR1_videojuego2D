using UnityEngine;
using UnityEngine.InputSystem;


public class ArmaScript : MonoBehaviour
{

    public GameObject bala;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Disparo

    bool disparo = InputSystem.actions["Attack"].WasPressedThisFrame();

        if (disparo)
        {
            Instantiate(bala, transform.position, Quaternion.identity);
        }
    }
}
