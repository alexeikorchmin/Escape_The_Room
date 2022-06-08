using UnityEngine;
using System;

public class GlobalEventManager : MonoBehaviour
{
    public static event Action<ItemType> OnPickableItem;
    public static Action<bool> OnMoveFreeze;
    public static Action<bool> OnCameraFreeze;

    public static void TriggerOnPickableItem(ItemType itemType)
    {
        OnPickableItem?.Invoke(itemType);
    }
}