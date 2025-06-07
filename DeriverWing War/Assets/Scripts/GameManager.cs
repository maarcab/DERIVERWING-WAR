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
    public void ChangePanel(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
    public void HidePanel(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    [SerializeField] GameObject pause;
    bool isPaused = false;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                pause.SetActive(true);
                isPaused = true;
                Time.timeScale = 0;
            }
            else
            {
                pause.SetActive(false);
                isPaused = false;
                Time.timeScale = 1;
            }
        }
    }
}
