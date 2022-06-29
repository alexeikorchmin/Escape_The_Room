using UnityEngine;

public class LaptopTriggerArea : Interactable
{
    [SerializeField] private GameObject laptopDesktop;
    [SerializeField] private GameObject cameraLaptop;
    [SerializeField] private GameObject cameraPlayer;

    private bool isLaptopOpen;

    public override void Interact()
    {
        if (isLaptopOpen)
        {
            SwitchLapTopState(false, "Close", CursorLockMode.Locked);
        }
        else
        {
            SwitchLapTopState(true, "Open", CursorLockMode.Confined);
        }
    }

    private void SwitchLapTopState(bool isActive, string laptopAnimationName, CursorLockMode cursorLockMode)
    {
        isLaptopOpen = isActive;
        laptopDesktop.SetActive(isActive);
        animator.SetTrigger(laptopAnimationName);
        cameraLaptop.SetActive(isActive);
        cameraPlayer.SetActive(!isActive);
        GlobalEventManager.OnMoveFreeze?.Invoke(isActive);
        Cursor.lockState = cursorLockMode;
    }
}