using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Text loseText;
    void Start()
    {
        Time.timeScale = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerKiller"))
        {
            loseText.gameObject.SetActive(true);
            Time.timeScale = 0;
            GameOver();
        }
    }
    private void OnDestroy()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            loseText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void GameOver()
    {
        Destroy(this.gameObject);
    }
}
