using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour
{
    [SerializeField] private Transform boxSpawner;
    public Text WINTEXT;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxDestroyer"))
        {
            Respawn();
        }

        if (collision.CompareTag("Win"))
        {
            WINTEXT.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void Respawn()
    {
        this.transform.position = boxSpawner.position;
        this.transform.rotation = boxSpawner.rotation;
    }
}

