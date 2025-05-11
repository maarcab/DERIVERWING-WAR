using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerKiller"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Destroy(this.gameObject);
    }
}
