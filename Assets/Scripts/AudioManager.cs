using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip clipBotones;
    public AudioClip bandaSonora;

    public AudioClip monedas;

    public AudioClip muerte;

    public AudioClip fantasma;

    public AudioClip fuego;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        // DontDestroyOnLoad(this.gameObject);

        if (Instance != null && Instance != this.gameObject)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        GetComponent<AudioSource>().clip = bandaSonora;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update() { }

    public void SonarBoton()
    {
        // GetComponent<AudioSource>().PlayOneShot(clipBotones);
        SonarClipUnaVez(clipBotones);
    }

    public void SonarClipUnaVez(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
