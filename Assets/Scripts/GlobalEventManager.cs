using UnityEngine;
using System;

public class GlobalEventManager : MonoBehaviour
{
    public static event Action<ItemType> OnPickableItem;

    public static void TriggerOnPickableItem(ItemType itemType)
    {
        OnPickableItem?.Invoke(itemType);
    }
}