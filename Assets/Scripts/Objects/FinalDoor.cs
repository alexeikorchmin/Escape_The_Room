using UnityEngine;
using System;

public class FinalDoor : Interactable
{
    public static Action<bool> OnFinalDoorOpened;

    [SerializeField] private Inventory inventory;

    public override void Interact()
    {
        OpenFinalDoor();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    private void OpenFinalDoor()
    {
        if (inventory.CurrentItemType == ItemType.Key)
        {
            animator.Play("DoorDouble_Open");
            GlobalEventManager.OnMoveFreeze?.Invoke(true);
            OnFinalDoorOpened?.Invoke(true);
        }
        else
        {
            audioSource.PlayOneShot(audioTracks.GetAudioClipByType(AudioType.KeyLock));
        }
    }
}