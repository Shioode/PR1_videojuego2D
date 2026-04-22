using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

   public static int vidas = 3;

    public static int puntos = 0;

    GameObject vidasObj;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidasObj = GameObject.Find("vidasObj");
    }

    // Update is called once per frame
    void Update()
    {

        vidasObj.GetComponent<TextMeshProUGUI>().text = vidas.ToString();
        Debug.Log("Vidas =" + vidas);
    }
}
