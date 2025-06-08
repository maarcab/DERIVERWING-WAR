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

    void GameOver()
    {
        Destroy(this.gameObject);
    }
}
