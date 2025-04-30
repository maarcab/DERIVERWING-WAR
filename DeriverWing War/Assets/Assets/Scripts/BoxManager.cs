using Unity.VisualScripting;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    [SerializeField] private Transform boxSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
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

