using UnityEngine;

public class Parallax : MonoBehaviour
{

    public float velocidadParallax = 1;

    public GameObject Personaje;

    public GameObject Camara;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camara = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {

        float positionX = Camara.transform.position.x + transform.position.x ;
        float positionY = Camara.transform.position.y + transform.position.y ;
        transform.position = new Vector3(Camara.transform.position.x*velocidadParallax, Camara.transform.position.y, -5.0f);
    }
}
