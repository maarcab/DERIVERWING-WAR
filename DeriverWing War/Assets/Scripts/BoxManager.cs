using UnityEngine;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    public Text winText;
    public Image durabilityBar;
    public float durability, maxDurability;
    public float damage;
    private bool isDecomposing = false;
    private float timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxDestroyer") || collision.CompareTag("PlayerKiller"))
        {
            Respawn();
        }

        if (collision.CompareTag("Win"))
        {
            winText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        if (collision.CompareTag("Fungus"))
        {
            isDecomposing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Fungus"))
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
            if (timer >= 0.05f)
            {
                Decompose();
                timer = 0f;
            }
        }
    }

    void Respawn()
    {
        this.transform.position = spawnPosition.position;
        this.transform.rotation = spawnPosition.rotation;
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

