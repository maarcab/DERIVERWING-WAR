using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Text LOSETEXT;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerKiller"))
        {
            LOSETEXT.gameObject.SetActive(true);
            Time.timeScale = 0;
            //GameOver();
        }
    }
    private void OnDestroy()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            //LOSETEXT.gameObject.SetActive(true);
            //Time.timeScale = 0;
        }
    }

    void GameOver()
    {
        Destroy(this.gameObject);
    }
}
