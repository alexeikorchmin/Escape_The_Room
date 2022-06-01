using UnityEngine;

public class FinalDoorCanvas : MonoBehaviour
{
    private Canvas finalCanvas;
    
    private void Awake()
    {
        FinalDoor.OnFinalDoorOpened += ShowFinalCanvas;

        finalCanvas = GetComponent<Canvas>();
        finalCanvas.enabled = false;
    }

    private void ShowFinalCanvas(bool flag)
    {
        finalCanvas.enabled = flag;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnDestroy()
    {
        FinalDoor.OnFinalDoorOpened -= ShowFinalCanvas;
    }
}