
public class KeyFinalDoor : Interactable
{
    public override void Interact()
    {
        GlobalEventManager.TriggerOnPickableItem(ItemType.Key);
        Destroy(gameObject);
    }
}