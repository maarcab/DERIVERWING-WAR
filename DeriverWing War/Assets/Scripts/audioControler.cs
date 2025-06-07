using UnityEngine;

public class audioControler : MonoBehaviour
{
   
    public AudioSource backgroundAudio; 
    public AudioSource effectAudio;

    public AudioClip effectButton;

    public static audioControler instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backgroundAudio.Play();
        backgroundAudio.loop = true;
    }

    public void ButtonPressed ()
    {
        effectAudio.clip = effectButton;
        effectAudio.Play();
    }
   
}
