using UnityEngine;
using System;

public class FinalDoor : Interactable
{
    [SerializeField] private Inventory inventory;

    public static Action<bool> OnFinalDoorOpened;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void Interact()
    {
        OpenFinalDoor();
    }

    private void OpenFinalDoor()
    {
        if (inventory.CurrentItemType == ItemType.Key)
        {
            animator.Play("DoorDouble_Open");
            OnFinalDoorOpened?.Invoke(true);
        }

        else
            audioSource.PlayOneShot(audioTracks.GetAudioClipByType(AudioType.KeyLock));
    }
}