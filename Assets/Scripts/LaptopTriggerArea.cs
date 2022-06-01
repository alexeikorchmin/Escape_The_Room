using UnityEngine;
using System;

public class LaptopTriggerArea : Interactable
{
    [SerializeField] private GameObject laptopDesktop;
    [SerializeField] private GameObject cameraLaptop;
    [SerializeField] private GameObject cameraPlayer;

    private bool isLaptopOpen;

    public static event Action<bool> OnFreeze;

    private void SwitchLapTopState(bool flag, string laptopAnimationName, CursorLockMode cursorLockMode)
    {
        isLaptopOpen = flag;
        laptopDesktop.SetActive(flag);
        animator.SetTrigger(laptopAnimationName);
        cameraLaptop.SetActive(flag);
        cameraPlayer.SetActive(!flag);
        OnFreeze?.Invoke(flag);
        Cursor.lockState = cursorLockMode;
    }

    public override void Interact()
    {
        if (isLaptopOpen)
            SwitchLapTopState(false, "Close", CursorLockMode.Locked);
        else
            SwitchLapTopState(true, "Open", CursorLockMode.Confined);
    }
}