using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public int valor = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
         //coin
        //Debug.Log(col.gameObject.name);
        if(col.gameObject.name == "Personaje")
        {
            GameManager.puntos += 10;

            gameObject.GetComponent<Animator>().SetBool("obtenerCoin",true);
            // this.gameObject.GetComponent<Animator>().SetBool("obtenerCoin",true);
            Destroy(this.gameObject, 1.0f);
        }
    }
}
