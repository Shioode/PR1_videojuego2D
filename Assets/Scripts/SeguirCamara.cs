using UnityEngine;

public class SeguirCamara : MonoBehaviour
{

    public GameObject personaje;
    Vector3 dondePersonaje;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dondePersonaje = personaje.transform.position;

        transform.position = new Vector3 (dondePersonaje.x,dondePersonaje.y, 7);
    }
}
