using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private static bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenu;

    void Update()
    {
        ResumePauseGame();
    }

    private void ResumePauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }

            else
            {
                PauseGame();
            }
        }
    }

    private void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}