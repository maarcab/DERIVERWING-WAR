using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour
{
    [SerializeField] private Transform BoxSpawner;
    public Text WINTEXT;
    public Image durabilityBar;
    public float durability, maxDurability;
    public float damage;
    private bool isDecomposing = false;
    private float timer;

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

        if (collision.CompareTag("Hongo"))
        {
            isDecomposing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hongo"))
        {
            isDecomposing = false;
            timer = 0f;
        }
    }
    private void Update()
    {
        if (isDecomposing)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                Decompose();
                timer = 0f;
            }
        }
        if (Input.GetKeyDown("f"))
        {
            Decompose();
        }
    }

    void Respawn()
    {
        this.transform.position = BoxSpawner.position;
        this.transform.rotation = BoxSpawner.rotation;
    }
    void Decompose()
    {
        durability -= damage;
        durabilityBar.fillAmount = durability / maxDurability;
        if (durability <= 0)
        {
            timer = 0f;
            durability = maxDurability;
            durabilityBar.fillAmount = 1f;
            Respawn();
        }
    }
}

