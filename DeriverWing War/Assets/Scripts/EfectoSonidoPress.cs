using UnityEngine;

public class EfectoSonidoPress : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip Click;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickAudio()
    {
        audioSource.PlayOneShot(Click);
    }
}
