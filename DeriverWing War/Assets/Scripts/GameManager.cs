using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void LoadLevel(int Scene) 
    {
        SceneManager.LoadScene(Scene);
        Time.timeScale = 1;
    }
}
