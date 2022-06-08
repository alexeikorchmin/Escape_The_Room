using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas pauseMenuCanvas;
    [SerializeField] private Button resumeButton;

    private static bool GameIsPaused = false;

    private void Awake()
    {
        resumeButton.onClick.AddListener(delegate { PauseGame(false, CursorLockMode.Locked); });
    }

    private void Update()
    {
        CheckIsPauseButtonPressed();
    }

    private void CheckIsPauseButtonPressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(true, CursorLockMode.Confined);
        }
    }

    private void PauseGame(bool flag, CursorLockMode cursorLockMode)
    {
        pauseMenuCanvas.enabled = flag;
        GameIsPaused = flag;
        Cursor.lockState = cursorLockMode;
        GlobalEventManager.OnMoveFreeze?.Invoke(flag);
        GlobalEventManager.OnCameraFreeze?.Invoke(flag);
    }
}