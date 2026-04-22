using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioScript : MonoBehaviour
{

    public GameObject panelInicio;

    public GameObject panelSettings;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelSettings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showSettings()
    {
        panelSettings.SetActive(true);
        panelInicio.SetActive(false);
    }

    public void goBack()
    {
        panelSettings.SetActive(false);
        panelInicio.SetActive(true);
    }
    public void Inicio()
    {
        SceneManager.LoadScene("juego");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
