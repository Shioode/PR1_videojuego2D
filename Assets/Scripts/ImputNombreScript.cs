using TMPro;
using UnityEngine;

public class ImputNombreScript : MonoBehaviour
{
    public string inputText;

    public GameObject panelNombre;
    public TMP_Text holaJugador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void RecogerInput(string input)
    {
        inputText = input;
        DisplayReactionToInput();
    }

    void DisplayReactionToInput()
    {
        holaJugador.text = "Bienvenido, " + inputText;
        panelNombre.SetActive(false);
    }
}
