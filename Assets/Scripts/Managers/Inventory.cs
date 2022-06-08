using UnityEngine;

public enum ItemType
{
    EmptyHand,
    Hammer,
    Key
}

public class Inventory : MonoBehaviour
{
    public ItemType CurrentItemType { get { return currentItemType; } }

    [SerializeField] private GameObject[] currentGameObjectsInventory;
    
    private ItemType currentItemType = ItemType.EmptyHand;

    private void Awake()
    {
        GlobalEventManager.OnPickableItem += SetItemType;
    }

    private void SetItemType(ItemType itemType)
    {
        currentItemType = itemType;

        switch (currentItemType)
        {
            case ItemType.Hammer:
                currentGameObjectsInventory[0].SetActive(true);
                break;

            case ItemType.Key:
                currentGameObjectsInventory[0].SetActive(false);
                currentGameObjectsInventory[1].SetActive(true);
                break;
        }
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnPickableItem -= SetItemType;
    }
}