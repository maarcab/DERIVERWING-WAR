using Unity.VisualScripting;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    [SerializeField] private Transform boxSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxDestroyer"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        this.transform.position = boxSpawner.position;
        this.transform.rotation = boxSpawner.rotation;
    }
}

