using UnityEngine;
using UnityEngine.UI;
using System;

public class ChestTriggerArea : Interactable
{
    public static event Action<bool> OnChestOpen;
    //public static event Action<bool> OnSafePanelActive;

    [SerializeField] private Text codeText;
    [SerializeField] private GameObject safePanel;

    private string passwordInputValue;
    private bool isSafeOpen;

    public void AddCodeNumber(string number)
    {
        passwordInputValue += number;
    }    

    protected override void Awake()
    {
        base.Awake();
        passwordInputValue = string.Empty;
    }

    private void PasswordInput()
    {
        codeText.text = passwordInputValue;

        if (passwordInputValue == "13579")
        {
            animator.Play("openChest");
            audioSource.PlayOneShot(audioTracks.GetAudioClipByType(AudioType.ChestOpen));
            safePanel.SetActive(false);
            isSafeOpen = true;
            OnChestOpen?.Invoke(true);
            GlobalEventManager.OnCameraFreeze?.Invoke(false);
            //OnSafePanelActive?.Invoke(false);
        }

        if (passwordInputValue.Length >= 5)
        {
            passwordInputValue = string.Empty;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PasswordInput();

            if (!isSafeOpen)
            {
                safePanel.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                GlobalEventManager.OnCameraFreeze?.Invoke(true);
                //OnSafePanelActive?.Invoke(true);

                if (Input.GetKeyUp(KeyCode.E))
                {
                    audioSource.PlayOneShot(audioTracks.GetAudioClipByType(AudioType.KeyLock));
                }
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    animator.Play("closeChest");
                    audioSource.PlayOneShot(audioTracks.GetAudioClipByType(AudioType.ChestClose));
                    isSafeOpen = false;
                    safePanel.SetActive(true);
                    GlobalEventManager.OnCameraFreeze?.Invoke(true);
                    //OnSafePanelActive?.Invoke(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            safePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            GlobalEventManager.OnCameraFreeze?.Invoke(false);
            //OnSafePanelActive?.Invoke(false);
        }
    }
}